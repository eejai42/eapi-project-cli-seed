using CLIClassLibrary.RoleHandlers;
using Newtonsoft.Json;
using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YP.SassyMQ.Lib.RabbitMQ;

namespace SSoTme.Default.Lib.CLIHandler
{

    public partial class EAPICLIHandler
    {
        public static string C_PROJECT_NAME = "ej-tictactoe-demo";

        public EAPICLIHandler(string[] args)
        {
            this.amqps = "amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/ej-tictactoe-demo";
            var list = args.ToList();
            list.Insert(0, "cli");
            this.Parser = new CommandLineParser(this);
            this.Parser.Parse(list.ToArray());
        }

        internal static string GetMostRecentUser()
        {
            var di = new DirectoryInfo(ProjectRootPath);
            var lastModified = di.GetFiles().OrderByDescending(fi => fi.LastWriteTime).FirstOrDefault();
            var lastName = Path.GetFileNameWithoutExtension(lastModified.Name);
            return lastName;
        }

        internal static string GetToken(string runas)
        {
            var root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var fileInfo = new FileInfo(Path.Combine(ProjectRootPath, $"{runas}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            if (!fileInfo.Exists) return String.Empty;
            else
            {
                var accessToken = File.ReadAllText(fileInfo.FullName);
                File.WriteAllText(fileInfo.FullName, accessToken);
                return accessToken;
            }
        }

        public string ProcessRequest()
        {
            this.SetInvokeIfMissing();
            if (!String.IsNullOrEmpty(this.authenticate)) return this.Authenticate();
            else if (!String.IsNullOrEmpty(this.invoke)) return this.Invoke();
            else throw new Exception($"Sytnax error: cli -invoke DoSomething -bodyData {{}} -runas Admin");
        }

        private void SetInvokeIfMissing()
        {
            if (String.IsNullOrEmpty(this.invoke) && this.Parser.RemainingArguments.Any())
            {
                this.invoke = this.Parser.RemainingArguments.First();
            }
        }

        private string Invoke()
        {
            this.RoleHandler = RoleHandlerFactory.CreateHandler(this.runas, this.amqps);
            if (!String.IsNullOrEmpty(this.bodyFile))
            {
                var fileInfo = new FileInfo(this.bodyFile);
                if (!fileInfo.Exists) throw new Exception($"-bodyFile {fileInfo.FullName} does not exists.");
                else if (String.IsNullOrEmpty(this.bodyData)) this.bodyData = File.ReadAllText(fileInfo.FullName);
            }
            var result = this.RoleHandler.Handle(this.invoke, this.bodyData, this.where);
            if (!String.IsNullOrEmpty(this.output)) File.WriteAllText(this.output, result);
            return result;
        }

        public string Authenticate()
        {
            var smqGuest = new SMQGuest(this.amqps);
            var authPayload = smqGuest.CreatePayload();
            authPayload.EmailAddress = this.authenticate;
            authPayload.DemoPassword = this.demoPassword;
            var result = "";
            smqGuest.ValidateTemporaryAccessToken(authPayload, (reply, bdea) =>
            {
                if (reply.HasNoErrors(bdea))
                {
                    this.SaveAuth(reply.AccessToken);
                }
                result = JsonConvert.SerializeObject(reply, Formatting.Indented, new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore
                });
            }).Wait(30000);
            return result;
        }

        private void SaveAuth(string accessToken)
        {
            var fileInfo = new FileInfo(Path.Combine(ProjectRootPath, $"{this.runas}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            File.WriteAllText(fileInfo.FullName, accessToken);
        }

        public CommandLineParser Parser { get; }
        internal RoleHandlerBase RoleHandler { get; private set; }

        public static string RootPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.UserProfile); } }

        public static string ProjectRootPath { get { return Path.Combine(RootPath, ".eapi", $"{C_PROJECT_NAME}"); } }

        public static void HandleRequest(string[] args)
        {
            var handler = new EAPICLIHandler(args);
            Console.WriteLine(handler.Parser.UsageInfo);
            Console.WriteLine(handler.ProcessRequest());
        }
    }
}

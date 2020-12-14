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
        public EAPICLIHandler(string[] args)
        {
            this.amqps = "amqps://smqPublic:smqPublic@effortlessapi-rmq.ssot.me/ej-tictactoe-demo";
            var list = args.ToList();
            list.Insert(0, "cli");
            this.Parser = new CommandLineParser(this);
            this.Parser.Parse(list.ToArray());
        }

        internal static string GetToken(string runas)
        {
            var root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var projectName = "ej-tictactoe-demo";
            var fileInfo = new FileInfo(Path.Combine(root, ".eapi", $"{runas}", $"{projectName}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            if (!fileInfo.Exists) return String.Empty;
            else return File.ReadAllText(fileInfo.FullName);            
        }

        public string ProcessRequest()
        {
            if (!String.IsNullOrEmpty(this.authenticate)) return this.Authenticate();
            else if (!String.IsNullOrEmpty(this.invoke)) return this.Invoke();
            else throw new Exception($"Sytnax error: cli -invoke DoSomething -bodyData {{}} -runas Admin");
        }

        private string Invoke()
        {
            this.RoleHandler = RoleHandlerFactory.CreateHandler(this.runas, this.amqps);            
            if (!String.IsNullOrEmpty(this.bodyFile))
            {
                var fileInfo = new FileInfo(this.bodyFile);
                if (!fileInfo.Exists) throw new Exception($"-bodyFile {this.bodyFile} does not exists.");
                else if (String.IsNullOrEmpty(this.bodyData)) this.bodyData = File.ReadAllText(fileInfo.FullName);
            }
            var result = this.RoleHandler.Handle(this.invoke, this.bodyData, this.where);
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
            var root = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            var projectName = "ej-tictactoe-demo";
            var fileInfo = new FileInfo(Path.Combine(root, ".eapi", $"{this.runas}", $"{projectName}.token"));
            if (!fileInfo.Directory.Exists) fileInfo.Directory.Create();
            File.WriteAllText(fileInfo.FullName, accessToken);
        }

        public CommandLineParser Parser { get; }
        internal RoleHandlerBase RoleHandler { get; private set; }

        public static void HandleRequest(string[] args)
        {
            var handler = new EAPICLIHandler(args);
            Console.WriteLine(handler.Parser.UsageInfo);
            Console.WriteLine(handler.ProcessRequest());
        }
    }
}

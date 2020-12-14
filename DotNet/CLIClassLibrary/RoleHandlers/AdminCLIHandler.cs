using Newtonsoft.Json;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    internal class AdminCLIHandler : RoleHandlerBase<SMQAdmin>
    {

        public AdminCLIHandler(string amqps, string accessToken)
            : base(new SMQAdmin(amqps), accessToken)
        {
        }

        public override string Handle(string invoke, string data)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            var result = "";

            switch (invoke)
            {
                case "AddCell":
                    var payload = this.SMQActor.CreatePayload();
                    payload.Cell = JsonConvert.DeserializeObject<Cell>(data);
                    this.SMQActor.AddCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;

                case "GetCells":
                    payload = this.SMQActor.CreatePayload();
                    
                    this.SMQActor.GetCells(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;

                default:
                    result = "{}";
                    break;
            }
            return result;
        }

        private static string SerializePayload(StandardPayload reply)
        {
            return JsonConvert.SerializeObject(reply, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}
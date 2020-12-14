using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class GuestCLIHandler
    {
        private string HandlerFactory(string invokeRequest, string payloadString, string where)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject<StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;

            switch (invokeRequest.ToLower())
            {
                case "requesttoken":
                    this.SMQActor.RequestToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "validatetemporaryaccesstoken":
                    this.SMQActor.ValidateTemporaryAccessToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "whoami":
                    this.SMQActor.WhoAmI(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "whoareyou":
                    this.SMQActor.WhoAreYou(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "storetempfile":
                    this.SMQActor.StoreTempFile(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getailevels":
                    this.SMQActor.GetAILevels(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcells":
                    this.SMQActor.GetCells(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcellstates":
                    this.SMQActor.GetCellStates(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
    }
}

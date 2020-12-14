using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class SpectatorCLIHandler
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
                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
    }
}

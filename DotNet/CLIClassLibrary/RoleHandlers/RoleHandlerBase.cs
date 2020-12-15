using Newtonsoft.Json;
using SSoTme.Default.Lib.CLIHandler;
using System;
using System.Collections.Generic;
using System.Text;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public abstract class RoleHandlerBase
    {
        public abstract string Handle(string invoke, string data, string where);

        protected string SerializePayload(StandardPayload reply)
        {
            return JsonConvert.SerializeObject(reply, Formatting.Indented, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }

        public abstract void AddHelp(StringBuilder sb, string helpTerm);
    }

    public abstract class RoleHandlerBase<T> : RoleHandlerBase
        where T : SMQActorBase
    {
        public T SMQActor;

        public RoleHandlerBase(T smqActor, string accessToken)
        {
            this.SMQActor = smqActor;
            this.SMQActor.AccessToken = accessToken;
        }
    }
}

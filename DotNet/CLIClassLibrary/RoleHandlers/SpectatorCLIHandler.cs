using Newtonsoft.Json;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class SpectatorCLIHandler : RoleHandlerBase<SMQSpectator>
    {

        public SpectatorCLIHandler(string amqps, string accessToken)
            : base(new SMQSpectator(amqps), accessToken)
        {
        }

        public override string Handle(string invoke, string data, string where)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data, where);
            return result;
        }
    }
}
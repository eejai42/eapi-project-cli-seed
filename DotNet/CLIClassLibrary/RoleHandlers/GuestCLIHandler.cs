using Newtonsoft.Json;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class GuestCLIHandler : RoleHandlerBase<SMQGuest>
    {

        public GuestCLIHandler(string amqps, string accessToken)
            : base(new SMQGuest(amqps), accessToken)
        {
        }

        public override string Handle(string invoke, string data)
        {
            if (string.IsNullOrEmpty(data)) data = "{}";
            string result = HandlerFactory(invoke, data);
            return result;
        }
    }
}
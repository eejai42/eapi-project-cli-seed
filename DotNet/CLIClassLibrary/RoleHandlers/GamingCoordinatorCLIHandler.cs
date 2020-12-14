using Newtonsoft.Json;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class GamingCoordinatorCLIHandler : RoleHandlerBase<SMQGamingCoordinator>
    {

        public GamingCoordinatorCLIHandler(string amqps, string accessToken)
            : base(new SMQGamingCoordinator(amqps), accessToken)
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
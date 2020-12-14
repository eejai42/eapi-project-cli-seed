using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public class PlayerCLIHandler : RoleHandlerBase<SMQPlayer>
    {

        public PlayerCLIHandler(string amqps, string accessToken)
            : base(new SMQPlayer(amqps), accessToken)
        {
        }

        public override string Handle(string invoke, string amqps)
        {
            throw new System.NotImplementedException();
        }
    }
}
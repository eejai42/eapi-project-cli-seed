using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public class GuestCLIHandler : RoleHandlerBase<SMQGuest>
    {
        public GuestCLIHandler(string amqps, string accessToken)
            : base(new SMQGuest(amqps), accessToken)
        {
            
        }

        public override string Handle(string invoke, string amqps)
        {
            throw new System.NotImplementedException();
        }
    }
}
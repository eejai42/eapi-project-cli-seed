using SSoTme.Default.Lib.CLIHandler;
using System;
using System.Collections.Generic;
using System.Text;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public abstract class RoleHandlerBase
    {
        public static RoleHandlerBase CreateHandler(string runas, string amqps)
        {
            var accessToken = EAPICLIHandler.GetToken(runas);
            switch (runas)
            {
                case "Guest":
                    return new GuestCLIHandler(amqps, accessToken);

                case "Player":
                    return new PlayerCLIHandler(amqps, accessToken);

                case "Admin":
                    return new AdminCLIHandler(amqps, accessToken);

                default:
                    throw new Exception($"Can't find CLIHandler for {runas} actor.");
            }
        }

        public abstract string Handle(string invoke, string data);
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

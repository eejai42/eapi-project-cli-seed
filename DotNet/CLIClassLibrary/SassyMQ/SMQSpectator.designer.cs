using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQSpectator : SMQActorBase
    {

        public SMQSpectator(String amqpConnectionString)
            : base(amqpConnectionString, "spectator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "spectator.custom.gamingcoordinator.gamingstarting":
                        this.OnGamingCoordinatorGamingStartingReceived(payload, bdea);
                        break;
                    
                    case "spectator.custom.gamingcoordinator.gamingchanged":
                        this.OnGamingCoordinatorGamingChangedReceived(payload, bdea);
                        break;
                    
                }

            }
            catch (Exception ex)
            {
                payload.ErrorMessage = ex.Message;
            }
            if (payload.AccessToken == originalAccessToken) payload.AccessToken = null;            
            this.Reply(payload, bdea.BasicProperties);
        }

        
        /// <summary>
        /// Responds to: GamingStarting from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGamingStartingReceived;
        protected virtual void OnGamingCoordinatorGamingStartingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGamingStartingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGamingStartingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GamingChanged from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGamingChangedReceived;
        protected virtual void OnGamingCoordinatorGamingChangedReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGamingChangedReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGamingChangedReceived(this, plea);
            }
        }

    }
}

                    

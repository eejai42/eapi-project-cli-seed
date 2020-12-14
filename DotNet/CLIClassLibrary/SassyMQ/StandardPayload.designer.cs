using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using dc = tictactoechallenge.Lib.DataClasses;
using System.Collections.Generic;


namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class StandardPayload
    {
        public string RoutingKey { get; set; }
        
        private StandardPayload(SMQActorBase actor, string content, bool final)
        {
            this.PayloadId = Guid.NewGuid().ToString();

            this.__Actor = actor;
            if (!ReferenceEquals(this.__Actor, null))
            {
                this.SenderId = actor.SenderId.ToString();
                this.SenderName = actor.SenderName;
                this.AccessToken = actor.AccessToken;
            }
            else
            {
                this.SenderId = Guid.NewGuid().ToString();
                this.SenderName = "Unnamed Actor";
                this.AccessToken = null;
            }

            this.Content = content;
        }

        // 17 odxml properties
        
        public String GlobalSettingId { get; set; }
        
        public dc.GlobalSetting GlobalSetting { get; set; }
        
        public List<dc.GlobalSetting> GlobalSettings { get; set; }
        
        public String ScoreId { get; set; }
        
        public dc.Score Score { get; set; }
        
        public List<dc.Score> Scores { get; set; }
        
        public String AILevelId { get; set; }
        
        public dc.AILevel AILevel { get; set; }
        
        public List<dc.AILevel> AILevels { get; set; }
        
        public String UIElementId { get; set; }
        
        public dc.UIElement UIElement { get; set; }
        
        public List<dc.UIElement> UIElements { get; set; }
        
        public String TranslationId { get; set; }
        
        public dc.Translation Translation { get; set; }
        
        public List<dc.Translation> Translations { get; set; }
        
        public String LanguageTokenId { get; set; }
        
        public dc.LanguageToken LanguageToken { get; set; }
        
        public List<dc.LanguageToken> LanguageTokens { get; set; }
        
        public String AdditionalResourceId { get; set; }
        
        public dc.AdditionalResource AdditionalResource { get; set; }
        
        public List<dc.AdditionalResource> AdditionalResources { get; set; }
        
        public String GameId { get; set; }
        
        public dc.Game Game { get; set; }
        
        public List<dc.Game> Games { get; set; }
        
        public String CellId { get; set; }
        
        public dc.Cell Cell { get; set; }
        
        public List<dc.Cell> Cells { get; set; }
        
        public String CellPatternId { get; set; }
        
        public dc.CellPattern CellPattern { get; set; }
        
        public List<dc.CellPattern> CellPatterns { get; set; }
        
        public String EntityId { get; set; }
        
        public dc.Entity Entity { get; set; }
        
        public List<dc.Entity> Entities { get; set; }
        
        public String UserId { get; set; }
        
        public dc.User User { get; set; }
        
        public List<dc.User> Users { get; set; }
        
        public String CellPatternCellId { get; set; }
        
        public dc.CellPatternCell CellPatternCell { get; set; }
        
        public List<dc.CellPatternCell> CellPatternCells { get; set; }
        
        public String TargetPlatformId { get; set; }
        
        public dc.TargetPlatform TargetPlatform { get; set; }
        
        public List<dc.TargetPlatform> TargetPlatforms { get; set; }
        
        public String AIStrategyId { get; set; }
        
        public dc.AIStrategy AIStrategy { get; set; }
        
        public List<dc.AIStrategy> AIStrategies { get; set; }
        
        public String CellStateId { get; set; }
        
        public dc.CellState CellState { get; set; }
        
        public List<dc.CellState> CellStates { get; set; }
        
        public String CellPatternTranslationId { get; set; }
        
        public dc.CellPatternTranslation CellPatternTranslation { get; set; }
        
        public List<dc.CellPatternTranslation> CellPatternTranslations { get; set; }
        
        
        public String ToJSON() 
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        private void HandleReplyTo(object sender, PayloadEventArgs e)
        {
            if (e.Payload.IsHandled && e.BasicDeliverEventArgs.BasicProperties.CorrelationId == this.PayloadId)
            {
                this.ReplyPayload = e.Payload;
                this.ReplyBDEA = e.BasicDeliverEventArgs;
                this.ReplyRecieved = true;
            }
        }

       
        public Task WaitForReply(PayloadHandler payloadHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var actor = this.__Actor;
            if (ReferenceEquals(actor, null)) throw new Exception("Can't handle response if payload.Actor is null");
            else
            {
                actor.ReplyTo += this.HandleReplyTo;
                var waitTask = Task.Factory.StartNew(() =>
                {
                    try
                    {
                        if (waitTimeout > 0 && !ReferenceEquals(payloadHandler, null))
                        {

                            this.TimedOutWaiting = false;
                            var startedAt = DateTime.Now;

                            while (!this.ReplyRecieved && !this.TimedOutWaiting && DateTime.Now < startedAt.AddSeconds(waitTimeout))
                            {
                                Thread.Sleep(100);
                            }

                            if (!this.ReplyRecieved) this.TimedOutWaiting = true;

                            var errorMessageReceived = !ReferenceEquals(this.ReplyPayload, null) && !String.IsNullOrEmpty(this.ReplyPayload.ErrorMessage);

                            if (this.ReplyRecieved && (!errorMessageReceived || ReferenceEquals(timeoutHandler, null)))
                            {
                                this.ReplyPayload.__Actor = actor;
                                payloadHandler(this.ReplyPayload, this.ReplyBDEA);
                            }
                            else if (!ReferenceEquals(timeoutHandler, null)) timeoutHandler(this.ReplyPayload, default(BasicDeliverEventArgs));
                        }

                    }
                    finally
                    {
                        actor.ReplyTo -= this.HandleReplyTo;
                    }
                });
                return waitTask;
            }
        }
    }
}
using System;
using System.Linq;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using System.Threading.Tasks;

namespace YP.SassyMQ.Lib.RabbitMQ
{
    public partial class SMQCRUDCoordinator : SMQActorBase
    {

        public SMQCRUDCoordinator(String amqpConnectionString)
            : base(amqpConnectionString, "crudcoordinator")
        {
        }

        protected override void CheckRouting(StandardPayload payload, BasicDeliverEventArgs  bdea)
        {
            var originalAccessToken = payload.AccessToken;
            try
            {
                switch (bdea.RoutingKey)
                {
                    
                    case "crudcoordinator.general.guest.requesttoken":
                        this.OnGuestRequestTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.validatetemporaryaccesstoken":
                        this.OnGuestValidateTemporaryAccessTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoami":
                        this.OnGuestWhoAmIReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.guest.whoareyou":
                        this.OnGuestWhoAreYouReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.utlity.guest.storetempfile":
                        this.OnGuestStoreTempFileReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration":
                        this.OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.general.crudcoordinator.resetjwtsecretkey":
                        this.OnCRUDCoordinatorResetJWTSecretKeyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addglobalsetting":
                        this.OnGamingCoordinatorAddGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getglobalsettings":
                        this.OnGamingCoordinatorGetGlobalSettingsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateglobalsetting":
                        this.OnGamingCoordinatorUpdateGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteglobalsetting":
                        this.OnGamingCoordinatorDeleteGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addglobalsetting":
                        this.OnAdminAddGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getglobalsettings":
                        this.OnAdminGetGlobalSettingsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateglobalsetting":
                        this.OnAdminUpdateGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteglobalsetting":
                        this.OnAdminDeleteGlobalSettingReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addscore":
                        this.OnGamingCoordinatorAddScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getscores":
                        this.OnGamingCoordinatorGetScoresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatescore":
                        this.OnGamingCoordinatorUpdateScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletescore":
                        this.OnGamingCoordinatorDeleteScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addscore":
                        this.OnAdminAddScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getscores":
                        this.OnAdminGetScoresReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatescore":
                        this.OnAdminUpdateScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletescore":
                        this.OnAdminDeleteScoreReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getailevels":
                        this.OnGuestGetAILevelsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addailevel":
                        this.OnGamingCoordinatorAddAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getailevels":
                        this.OnGamingCoordinatorGetAILevelsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateailevel":
                        this.OnGamingCoordinatorUpdateAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteailevel":
                        this.OnGamingCoordinatorDeleteAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addailevel":
                        this.OnAdminAddAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getailevels":
                        this.OnAdminGetAILevelsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateailevel":
                        this.OnAdminUpdateAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteailevel":
                        this.OnAdminDeleteAILevelReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.adduielement":
                        this.OnGamingCoordinatorAddUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getuielements":
                        this.OnGamingCoordinatorGetUIElementsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateuielement":
                        this.OnGamingCoordinatorUpdateUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteuielement":
                        this.OnGamingCoordinatorDeleteUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.adduielement":
                        this.OnAdminAddUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getuielements":
                        this.OnAdminGetUIElementsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateuielement":
                        this.OnAdminUpdateUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteuielement":
                        this.OnAdminDeleteUIElementReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addtranslation":
                        this.OnGamingCoordinatorAddTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.gettranslations":
                        this.OnGamingCoordinatorGetTranslationsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatetranslation":
                        this.OnGamingCoordinatorUpdateTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletetranslation":
                        this.OnGamingCoordinatorDeleteTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addtranslation":
                        this.OnAdminAddTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.gettranslations":
                        this.OnAdminGetTranslationsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatetranslation":
                        this.OnAdminUpdateTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletetranslation":
                        this.OnAdminDeleteTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addlanguagetoken":
                        this.OnGamingCoordinatorAddLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getlanguagetokens":
                        this.OnGamingCoordinatorGetLanguageTokensReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatelanguagetoken":
                        this.OnGamingCoordinatorUpdateLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletelanguagetoken":
                        this.OnGamingCoordinatorDeleteLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addlanguagetoken":
                        this.OnAdminAddLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getlanguagetokens":
                        this.OnAdminGetLanguageTokensReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatelanguagetoken":
                        this.OnAdminUpdateLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletelanguagetoken":
                        this.OnAdminDeleteLanguageTokenReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addadditionalresource":
                        this.OnGamingCoordinatorAddAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getadditionalresources":
                        this.OnGamingCoordinatorGetAdditionalResourcesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateadditionalresource":
                        this.OnGamingCoordinatorUpdateAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteadditionalresource":
                        this.OnGamingCoordinatorDeleteAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addadditionalresource":
                        this.OnAdminAddAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getadditionalresources":
                        this.OnAdminGetAdditionalResourcesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateadditionalresource":
                        this.OnAdminUpdateAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteadditionalresource":
                        this.OnAdminDeleteAdditionalResourceReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addgame":
                        this.OnGamingCoordinatorAddGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getgames":
                        this.OnGamingCoordinatorGetGamesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updategame":
                        this.OnGamingCoordinatorUpdateGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletegame":
                        this.OnGamingCoordinatorDeleteGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addgame":
                        this.OnAdminAddGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getgames":
                        this.OnAdminGetGamesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updategame":
                        this.OnAdminUpdateGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletegame":
                        this.OnAdminDeleteGameReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getcells":
                        this.OnGuestGetCellsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addcell":
                        this.OnGamingCoordinatorAddCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getcells":
                        this.OnGamingCoordinatorGetCellsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatecell":
                        this.OnGamingCoordinatorUpdateCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletecell":
                        this.OnGamingCoordinatorDeleteCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcell":
                        this.OnAdminAddCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcells":
                        this.OnAdminGetCellsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecell":
                        this.OnAdminUpdateCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecell":
                        this.OnAdminDeleteCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addcellpattern":
                        this.OnGamingCoordinatorAddCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getcellpatterns":
                        this.OnGamingCoordinatorGetCellPatternsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatecellpattern":
                        this.OnGamingCoordinatorUpdateCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletecellpattern":
                        this.OnGamingCoordinatorDeleteCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcellpattern":
                        this.OnAdminAddCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcellpatterns":
                        this.OnAdminGetCellPatternsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecellpattern":
                        this.OnAdminUpdateCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecellpattern":
                        this.OnAdminDeleteCellPatternReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addentity":
                        this.OnGamingCoordinatorAddEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getentities":
                        this.OnGamingCoordinatorGetEntitiesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateentity":
                        this.OnGamingCoordinatorUpdateEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteentity":
                        this.OnGamingCoordinatorDeleteEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addentity":
                        this.OnAdminAddEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getentities":
                        this.OnAdminGetEntitiesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateentity":
                        this.OnAdminUpdateEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteentity":
                        this.OnAdminDeleteEntityReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.adduser":
                        this.OnGamingCoordinatorAddUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getusers":
                        this.OnGamingCoordinatorGetUsersReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateuser":
                        this.OnGamingCoordinatorUpdateUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteuser":
                        this.OnGamingCoordinatorDeleteUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.player.getusers":
                        this.OnPlayerGetUsersReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.adduser":
                        this.OnAdminAddUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getusers":
                        this.OnAdminGetUsersReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateuser":
                        this.OnAdminUpdateUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteuser":
                        this.OnAdminDeleteUserReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addcellpatterncell":
                        this.OnGamingCoordinatorAddCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getcellpatterncells":
                        this.OnGamingCoordinatorGetCellPatternCellsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatecellpatterncell":
                        this.OnGamingCoordinatorUpdateCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletecellpatterncell":
                        this.OnGamingCoordinatorDeleteCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcellpatterncell":
                        this.OnAdminAddCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcellpatterncells":
                        this.OnAdminGetCellPatternCellsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecellpatterncell":
                        this.OnAdminUpdateCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecellpatterncell":
                        this.OnAdminDeleteCellPatternCellReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addtargetplatform":
                        this.OnGamingCoordinatorAddTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.gettargetplatforms":
                        this.OnGamingCoordinatorGetTargetPlatformsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatetargetplatform":
                        this.OnGamingCoordinatorUpdateTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletetargetplatform":
                        this.OnGamingCoordinatorDeleteTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addtargetplatform":
                        this.OnAdminAddTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.gettargetplatforms":
                        this.OnAdminGetTargetPlatformsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatetargetplatform":
                        this.OnAdminUpdateTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletetargetplatform":
                        this.OnAdminDeleteTargetPlatformReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addaistrategy":
                        this.OnGamingCoordinatorAddAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getaistrategies":
                        this.OnGamingCoordinatorGetAIStrategiesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updateaistrategy":
                        this.OnGamingCoordinatorUpdateAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deleteaistrategy":
                        this.OnGamingCoordinatorDeleteAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addaistrategy":
                        this.OnAdminAddAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getaistrategies":
                        this.OnAdminGetAIStrategiesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updateaistrategy":
                        this.OnAdminUpdateAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deleteaistrategy":
                        this.OnAdminDeleteAIStrategyReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.guest.getcellstates":
                        this.OnGuestGetCellStatesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addcellstate":
                        this.OnGamingCoordinatorAddCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getcellstates":
                        this.OnGamingCoordinatorGetCellStatesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatecellstate":
                        this.OnGamingCoordinatorUpdateCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletecellstate":
                        this.OnGamingCoordinatorDeleteCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcellstate":
                        this.OnAdminAddCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcellstates":
                        this.OnAdminGetCellStatesReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecellstate":
                        this.OnAdminUpdateCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecellstate":
                        this.OnAdminDeleteCellStateReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.addcellpatterntranslation":
                        this.OnGamingCoordinatorAddCellPatternTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.getcellpatterntranslations":
                        this.OnGamingCoordinatorGetCellPatternTranslationsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.updatecellpatterntranslation":
                        this.OnGamingCoordinatorUpdateCellPatternTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.gamingcoordinator.deletecellpatterntranslation":
                        this.OnGamingCoordinatorDeleteCellPatternTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.addcellpatterntranslation":
                        this.OnAdminAddCellPatternTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.getcellpatterntranslations":
                        this.OnAdminGetCellPatternTranslationsReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.updatecellpatterntranslation":
                        this.OnAdminUpdateCellPatternTranslationReceived(payload, bdea);
                        break;
                    
                    case "crudcoordinator.crud.admin.deletecellpatterntranslation":
                        this.OnAdminDeleteCellPatternTranslationReceived(payload, bdea);
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
        /// Responds to: RequestToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestRequestTokenReceived;
        protected virtual void OnGuestRequestTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestRequestTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestRequestTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ValidateTemporaryAccessToken from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestValidateTemporaryAccessTokenReceived;
        protected virtual void OnGuestValidateTemporaryAccessTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestValidateTemporaryAccessTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestValidateTemporaryAccessTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAmI from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAmIReceived;
        protected virtual void OnGuestWhoAmIReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAmIReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAmIReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: WhoAreYou from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestWhoAreYouReceived;
        protected virtual void OnGuestWhoAreYouReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestWhoAreYouReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestWhoAreYouReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: StoreTempFile from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestStoreTempFileReceived;
        protected virtual void OnGuestStoreTempFileReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestStoreTempFileReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestStoreTempFileReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetRabbitSassyMQConfiguration from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetRabbitSassyMQConfigurationReceived;
        protected virtual void OnCRUDCoordinatorResetRabbitSassyMQConfigurationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetRabbitSassyMQConfigurationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: ResetJWTSecretKey from CRUDCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> CRUDCoordinatorResetJWTSecretKeyReceived;
        protected virtual void OnCRUDCoordinatorResetJWTSecretKeyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.CRUDCoordinatorResetJWTSecretKeyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.CRUDCoordinatorResetJWTSecretKeyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddGlobalSetting from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddGlobalSettingReceived;
        protected virtual void OnGamingCoordinatorAddGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGlobalSettings from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetGlobalSettingsReceived;
        protected virtual void OnGamingCoordinatorGetGlobalSettingsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetGlobalSettingsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetGlobalSettingsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateGlobalSetting from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateGlobalSettingReceived;
        protected virtual void OnGamingCoordinatorUpdateGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteGlobalSetting from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteGlobalSettingReceived;
        protected virtual void OnGamingCoordinatorDeleteGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddGlobalSetting from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddGlobalSettingReceived;
        protected virtual void OnAdminAddGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGlobalSettings from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetGlobalSettingsReceived;
        protected virtual void OnAdminGetGlobalSettingsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetGlobalSettingsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetGlobalSettingsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateGlobalSetting from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateGlobalSettingReceived;
        protected virtual void OnAdminUpdateGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteGlobalSetting from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteGlobalSettingReceived;
        protected virtual void OnAdminDeleteGlobalSettingReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteGlobalSettingReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteGlobalSettingReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddScore from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddScoreReceived;
        protected virtual void OnGamingCoordinatorAddScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetScores from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetScoresReceived;
        protected virtual void OnGamingCoordinatorGetScoresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetScoresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetScoresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateScore from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateScoreReceived;
        protected virtual void OnGamingCoordinatorUpdateScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteScore from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteScoreReceived;
        protected virtual void OnGamingCoordinatorDeleteScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddScore from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddScoreReceived;
        protected virtual void OnAdminAddScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetScores from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetScoresReceived;
        protected virtual void OnAdminGetScoresReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetScoresReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetScoresReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateScore from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateScoreReceived;
        protected virtual void OnAdminUpdateScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteScore from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteScoreReceived;
        protected virtual void OnAdminDeleteScoreReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteScoreReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteScoreReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAILevels from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetAILevelsReceived;
        protected virtual void OnGuestGetAILevelsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetAILevelsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetAILevelsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAILevel from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddAILevelReceived;
        protected virtual void OnGamingCoordinatorAddAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAILevels from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetAILevelsReceived;
        protected virtual void OnGamingCoordinatorGetAILevelsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetAILevelsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetAILevelsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAILevel from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateAILevelReceived;
        protected virtual void OnGamingCoordinatorUpdateAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAILevel from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteAILevelReceived;
        protected virtual void OnGamingCoordinatorDeleteAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAILevel from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddAILevelReceived;
        protected virtual void OnAdminAddAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAILevels from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetAILevelsReceived;
        protected virtual void OnAdminGetAILevelsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetAILevelsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetAILevelsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAILevel from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateAILevelReceived;
        protected virtual void OnAdminUpdateAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAILevel from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteAILevelReceived;
        protected virtual void OnAdminDeleteAILevelReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteAILevelReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteAILevelReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddUIElement from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddUIElementReceived;
        protected virtual void OnGamingCoordinatorAddUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetUIElements from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetUIElementsReceived;
        protected virtual void OnGamingCoordinatorGetUIElementsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetUIElementsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetUIElementsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateUIElement from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateUIElementReceived;
        protected virtual void OnGamingCoordinatorUpdateUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteUIElement from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteUIElementReceived;
        protected virtual void OnGamingCoordinatorDeleteUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddUIElement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddUIElementReceived;
        protected virtual void OnAdminAddUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetUIElements from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetUIElementsReceived;
        protected virtual void OnAdminGetUIElementsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetUIElementsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetUIElementsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateUIElement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateUIElementReceived;
        protected virtual void OnAdminUpdateUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteUIElement from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteUIElementReceived;
        protected virtual void OnAdminDeleteUIElementReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteUIElementReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteUIElementReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddTranslationReceived;
        protected virtual void OnGamingCoordinatorAddTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTranslations from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetTranslationsReceived;
        protected virtual void OnGamingCoordinatorGetTranslationsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetTranslationsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetTranslationsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateTranslationReceived;
        protected virtual void OnGamingCoordinatorUpdateTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteTranslationReceived;
        protected virtual void OnGamingCoordinatorDeleteTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddTranslationReceived;
        protected virtual void OnAdminAddTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTranslations from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetTranslationsReceived;
        protected virtual void OnAdminGetTranslationsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetTranslationsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetTranslationsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateTranslationReceived;
        protected virtual void OnAdminUpdateTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteTranslationReceived;
        protected virtual void OnAdminDeleteTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddLanguageToken from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddLanguageTokenReceived;
        protected virtual void OnGamingCoordinatorAddLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetLanguageTokens from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetLanguageTokensReceived;
        protected virtual void OnGamingCoordinatorGetLanguageTokensReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetLanguageTokensReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetLanguageTokensReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateLanguageToken from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateLanguageTokenReceived;
        protected virtual void OnGamingCoordinatorUpdateLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteLanguageToken from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteLanguageTokenReceived;
        protected virtual void OnGamingCoordinatorDeleteLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddLanguageToken from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddLanguageTokenReceived;
        protected virtual void OnAdminAddLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetLanguageTokens from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetLanguageTokensReceived;
        protected virtual void OnAdminGetLanguageTokensReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetLanguageTokensReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetLanguageTokensReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateLanguageToken from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateLanguageTokenReceived;
        protected virtual void OnAdminUpdateLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteLanguageToken from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteLanguageTokenReceived;
        protected virtual void OnAdminDeleteLanguageTokenReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteLanguageTokenReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteLanguageTokenReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAdditionalResource from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddAdditionalResourceReceived;
        protected virtual void OnGamingCoordinatorAddAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAdditionalResources from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetAdditionalResourcesReceived;
        protected virtual void OnGamingCoordinatorGetAdditionalResourcesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetAdditionalResourcesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetAdditionalResourcesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAdditionalResource from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateAdditionalResourceReceived;
        protected virtual void OnGamingCoordinatorUpdateAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAdditionalResource from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteAdditionalResourceReceived;
        protected virtual void OnGamingCoordinatorDeleteAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAdditionalResource from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddAdditionalResourceReceived;
        protected virtual void OnAdminAddAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAdditionalResources from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetAdditionalResourcesReceived;
        protected virtual void OnAdminGetAdditionalResourcesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetAdditionalResourcesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetAdditionalResourcesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAdditionalResource from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateAdditionalResourceReceived;
        protected virtual void OnAdminUpdateAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAdditionalResource from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteAdditionalResourceReceived;
        protected virtual void OnAdminDeleteAdditionalResourceReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteAdditionalResourceReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteAdditionalResourceReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddGame from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddGameReceived;
        protected virtual void OnGamingCoordinatorAddGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGames from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetGamesReceived;
        protected virtual void OnGamingCoordinatorGetGamesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetGamesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetGamesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateGame from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateGameReceived;
        protected virtual void OnGamingCoordinatorUpdateGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteGame from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteGameReceived;
        protected virtual void OnGamingCoordinatorDeleteGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddGame from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddGameReceived;
        protected virtual void OnAdminAddGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetGames from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetGamesReceived;
        protected virtual void OnAdminGetGamesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetGamesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetGamesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateGame from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateGameReceived;
        protected virtual void OnAdminUpdateGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteGame from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteGameReceived;
        protected virtual void OnAdminDeleteGameReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteGameReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteGameReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCells from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetCellsReceived;
        protected virtual void OnGuestGetCellsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetCellsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetCellsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddCellReceived;
        protected virtual void OnGamingCoordinatorAddCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCells from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetCellsReceived;
        protected virtual void OnGamingCoordinatorGetCellsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetCellsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetCellsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateCellReceived;
        protected virtual void OnGamingCoordinatorUpdateCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteCellReceived;
        protected virtual void OnGamingCoordinatorDeleteCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCellReceived;
        protected virtual void OnAdminAddCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCells from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCellsReceived;
        protected virtual void OnAdminGetCellsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCellsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCellsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCellReceived;
        protected virtual void OnAdminUpdateCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCellReceived;
        protected virtual void OnAdminDeleteCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPattern from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddCellPatternReceived;
        protected virtual void OnGamingCoordinatorAddCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatterns from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetCellPatternsReceived;
        protected virtual void OnGamingCoordinatorGetCellPatternsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetCellPatternsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetCellPatternsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPattern from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateCellPatternReceived;
        protected virtual void OnGamingCoordinatorUpdateCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPattern from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteCellPatternReceived;
        protected virtual void OnGamingCoordinatorDeleteCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPattern from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCellPatternReceived;
        protected virtual void OnAdminAddCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatterns from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCellPatternsReceived;
        protected virtual void OnAdminGetCellPatternsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCellPatternsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCellPatternsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPattern from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCellPatternReceived;
        protected virtual void OnAdminUpdateCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPattern from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCellPatternReceived;
        protected virtual void OnAdminDeleteCellPatternReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCellPatternReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCellPatternReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEntity from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddEntityReceived;
        protected virtual void OnGamingCoordinatorAddEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEntities from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetEntitiesReceived;
        protected virtual void OnGamingCoordinatorGetEntitiesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetEntitiesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetEntitiesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEntity from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateEntityReceived;
        protected virtual void OnGamingCoordinatorUpdateEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEntity from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteEntityReceived;
        protected virtual void OnGamingCoordinatorDeleteEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddEntity from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddEntityReceived;
        protected virtual void OnAdminAddEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetEntities from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetEntitiesReceived;
        protected virtual void OnAdminGetEntitiesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetEntitiesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetEntitiesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateEntity from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateEntityReceived;
        protected virtual void OnAdminUpdateEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteEntity from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteEntityReceived;
        protected virtual void OnAdminDeleteEntityReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteEntityReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteEntityReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddUser from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddUserReceived;
        protected virtual void OnGamingCoordinatorAddUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetUsers from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetUsersReceived;
        protected virtual void OnGamingCoordinatorGetUsersReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetUsersReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetUsersReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateUser from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateUserReceived;
        protected virtual void OnGamingCoordinatorUpdateUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteUser from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteUserReceived;
        protected virtual void OnGamingCoordinatorDeleteUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetUsers from Player
        /// </summary>
        public event EventHandler<PayloadEventArgs> PlayerGetUsersReceived;
        protected virtual void OnPlayerGetUsersReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.PlayerGetUsersReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.PlayerGetUsersReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddUser from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddUserReceived;
        protected virtual void OnAdminAddUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetUsers from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetUsersReceived;
        protected virtual void OnAdminGetUsersReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetUsersReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetUsersReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateUser from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateUserReceived;
        protected virtual void OnAdminUpdateUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteUser from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteUserReceived;
        protected virtual void OnAdminDeleteUserReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteUserReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteUserReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPatternCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddCellPatternCellReceived;
        protected virtual void OnGamingCoordinatorAddCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatternCells from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetCellPatternCellsReceived;
        protected virtual void OnGamingCoordinatorGetCellPatternCellsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetCellPatternCellsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetCellPatternCellsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPatternCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateCellPatternCellReceived;
        protected virtual void OnGamingCoordinatorUpdateCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPatternCell from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteCellPatternCellReceived;
        protected virtual void OnGamingCoordinatorDeleteCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPatternCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCellPatternCellReceived;
        protected virtual void OnAdminAddCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatternCells from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCellPatternCellsReceived;
        protected virtual void OnAdminGetCellPatternCellsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCellPatternCellsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCellPatternCellsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPatternCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCellPatternCellReceived;
        protected virtual void OnAdminUpdateCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPatternCell from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCellPatternCellReceived;
        protected virtual void OnAdminDeleteCellPatternCellReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCellPatternCellReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCellPatternCellReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTargetPlatform from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddTargetPlatformReceived;
        protected virtual void OnGamingCoordinatorAddTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTargetPlatforms from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetTargetPlatformsReceived;
        protected virtual void OnGamingCoordinatorGetTargetPlatformsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetTargetPlatformsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetTargetPlatformsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTargetPlatform from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateTargetPlatformReceived;
        protected virtual void OnGamingCoordinatorUpdateTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTargetPlatform from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteTargetPlatformReceived;
        protected virtual void OnGamingCoordinatorDeleteTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddTargetPlatform from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddTargetPlatformReceived;
        protected virtual void OnAdminAddTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetTargetPlatforms from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetTargetPlatformsReceived;
        protected virtual void OnAdminGetTargetPlatformsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetTargetPlatformsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetTargetPlatformsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateTargetPlatform from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateTargetPlatformReceived;
        protected virtual void OnAdminUpdateTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteTargetPlatform from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteTargetPlatformReceived;
        protected virtual void OnAdminDeleteTargetPlatformReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteTargetPlatformReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteTargetPlatformReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAIStrategy from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddAIStrategyReceived;
        protected virtual void OnGamingCoordinatorAddAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAIStrategies from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetAIStrategiesReceived;
        protected virtual void OnGamingCoordinatorGetAIStrategiesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetAIStrategiesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetAIStrategiesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAIStrategy from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateAIStrategyReceived;
        protected virtual void OnGamingCoordinatorUpdateAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAIStrategy from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteAIStrategyReceived;
        protected virtual void OnGamingCoordinatorDeleteAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddAIStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddAIStrategyReceived;
        protected virtual void OnAdminAddAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetAIStrategies from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetAIStrategiesReceived;
        protected virtual void OnAdminGetAIStrategiesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetAIStrategiesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetAIStrategiesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateAIStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateAIStrategyReceived;
        protected virtual void OnAdminUpdateAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteAIStrategy from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteAIStrategyReceived;
        protected virtual void OnAdminDeleteAIStrategyReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteAIStrategyReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteAIStrategyReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellStates from Guest
        /// </summary>
        public event EventHandler<PayloadEventArgs> GuestGetCellStatesReceived;
        protected virtual void OnGuestGetCellStatesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GuestGetCellStatesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GuestGetCellStatesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellState from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddCellStateReceived;
        protected virtual void OnGamingCoordinatorAddCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellStates from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetCellStatesReceived;
        protected virtual void OnGamingCoordinatorGetCellStatesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetCellStatesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetCellStatesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellState from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateCellStateReceived;
        protected virtual void OnGamingCoordinatorUpdateCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellState from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteCellStateReceived;
        protected virtual void OnGamingCoordinatorDeleteCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellState from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCellStateReceived;
        protected virtual void OnAdminAddCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellStates from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCellStatesReceived;
        protected virtual void OnAdminGetCellStatesReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCellStatesReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCellStatesReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellState from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCellStateReceived;
        protected virtual void OnAdminUpdateCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellState from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCellStateReceived;
        protected virtual void OnAdminDeleteCellStateReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCellStateReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCellStateReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPatternTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorAddCellPatternTranslationReceived;
        protected virtual void OnGamingCoordinatorAddCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorAddCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorAddCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatternTranslations from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorGetCellPatternTranslationsReceived;
        protected virtual void OnGamingCoordinatorGetCellPatternTranslationsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorGetCellPatternTranslationsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorGetCellPatternTranslationsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPatternTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorUpdateCellPatternTranslationReceived;
        protected virtual void OnGamingCoordinatorUpdateCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorUpdateCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorUpdateCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPatternTranslation from GamingCoordinator
        /// </summary>
        public event EventHandler<PayloadEventArgs> GamingCoordinatorDeleteCellPatternTranslationReceived;
        protected virtual void OnGamingCoordinatorDeleteCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.GamingCoordinatorDeleteCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.GamingCoordinatorDeleteCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: AddCellPatternTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminAddCellPatternTranslationReceived;
        protected virtual void OnAdminAddCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminAddCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminAddCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: GetCellPatternTranslations from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminGetCellPatternTranslationsReceived;
        protected virtual void OnAdminGetCellPatternTranslationsReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminGetCellPatternTranslationsReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminGetCellPatternTranslationsReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: UpdateCellPatternTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminUpdateCellPatternTranslationReceived;
        protected virtual void OnAdminUpdateCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminUpdateCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminUpdateCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// Responds to: DeleteCellPatternTranslation from Admin
        /// </summary>
        public event EventHandler<PayloadEventArgs> AdminDeleteCellPatternTranslationReceived;
        protected virtual void OnAdminDeleteCellPatternTranslationReceived(StandardPayload payload, BasicDeliverEventArgs bdea)
        {
            var plea = new PayloadEventArgs(payload, bdea);
            if (!ReferenceEquals(this.AdminDeleteCellPatternTranslationReceived, null))
            {
                plea.Payload.IsHandled = true;
                this.AdminDeleteCellPatternTranslationReceived(this, plea);
            }
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetRabbitSassyMQConfiguration(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetRabbitSassyMQConfiguration(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetRabbitSassyMQConfiguration - 
        /// </summary>
        public Task ResetRabbitSassyMQConfiguration(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetrabbitsassymqconfiguration", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.ResetJWTSecretKey(this.CreatePayload(), replyHandler, timeoutHandler, waitTimeout);
        }

        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(String content, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            var payload = this.CreatePayload(content);
            return this.ResetJWTSecretKey(payload, replyHandler, timeoutHandler, waitTimeout);
        }
    
        
        /// <summary>
        /// ResetJWTSecretKey - 
        /// </summary>
        public Task ResetJWTSecretKey(StandardPayload payload, PayloadHandler replyHandler = null, PayloadHandler timeoutHandler = null, int waitTimeout = StandardPayload.DEFAULT_TIMEOUT)
        {
            return this.SendMessage("crudcoordinator.general.crudcoordinator.resetjwtsecretkey", payload, replyHandler, timeoutHandler, waitTimeout);
        }
        
        
    }
}

                    

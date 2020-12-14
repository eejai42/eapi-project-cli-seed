using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using tictactoechallenge.Lib.DataClasses;
using YP.SassyMQ.Lib.RabbitMQ;

namespace CLIClassLibrary.RoleHandlers
{
    public partial class AdminCLIHandler
    {
        private string HandlerFactory(string invokeRequest, string payloadString, string where)
        {
            var result = "";
            var payload = JsonConvert.DeserializeObject<StandardPayload>(payloadString);
            payload.SetActor(this.SMQActor);
            payload.AccessToken = this.SMQActor.AccessToken;
            payload.AirtableWhere = where;

            switch (invokeRequest.ToLower())
            {
                case "addglobalsetting":
                    this.SMQActor.AddGlobalSetting(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getglobalsettings":
                    this.SMQActor.GetGlobalSettings(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateglobalsetting":
                    this.SMQActor.UpdateGlobalSetting(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteglobalsetting":
                    this.SMQActor.DeleteGlobalSetting(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addscore":
                    this.SMQActor.AddScore(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getscores":
                    this.SMQActor.GetScores(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatescore":
                    this.SMQActor.UpdateScore(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletescore":
                    this.SMQActor.DeleteScore(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addailevel":
                    this.SMQActor.AddAILevel(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getailevels":
                    this.SMQActor.GetAILevels(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateailevel":
                    this.SMQActor.UpdateAILevel(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteailevel":
                    this.SMQActor.DeleteAILevel(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "adduielement":
                    this.SMQActor.AddUIElement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getuielements":
                    this.SMQActor.GetUIElements(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateuielement":
                    this.SMQActor.UpdateUIElement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteuielement":
                    this.SMQActor.DeleteUIElement(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addtranslation":
                    this.SMQActor.AddTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "gettranslations":
                    this.SMQActor.GetTranslations(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatetranslation":
                    this.SMQActor.UpdateTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletetranslation":
                    this.SMQActor.DeleteTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addlanguagetoken":
                    this.SMQActor.AddLanguageToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getlanguagetokens":
                    this.SMQActor.GetLanguageTokens(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatelanguagetoken":
                    this.SMQActor.UpdateLanguageToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletelanguagetoken":
                    this.SMQActor.DeleteLanguageToken(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addadditionalresource":
                    this.SMQActor.AddAdditionalResource(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getadditionalresources":
                    this.SMQActor.GetAdditionalResources(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateadditionalresource":
                    this.SMQActor.UpdateAdditionalResource(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteadditionalresource":
                    this.SMQActor.DeleteAdditionalResource(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addgame":
                    this.SMQActor.AddGame(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getgames":
                    this.SMQActor.GetGames(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updategame":
                    this.SMQActor.UpdateGame(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletegame":
                    this.SMQActor.DeleteGame(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcell":
                    this.SMQActor.AddCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcells":
                    this.SMQActor.GetCells(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecell":
                    this.SMQActor.UpdateCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecell":
                    this.SMQActor.DeleteCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcellpattern":
                    this.SMQActor.AddCellPattern(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcellpatterns":
                    this.SMQActor.GetCellPatterns(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecellpattern":
                    this.SMQActor.UpdateCellPattern(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecellpattern":
                    this.SMQActor.DeleteCellPattern(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addentity":
                    this.SMQActor.AddEntity(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getentities":
                    this.SMQActor.GetEntities(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateentity":
                    this.SMQActor.UpdateEntity(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteentity":
                    this.SMQActor.DeleteEntity(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "adduser":
                    this.SMQActor.AddUser(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getusers":
                    this.SMQActor.GetUsers(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateuser":
                    this.SMQActor.UpdateUser(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteuser":
                    this.SMQActor.DeleteUser(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcellpatterncell":
                    this.SMQActor.AddCellPatternCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcellpatterncells":
                    this.SMQActor.GetCellPatternCells(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecellpatterncell":
                    this.SMQActor.UpdateCellPatternCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecellpatterncell":
                    this.SMQActor.DeleteCellPatternCell(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addtargetplatform":
                    this.SMQActor.AddTargetPlatform(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "gettargetplatforms":
                    this.SMQActor.GetTargetPlatforms(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatetargetplatform":
                    this.SMQActor.UpdateTargetPlatform(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletetargetplatform":
                    this.SMQActor.DeleteTargetPlatform(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addaistrategy":
                    this.SMQActor.AddAIStrategy(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getaistrategies":
                    this.SMQActor.GetAIStrategies(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updateaistrategy":
                    this.SMQActor.UpdateAIStrategy(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deleteaistrategy":
                    this.SMQActor.DeleteAIStrategy(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcellstate":
                    this.SMQActor.AddCellState(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcellstates":
                    this.SMQActor.GetCellStates(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecellstate":
                    this.SMQActor.UpdateCellState(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecellstate":
                    this.SMQActor.DeleteCellState(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "addcellpatterntranslation":
                    this.SMQActor.AddCellPatternTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "getcellpatterntranslations":
                    this.SMQActor.GetCellPatternTranslations(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "updatecellpatterntranslation":
                    this.SMQActor.UpdateCellPatternTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                case "deletecellpatterntranslation":
                    this.SMQActor.DeleteCellPatternTranslation(payload, (reply, bdea) =>
                    {
                        result = SerializePayload(reply);
                    }).Wait(30000);
                    break;                   

                default:
                    throw new Exception($"Invalid request: {invokeRequest}");
            }

            return result;
        }
    }
}

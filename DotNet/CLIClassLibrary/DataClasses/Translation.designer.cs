using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace tictactoechallenge.Lib.DataClasses
{                            
    public partial class Translation
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TranslationId")]
        public String TranslationId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CustomDescription")]
        public String CustomDescription { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Id")]
        public String Id { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsClockwise")]
        public Nullable<Boolean> IsClockwise { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Cells")]
        [RemoteIsCollection]
        public String[] Cells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternTranslations")]
        [RemoteIsCollection]
        public String[] CellPatternTranslations { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RotateTranslation_CellsesExpanded")]
        public BindingList<Cell> RotateTranslation_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsClockwise_CellsesExpanded")]
        public BindingList<Cell> IsClockwise_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternTranslationsesExpanded")]
        public BindingList<CellPatternTranslation> CellPatternTranslationsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TranslationName_CellPatternTranslationsesExpanded")]
        public BindingList<CellPatternTranslation> TranslationName_CellPatternTranslationsExpanded { get; set; }
            

        
        
        private static string CreateTranslationWhere(IEnumerable<Translation> translations, String forignKeyFieldName = "TranslationId")
        {
            if (!translations.Any()) return "1=1";
            else 
            {
                var idList = translations.Select(selectTranslation => String.Format("'{0}'", selectTranslation.TranslationId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

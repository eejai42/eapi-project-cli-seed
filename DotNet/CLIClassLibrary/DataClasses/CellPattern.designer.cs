using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace tictactoechallenge.Lib.DataClasses
{                            
    public partial class CellPattern
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternId")]
        public String CellPatternId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsWinPattern")]
        public Nullable<Boolean> IsWinPattern { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCells")]
        [RemoteIsCollection]
        public String[] CellPatternCells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternTranslations")]
        [RemoteIsCollection]
        public String[] CellPatternTranslations { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCell")]
        [RemoteIsCollection]
        public String TargetCell { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellState")]
        [RemoteIsCollection]
        public String TargetCellState { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellIndex")]
        [RemoteIsCollection]
        public Nullable<Int32> TargetCellIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellStateId")]
        [RemoteIsCollection]
        public String TargetCellStateId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternTranslationCodes")]
        [RemoteIsCollection]
        public String[] CellPatternTranslationCodes { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Cells")]
        public String Cells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCellStates")]
        [RemoteIsCollection]
        public String[] CellPatternCellStates { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Target")]
        public String Target { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Translations")]
        public String Translations { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SortOrder")]
        public Nullable<Int32> SortOrder { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatterns_CellsesExpanded")]
        public BindingList<Cell> CellPatterns_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellPatternCellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatterns_CellStatesesExpanded")]
        public BindingList<CellState> CellPatterns_CellStatesExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternTranslationsesExpanded")]
        public BindingList<CellPatternTranslation> CellPatternTranslationsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternName_CellPatternTranslationsesExpanded")]
        public BindingList<CellPatternTranslation> CellPatternName_CellPatternTranslationsExpanded { get; set; }
            

        
        
        private static string CreateCellPatternWhere(IEnumerable<CellPattern> cellPatterns, String forignKeyFieldName = "CellPatternId")
        {
            if (!cellPatterns.Any()) return "1=1";
            else 
            {
                var idList = cellPatterns.Select(selectCellPattern => String.Format("'{0}'", selectCellPattern.CellPatternId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

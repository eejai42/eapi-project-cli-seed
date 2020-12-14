using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace tictactoechallenge.Lib.DataClasses
{                            
    public partial class CellState
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellStateId")]
        public String CellStateId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Code")]
        public String Code { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Color")]
        public String Color { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FontColor")]
        public String FontColor { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultMark")]
        public String DefaultMark { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Cursor")]
        public String Cursor { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SortOrder")]
        public String SortOrder { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Id")]
        public String Id { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCells")]
        [RemoteIsCollection]
        public String[] CellPatternCells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatterns")]
        [RemoteIsCollection]
        public String[] CellPatterns { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentStateCells")]
        [RemoteIsCollection]
        public String[] CurrentStateCells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultStateCells")]
        [RemoteIsCollection]
        public String[] DefaultStateCells { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultState_CellsesExpanded")]
        public BindingList<Cell> DefaultState_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentState_CellsesExpanded")]
        public BindingList<Cell> CurrentState_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentCellState_CellsesExpanded")]
        public BindingList<Cell> CurrentCellState_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultCellState_CellsesExpanded")]
        public BindingList<Cell> DefaultCellState_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellState_CellPatternsesExpanded")]
        public BindingList<CellPattern> TargetCellState_CellPatternsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellStateId_CellPatternsesExpanded")]
        public BindingList<CellPattern> TargetCellStateId_CellPatternsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellPatternCellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellStateName_CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellStateName_CellPatternCellsExpanded { get; set; }
            

        
        
        private static string CreateCellStateWhere(IEnumerable<CellState> cellStates, String forignKeyFieldName = "CellStateId")
        {
            if (!cellStates.Any()) return "1=1";
            else 
            {
                var idList = cellStates.Select(selectCellState => String.Format("'{0}'", selectCellState.CellStateId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

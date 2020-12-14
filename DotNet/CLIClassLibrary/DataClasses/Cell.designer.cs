using System;
using System.ComponentModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using CoreLibrary.Extensions;

namespace tictactoechallenge.Lib.DataClasses
{                            
    public partial class Cell
    {
        private void InitPoco()
        {
        }
        
        partial void AfterGet();
        partial void BeforeInsert();
        partial void AfterInsert();
        partial void BeforeUpdate();
        partial void AfterUpdate();

        

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellId")]
        public String CellId { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Name")]
        public String Name { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RotateDescription")]
        public String RotateDescription { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RotateIndex")]
        public Nullable<Int32> RotateIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Clockwise")]
        [RemoteIsCollection]
        public String Clockwise { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwise")]
        [RemoteIsCollection]
        public String CounterClockwise { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Flip")]
        [RemoteIsCollection]
        public String Flip { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SampleValue")]
        public String SampleValue { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultState")]
        [RemoteIsCollection]
        public String DefaultState { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentState")]
        [RemoteIsCollection]
        public String CurrentState { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Description")]
        public String Description { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "X")]
        public Nullable<Int32> X { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Y")]
        public Nullable<Int32> Y { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RotateFrom")]
        public String RotateFrom { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "RotateTranslation")]
        [RemoteIsCollection]
        public String RotateTranslation { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "IsClockwise")]
        [RemoteIsCollection]
        public Nullable<Boolean> IsClockwise { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClockwiseRotateFrom")]
        [RemoteIsCollection]
        public String ClockwiseRotateFrom { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwiseRotateFrom")]
        [RemoteIsCollection]
        public String CounterClockwiseRotateFrom { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FlipFromName")]
        [RemoteIsCollection]
        public String FlipFromName { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FlipIndex")]
        [RemoteIsCollection]
        public Nullable<Int32> FlipIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellIndex")]
        public Nullable<Int32> CellIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCells")]
        [RemoteIsCollection]
        public String[] CellPatternCells { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatterns")]
        [RemoteIsCollection]
        public String[] CellPatterns { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClockwiseRotateFromIndex")]
        [RemoteIsCollection]
        public Nullable<Int32> ClockwiseRotateFromIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwiseRotateFromIndex")]
        [RemoteIsCollection]
        public Nullable<Int32> CounterClockwiseRotateFromIndex { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentCellState")]
        [RemoteIsCollection]
        public String CurrentCellState { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultCellState")]
        [RemoteIsCollection]
        public String DefaultCellState { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FlipDescription")]
        public String FlipDescription { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "SortOrder")]
        public Nullable<Int32> SortOrder { get; set; }
    
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellKey")]
        public Nullable<Int32> CellKey { get; set; }
    

        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Cells_TranslationsesExpanded")]
        public BindingList<Translation> Cells_TranslationsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Clockwise_CellsesExpanded")]
        public BindingList<Cell> Clockwise_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwise_CellsesExpanded")]
        public BindingList<Cell> CounterClockwise_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "Flip_CellsesExpanded")]
        public BindingList<Cell> Flip_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClockwiseRotateFrom_CellsesExpanded")]
        public BindingList<Cell> ClockwiseRotateFrom_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwiseRotateFrom_CellsesExpanded")]
        public BindingList<Cell> CounterClockwiseRotateFrom_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FlipFromName_CellsesExpanded")]
        public BindingList<Cell> FlipFromName_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "FlipIndex_CellsesExpanded")]
        public BindingList<Cell> FlipIndex_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "ClockwiseRotateFromIndex_CellsesExpanded")]
        public BindingList<Cell> ClockwiseRotateFromIndex_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CounterClockwiseRotateFromIndex_CellsesExpanded")]
        public BindingList<Cell> CounterClockwiseRotateFromIndex_CellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCell_CellPatternsesExpanded")]
        public BindingList<CellPattern> TargetCell_CellPatternsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "TargetCellIndex_CellPatternsesExpanded")]
        public BindingList<CellPattern> TargetCellIndex_CellPatternsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellPatternCellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellIndex_CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellIndex_CellPatternCellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CellName_CellPatternCellsesExpanded")]
        public BindingList<CellPatternCell> CellName_CellPatternCellsExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "CurrentStateCells_CellStatesesExpanded")]
        public BindingList<CellState> CurrentStateCells_CellStatesExpanded { get; set; }
            
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.IgnoreAndPopulate, PropertyName = "DefaultStateCells_CellStatesesExpanded")]
        public BindingList<CellState> DefaultStateCells_CellStatesExpanded { get; set; }
            

        
        
        private static string CreateCellWhere(IEnumerable<Cell> cells, String forignKeyFieldName = "CellId")
        {
            if (!cells.Any()) return "1=1";
            else 
            {
                var idList = cells.Select(selectCell => String.Format("'{0}'", selectCell.CellId));
                var csIdList = String.Join(",", idList);
                return String.Format("{0} in ({1})", forignKeyFieldName, csIdList);
            }
        }
        
    }
}

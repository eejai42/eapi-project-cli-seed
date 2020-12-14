using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSoTme.Default.Lib.CLIHandler
{

    [CommandLineManager(ApplicationName = "SSOT.me Command Line Request",
                        Copyright = "Copyright (c) EJ Alexandra, CODEiverse.com",
                        Description = @"
SYNTAX: ssotme {command} [...{additional_args}] [options]

Options
")]
    public partial class PlossumCLIHandler
    {
        
        [CommandLineOption(Description = "Authenticate as a user", MinOccurs = 0, Aliases = "auth")]
        public bool authenticate { get; set; }
        
        [CommandLineOption(Description = "The users email address", MinOccurs = 0, Aliases = "e")]
        public string emailAddress { get; set; }
        
        [CommandLineOption(Description = "the user's password", MinOccurs = 0, Aliases = "p")]
        public string password { get; set; }
        
        [CommandLineOption(Description = "Add a cell to the database", MinOccurs = 0, Aliases = "")]
        public string AddCell { get; set; }
        
        [CommandLineOption(Description = "Removes a cell from the db", MinOccurs = 0, Aliases = "")]
        public string DeleteCell { get; set; }
        
        [CommandLineOption(Description = "Get a list of cells from the db", MinOccurs = 0, Aliases = "")]
        public string GetCells { get; set; }
        
    }
}

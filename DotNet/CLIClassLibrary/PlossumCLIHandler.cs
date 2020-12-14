using Plossum.CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSoTme.Default.Lib.CLIHandler
{

    public partial class PlossumCLIHandler
    {
        public PlossumCLIHandler(string[] args)
        {
            // Initialize your parameters
            this.Parser = new CommandLineParser(this);
            this.Parser.Parse(args);
        }

        public CommandLineParser Parser { get; }

        private void Parse()
        {
        }
    }
}

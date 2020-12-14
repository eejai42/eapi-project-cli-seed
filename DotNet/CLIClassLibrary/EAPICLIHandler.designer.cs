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
    public partial class EAPICLIHandler
    {
        private string _amqps;

        [CommandLineOption(Description = "AMQPS Connection String", MinOccurs = 0, Aliases = "amqp")]
        public string amqps { get => _amqps; set => _amqps = value; }

        [CommandLineOption(Description = "Authenticate as a user", MinOccurs = 0, Aliases = "auth")]
        public string authenticate { get; set; }

        [CommandLineOption(Description = "the user's password", MinOccurs = 0, Aliases = "p")]
        public string demoPassword { get; set; }

        [CommandLineOption(Description = "Invoke a method", MinOccurs = 0, Aliases = "i")]
        public string invoke { get; set; }

        [CommandLineOption(Description = "Raw data provided", MinOccurs = 0, Aliases = "d")]
        public string bodyData { get; set; }

        [CommandLineOption(Description = "Path to file to use", MinOccurs = 0, Aliases = "f")]
        public string bodyFile { get; set; }

        [CommandLineOption(Description = "Who to run as", MinOccurs = 0, Aliases = "as")]
        public string runas { get; set; }

    }
}

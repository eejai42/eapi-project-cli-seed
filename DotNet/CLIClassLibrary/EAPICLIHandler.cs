using SSoTme.Default.Lib.CLIHandler;
using System;

namespace EAPICLILib
{
    public class EAPICLIHandler
    {
        public static void HandleRequest(string[] args)
        {
            var handler = new PlossumCLIHandler(args);
            Console.WriteLine(handler.Parser.UsageInfo);
            object o = 1;





        }
    }
}
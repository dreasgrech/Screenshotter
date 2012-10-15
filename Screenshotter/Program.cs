
namespace Screenshotter
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        private static OptionSet options;

        private static string options_screenshotPath;
        private static int? options_pId;

        static void Main(string[] args)
        {
            if (!HandleCommandLineArgs(args))
            {
                ShowHelp(options);
                return;
            }

            Camera.ClickClick(options_pId.Value, options_screenshotPath);
        }

        static void ShowHelp(OptionSet options)
        {
            Console.WriteLine("Usage: {0} [options] processIdentifier\n", AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);
        }

        static bool HandleCommandLineArgs(IEnumerable<string> args)
        {
            bool status = true;
            options = new OptionSet
                          {
                              { "s|screenshot=", "The location and filename of where the screenshot should be saved", (string v) => options_screenshotPath = v },
                              { "?|h|help", "Show help", v => { status = false; } },
                              { "<>", (int v) => options_pId = v } // For the default argument, you need to specify the pId
                          };
            try
            {
                options.Parse(args);
            }
            catch (OptionException)
            {
                status = false;
            }

            if (!options_pId.HasValue)
            {
                status = false;
            }

            return status;
        }

    }
}

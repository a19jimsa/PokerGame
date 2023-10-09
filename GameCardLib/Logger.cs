using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{
    public static class Logger
    {
        public static Action<string>? WriteMessage = null;

        /// <summary>
        /// Log message to console window
        /// </summary>
        /// <param name="msg"></param>
        public static void LogMessage(string msg)
        {
            if(WriteMessage == null)
            {
                WriteMessage += WriteToConsole;
                WriteMessage += StoreToFile;
            }
            if (WriteMessage != null)
            {
                WriteMessage.Invoke(msg);
            }
        }

        private static void WriteToConsole(string msg)
        {
            Trace.WriteLine(msg);
        }

        private static void StoreToFile(string msg)
        {
            string path = @"Logfile.txt";
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using StreamWriter sw = File.CreateText(path);
                sw.Write(msg);
            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.Write(msg);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace ADSAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ADSWriter("Hello", "C:\\debug.txt", "hide"); //Writes 'hello' to the file debug.txt in the alternate datastream 'hide'
            Console.WriteLine(ADSReader("C:\\debug.txt", "hide")); //Reads data from alternate datastream 'hide' in the file debug.txt and prints to console
            Console.ReadKey(); //Pause for humans
        }
        static public void ADSWriter(String Content, String File, String StreamName) //Write data to alternate datastream
        {
            System.Diagnostics.Process.Start("CMD.exe", "/C echo " + Content + "> " + File + ":" + StreamName); //Can use dirty process.start because we dont care about output
        }
        static public String ADSReader(String File, String StreamName) //Read data from alternate datastream, will return nothing if there is no data in stream or if stream doesnt exist
        {
            Process Reader = new Process(); //Have to use a defined process because we care about process output
            Reader.StartInfo.FileName = "CMD.exe";
            Reader.StartInfo.Arguments = "/C more < " + File + ":" + StreamName;
            Reader.StartInfo.CreateNoWindow = true;
            Reader.StartInfo.UseShellExecute = false;
            Reader.StartInfo.RedirectStandardOutput = true;
            Reader.Start();
            string DataFound = Reader.StandardOutput.ReadToEnd();
            Reader.WaitForExit();
            return DataFound;
        }
    }
}

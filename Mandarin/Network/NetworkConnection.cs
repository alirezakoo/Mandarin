using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mandarin.Network
{


    public class NetworkConnection
    {
        [DllImport("wininet.dll")]
        public static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int dwBufferLength);
        public const int INTERNET_OPTION_SETTINGS_CHANGED = 39;
        public const int INTERNET_OPTION_REFRESH = 37;
        private bool settingsReturn, refreshReturn;
        public List<string> NetConnections = new List<string>();
        public string freeConnection, localConnection;
        public NetworkConnection()
        {
            FillConnections();

            freeConnection = Mandarin.Properties.Settings.Default.freeConnection;
            localConnection = Mandarin.Properties.Settings.Default.localConnection;

        }
        public static void reset()
        {
            Mandarin.Properties.Settings.Default.is_start = false;
            Mandarin.Properties.Settings.Default.is_on_free = false;
            Mandarin.Properties.Settings.Default.Save();
        }
        public void FillConnections()
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);
            NetConnections.Clear();
            foreach (ManagementObject item in searchProcedure.Get())
            {
                //if (((string)item["NetConnectionId"]) == "Local Network Connection")
                //{
                //    //item.InvokeMethod("Disable", null);
                //    MessageBox.Show(item.GetPropertyValue("Name").ToString());
                //}
                NetConnections.Add((string)item["NetConnectionId"]);
                //cboInternet.Items.Add((string)item["NetConnectionId"]);
                //cboLocalNet.Items.Add((string)item["NetConnectionId"]);
            }
        }

        private void ChangeConnectionState(string ConnectionName, bool Status)
        {
            SelectQuery wmiQuery = new SelectQuery("SELECT * FROM Win32_NetworkAdapter WHERE NetConnectionId != NULL");
            ManagementObjectSearcher searchProcedure = new ManagementObjectSearcher(wmiQuery);

            foreach (ManagementObject item in searchProcedure.Get())
            {
                if (ConnectionName == ((string)item["NetConnectionId"]))
                {
                    item.InvokeMethod(Status ? "Enable" : "Disable", null);
                    return;
                }
            }
        }
        private void ShowStatusLog(string description)
        {
            System.Console.WriteLine(description);
        }
        private void EnableAdapter(string interfaceName)
        {
            ShowStatusLog("Connecting with " + interfaceName + "...");
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.ErrorDialog = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            ShowStatusLog("Connect with " + interfaceName);
        }

        private void DisableAdapter(string interfaceName)
        {
            ShowStatusLog("Disconnecting " + interfaceName + "...");
            ProcessStartInfo psi = new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            psi.UseShellExecute = false;
            psi.RedirectStandardError = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.ErrorDialog = false;
            psi.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
            ShowStatusLog("Disconnected " + interfaceName);
        }
        public static bool PingNetwork()
        {
            try
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://google.com/generate_204"))
                    return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangeConnectionToFreeNetwork(bool isAutoConnectToWireless = true)
        {

            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            RegKey.SetValue("ProxyServer", Mandarin.Properties.Settings.Default.ProxyServer);
            DisableAdapter(localConnection);
            EnableAdapter(freeConnection);
            System.Threading.Thread.Sleep(500);
            RegKey.SetValue("ProxyEnable", 0);
            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            Mandarin.Properties.Settings.Default.is_on_free = true;
            Mandarin.Properties.Settings.Default.Save();
            System.Threading.Thread.Sleep(500);
            try
            {
                if (!isAutoConnectToWireless)
                {
                    if (PingNetwork())
                        return settingsReturn & refreshReturn;
                    else
                    {
                        System.Threading.Thread.Sleep(3000);
                        if (PingNetwork())
                            return settingsReturn & refreshReturn;
                    }
                }
            }
            catch { ShowStatusLog("can not connect please check wireless connection or network"); }
            return settingsReturn & refreshReturn;
        }
        public bool ChangeConnectionToLocalNetwork()
        {
            RegistryKey RegKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings", true);
            RegKey.SetValue("ProxyServer", Mandarin.Properties.Settings.Default.ProxyServer);

            EnableAdapter(localConnection);
            DisableAdapter(freeConnection);
            RegKey.SetValue("ProxyEnable", 1);

            settingsReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_SETTINGS_CHANGED, IntPtr.Zero, 0);
            refreshReturn = InternetSetOption(IntPtr.Zero, INTERNET_OPTION_REFRESH, IntPtr.Zero, 0);
            Mandarin.Properties.Settings.Default.is_on_free = false;
            Mandarin.Properties.Settings.Default.Save();
            return settingsReturn & refreshReturn;

        }

    }
}

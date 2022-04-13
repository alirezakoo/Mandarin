
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace Mandarin
{
    public partial class SettingForm : Form
    {

        private Network.NetworkConnection connection;
        public SettingForm(Network.NetworkConnection connection)
        {
            InitializeComponent();

            this.connection = connection;
            refresh();
        }


        private void refresh()
        {
            connection.FillConnections();

            cboLocalNet.Items.Clear();
            cboInternet.Items.Clear();


            cboLocalNet.Items.AddRange(connection.NetConnections.ToArray());
            cboInternet.Items.AddRange(connection.NetConnections.ToArray());
            cboInternet.SelectedItem = Mandarin.Properties.Settings.Default.freeConnection;
            cboLocalNet.SelectedItem = Mandarin.Properties.Settings.Default.localConnection;

            TxtProxyServer.Text = Mandarin.Properties.Settings.Default.ProxyServer;


        }

        private void button1_Click(object sender, EventArgs e)
        {


            if (cboInternet.SelectedItem.ToString().Trim() == string.Empty || cboLocalNet.SelectedItem.ToString().Trim() == string.Empty || TxtProxyServer.Text.Trim() == string.Empty)
                return;

            if (!connection.NetConnections.Contains(cboInternet.SelectedItem.ToString()) || !connection.NetConnections.Contains(cboLocalNet.SelectedItem.ToString()))
                return;

            Mandarin.Properties.Settings.Default.localConnection = cboLocalNet.SelectedItem.ToString();
            Mandarin.Properties.Settings.Default.freeConnection = cboInternet.SelectedItem.ToString();


            Mandarin.Properties.Settings.Default.ProxyServer = TxtProxyServer.Text;

            Mandarin.Properties.Settings.Default.Save();
            Startup.RunOnStartup();
            this.Close();
        }


        private void Switch_Load(object sender, EventArgs e)
        {

        }

        private void butRef_Click(object sender, EventArgs e)
        {
            refresh();

        }




        private void butTerminate_Click(object sender, EventArgs e)
        {

            System.Threading.Thread.Sleep(1000);

            Process[] workers = Process.GetProcessesByName(Application.ProductName);
            foreach (Process worker in workers)
            {
                Network.SystemLog.AddLog("Kill Process " + worker.ProcessName, System.Diagnostics.EventLogEntryType.Information, "Stop");
                worker.Kill();
                System.Threading.Thread.Sleep(1000);
            }
            Application.Exit();
        }
    }
}

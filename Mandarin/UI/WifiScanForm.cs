using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.ListBox;

namespace Mandarin
{
    public partial class WifiScanForm : Form
    {
        private Network.NetworkConnection net;
        public WifiScanForm(Network.NetworkConnection net)
        {
            this.net = net;
            InitializeComponent();
            
        }

        private void WifiScanForm_Load(object sender, EventArgs e)
        {
            //scan();
        }
        //private void scan()
        //{
        //    WifilistBox.Items.Clear();
        //    bool is_on_free_state = Mandarin.Properties.Settings.Default.is_on_free;
        //    if (!Mandarin.Properties.Settings.Default.is_on_free)
        //    {
        //        net.ChangeConnectionToFreeNetwork(false);
        //    }
        //    int i;
        //    string[] ssidsArray = null;
        //    for (i = 1; i <= 4; i++)
        //    {
        //        var ssids = net.wifi.ScanSSID();
        //        if (!ssids.Any())
        //            System.Threading.Thread.Sleep(i * 1000);
        //        else
        //        {
        //            ssidsArray = ssids.Select(x => x.SSID).ToArray();
        //            break;
        //        }
        //    }
        //    if (ssidsArray!=null)
        //    {
        //        WifilistBox.Items.AddRange(ssidsArray);
        //    }
        //    if (!is_on_free_state)
        //        net.ChangeConnectionToLocalNetwork();
        //}
        public SelectedObjectCollection GetSelectedSSID()
        {
            return WifilistBox.SelectedItems;
        }
        private void scanbutton1_Click(object sender, EventArgs e)
        {
            //scan();
        }

        private void okbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cancelbut_Click(object sender, EventArgs e)
        {
            WifilistBox.SelectedItems.Clear();
        }
    }
}

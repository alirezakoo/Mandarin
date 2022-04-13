using Mandarin.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;


namespace Mandarin
{
    internal class CustomApplicationContext : TrayIconApplicationContext
    {
        #region Instance Fields


        private SettingForm _settingsDialog;

        private Network.NetworkConnection connection;
        #endregion

        #region Constructors

        public CustomApplicationContext()
        {

            connection = new Network.NetworkConnection();
            this.TrayIcon.Icon = Resources.MandarinIcon;
            if ((!connection.NetConnections.Contains(Mandarin.Properties.Settings.Default.freeConnection) || !connection.NetConnections.Contains(Mandarin.Properties.Settings.Default.localConnection)) || Mandarin.Properties.Settings.Default.freeConnection == "0" || Mandarin.Properties.Settings.Default.localConnection == "0")
                new Mandarin.SettingForm(connection).ShowDialog();

            this.ContextMenu.Items.Add("&Connect to local...", Resources.local, this.LocalContextMenuClickHandler);
            this.ContextMenu.Items.Add("&Connect to Free...", Resources.free, this.FreeContextMenuClickHandler);
            this.ContextMenu.Items.Add("-");
            this.ContextMenu.Items.Add("&Settings...", Resources.setting, this.SettingsContextMenuClickHandler).Font = new Font(this.ContextMenu.Font, FontStyle.Bold);
            //this.ContextMenu.Items.Add("-");
            //this.ContextMenu.Items.Add("Exit", null, this.ExitContextMenuClickHandler);



            if (Mandarin.Properties.Settings.Default.is_on_free)
            {
                connection.ChangeConnectionToFreeNetwork();
                this.TrayIcon.Icon = Mandarin.Properties.Resources.freeIcon;
            }
            else
            {
                connection.ChangeConnectionToLocalNetwork();
                this.TrayIcon.Icon = Mandarin.Properties.Resources.localIcon;
            }
        }

        #endregion

        #region Overridden Members



        protected override void OnTrayIconDoubleClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                this.ShowSettings();

            base.OnTrayIconDoubleClick(e);
        }

        #endregion

        #region Members


        private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
        {

            this.ExitThread();
        }
        private void LocalContextMenuClickHandler(object sender, EventArgs eventArgs)
        {

            if(connection.ChangeConnectionToLocalNetwork())
            {
                this.ContextMenu.Items[0].Visible = false;
                this.ContextMenu.Items[1].Visible = true;
            }
            else
            {

                this.ContextMenu.Items[0].Visible = true;
                this.ContextMenu.Items[1].Visible = true;
            }
            this.TrayIcon.Icon = Mandarin.Properties.Resources.localIcon;
        }
        private void FreeContextMenuClickHandler(object sender, EventArgs eventArgs)
        {
            if (connection.ChangeConnectionToFreeNetwork())
            {
                this.ContextMenu.Items[1].Visible = false;
                this.ContextMenu.Items[0].Visible = true;
            }
            else
            {

                this.ContextMenu.Items[0].Visible = true;
                this.ContextMenu.Items[1].Visible = true;
            }
            this.TrayIcon.Icon = Mandarin.Properties.Resources.freeIcon;
        }


        private void SettingsContextMenuClickHandler(object sender, EventArgs eventArgs)
        {
            this.ShowSettings();
        }

        private void ShowSettings()
        {


            if (_settingsDialog == null)
            {
                using (_settingsDialog = new SettingForm(connection))
                    _settingsDialog.ShowDialog();
                _settingsDialog = null;
            }
            else
                _settingsDialog.Activate();
        }

        #endregion
    }
}

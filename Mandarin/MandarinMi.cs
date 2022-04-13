using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandarin
{
    public class MandarinMi
    {
        private int IdleTime = (60000 * 10);//10 min
        private bool Is_ok_time()
        {
            if (Win32_API.Win32.GetIdleTime() < IdleTime)
            {
                return false;
            }
            TimeSpan now = DateTime.Now.TimeOfDay;
            int start_h = Mandarin.Properties.Settings.Default.start;
            int stop_h = Mandarin.Properties.Settings.Default.stop;
            TimeSpan start = new TimeSpan(start_h, 0, 0);
            TimeSpan stop = new TimeSpan(stop_h, 0, 0);
            if (now >= new TimeSpan(23, 58, 57) && now <= new TimeSpan(00, 01, 01))
                return true;

            if (start > stop)
            {
                if ((now >= start && now <= new TimeSpan(23, 59, 59)) || (now >= new TimeSpan(00, 00, 00) && now <= stop))
                    return true;
            }
            else
            {
                if (((now >= start && now <= stop)) /*&& Win32_API.Win32.GetIdleTime() > IdleTime*/)
                    return true;
            }
            return false;
        }
        public void StartMine()
        {
            Network.NetworkConnection connection = new Network.NetworkConnection();
            bool is_connected_to_local_before_start = true;


            while (true)
            {
                System.Threading.Thread.Sleep(2000);
                if (Is_ok_time())
                {
                    if (Mandarin.Properties.Settings.Default.is_start)
                        continue;
                    Win32_API.Win32.LockWorkStation();
                    is_connected_to_local_before_start = !Mandarin.Properties.Settings.Default.is_on_free;

                }
                else
                {
                    if (!Mandarin.Properties.Settings.Default.is_start)
                        continue;

                    System.Threading.Thread.Sleep(IdleTime);
                }

            }
        }
    }
}
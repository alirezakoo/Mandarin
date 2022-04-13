using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandarin.Network
{
    class SystemLog
    {
        public SystemLog(NetworkConnection network)
        {

        }

        
        public static void AddLog(string event_body,EventLogEntryType event_type,string source)
        {
            //// Create the source, if it does not already exist.
            //if (!EventLog.SourceExists(source))
            //{
            //    //An event log source should not be created and immediately used.
            //    //There is a latency time to enable the source, it should be created
            //    //prior to executing the application that uses the source.
            //    //Execute this sample a second time to use the new source.
            //    EventLog.CreateEventSource(source, "MyNewLog");

            //    // The source is created.  Exit the application to allow it to be registered.
            //    return;
            //}

            //// Create an EventLog instance and assign its source.
            //EventLog myLog = new EventLog();
            //myLog.Source = source;

            //// Write an informational entry to the event log.
            //myLog.WriteEntry(event_body, event_type);
        }
    }
    
}

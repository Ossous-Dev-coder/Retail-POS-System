using System;
using System.Diagnostics;


namespace Loging_Service
{
    public class LogToEventsLog : ILog
    {
        private readonly string _logName;

        private readonly string _source;

        private readonly  EventLogEntryType _eventType;

        public LogToEventsLog(string source, string logName, EventLogEntryType eventType)
        {
            _logName = logName;

            _source = source;

            _eventType = eventType;

            _CreateSource();
        }

        private void _CreateSource()
        {
            try
            {
                if(!EventLog.SourceExists(_source))

			    EventLog.CreateEventSource(_source,  _logName);

            }
            catch(Exception ex)
            {
                Debug.WriteLine("Event log source creation has failed : " + ex);
            }
        }

        public void Log(string errorMessage)
        {
			EventLog.WriteEntry(_source, errorMessage, _eventType);
		}
    } 
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loging_Service
{
    public interface ILog
    {
        void Log(string content);
    }

    public class LoggingService
    {
        private ILog _log { get; set; }

        public LoggingService(ILog log)
        {
            _log = log;
        }

        public void Log(string content)
        {
            _log.Log(content);
        }
    
    }
}

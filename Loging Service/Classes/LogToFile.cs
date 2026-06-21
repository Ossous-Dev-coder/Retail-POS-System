using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Loging_Service
{
    class LogToFile : ILog
    {
        private string _fileName { get; set; }

        public LogToFile(string fileName)
        {
            _fileName = fileName;
        }

        public void Log(string ErrorMessage)
        {
			string content = DateTime.Now.ToString() + "\n" + "\n Error : " + ErrorMessage + "\n ================================\n";

			File.WriteAllText(_fileName, content);
		}
    }
}

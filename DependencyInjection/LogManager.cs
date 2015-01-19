using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DependencyInjection
{
    public class LogManager
    {
        private ILogger _logger;

        public ILogger Logger
        {
            set { _logger = value; } //Birinci dependency Injection yolu.
        }

        public LogManager()
        {

        }

        public LogManager(ILogger logger)
        {
            this._logger = logger;//ikinci dependency ınjection yolu
        }

        public void SetLogger(ILogger logger)
        {
            this._logger = logger;//üçüncü dependency injection yolu
        }

        public void LogAt(string text)
        {
            _logger.LogAt(text);
        }
    }
}

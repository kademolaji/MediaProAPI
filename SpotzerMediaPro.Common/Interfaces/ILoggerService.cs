using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Common.Interfaces
{
    public interface ILoggerService
    {
        /*
       * Logs the given log line as Information.
       */
        void Info(string message);

        /*
        * Logs the given log line as Warning.
        */
        void Warn(string message);

        /*
        * Logs the given log line as Error.
        */
        void Error(string message);
    }
}

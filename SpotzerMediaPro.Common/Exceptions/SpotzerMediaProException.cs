using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotzerMediaPro.Common.Exceptions
{
    public class SpotzerMediaProException : Exception
    {
        public SpotzerMediaProException() : base()
        {
            // Noop
        }

        public SpotzerMediaProException(string message) : base(message)
        {
            // Noop
        }

        public SpotzerMediaProException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args))
        {
            // Noop
        }

        public SpotzerMediaProException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

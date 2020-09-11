using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class AppException : Exception
    {
        public AppException() : base() { }
        public AppException(string msg) : base(msg) { }
        public AppException(string msg, Exception ex) : base(msg, ex) { }
    }
}

using System;

namespace AspectLibrary
{
    internal class Context : IContext
    {
        public string MethodName { get; set; }

        public string ClassName { get; set; }

        public object[] Arguments { get; set; }

        public object Result { get; set; }

        public Exception Exception { get; set; }
    }
}
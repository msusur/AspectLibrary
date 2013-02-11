using System;

namespace AspectLibrary
{
    public interface IContext
    {
        string MethodName { get; set; }
        string ClassName { get; set; }
        object[] Arguments { get; set; }
        object Result { get; set; }
        Exception Exception { get; set; }
    }
}
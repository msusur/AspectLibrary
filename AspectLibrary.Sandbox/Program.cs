using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectLibrary.Sandbox
{
    public class Program
    {
        static void Main(string[] args)
        {
            var proxy =
                Proxy<Program>.New()
                      //If the input parameter is any integer, call my OnBefore Method before the method execution.
                     .To(p => p.Calculate(It.IsAny<int>())).OnBefore(context => Console.WriteLine(context.ClassName))
                     //If the input parameter is integer and it is 12 then call my OnAfter method after the method is executed.
                     .To(p => p.Calculate(It.Is(12))).OnAfter(context => Console.WriteLine("die"))
                     //For any input parameter that is an integer, call the OnCatch method whenever an exception is occured.
                     .To(p => p.Calculate(It.IsAny<int>())).OnCatch(context => Console.WriteLine(context.Exception.Message))
                     .Build();

            var result = proxy.Calculate(12);
        }

        private int Calculate(int x)
        {
            return x * x;
        }
    }

}

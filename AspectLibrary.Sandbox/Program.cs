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
                     .To(p => p.Calculate(It.IsAny<int>())).OnBefore(context => Console.WriteLine(context.ClassName))
                     .To(p => p.Calculate(It.Is(12))).OnAfter(context => Console.WriteLine("die"))
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

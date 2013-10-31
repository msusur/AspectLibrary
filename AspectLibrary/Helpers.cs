using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspectLibrary
{
    public static class It
    {
        public static TType Is<TType>(TType value)
        {
            return value;
        }

        public static TType IsAny<TType>()
        {
            return default(TType);
        }

        public static TType IsAny2<TType>()
        {
            return default(TType);
        }
    }
}

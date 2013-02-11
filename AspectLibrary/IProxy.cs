using System;
using System.Linq.Expressions;

namespace AspectLibrary
{
    public interface IProxy<TType> where TType : class
    {
        IAspect<Proxy<TType>, TType> To(Expression<Func<TType, object>> predicate);
        TType Build();
    }
}
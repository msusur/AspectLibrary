using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Castle.DynamicProxy;

namespace AspectLibrary
{
    public class Proxy<TType> : IProxy<TType> where TType : class
    {
        private readonly List<IAspect<Proxy<TType>, TType>> _aspects = new List<IAspect<Proxy<TType>, TType>>();


        public static IProxy<TType> New()
        {
            return new Proxy<TType>();
        }

        public IAspect<Proxy<TType>, TType> To(Expression<Func<TType, object>> predicate)
        {
            var aspect = new Aspect<Proxy<TType>, TType>(this, predicate);
            _aspects.Add(aspect);
            return aspect;
        }

        public TType Build()
        {
            var generator = new ProxyGenerator();
            var proxy = generator.CreateClassProxy<TType>(new AspectsInterceptor<TType>(_aspects));
            return default(TType);
        }
    }
}

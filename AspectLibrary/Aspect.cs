using System;
using System.Linq.Expressions;

namespace AspectLibrary
{
    public interface IAspect<out TProxy, TType> 
        where TProxy : Proxy<TType>
        where TType : class
    {
        TProxy OnBefore(Action<IContext> interceptor);
        TProxy OnAfter(Action<IContext> interceptor);
        TProxy OnCatch(Action<IContext> interceptor);
        TProxy OnFinally(Action<IContext> interceptor);

    }

    public class Aspect<TProxy, TType> : IAspect<TProxy, TType>
        where TProxy : Proxy<TType>
        where TType : class
    {
        private readonly TProxy _proxy;

        private readonly Expression<Func<TType, object>> _predicate;

        internal Action<IContext> BeforeAction { get; private set; }

        internal Action<IContext> AfterAction { get; private set; }

        internal Action<IContext> OnCatchAction { get; private set; }

        internal Action<IContext> FinallyAction { get; private set; }


        public Aspect(TProxy proxy, Expression<Func<TType, object>> predicate)
        {
            _proxy = proxy;
            _predicate = predicate;
        }

        public TProxy OnBefore(Action<IContext> interceptor)
        {
            BeforeAction = interceptor;
            return _proxy;
        }

        public TProxy OnAfter(Action<IContext> interceptor)
        {
            AfterAction = interceptor;
            return _proxy;
        }

        public TProxy OnCatch(Action<IContext> interceptor)
        {
            OnCatchAction = interceptor;
            return _proxy;
        }

        public TProxy OnFinally(Action<IContext> interceptor)
        {
            FinallyAction = interceptor;
            return _proxy;
        }

        public void Invoke(IContext context, AspectTypes type)
        {


        }
    }
}
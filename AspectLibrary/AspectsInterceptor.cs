using System;
using System.Collections.Generic;
using Castle.DynamicProxy;

namespace AspectLibrary
{
    internal enum AspectTypes { Before, After, Finally, Exception, Invocation }
    internal class AspectsInterceptor<TType> : IInterceptor
        where TType : class
    {
        private readonly List<IAspect<Proxy<TType>, TType>> _aspects;

        public AspectsInterceptor(List<IAspect<Proxy<TType>, TType>> aspects)
        {
            _aspects = aspects;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                OnBefore(invocation);
                OnInvocation(invocation);
                OnAfter(invocation);
            }
            catch (Exception e)
            {
                OnException(invocation, e);
            }
            finally
            {
                OnFinally(invocation);
            }

        }

        protected virtual void OnFinally(IInvocation invocation)
        {

        }

        protected virtual void OnAfter(IInvocation invocation)
        {

        }

        protected virtual void OnInvocation(IInvocation invocation)
        {
            invocation.Proceed();
        }

        protected virtual void OnBefore(IInvocation invocation)
        {

        }

        protected virtual void OnException(IInvocation invocation, Exception exception)
        {

        }

        private void InvokeAspects(IContext context, AspectTypes type)
        {
            _aspects.ForEach(aspect => AspectInvoker<TType>.Invoke(context, type, aspect));
        }

        private static IContext InvocationToContext(IInvocation invocation)
        {
            return new Context
                       {
                           Arguments = invocation.Arguments,
                           ClassName = invocation.TargetType.FullName,
                           MethodName = invocation.Method.Name,
                           Result = invocation.ReturnValue
                       };
        }
    }

    internal class AspectInvoker<TType> where TType : class
    {
        public static void Invoke(IContext context, AspectTypes type, IAspect<Proxy<TType>, TType> aspect)
        {
            switch (type)
            {
                    case AspectTypes.After:
                    if(aspect.)
                    break;
            }
        }
    }
}
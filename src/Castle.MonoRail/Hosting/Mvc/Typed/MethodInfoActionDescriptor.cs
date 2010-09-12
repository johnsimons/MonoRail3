namespace Castle.MonoRail.Hosting.Mvc.Typed
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;
    using System.Reflection;

    public class MethodInfoActionDescriptor : ActionDescriptor
    {
        private readonly MethodInfo _method;

        public MethodInfoActionDescriptor(MethodInfo method)
        {
            Contract.Requires(method != null);
            Contract.EndContractBlock();

            _method = method;

            this.Name = _method.Name;
            this.Action = BuildInvocationFunc();
        }

        private Func<object, object [], object> BuildInvocationFunc()
        {
            // ((TController) c)._method( (TP0) p0, (TP1) p1, ..., (TPN) pN );

            var controllerType = _method.DeclaringType;
            var target = Expression.Parameter(typeof(object), "target");
            var args = Expression.Parameter(typeof(object[]), "args");
            var expParams = BuildCastExpressionForParameters(args);
            var call = Expression.Call(Expression.Convert(target, controllerType), _method, expParams);
            Expression lambdaBody = null;

            if (_method.ReturnType != typeof(void))
            {
                lambdaBody = Expression.Convert(call, typeof(object));
            }
            else
            {
                var nullReturn = Expression.Constant(null, typeof(object));
                lambdaBody = Expression.Block(call, nullReturn);
            }

            var lambda = Expression.Lambda<Func<object, object[], object>>(lambdaBody, target, args);
            return lambda.Compile();
        }

        private IEnumerable<Expression> BuildCastExpressionForParameters(ParameterExpression args)
        {
            var parameters = new List<Expression>();
            var index = 0;
            
            foreach(var parameter in _method.GetParameters())
            {
                var paramType = parameter.ParameterType;
                var argAccess = Expression.ArrayAccess(args, Expression.Constant(index++));
                var exp = Expression.Convert(argAccess, paramType);
                parameters.Add(exp);
            }

            return parameters;
        }
    }
}
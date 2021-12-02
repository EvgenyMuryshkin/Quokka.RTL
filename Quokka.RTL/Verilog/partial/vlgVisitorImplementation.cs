using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.Verilog
{
    public abstract class vlgVisitorImplementation<T> : vlgVisitorInterface<T>
        where T : class
    {
        private readonly vlgVisitorImplementationDeps _deps;
        protected IndentedStringBuilder _builder { get; private set; }
        protected vlgVisitorFactoryInterface _visitorFactory => _deps.VisitorFactory;
        protected vlgFormattersInterface _formatters => _deps.Formatters;

        public vlgVisitorImplementation(vlgVisitorImplementationDeps deps)
        {
            _deps = deps;
        }

        public void Visit(object obj)
        {
            Visit(obj, _builder);
        }

        public void Visit(object obj, IndentedStringBuilder builder)
        {
            if (obj is T typed) 
            {
                var oldBuilder = _builder;
                _builder = builder;
                OnVisit(typed);
                _builder = oldBuilder;
                return; 
            }
            else
            {
                var visitor = _visitorFactory.Resolve(obj);
                visitor.Visit(obj, builder ?? _builder);
            }
        }

        public abstract void OnVisit(T obj);

        protected string Raw(object obj)
        {
            var builder = new IndentedStringBuilder();
            var visitor = _visitorFactory.Resolve(obj);
            visitor.Visit(obj, builder);

            return builder.ToString();
        }

        protected string Brackets(object obj)
        {
            switch (obj)
            {
                case vlgIdentifierExpression e:
                    return Raw(obj);
                default:
                    return $"({Raw(obj)})";
            }
        }
    }
}

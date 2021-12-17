using Quokka.RTL.Tools;
using System;

namespace Quokka.RTL.VHDL
{
    public abstract class vhdVisitorImplementation<T> : vhdVisitorInterface<T>
        where T : class
    {
        private readonly vhdVisitorImplementationDeps _deps;
        protected IndentedStringBuilder _builder { get; private set; }
        protected vhdVisitorFactoryInterface _visitorFactory => _deps.VisitorFactory;
        protected vhdFormattersInterface _formatters => _deps.Formatters;

        public vhdVisitorImplementation(vhdVisitorImplementationDeps deps)
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
            return $"({Raw(obj)})";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quokka.RTL.SourceGenerators
{
    public class MetadataRTLBitArray
    {

    }
    public interface IMetadataInterface { }

    public interface IMetadataChildrenCollection<T> : IMetadataInterface
    {
        [NoCtorInit]
        List<T> Children { get; }
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class FluentTypeAttribute : Attribute
    {
        public Type Type; 
        public FluentTypeAttribute(Type type)
        {
            Type = type;;
        }
    }
}

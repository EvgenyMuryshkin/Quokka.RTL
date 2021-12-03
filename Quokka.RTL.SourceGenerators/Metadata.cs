using System;
using System.Collections.Generic;
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
}

using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection
{
}
public abstract partial class vhdAbstractObject
{
}
public partial class vhdArchitecture
{
}
public partial class vhdArchitectureDeclarations
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdDefaultSignal> AsDefaultSignal => Children.OfType<vhdDefaultSignal>();
	public IEnumerable<vhdLogicSignal> AsLogicSignal => Children.OfType<vhdLogicSignal>();
	public IEnumerable<vhdArrayTypeDeclaration> AsArrayTypeDeclaration => Children.OfType<vhdArrayTypeDeclaration>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdNet> AsNet => Children.OfType<vhdNet>();
	public IEnumerable<vhdTypeDeclaration> AsTypeDeclaration => Children.OfType<vhdTypeDeclaration>();
}
public partial class vhdArchitectureImplementation
{
}
public partial class vhdArchitectureImplementationBlock
{
}
public partial class vhdArrayTypeDeclaration
{
}
public partial class vhdAttribute
{
}
public abstract partial class vhdBlock
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
}
public partial class vhdComment
{
}
public partial class vhdCustomDataType
{
}
public partial class vhdCustomEntityPort
{
}
public partial class vhdCustomNetType
{
}
public abstract partial class vhdDataTypeSource
{
}
public partial class vhdDefaultDataType
{
}
public partial class vhdDefaultNetType
{
}
public partial class vhdDefaultSignal
{
}
public partial class vhdEntity
{
}
public partial class vhdEntityInterface
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdCustomEntityPort> AsCustomEntityPort => Children.OfType<vhdCustomEntityPort>();
	public IEnumerable<vhdStandardEntityPort> AsStandardEntityPort => Children.OfType<vhdStandardEntityPort>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
	public IEnumerable<vhdEntityPort> AsEntityPort => Children.OfType<vhdEntityPort>();
}
public abstract partial class vhdEntityPort
{
}
public partial class vhdFile
{
	public IEnumerable<vhdComment> AsComment => Children.OfType<vhdComment>();
	public IEnumerable<vhdText> AsText => Children.OfType<vhdText>();
	public IEnumerable<vhdLibraryReference> AsLibraryReference => Children.OfType<vhdLibraryReference>();
	public IEnumerable<vhdUse> AsUse => Children.OfType<vhdUse>();
	public IEnumerable<vhdEntity> AsEntity => Children.OfType<vhdEntity>();
	public IEnumerable<vhdArchitecture> AsArchitecture => Children.OfType<vhdArchitecture>();
	public IEnumerable<vhdAttribute> AsAttribute => Children.OfType<vhdAttribute>();
	public IEnumerable<vhdAbstractObject> AsAbstractObject => Children.OfType<vhdAbstractObject>();
}
public partial class vhdLibraryReference
{
}
public partial class vhdLogicSignal
{
}
public abstract partial class vhdNet
{
}
public abstract partial class vhdNetTypeSource
{
}
public partial class vhdStandardEntityPort
{
}
public partial class vhdText
{
}
public abstract partial class vhdTypeDeclaration
{
}
public partial class vhdUse
{
}
} // Quokka.RTL.VHDL

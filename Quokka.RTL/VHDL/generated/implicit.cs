using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection : vhdAbstractObject
{
}
public abstract partial class vhdAbstractObject
{
	public static implicit operator vhdAbstractObject(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
	public static implicit operator vhdAbstractObject(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdArchitecture : vhdAbstractObject
{
}
public partial class vhdArchitectureDeclarations : vhdAbstractCollection
{
}
public partial class vhdArchitectureImplementation : vhdAbstractObject
{
	public static implicit operator vhdArchitectureImplementation(vhdArchitectureImplementationBlock Block)
	{
		return new vhdArchitectureImplementation(Block);
	}
}
public partial class vhdArchitectureImplementationBlock : vhdBlock
{
}
public partial class vhdArrayTypeDeclaration : vhdTypeDeclaration
{
}
public partial class vhdAttribute : vhdAbstractObject
{
}
public abstract partial class vhdBlock : vhdAbstractCollection
{
}
public partial class vhdComment : vhdAbstractObject
{
}
public partial class vhdCustomDataType : vhdDataTypeSource
{
	public static implicit operator vhdCustomDataType(String DataType)
	{
		return new vhdCustomDataType(DataType);
	}
}
public partial class vhdCustomEntityPort : vhdEntityPort
{
}
public partial class vhdCustomNetType : vhdNetTypeSource
{
	public static implicit operator vhdCustomNetType(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
}
public abstract partial class vhdDataTypeSource : vhdAbstractObject
{
	public static implicit operator vhdDataTypeSource(String DataType)
	{
		return new vhdCustomDataType(DataType);
	}
	public static implicit operator vhdDataTypeSource(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultDataType : vhdDataTypeSource
{
	public static implicit operator vhdDefaultDataType(vhdDataType DataType)
	{
		return new vhdDefaultDataType(DataType);
	}
}
public partial class vhdDefaultNetType : vhdNetTypeSource
{
	public static implicit operator vhdDefaultNetType(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdDefaultSignal : vhdNet
{
}
public partial class vhdEntity : vhdAbstractObject
{
	public static implicit operator vhdEntity(String Name)
	{
		return new vhdEntity(Name);
	}
}
public partial class vhdEntityInterface : vhdAbstractCollection
{
}
public abstract partial class vhdEntityPort : vhdAbstractObject
{
}
public partial class vhdFile : vhdAbstractCollection
{
}
public partial class vhdLibraryReference : vhdAbstractObject
{
	public static implicit operator vhdLibraryReference(String Name)
	{
		return new vhdLibraryReference(Name);
	}
}
public partial class vhdLogicSignal : vhdNet
{
}
public abstract partial class vhdNet : vhdAbstractObject
{
}
public abstract partial class vhdNetTypeSource : vhdAbstractObject
{
	public static implicit operator vhdNetTypeSource(String NetType)
	{
		return new vhdCustomNetType(NetType);
	}
	public static implicit operator vhdNetTypeSource(vhdNetType NetType)
	{
		return new vhdDefaultNetType(NetType);
	}
}
public partial class vhdStandardEntityPort : vhdEntityPort
{
}
public partial class vhdText : vhdAbstractObject
{
}
public abstract partial class vhdTypeDeclaration : vhdAbstractObject
{
}
public partial class vhdUse : vhdAbstractObject
{
	public static implicit operator vhdUse(String Value)
	{
		return new vhdUse(Value);
	}
}
} // Quokka.RTL.VHDL

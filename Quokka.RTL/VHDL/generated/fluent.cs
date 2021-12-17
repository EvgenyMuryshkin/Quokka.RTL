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
	//vhdComment
	public vhdArchitectureDeclarations WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdArchitectureDeclarations WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdDefaultSignal
	public vhdArchitectureDeclarations WithDefaultSignal(vhdDefaultSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.Children.Add(new vhdDefaultSignal(NetType, Name, DataType, Width, Initializer));
		return this;
	}
	//vhdLogicSignal
	public vhdArchitectureDeclarations WithLogicSignal(vhdLogicSignal obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.Children.Add(new vhdLogicSignal(NetType, Name, Initializer));
		return this;
	}
	//vhdArrayTypeDeclaration
	public vhdArchitectureDeclarations WithArrayTypeDeclaration(vhdArrayTypeDeclaration obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdArchitectureDeclarations WithArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Children.Add(new vhdArrayTypeDeclaration(Name, Depth, Type, Width));
		return this;
	}
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
	//vhdComment
	public vhdBlock WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdBlock WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdBlock WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
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
	//vhdComment
	public vhdEntityInterface WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdEntityInterface WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdCustomEntityPort
	public vhdEntityInterface WithCustomEntityPort(vhdCustomEntityPort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithCustomEntityPort(String Name, vhdPortDirection Direction, String Declaration, String Initializer)
	{
		this.Children.Add(new vhdCustomEntityPort(Name, Direction, Declaration, Initializer));
		return this;
	}
	//vhdStandardEntityPort
	public vhdEntityInterface WithStandardEntityPort(vhdStandardEntityPort obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdEntityInterface WithStandardEntityPort(String Name, vhdPortDirection Direction, vhdDataType Sign, Int32 Width, String Initializer)
	{
		this.Children.Add(new vhdStandardEntityPort(Name, Direction, Sign, Width, Initializer));
		return this;
	}
}
public abstract partial class vhdEntityPort
{
}
public partial class vhdFile
{
	//vhdComment
	public vhdFile WithComment(vhdComment obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithComment(params String[] Lines)
	{
		this.Children.Add(new vhdComment(Lines));
		return this;
	}
	//vhdText
	public vhdFile WithText(vhdText obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithText(params String[] Lines)
	{
		this.Children.Add(new vhdText(Lines));
		return this;
	}
	//vhdLibraryReference
	public vhdFile WithLibraryReference(vhdLibraryReference obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithLibraryReference(String Name)
	{
		this.Children.Add(new vhdLibraryReference(Name));
		return this;
	}
	//vhdUse
	public vhdFile WithUse(vhdUse obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithUse(String Value)
	{
		this.Children.Add(new vhdUse(Value));
		return this;
	}
	//vhdEntity
	public vhdFile WithEntity(vhdEntity obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithEntity(String Name)
	{
		this.Children.Add(new vhdEntity(Name));
		return this;
	}
	//vhdArchitecture
	public vhdFile WithArchitecture(vhdArchitecture obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithArchitecture(String Type, String Entity)
	{
		this.Children.Add(new vhdArchitecture(Type, Entity));
		return this;
	}
	//vhdAttribute
	public vhdFile WithAttribute(vhdAttribute obj)
	{
		if (obj != null) Children.Add(obj);
		return this;
	}
	public vhdFile WithAttribute(String Name, String Target, String Value)
	{
		this.Children.Add(new vhdAttribute(Name, Target, Value));
		return this;
	}
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

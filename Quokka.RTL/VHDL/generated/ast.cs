using System;
using System.Collections.Generic;
using System.Linq;
namespace Quokka.RTL.VHDL
{
using Quokka.RTL.Tools;
public abstract partial class vhdAbstractCollection : vhdAbstractObject
{
	public vhdAbstractCollection() { }
	/// <summary>
	/// vhdArchitecture
	/// vhdArchitectureDeclarations
	/// vhdArchitectureImplementation
	/// vhdArchitectureImplementationBlock
	/// vhdArrayTypeDeclaration
	/// vhdAttribute
	/// vhdComment
	/// vhdCustomDataType
	/// vhdCustomEntityPort
	/// vhdCustomNetType
	/// vhdDefaultDataType
	/// vhdDefaultNetType
	/// vhdDefaultSignal
	/// vhdEntity
	/// vhdEntityInterface
	/// vhdFile
	/// vhdLibraryReference
	/// vhdLogicSignal
	/// vhdStandardEntityPort
	/// vhdText
	/// vhdUse
	/// </summary>
	public List<vhdAbstractObject> Children { get; set; } = new List<vhdAbstractObject>();
}
public abstract partial class vhdAbstractObject
{
	public vhdAbstractObject() { }
}
public partial class vhdArchitecture : vhdAbstractObject
{
	public vhdArchitecture() { }
	public vhdArchitecture(String Type, String Entity)
	{
		this.Type = Type;
		this.Entity = Entity;
	}
	public String Type { get; set; }
	public String Entity { get; set; }
	public vhdArchitectureDeclarations Declarations { get; set; } = new vhdArchitectureDeclarations();
	public vhdArchitectureImplementation Implementation { get; set; } = new vhdArchitectureImplementation();
}
public partial class vhdArchitectureDeclarations : vhdAbstractCollection
{
	public vhdArchitectureDeclarations() { }
}
public partial class vhdArchitectureImplementation : vhdAbstractObject
{
	public vhdArchitectureImplementation() { }
	public vhdArchitectureImplementation(vhdArchitectureImplementationBlock Block)
	{
		this.Block = Block;
	}
	public vhdArchitectureImplementationBlock Block { get; set; } = new vhdArchitectureImplementationBlock();
}
public partial class vhdArchitectureImplementationBlock : vhdBlock
{
	public vhdArchitectureImplementationBlock() { }
}
public partial class vhdArrayTypeDeclaration : vhdTypeDeclaration
{
	public vhdArrayTypeDeclaration() { }
	public vhdArrayTypeDeclaration(String Name, Int32 Depth, vhdDataType Type, Int32 Width)
	{
		this.Name = Name;
		this.Depth = Depth;
		this.Type = Type;
		this.Width = Width;
	}
	public Int32 Depth { get; set; }
	public vhdDataType Type { get; set; }
	public Int32 Width { get; set; }
}
public partial class vhdAttribute : vhdAbstractObject
{
	public vhdAttribute() { }
	public vhdAttribute(String Name, String Target, String Value)
	{
		this.Name = Name;
		this.Target = Target;
		this.Value = Value;
	}
	public String Name { get; set; }
	public String Target { get; set; }
	public String Value { get; set; }
}
public abstract partial class vhdBlock : vhdAbstractCollection
{
	public vhdBlock() { }
}
public partial class vhdComment : vhdAbstractObject
{
	public vhdComment() { }
	public vhdComment(params String[] Lines)
	{
		this.Lines = (Lines ?? Array.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public partial class vhdCustomDataType : vhdDataTypeSource
{
	public vhdCustomDataType() { }
	public vhdCustomDataType(String DataType)
	{
		this.DataType = DataType;
	}
	public String DataType { get; set; }
}
public partial class vhdCustomEntityPort : vhdEntityPort
{
	public vhdCustomEntityPort() { }
	public vhdCustomEntityPort(String Name, vhdPortDirection Direction, String Declaration, String Initializer)
	{
		this.Name = Name;
		this.Direction = Direction;
		this.Declaration = Declaration;
		this.Initializer = Initializer;
	}
	public String Declaration { get; set; }
	public String Initializer { get; set; }
}
public partial class vhdCustomNetType : vhdNetTypeSource
{
	public vhdCustomNetType() { }
	public vhdCustomNetType(String NetType)
	{
		this.NetType = NetType;
	}
	public String NetType { get; set; }
}
public abstract partial class vhdDataTypeSource : vhdAbstractObject
{
	public vhdDataTypeSource() { }
}
public partial class vhdDefaultDataType : vhdDataTypeSource
{
	public vhdDefaultDataType() { }
	public vhdDefaultDataType(vhdDataType DataType)
	{
		this.DataType = DataType;
	}
	public vhdDataType DataType { get; set; }
}
public partial class vhdDefaultNetType : vhdNetTypeSource
{
	public vhdDefaultNetType() { }
	public vhdDefaultNetType(vhdNetType NetType)
	{
		this.NetType = NetType;
	}
	public vhdNetType NetType { get; set; }
}
public partial class vhdDefaultSignal : vhdNet
{
	public vhdDefaultSignal() { }
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width, params String[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
		this.Initializer = (Initializer ?? Array.Empty<String>()).Where(s => s != null).ToList();
	}
	public vhdDefaultSignal(vhdNetTypeSource NetType, String Name, vhdDataTypeSource DataType, Int32 Width)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.DataType = DataType;
		this.Width = Width;
	}
	public vhdDataTypeSource DataType { get; set; }
	public Int32 Width { get; set; }
	public List<String> Initializer { get; set; } = new List<String>();
}
public partial class vhdEntity : vhdAbstractObject
{
	public vhdEntity() { }
	public vhdEntity(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
	public vhdEntityInterface Interface { get; set; } = new vhdEntityInterface();
}
public partial class vhdEntityInterface : vhdAbstractCollection
{
	public vhdEntityInterface() { }
}
public abstract partial class vhdEntityPort : vhdAbstractObject
{
	public vhdEntityPort() { }
	public vhdEntityPort(String Name, vhdPortDirection Direction)
	{
		this.Name = Name;
		this.Direction = Direction;
	}
	public String Name { get; set; }
	public vhdPortDirection Direction { get; set; }
}
public partial class vhdFile : vhdAbstractCollection
{
	public vhdFile() { }
}
public partial class vhdLibraryReference : vhdAbstractObject
{
	public vhdLibraryReference() { }
	public vhdLibraryReference(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vhdLogicSignal : vhdNet
{
	public vhdLogicSignal() { }
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name, params RTLBitArray[] Initializer)
	{
		this.NetType = NetType;
		this.Name = Name;
		this.Initializer = (Initializer ?? Array.Empty<RTLBitArray>()).Where(s => s != null).ToList();
	}
	public vhdLogicSignal(vhdNetTypeSource NetType, String Name)
	{
		this.NetType = NetType;
		this.Name = Name;
	}
	public List<RTLBitArray> Initializer { get; set; } = new List<RTLBitArray>();
}
public abstract partial class vhdNet : vhdAbstractObject
{
	public vhdNet() { }
	public vhdNet(vhdNetTypeSource NetType, String Name)
	{
		this.NetType = NetType;
		this.Name = Name;
	}
	public vhdNetTypeSource NetType { get; set; }
	public String Name { get; set; }
}
public abstract partial class vhdNetTypeSource : vhdAbstractObject
{
	public vhdNetTypeSource() { }
}
public partial class vhdStandardEntityPort : vhdEntityPort
{
	public vhdStandardEntityPort() { }
	public vhdStandardEntityPort(String Name, vhdPortDirection Direction, vhdDataType Sign, Int32 Width, String Initializer)
	{
		this.Name = Name;
		this.Direction = Direction;
		this.Sign = Sign;
		this.Width = Width;
		this.Initializer = Initializer;
	}
	public vhdDataType Sign { get; set; }
	public Int32 Width { get; set; }
	public String Initializer { get; set; }
}
public partial class vhdText : vhdAbstractObject
{
	public vhdText() { }
	public vhdText(params String[] Lines)
	{
		this.Lines = (Lines ?? Array.Empty<String>()).Where(s => s != null).ToList();
	}
	public List<String> Lines { get; set; } = new List<String>();
}
public abstract partial class vhdTypeDeclaration : vhdAbstractObject
{
	public vhdTypeDeclaration() { }
	public vhdTypeDeclaration(String Name)
	{
		this.Name = Name;
	}
	public String Name { get; set; }
}
public partial class vhdUse : vhdAbstractObject
{
	public vhdUse() { }
	public vhdUse(String Value)
	{
		this.Value = Value;
	}
	public String Value { get; set; }
}
} // Quokka.RTL.VHDL

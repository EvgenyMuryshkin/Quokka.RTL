using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quokka.RTL;
using Quokka.RTL.MemoryTemplates.Generic;
using Quokka.RTL.Verilog;
using Quokka.RTL.VHDL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.VCD.Tests
{
	public partial class vlgCase1
	{
		public vlgCase1 Clone() => UntypedClone() as vlgCase1;
		public override vlgAbstractObject UntypedClone()
		{
			var result = new vlgCase1();
			result.Check = Check?.UntypedClone() as vlgExpression;
			result.Statements = Statements.Select(i => i.UntypedClone() as vlgCaseStatement).ToList();
			result.Default = Default?.UntypedClone() as vlgCaseDefault;
			return result;
		}
	}
	public partial class vlgCase1 : vlgAbstractObject
	{
		/// <summary>
		/// from vlgCase
		/// </summary>
		public static implicit operator vlgCase1(vlgAggregateExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgExpression source)
		{
			return new vlgCase1(new vlgAggregateExpression(new[] { source }));
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgAssignExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgBinaryValueExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(RTLBitArray Value)
		{
			return new vlgCase1(new vlgBinaryValueExpression(Value));
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgCompareExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgIdentifierExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(String Name)
		{
			return new vlgCase1(new vlgIdentifierExpression(new vlgIdentifier(Name)));
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgIdentifier Source)
		{
			return new vlgCase1(new vlgIdentifierExpression(Source));
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgLogicExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgMathExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgShiftExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgSizedAggregateExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(Int32 Size)
		{
			return new vlgCase1(new vlgSizedAggregateExpression(Size));
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgTernaryExpression source)
		{
			return new vlgCase1(source);
		}
		/// <summary>
		/// from vlgCase1
		/// </summary>
		public static implicit operator vlgCase1(vlgUnaryExpression source)
		{
			return new vlgCase1(source);
		}
	}

	public partial class vlgCase1 : vlgAbstractObject, vlgGenericBlockChild, vlgModuleImplementationBlockChild//, IEnumerable<vlgCaseStatement>
	{
		public vlgCase1() { }
		/*
		// vlgCaseStatement single list member
		IEnumerator IEnumerable.GetEnumerator() => (Statements as IEnumerable).GetEnumerator();
		IEnumerator<vlgCaseStatement> IEnumerable<vlgCaseStatement>.GetEnumerator() => Statements.OfType<vlgCaseStatement>().GetEnumerator();
		public void Add(vlgCaseStatement child)
		{
			Statements.Add(child);
		}
		*/
		public vlgCase1(vlgExpression Check, IEnumerable<vlgCaseStatement> Statements)
		{
			this.Check = Check;
			this.Statements = (Statements ?? Enumerable.Empty<vlgCaseStatement>()).Where(s => s != null).ToList();
		}
		public vlgCase1(vlgExpression Check, params vlgCaseStatement[] Statements)
		{
			this.Check = Check;
			this.Statements = (Statements ?? Enumerable.Empty<vlgCaseStatement>()).Where(s => s != null).ToList();
		}
		public vlgCase1(vlgExpression Check)
		{
			this.Check = Check;
		}

		/// <summary>
		/// from vlgAggregateExpression
		/// </summary>
		/// <param name="Expressions"></param>
		public vlgCase1(IEnumerable<vlgExpression> Expressions)
		{
			this.Check = new vlgAggregateExpression(Expressions);
		}
		/// <summary>
		/// from vlgAssignExpression
		/// </summary>
		/// <param name="Target"></param>
		/// <param name="Type"></param>
		/// <param name="Expression"></param>
		public vlgCase1(vlgIdentifier Target, vlgAssignType Type, vlgExpression Expression)
		{
			this.Check = new vlgAssignExpression(Target, Type, Expression);
		}
		/// <summary>
		/// from vlgBinaryValueExpression
		/// </summary>
		/// <param name="Value"></param>
		public vlgCase1(RTLBitArray Value)
		{
			this.Check = new vlgBinaryValueExpression(Value);
		}
		/// <summary>
		/// from vlgCompareExpression
		/// </summary>
		/// <param name="Lhs"></param>
		/// <param name="Type"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgExpression Lhs, vlgCompareType Type, vlgExpression Rhs)
		{
			this.Check = new vlgCompareExpression(Lhs, Type, Rhs);
		}
		/// <summary>
		/// from vlgIdentifierExpression
		/// </summary>
		/// <param name="Source"></param>
		public vlgCase1(vlgIdentifier Source)
		{
			this.Check = new vlgIdentifierExpression(Source);
		}
		/// <summary>
		/// from vlgLogicExpression
		/// </summary>
		/// <param name="Lhs"></param>
		/// <param name="Type"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgExpression Lhs, vlgLogicType Type, vlgExpression Rhs)
		{
			this.Check = new vlgLogicExpression(Lhs, Type, Rhs);
		}
		/// <summary>
		/// from vlgMathExpression
		/// </summary>
		/// <param name="Lhs"></param>
		/// <param name="Type"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgExpression Lhs, vlgMathType Type, vlgExpression Rhs)
		{
			this.Check = new vlgMathExpression(Lhs, Type, Rhs);
		}
		/// <summary>
		/// from vlgShiftExpression
		/// </summary>
		/// <param name="Lhs"></param>
		/// <param name="Type"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgExpression Lhs, vlgShiftType Type, vlgExpression Rhs)
		{
			this.Check = new vlgShiftExpression(Lhs, Type, Rhs);
		}
		/// <summary>
		/// from vlgSizedAggregateExpression
		/// </summary>
		/// <param name="Size"></param>
		/// <param name="Expressions"></param>
		public vlgCase1(Int32 Size, IEnumerable<vlgExpression> Expressions)
		{
			this.Check = new vlgSizedAggregateExpression(Size, Expressions);
		}
		/// <summary>
		/// from vlgSizedAggregateExpression
		/// </summary>
		/// <param name="Size"></param>
		public vlgCase1(Int32 Size)
		{
			this.Check = new vlgSizedAggregateExpression(Size);
		}
		/// <summary>
		/// from vlgTernaryExpression
		/// </summary>
		/// <param name="Condition"></param>
		/// <param name="Lhs"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgExpression Condition, vlgExpression Lhs, vlgExpression Rhs)
		{
			this.Check = new vlgTernaryExpression(Condition, Lhs, Rhs);
		}
		/// <summary>
		/// from vlgUnaryExpression
		/// </summary>
		/// <param name="Type"></param>
		/// <param name="Rhs"></param>
		public vlgCase1(vlgUnaryType Type, vlgExpression Rhs)
		{
			this.Check = new vlgUnaryExpression(Type, Rhs);
		}
		public vlgExpression Check { get; set; }
		public List<vlgCaseStatement> Statements { get; set; } = new List<vlgCaseStatement>();
		public vlgCaseDefault Default { get; set; } = new vlgCaseDefault();
	}


	class CtorAmbiguity : IEnumerable<CtorAmbiguity>
    {
        public string Value { get; set; }
        public List<CtorAmbiguity> Idx = new List<CtorAmbiguity>();

        public CtorAmbiguity(string value, IEnumerable<CtorAmbiguity> idx)
        {
            Value = value;
            Idx.AddRange(idx);
        }

        public CtorAmbiguity(string value, params CtorAmbiguity[] idx)
        {
            Value = value;
            Idx.AddRange(idx);
        }

        public IEnumerator<CtorAmbiguity> GetEnumerator()
        {
            return Idx.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Idx.GetEnumerator();
        }

        public void Add(CtorAmbiguity idx)
        {
            Idx.Add(idx);
        }
    }

    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void CtorTest()
        {
            var s = new CtorAmbiguity("test");
        }

        [TestMethod]
        public void vhdAggregateCtor()
        {
            var generator = new GenericRAMTemplates();
            var block = generator.SDP_RF("clock", "we", "mem", "w_addr", "w_data", "r_addr", "r_daa");
            var hdl = vhdVHDLWriter.WriteObject(block);
        }
    }
}

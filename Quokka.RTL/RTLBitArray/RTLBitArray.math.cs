using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Quokka.RTL
{
    public partial class RTLBitArray
    {
        internal void Add(RTLBitArray value)
        {
            var size = Math.Max(Size, value.Size) + 1;
            internalResize(size);

            if (DataType != value.DataType)
            {
                internalToSigned();
            }

            internalAdd(value);
        }

        internal void Subtract(RTLBitArray value)
        {
            if (DataType != RTLBitArrayType.Signed)
            {
                internalToSigned();
            }

            var copy = new RTLBitArray(value);
            if (copy.DataType != RTLBitArrayType.Signed)
            {
                copy.internalToSigned();
            }

            internalResize(Math.Max(Size, copy.Size) + 1);

            copy.internalResize(Math.Max(Size, copy.Size) + 1);
            copy.internal2SComplement();

            internalAdd(copy);
        }

        internal void Multiply(RTLBitArray value)
        {
            var thisOp = new RTLBitArray(this);
            var valueOp = new RTLBitArray(value);

            var isResultNegative = false;
            if (thisOp.DataType == RTLBitArrayType.Signed && thisOp[thisOp.Size - 1] == true)
            {
                isResultNegative = !isResultNegative;
                thisOp.internal2SComplement();
                thisOp.internalChangeType(RTLBitArrayType.Unsigned);
            }

            if (valueOp.DataType == RTLBitArrayType.Signed && valueOp[valueOp.Size - 1] == true)
            {
                isResultNegative = !isResultNegative;
                valueOp.internal2SComplement();
                valueOp.internalChangeType(RTLBitArrayType.Unsigned);
            }

            var result = new RTLBitArray();

            for (int idx = 0; idx < value.Size; idx++)
            {
                if (valueOp[idx])
                {
                    var part = new RTLBitArray(thisOp);

                    part = part << idx;

                    result += part;
                }
            }

            if (isResultNegative)
            {
                result.internalToSigned();
                result.internal2SComplement();
            }

            _data = result._data;
            DataType = result.DataType;
        }
    }
}

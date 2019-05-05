﻿using System;
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

            if (_dataType != value._dataType)
            {
                internalToSigned();
            }

            internalAdd(value);
        }

        internal void Subtract(RTLBitArray value)
        {
            if (_dataType != RTLBitArrayType.Signed)
            {
                internalToSigned();
            }

            var copy = new RTLBitArray(value);
            if (copy._dataType != RTLBitArrayType.Signed)
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
            if (thisOp._dataType == RTLBitArrayType.Signed && thisOp[thisOp.Size - 1] == true)
            {
                isResultNegative = !isResultNegative;
                thisOp.internal2SComplement();
                thisOp.internalChangeType(RTLBitArrayType.Unsigned);
            }

            if (valueOp._dataType == RTLBitArrayType.Signed && valueOp[valueOp.Size - 1] == true)
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
            _dataType = result._dataType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public abstract class PHPPrimitive : PHPValue, IConvertible {
        #region Implicit operators

        public static implicit operator bool(PHPPrimitive value) {
                return ((IConvertible)value).ToBoolean(null);
        }
        public static implicit operator byte(PHPPrimitive value) {
                return ((IConvertible)value).ToByte(null);
        }
        public static implicit operator char(PHPPrimitive value) {
                return ((IConvertible)value).ToChar(null);
        }
        public static implicit operator decimal(PHPPrimitive value) {
                return ((IConvertible)value).ToDecimal(null);
        }
        public static implicit operator double(PHPPrimitive value) {
                return ((IConvertible)value).ToDouble(null);
        }
        public static implicit operator short(PHPPrimitive value) {
                return ((IConvertible)value).ToInt16(null);
        }
        public static implicit operator int(PHPPrimitive value) {
                return ((IConvertible)value).ToInt32(null);
        }
        public static implicit operator long(PHPPrimitive value) {
                return ((IConvertible)value).ToInt64(null);
        }
        public static implicit operator sbyte(PHPPrimitive value) {
                return ((IConvertible)value).ToSByte(null);
        }
        public static implicit operator float(PHPPrimitive value) {
                return ((IConvertible)value).ToSingle(null);
        }
        public static implicit operator string(PHPPrimitive value) {
                return ((IConvertible)value).ToString(null);
        }
        public static implicit operator ushort(PHPPrimitive value) {
                return ((IConvertible)value).ToUInt16(null);
        }
        public static implicit operator uint(PHPPrimitive value) {
                return value.ToUInt32(null);
        }
        public static implicit operator ulong(PHPPrimitive value) {
                return ((IConvertible)value).ToUInt64(null);
        }

        #endregion
        #region IConvertible

        TypeCode IConvertible.GetTypeCode() {
            return this.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            return this.ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            return this.ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            return this.ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider) {
            return this.ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            return this.ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            return this.ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            return this.ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            return this.ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            return this.ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            return this.ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider) {
            return this.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
            throw new NotSupportedException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            return this.ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider) {
            return this.ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            return this.ToUInt64(provider);
        }

        protected abstract TypeCode GetTypeCode();
        protected abstract bool ToBoolean(IFormatProvider provider);
        protected abstract byte ToByte(IFormatProvider provider); 
        protected abstract char ToChar(IFormatProvider provider); 
        protected abstract decimal ToDecimal(IFormatProvider provider);
        protected abstract double ToDouble(IFormatProvider provider); 
        protected abstract short ToInt16(IFormatProvider provider); 
        protected abstract int ToInt32(IFormatProvider provider); 
        protected abstract long ToInt64(IFormatProvider provider); 
        protected abstract sbyte ToSByte(IFormatProvider provider); 
        protected abstract float ToSingle(IFormatProvider provider); 
        protected abstract string ToString(IFormatProvider provider); 
        protected abstract ushort ToUInt16(IFormatProvider provider); 
        protected abstract uint ToUInt32(IFormatProvider provider); 
        protected abstract ulong ToUInt64(IFormatProvider provider);

        #endregion
    }
}

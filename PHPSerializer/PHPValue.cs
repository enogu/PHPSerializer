using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PHP {
    public abstract class PHPValue : IConvertible, IEquatable<PHPValue> {
        public static PHPValue Unserialize(Stream stream, Encoding encoding) {
            var reader = new Internals.Deserializer(stream, encoding);
            return reader.Parse();
        }

        public abstract void Serialize(StringBuilder builder, Encoding encoding);

        #region Predicates

        public virtual bool IsNumeric() {
            return false;
        }

        #endregion

        #region Implicit operators

        public static implicit operator bool(PHPValue value) {
            return value.ToBoolean(null);
        }
        public static implicit operator byte(PHPValue value) {
            return value.ToByte(null);
        }
        public static implicit operator char(PHPValue value) {
            return value.ToChar(null);
        }
        public static implicit operator decimal(PHPValue value) {
            return value.ToDecimal(null);
        }
        public static implicit operator double(PHPValue value) {
            return value.ToDouble(null);
        }
        public static implicit operator short(PHPValue value) {
            return value.ToInt16(null);
        }
        public static implicit operator int(PHPValue value) {
            return value.ToInt32(null);
        }
        public static implicit operator long(PHPValue value) {
            return value.ToInt64(null);
        }
        public static implicit operator sbyte(PHPValue value) {
            return value.ToSByte(null);
        }
        public static implicit operator float(PHPValue value) {
            return value.ToSingle(null);
        }
        public static implicit operator string(PHPValue value) {
            return value.ToString(null);
        }
        public static implicit operator ushort(PHPValue value) {
            return value.ToUInt16(null);
        }
        public static implicit operator uint(PHPValue value) {
            return value.ToUInt32(null);
        }
        public static implicit operator ulong(PHPValue value) {
            return value.ToUInt64(null);
        }

        public static implicit operator PHPValue(bool value) {
            return new Internals.Boolean(value);
        }
        public static implicit operator PHPValue(byte value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(char value) {
            return new Internals.String(value);
        }
        public static implicit operator PHPValue(decimal value) {
            return new Internals.String(value.ToString());
        }
        public static implicit operator PHPValue(double value) {
            return new Internals.Double(value);
        }
        public static implicit operator PHPValue(short value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(int value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(long value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(sbyte value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(float value) {
            return new Internals.Double(value);
        }
        public static implicit operator PHPValue(string value) {
            return new Internals.String(value);
        }
        public static implicit operator PHPValue(ushort value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(uint value) {
            return new Internals.Integer(value);
        }
        public static implicit operator PHPValue(ulong value) {
            return new Internals.Integer((long)value);
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
        #region Comparer

        public virtual bool Equals(PHPValue other) {
            return other != null && base.Equals(other);
        }

        public override sealed bool Equals(object obj) {
            return obj is PHPValue && this.Equals((PHPValue)obj);
        }

        public static bool operator ==(PHPValue value1, PHPValue value2) {
            if (Object.Equals(value1, null)) {
                return Object.Equals(value2, null);
            }
            return value1.Equals(value2);
        }

        public static bool operator !=(PHPValue value1, PHPValue value2) {
            if (Object.Equals(value1, null)) {
                return Object.Equals(value2, null);
            }
            return !value1.Equals(value2);
        }

        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PHP.Internals {
    class Double : PHPPrimitive {
        private readonly double value;

        public Double(float value) {
            this.value = value;
        }
        public Double(double value) {
            this.value = value;
        }

        public override bool IsNumeric() {
            return true;
        }

        public override void Serialize(StringBuilder builder, Encoding encoding) {
            builder.AppendFormat("d:{0}", this.value);
        }

        protected override TypeCode GetTypeCode() {
            return TypeCode.Double;
        }

        protected override bool ToBoolean(IFormatProvider provider) {
            return !double.IsNaN(this.value) && this.value != 0;
        }

        protected override byte ToByte(IFormatProvider provider) {
            return (byte)this.value;
        }

        protected override char ToChar(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override decimal ToDecimal(IFormatProvider provider) {
            return new decimal(this.value);
        }

        protected override double ToDouble(IFormatProvider provider) {
            return this.value;
        }

        protected override short ToInt16(IFormatProvider provider) {
            return (short)this.value;
        }

        protected override int ToInt32(IFormatProvider provider) {
            return (int)this.value;
        }

        protected override long ToInt64(IFormatProvider provider) {
            return (long)this.value;
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            return (sbyte)this.value;
        }

        protected override float ToSingle(IFormatProvider provider) {
            return (float)this.value;
        }

        protected override string ToString(IFormatProvider provider) {
            return this.value.ToString(provider);
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            return (ushort)this.value;
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            return (uint)this.value;
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            return (ulong)this.value;
        }

        public override int GetHashCode() {
            return this.value.GetHashCode();
        }

        public override bool Equals(PHPValue other) {
            if (!Object.Equals(other, null)) {
                if (other is Internals.Double) {
                    return ((Internals.Double)other).value == this.value;
                }
                return this.value == (double)other;
            }
            return false;
        }
    }
}

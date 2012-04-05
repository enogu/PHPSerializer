using System;
using System.Collections.Generic;
using System.Text;

namespace PHP.Internals {
    class Boolean : PHPPrimitive {
        private readonly bool value;

        public Boolean(bool value) {
            this.value = value;
        }

        public override bool IsNumeric() {
            return true;
        }

        public override void Serialize(StringBuilder builder, Encoding encoding) {
            builder.Append(this.value ? "b:1" : "b:0");
        }

        protected override TypeCode GetTypeCode() {
            return TypeCode.Boolean;
        }

        protected override bool ToBoolean(IFormatProvider provider) {
            return this.value;
        }

        protected override byte ToByte(IFormatProvider provider) {
            return (byte)this.ToInt32(provider);
        }

        protected override char ToChar(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override decimal ToDecimal(IFormatProvider provider) {
            return this.value ? 1m : 0m;
        }

        protected override double ToDouble(IFormatProvider provider) {
            return this.ToInt32(provider);
        }

        protected override short ToInt16(IFormatProvider provider) {
            return (short)this.ToInt32(provider);
        }

        protected override int ToInt32(IFormatProvider provider) {
            return this.value ? 1 : 0;
        }

        protected override long ToInt64(IFormatProvider provider) {
            return this.ToInt32(provider);
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            return (sbyte)this.ToInt32(provider);
        }

        protected override float ToSingle(IFormatProvider provider) {
            return this.ToInt32(provider);
        }

        protected override string ToString(IFormatProvider provider) {
            return this.value.ToString().ToLower();
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            return (ushort)this.ToInt32(provider);
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            return (uint)this.ToInt32(provider);
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            return (ulong)this.ToInt32(provider);
        }

        public override string ToString() {
            return this.value.ToString();
        }

        public override int GetHashCode() {
            return this.value.GetHashCode();
        }

        public override bool Equals(PHPValue other) {
            if (!Object.Equals(other, null)) {
                if (other is Internals.Boolean) {
                    return ((Internals.Boolean)other).value == this.value;
                }
                return this.value == (bool)other;
            }
            return false;
        }
    }
}

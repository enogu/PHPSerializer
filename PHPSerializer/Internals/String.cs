using System;
using System.Collections.Generic;
using System.Text;

namespace PHP.Internals {
    class String : PHPPrimitive {
        private readonly string value;

        public String(char value) {
            this.value = value.ToString();
        }
        public String(string value) {
            this.value = value;
        }

        public override void Serialize(StringBuilder builder, Encoding encoding) {
            builder.AppendFormat("s:{0}:\"{1}\"", encoding.GetByteCount(this.value), this.value);
        }

        protected override TypeCode GetTypeCode() {
            return TypeCode.String;
        }

        protected override bool ToBoolean(IFormatProvider provider) {
            bool value;
            if (bool.TryParse(this.value, out value)) {
                return value;
            }
            return !string.IsNullOrEmpty(this.value);
        }

        protected override byte ToByte(IFormatProvider provider) {
            return byte.Parse(this.value);
        }

        protected override char ToChar(IFormatProvider provider) {
            if (this.value.Length == 1) {
                return value[0];
            }
            throw new FormatException();
        }

        protected override decimal ToDecimal(IFormatProvider provider) {
            return decimal.Parse(this.value);
        }

        protected override double ToDouble(IFormatProvider provider) {
            return double.Parse(this.value);
        }

        protected override short ToInt16(IFormatProvider provider) {
            return short.Parse(this.value);
        }

        protected override int ToInt32(IFormatProvider provider) {
            return int.Parse(this.value);
        }

        protected override long ToInt64(IFormatProvider provider) {
            return long.Parse(this.value);
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            return sbyte.Parse(this.value);
        }

        protected override float ToSingle(IFormatProvider provider) {
            return float.Parse(this.value);
        }

        protected override string ToString(IFormatProvider provider) {
            return this.value;
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            return ushort.Parse(this.value);
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            return uint.Parse(this.value);
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            return ulong.Parse(this.value);
        }
    }
}

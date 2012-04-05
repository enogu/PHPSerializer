using System;
using System.Collections.Generic;
using System.Text;

namespace PHP.Internals {
    class String : PHPPrimitive {
        private readonly string value;
        private double? numberCache = null;
        private double NumberCache {
            get {
                if (!this.numberCache.HasValue) {
                    ParseNumber();
                }
                return this.numberCache.Value;
            }
        }
        private bool? isNumeric = null;

        public String(char value) {
            this.value = value.ToString();
        }
        public String(string value) {
            this.value = value;
        }

        public override bool IsNumeric() {
            if (!isNumeric.HasValue) {
                ParseNumber();
            }
            return isNumeric.Value;
        }

        private void ParseNumber() {
            double cache;
            if (double.TryParse(this.value, out cache)) {
                isNumeric = true;
                numberCache = cache;
            }
            else {
                isNumeric = false;
                numberCache = double.NaN;
            }
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
            return (byte)NumberCache;
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
            return NumberCache;
        }

        protected override short ToInt16(IFormatProvider provider) {
            return (short)NumberCache;
        }

        protected override int ToInt32(IFormatProvider provider) {
            return (int)NumberCache;
        }

        protected override long ToInt64(IFormatProvider provider) {
            return (long)NumberCache;
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            return (sbyte)NumberCache;
        }

        protected override float ToSingle(IFormatProvider provider) {
            return (float)NumberCache;
        }

        protected override string ToString(IFormatProvider provider) {
            return this.value;
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            return (ushort)NumberCache;
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            return (uint)NumberCache;
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            return (ulong)NumberCache;
        }

        public override int GetHashCode() {
            return this.value.GetHashCode();
        }

        public override bool Equals(PHPValue other) {
            if (!Object.Equals(other, null)) {
                if (other is Internals.String) {
                    return ((Internals.String)other).value == this.value;
                }
                return this.value == (string)other;
            }
            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PHP.Internals {
    class Double : PHPPrimitive {
        public Double(float value) {
        }
        public Double(double value) {
        }

        protected override TypeCode GetTypeCode() {
            throw new NotImplementedException();
        }

        protected override bool ToBoolean(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override byte ToByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override char ToChar(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override decimal ToDecimal(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override double ToDouble(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override short ToInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override int ToInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override long ToInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override float ToSingle(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override string ToString(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            throw new NotImplementedException();
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            throw new NotImplementedException();
        }
    }
}

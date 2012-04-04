using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public class PHPArray : PHPValue, IDictionary<PHPValue, PHPValue> {
        public override void Serialize(StringBuilder builder, Encoding encoding) {
            throw new NotImplementedException();
        }

        #region IDictionary<PHPValue, PHPValue>

        public void Add(PHPValue key, PHPValue value) {
            throw new NotImplementedException();
        }

        public bool ContainsKey(PHPValue key) {
            throw new NotImplementedException();
        }

        public ICollection<PHPValue> Keys {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(PHPValue key) {
            throw new NotImplementedException();
        }

        public bool TryGetValue(PHPValue key, out PHPValue value) {
            throw new NotImplementedException();
        }

        public ICollection<PHPValue> Values {
            get { throw new NotImplementedException(); }
        }

        public PHPValue this[PHPValue key] {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }

        public void Add(KeyValuePair<PHPValue, PHPValue> item) {
            throw new NotImplementedException();
        }

        public void Clear() {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<PHPValue, PHPValue> item) {
            throw new NotImplementedException();
        }

        public void CopyTo(KeyValuePair<PHPValue, PHPValue>[] array, int arrayIndex) {
            throw new NotImplementedException();
        }

        public int Count {
            get { throw new NotImplementedException(); }
        }

        public bool IsReadOnly {
            get { throw new NotImplementedException(); }
        }

        public bool Remove(KeyValuePair<PHPValue, PHPValue> item) {
            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<PHPValue, PHPValue>> GetEnumerator() {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            throw new NotImplementedException();
        }

        #endregion

        protected override TypeCode GetTypeCode() {
            throw new NotSupportedException();
        }

        protected override bool ToBoolean(IFormatProvider provider) {
            return this.Count != 0;
        }

        protected override byte ToByte(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override char ToChar(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override decimal ToDecimal(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override double ToDouble(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override short ToInt16(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override int ToInt32(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override long ToInt64(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override sbyte ToSByte(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override float ToSingle(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override string ToString(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override ushort ToUInt16(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override uint ToUInt32(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        protected override ulong ToUInt64(IFormatProvider provider) {
            throw new NotSupportedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public class PHPArray : PHPValue, IDictionary<PHPValue, PHPValue> {
        private readonly Dictionary<PHPValue, PHPValue> dictionary = new Dictionary<PHPValue,PHPValue>();
        private ICollection<KeyValuePair<PHPValue, PHPValue>> List {
            get { return (ICollection<KeyValuePair<PHPValue, PHPValue>>)this.dictionary; }
        }

        private int lastIndex = 0;

        public override void Serialize(StringBuilder builder, Encoding encoding) {
            builder.AppendFormat("a:{0}:{{", this.dictionary.Count);
            foreach (var item in this.dictionary) {
                item.Key.Serialize(builder, encoding);
                builder.Append(';');
                item.Value.Serialize(builder, encoding);
                builder.Append(';');
            }
            builder.Append('}');
        }

        #region IDictionary<PHPValue, PHPValue>

        public ICollection<PHPValue> Keys {
            get { return this.dictionary.Keys; }
        }

        public ICollection<PHPValue> Values {
            get { return this.dictionary.Values; }
        }

        public PHPValue this[PHPValue key] {
            get { return this.dictionary[key]; }
            set { this.dictionary[key] = value; }
        }

        public int Count {
            get { return this.dictionary.Count; }
        }

        bool ICollection<KeyValuePair<PHPValue, PHPValue>>.IsReadOnly {
            get { return false; }
        }

        public void Add(PHPValue key, PHPValue value) {
            if (!(key is PHPPrimitive)) {
                throw new ArgumentException();
            }
            if (key.IsNumeric()) {
                this.lastIndex = (int)key;
                this.dictionary.Add(this.lastIndex++, value);
            }
            else if (key is Internals.String) {
                this.dictionary.Add(key, value);
            }
        }

        public void Add(PHPValue value) {
            this.dictionary.Add(this.lastIndex++, value);
        }

        public bool ContainsKey(PHPValue key) {
            return this.dictionary.ContainsKey(key);
        }

        public bool Remove(PHPValue key) {
            return this.dictionary.Remove(key);
        }

        public bool TryGetValue(PHPValue key, out PHPValue value) {
            return this.dictionary.TryGetValue(key, out value);
        }

        void ICollection<KeyValuePair<PHPValue, PHPValue>>.Add(KeyValuePair<PHPValue, PHPValue> item) {
            this.List.Add(item);
        }

        public void Clear() {
            this.dictionary.Clear();
        }

        bool ICollection<KeyValuePair<PHPValue, PHPValue>>.Contains(KeyValuePair<PHPValue, PHPValue> item) {
            return List.Contains(item);
        }

        void ICollection<KeyValuePair<PHPValue, PHPValue>>.CopyTo(KeyValuePair<PHPValue, PHPValue>[] array, int arrayIndex) {
            List.CopyTo(array, arrayIndex);
        }

        bool ICollection<KeyValuePair<PHPValue, PHPValue>>.Remove(KeyValuePair<PHPValue, PHPValue> item) {
            return List.Remove(item);
        }

        public IEnumerator<KeyValuePair<PHPValue, PHPValue>> GetEnumerator() {
            return this.dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
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

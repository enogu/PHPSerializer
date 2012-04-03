using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public class PHPArray : PHPValue, IDictionary<PHPValue, PHPValue> {
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
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public abstract class PHPValue {
        public static PHPValue Unserialize(string value, Encoding encoding) {
            throw new NotImplementedException();
        }

        public abstract void Serialize(StringBuilder builder, Encoding encoding);
    }
}

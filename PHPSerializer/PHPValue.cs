using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public abstract class PHPValue {
        public static PHPValue Unserialize(string value) {
            throw new NotImplementedException();
        }

        public virtual string Serialize() {
            throw new NotImplementedException();
        }
    }
}

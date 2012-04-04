﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PHP {
    public abstract class PHPValue : IConvertible {
        public static PHPValue Unserialize(string value, Encoding encoding) {
            try {
                int pos = 0;
                return Unserialize(ref pos, value, encoding);
            }
            catch (FormatException) {
                throw;
            }
            catch (Exception error) {
                throw new FormatException("", error);
            }
        }

        private static PHPValue Unserialize(ref int pos, string value, Encoding encoding) {
            int p = pos;
            int limit = value.Length;
            if (limit <= p) {
                return null;
            }
            switch (value[p++]) {
                case 'a':
                    break;
                case 'b':
                    if (value[p++] == ':') {
                        bool bvalue = value[p++] != '0';
                        pos = p;
                        return  new Internals.Boolean(bvalue);
                    }
                    break;
                case 'd':
                    if (value[p++] == ':') {
                        var dstart = p;
                        pos = SeekEndOfNumber(value, p, limit);
                        return new Internals.Double(double.Parse(value.Substring(dstart, pos - dstart)));
                    }
                    break;
                case 'i':
                    if (value[p++] == ':') {
                        var istart = p;
                        pos = SeekEndOfNumber(value, p, limit);
                        return new Internals.Integer(long.Parse(value.Substring(istart, pos - istart)));
                    }
                    break;
                case 's':
                    if (value[p++] == ':') {
                        var lenstart = p;
                        p = SeekEndOfNumber(value, p, limit);
                        var slen = int.Parse(value.Substring(lenstart, p - lenstart));
                        if (value[p++] == ':' && value[p++] == '"') {
                            pos = p + slen;
                            if (value[pos++] == '"') {
                                return new Internals.String(value.Substring(p, slen));
                            }
                        }
                        throw new FormatException();
                    }
                    break;
            }
            throw new NotSupportedException();
        }

        private static int SeekEndOfNumber(string value, int p, int limit) {
            if (value[p] == '-') {
                p++;
            }
            bool rep = false;
            while (p < limit) {
                switch (value[p]) {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                        break;
                    case '.':
                        if (!rep) {
                            rep = true;
                            break;
                        }
                        throw new FormatException();
                    case ';':
                    case ':':
                        return p;
                    default:
                        throw new FormatException();
                }
                p++;
            }
            return p;
        }

        public abstract void Serialize(StringBuilder builder, Encoding encoding);

        #region Implicit operators

        public static implicit operator bool(PHPValue value) {
                return ((IConvertible)value).ToBoolean(null);
        }
        public static implicit operator byte(PHPValue value) {
                return ((IConvertible)value).ToByte(null);
        }
        public static implicit operator char(PHPValue value) {
                return ((IConvertible)value).ToChar(null);
        }
        public static implicit operator decimal(PHPValue value) {
                return ((IConvertible)value).ToDecimal(null);
        }
        public static implicit operator double(PHPValue value) {
                return ((IConvertible)value).ToDouble(null);
        }
        public static implicit operator short(PHPValue value) {
                return ((IConvertible)value).ToInt16(null);
        }
        public static implicit operator int(PHPValue value) {
                return ((IConvertible)value).ToInt32(null);
        }
        public static implicit operator long(PHPValue value) {
                return ((IConvertible)value).ToInt64(null);
        }
        public static implicit operator sbyte(PHPValue value) {
                return ((IConvertible)value).ToSByte(null);
        }
        public static implicit operator float(PHPValue value) {
                return ((IConvertible)value).ToSingle(null);
        }
        public static implicit operator string(PHPValue value) {
                return ((IConvertible)value).ToString(null);
        }
        public static implicit operator ushort(PHPValue value) {
                return ((IConvertible)value).ToUInt16(null);
        }
        public static implicit operator uint(PHPValue value) {
                return value.ToUInt32(null);
        }
        public static implicit operator ulong(PHPValue value) {
                return ((IConvertible)value).ToUInt64(null);
        }

        #endregion
        #region IConvertible

        TypeCode IConvertible.GetTypeCode() {
            return this.GetTypeCode();
        }

        bool IConvertible.ToBoolean(IFormatProvider provider) {
            return this.ToBoolean(provider);
        }

        byte IConvertible.ToByte(IFormatProvider provider) {
            return this.ToByte(provider);
        }

        char IConvertible.ToChar(IFormatProvider provider) {
            return this.ToChar(provider);
        }

        DateTime IConvertible.ToDateTime(IFormatProvider provider) {
            throw new NotSupportedException();
        }

        decimal IConvertible.ToDecimal(IFormatProvider provider) {
            return this.ToDecimal(provider);
        }

        double IConvertible.ToDouble(IFormatProvider provider) {
            return this.ToDouble(provider);
        }

        short IConvertible.ToInt16(IFormatProvider provider) {
            return this.ToInt16(provider);
        }

        int IConvertible.ToInt32(IFormatProvider provider) {
            return this.ToInt32(provider);
        }

        long IConvertible.ToInt64(IFormatProvider provider) {
            return this.ToInt64(provider);
        }

        sbyte IConvertible.ToSByte(IFormatProvider provider) {
            return this.ToSByte(provider);
        }

        float IConvertible.ToSingle(IFormatProvider provider) {
            return this.ToSingle(provider);
        }

        string IConvertible.ToString(IFormatProvider provider) {
            return this.ToString(provider);
        }

        object IConvertible.ToType(Type conversionType, IFormatProvider provider) {
            throw new NotSupportedException();
        }

        ushort IConvertible.ToUInt16(IFormatProvider provider) {
            return this.ToUInt16(provider);
        }

        uint IConvertible.ToUInt32(IFormatProvider provider) {
            return this.ToUInt32(provider);
        }

        ulong IConvertible.ToUInt64(IFormatProvider provider) {
            return this.ToUInt64(provider);
        }

        protected abstract TypeCode GetTypeCode();
        protected abstract bool ToBoolean(IFormatProvider provider);
        protected abstract byte ToByte(IFormatProvider provider); 
        protected abstract char ToChar(IFormatProvider provider); 
        protected abstract decimal ToDecimal(IFormatProvider provider);
        protected abstract double ToDouble(IFormatProvider provider); 
        protected abstract short ToInt16(IFormatProvider provider); 
        protected abstract int ToInt32(IFormatProvider provider); 
        protected abstract long ToInt64(IFormatProvider provider); 
        protected abstract sbyte ToSByte(IFormatProvider provider); 
        protected abstract float ToSingle(IFormatProvider provider); 
        protected abstract string ToString(IFormatProvider provider); 
        protected abstract ushort ToUInt16(IFormatProvider provider); 
        protected abstract uint ToUInt32(IFormatProvider provider); 
        protected abstract ulong ToUInt64(IFormatProvider provider);

        #endregion
    }
}

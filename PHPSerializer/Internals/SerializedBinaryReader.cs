using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PHP.Internals {
    class SerializedBinaryReader {
        const int UnserializeMinibufSize = 30;

        private readonly Stream stream;
        private readonly Encoding encoding;
        private readonly byte[] minibuf = new byte[UnserializeMinibufSize];
        private byte[] strbuf = new byte[1024];

        public SerializedBinaryReader(Stream stream, Encoding encoding) {
            this.stream = stream;
            this.encoding = encoding;
        }

        public PHPValue Parse() {
            try {
                if (ReadBin(0, 2) < 2) {
                    throw new FormatException();
                }
                if (minibuf[1] != ':') {
                    //TODO:プリミティブ型以外の可能性がある
                    throw new FormatException();
                }
                switch (minibuf[0]) {
                    case 0x61: //a
                        var count = ReadLong();
                        if (stream.ReadByte() == '{') {
                            var result = new PHPArray();
                            for (int i = 0; i < count; i++) {
                                result.Add(Parse(), Parse());
                            }
                            var end = ReadBin(0, 2);
                            if (0 < end && minibuf[0] == '}' && (end == 1 || minibuf[1] == ';')) {
                                return result;
                            }
                        }
                        break;
                    case 0x62: //b
                        var len = stream.Read(minibuf, 2, 2);
                        if (len == 0 || (len == 2 && minibuf[3] != ';')) {
                            throw new FormatException();
                        }
                        bool bvalue = minibuf[2] != '0';
                        return  new Internals.Boolean(bvalue);
                    case 0x64: //d
                        return ReadDouble();
                    case 0x69: //i
                        return ReadInt();
                    case 0x73: //s
                        return ReadStr(ReadInt());
                }
                throw new NotSupportedException();
            }
            catch (FormatException) {
                throw;
            }
            catch (Exception error) {
                throw new FormatException("", error);
            }
        }

        private int ReadBin(int offset, int length) {
            return stream.Read(minibuf, offset, length);
        }

        private string ReadStr(int length) {
            var len = length + 3;
            if (strbuf.Length < length) {
                strbuf = new byte[strbuf.Length * 2];
            }
            var actual = stream.Read(strbuf, 0, len);
            if (strbuf[0] != '"' || strbuf[len - 2] != '"') {
                throw new FormatException();
            }
            if (len == actual && strbuf[len - 1] != ';') {
                throw new FormatException();
            }
            return encoding.GetString(strbuf, 1, length);
        }

        private int ReadInt() {
            var len = ReadNumber();
            return int.Parse(Encoding.ASCII.GetString(minibuf, 0, len));
        }
        private long ReadLong() {
            var len = ReadNumber();
            return long.Parse(Encoding.ASCII.GetString(minibuf, 0, len));
        }
        private double ReadDouble() {
            var len = ReadNumber();
            return double.Parse(Encoding.ASCII.GetString(minibuf, 0, len));
        }

        private int ReadNumber() {
            int p = 0;
            bool rep = false;
            while (true) {
                var c = stream.ReadByte();
                switch (c) {
                    case '-':
                        if (p == 0) {
                            break;
                        }
                        throw new FormatException();
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
                    case -1: //ストリームの終端
                    case ';':
                    case ':':
                        return p;
                    default:
                        throw new FormatException();
                }
                minibuf[p++] = (byte)c;
            }
        }
    }
}

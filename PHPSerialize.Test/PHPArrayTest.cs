using PHP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;

namespace PHPSerialize.Test
{
    
    
    /// <summary>
    ///PHPArrayTest のテスト クラスです。すべての
    ///PHPArrayTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class PHPArrayTest {


        private TestContext testContextInstance;

        /// <summary>
        ///現在のテストの実行についての情報および機能を
        ///提供するテスト コンテキストを取得または設定します。
        ///</summary>
        public TestContext TestContext {
            get {
                return testContextInstance;
            }
            set {
                testContextInstance = value;
            }
        }

        #region 追加のテスト属性
        // 
        //テストを作成するときに、次の追加属性を使用することができます:
        //
        //クラスの最初のテストを実行する前にコードを実行するには、ClassInitialize を使用
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //クラスのすべてのテストを実行した後にコードを実行するには、ClassCleanup を使用
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //各テストを実行する前にコードを実行するには、TestInitialize を使用
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //各テストを実行した後にコードを実行するには、TestCleanup を使用
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///PHPArray コンストラクター のテスト
        ///</summary>
        [TestMethod()]
        public void PHPArrayConstructorTest() {
            PHPArray target = new PHPArray();
            Assert.AreEqual(0, target.Count);
        }

        [TestMethod]
        public void SerializeTest() {
            PHPArray target = new PHPArray();
            target.Add(1000);
            target.Add("test");
            var builder = new System.Text.StringBuilder();
            target.Serialize(builder, System.Text.Encoding.UTF8);
            Assert.AreEqual("a:2:{i:0;i:1000;i:1;s:4:\"test\";}", builder.ToString());
        }
        [TestMethod]
        public void SerializeEmptyTest() {
            PHPArray target = new PHPArray();
            var builder = new System.Text.StringBuilder();
            target.Serialize(builder, System.Text.Encoding.UTF8);
            Assert.AreEqual("a:0:{}", builder.ToString());
        }
        [TestMethod]
        public void SerializeMixtureTest() {
            PHPArray target = new PHPArray();
            target.Add("id", 1000);
            target.Add("test");
            var builder = new System.Text.StringBuilder();
            target.Serialize(builder, System.Text.Encoding.UTF8);
            Assert.AreEqual("a:2:{s:2:\"id\";i:1000;i:0;s:4:\"test\";}", builder.ToString());
        }

        /// <summary>
        ///Add のテスト
        ///</summary>
        [TestMethod()]
        public void AddTest() {
            IDictionary<PHPValue, PHPValue> target = new PHPArray();
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>("id", 1200);
            target.Add(item);
            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.Contains(item));
            Assert.IsTrue(target.ContainsKey("id"));
            Assert.AreEqual(1200, (int)target["id"]);
        }

        /// <summary>
        ///Add のテスト
        ///</summary>
        [TestMethod()]
        public void AddTest1() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("type", "Test");
            Assert.AreEqual(1, target.Count);
            Assert.IsTrue(target.ContainsKey("type"));
            Assert.AreEqual("Test", (string)target["type"]);
        }
        [TestMethod()]
        public void AddTest2() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("Test");
            target.Add("Value");
            Assert.AreEqual(2, target.Count);
            Assert.IsTrue(target.ContainsKey(1));
            Assert.AreEqual("Test", (string)target[0]);
            Assert.AreEqual("Value", (string)target[1]);
        }
        [TestMethod()]
        public void AddTest3() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("Test");
            target.Add("4", "Key");
            target.Add("Value");
            Assert.AreEqual(3, target.Count);
            Assert.IsFalse(target.ContainsKey(1));
            Assert.IsTrue(target.ContainsKey(4));
            Assert.IsTrue(target.ContainsKey(5));
            Assert.AreEqual("Test", (string)target[0]);
            Assert.AreEqual("Key", (string)target[4]);
            Assert.AreEqual("Value", (string)target[5]);
        }

        /// <summary>
        ///Clear のテスト
        ///</summary>
        [TestMethod()]
        public void ClearTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("Test");
            target.Add("Test");
            Assert.AreEqual(2, target.Count);
            target.Clear();
            Assert.AreEqual(0, target.Count);
        }

        /// <summary>
        ///Contains のテスト
        ///</summary>
        [TestMethod()]
        public void ContainsTest() {
            IDictionary<PHPValue, PHPValue> target = new PHPArray();
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>("id", 1200);
            Assert.IsFalse(target.Contains(item));
            target.Add(item);
            Assert.IsTrue(target.Contains(item));
        }

        /// <summary>
        ///ContainsKey のテスト
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            Assert.IsFalse(target.ContainsKey("id"));
            target.Add("id", 1200);
            Assert.IsTrue(target.ContainsKey("id"));
        }

        /// <summary>
        ///CopyTo のテスト
        ///</summary>
        [TestMethod()]
        public void CopyToTest() {
            PHPArray source = new PHPArray();
            IDictionary<PHPValue, PHPValue> target = source;
            source.Add(1000);
            source.Add(1001);
            source.Add(1002);
            KeyValuePair<PHPValue, PHPValue>[] dest = new KeyValuePair<PHPValue,PHPValue>[4];
            target.CopyTo(dest, 1);
            Assert.IsNull(dest[0].Value);
            Assert.AreEqual(0, (int)dest[1].Key);
            Assert.AreEqual(1000, (int)dest[1].Value);
            Assert.AreEqual(1, (int)dest[2].Key);
            Assert.AreEqual(1001, (int)dest[2].Value);
            Assert.AreEqual(2, (int)dest[3].Key);
            Assert.AreEqual(1002, (int)dest[3].Value);
        }

        /// <summary>
        ///GetEnumerator のテスト
        ///</summary>
        private void GetEnumeratorTest<T>(Func<PHPArray, T> creator) where T:IEnumerator {
            var values = new[] { 1000, 1001, 1002 };
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            Array.ForEach(values, n => target.Add(n));
            T actual = creator(target);
            Assert.IsNotNull(actual);
            actual.Reset();
            Assert.IsTrue(actual.MoveNext());
            Assert.AreEqual(values[0], (int)((KeyValuePair<PHPValue, PHPValue>)actual.Current).Value);
            Assert.IsTrue(actual.MoveNext());
            Assert.AreEqual(values[1], (int)((KeyValuePair<PHPValue, PHPValue>)actual.Current).Value);
            Assert.IsTrue(actual.MoveNext());
            Assert.AreEqual(values[2], (int)((KeyValuePair<PHPValue, PHPValue>)actual.Current).Value);
        }

        [TestMethod()]
        public void GetEnumeratorTest() {
            GetEnumeratorTest((target) => target.GetEnumerator());
        }

        /// <summary>
        ///Remove のテスト
        ///</summary>
        [TestMethod()]
        public void RemoveTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add(1000);
            target.Add(1001);
            target.Add(1002);
            PHPValue key = 1; // TODO: 適切な値に初期化してください
            Assert.IsTrue(target.Remove(key));
            Assert.AreEqual(2, target.Count);
        }

        /// <summary>
        ///Remove のテスト
        ///</summary>
        [TestMethod()]
        public void RemoveTest1() {
            IDictionary<PHPValue, PHPValue> target = new PHPArray(); // TODO: 適切な値に初期化してください
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>("id", 1000); // TODO: 適切な値に初期化してください
            Assert.IsFalse(target.Remove(item));
            target.Add(item);
            Assert.IsTrue(target.Remove(item));
            Assert.IsFalse(target.Contains(item));
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void GetEnumeratorTest1() {
            GetEnumeratorTest((target) => ((IEnumerable)target).GetEnumerator());
        }

        /// <summary>
        ///TryGetValue のテスト
        ///</summary>
        [TestMethod()]
        public void TryGetValueTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("key", "value");
            PHPValue result;
            Assert.IsTrue(target.TryGetValue("key", out result));
            Assert.AreEqual("value", (string)result);
        }
        [TestMethod()]
        public void TryGetValueFailureTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add("id", 1000);
            PHPValue result;
            Assert.IsFalse(target.TryGetValue("key", out result));
            Assert.IsNull(result);
        }

        /// <summary>
        ///IsReadOnly のテスト
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest() {
            IDictionary<PHPValue, PHPValue> target = new PHPArray(); // TODO: 適切な値に初期化してください
            Assert.IsFalse(target.IsReadOnly);
        }

        /// <summary>
        ///Keys のテスト
        ///</summary>
        [TestMethod()]
        public void KeysTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add(0, 100);
            target.Add(4, 104);
            target.Add(6, 106);
            ICollection<PHPValue> actual;
            actual = target.Keys;
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
            var keys = (from item in actual select (int)item).ToArray();
            Assert.AreEqual(0, keys.Min());
            Assert.AreEqual(6, keys.Max());
        }

        /// <summary>
        ///Values のテスト
        ///</summary>
        [TestMethod()]
        public void ValuesTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add(0, 100);
            target.Add(4, 104);
            target.Add(6, 106);
            ICollection<PHPValue> actual;
            actual = target.Values;
            Assert.IsNotNull(actual);
            Assert.AreEqual(3, actual.Count);
            var values = (from item in actual select (int)item).ToArray();
            Assert.AreEqual(100, values.Min());
            Assert.AreEqual(106, values.Max());
        }

        /// <summary>
        ///System.IConvertible.GetTypeCode のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void GetTypeCodeTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            TypeCode expected = new TypeCode(); // TODO: 適切な値に初期化してください
            TypeCode actual;
            actual = target.GetTypeCode();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToBoolean のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToBooleanTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Add(1000);
            Assert.IsTrue(target);
        }
        [TestMethod()]
        public void ToEmptyBooleanTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            Assert.IsFalse(target);
        }

        /// <summary>
        ///System.IConvertible.ToByte のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToByteTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            byte expected = 0; // TODO: 適切な値に初期化してください
            byte actual;
            actual = target.ToByte(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToChar のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToCharTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            char expected = '\0'; // TODO: 適切な値に初期化してください
            char actual;
            actual = target.ToChar(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToDateTime のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToDateTimeTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            DateTime expected = new DateTime(); // TODO: 適切な値に初期化してください
            DateTime actual;
            actual = target.ToDateTime(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToDecimal のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToDecimalTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            Decimal expected = new Decimal(); // TODO: 適切な値に初期化してください
            Decimal actual;
            actual = target.ToDecimal(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToDouble のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToDoubleTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            double expected = 0F; // TODO: 適切な値に初期化してください
            double actual;
            actual = target.ToDouble(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt16 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToInt16Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            short expected = 0; // TODO: 適切な値に初期化してください
            short actual;
            actual = target.ToInt16(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt32 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToInt32Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            int expected = 0; // TODO: 適切な値に初期化してください
            int actual;
            actual = target.ToInt32(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt64 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToInt64Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            long expected = 0; // TODO: 適切な値に初期化してください
            long actual;
            actual = target.ToInt64(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToSByte のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToSByteTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            sbyte expected = 0; // TODO: 適切な値に初期化してください
            sbyte actual;
            actual = target.ToSByte(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToSingle のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToSingleTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            float expected = 0F; // TODO: 適切な値に初期化してください
            float actual;
            actual = target.ToSingle(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToString のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToStringTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            string expected = string.Empty; // TODO: 適切な値に初期化してください
            string actual;
            actual = target.ToString(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToType のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToTypeTest() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            Type conversionType = null; // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            object expected = null; // TODO: 適切な値に初期化してください
            object actual;
            actual = target.ToType(conversionType, provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToUInt16 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToUInt16Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ushort expected = 0; // TODO: 適切な値に初期化してください
            ushort actual;
            actual = target.ToUInt16(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToUInt32 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToUInt32Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            uint expected = 0; // TODO: 適切な値に初期化してください
            uint actual;
            actual = target.ToUInt32(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToUInt64 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        [ExpectedException(typeof(NotSupportedException))]
        public void ToUInt64Test() {
            IConvertible target = new PHPArray(); // TODO: 適切な値に初期化してください
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ulong expected = 0; // TODO: 適切な値に初期化してください
            ulong actual;
            actual = target.ToUInt64(provider);
            Assert.AreEqual(expected, actual);
        }
    }
}

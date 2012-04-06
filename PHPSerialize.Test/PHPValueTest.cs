using PHP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PHPSerialize.Test
{
    
    
    /// <summary>
    ///PHPValueTest のテスト クラスです。すべての
    ///PHPValueTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class PHPValueTest {


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


        internal virtual PHPValue CreatePHPValue() {
            // TODO: 適切な具象クラスをインスタンス化します。
            PHPValue target = null;
            return target;
        }

        /*
        /// <summary>
        ///Serialize のテスト
        ///</summary>
        [TestMethod()]
        public void SerializeTest() {
            PHPValue target = CreatePHPValue(); // TODO: 適切な値に初期化してください
            string expected = string.Empty; // TODO: 適切な値に初期化してください
            string actual;
            actual = target.Serialize();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
        */

        private static void UnserializeTest(string value, System.Text.Encoding encoding, Action<PHPValue> test) {
            using (var stream = new System.IO.MemoryStream(encoding.GetBytes(value))) {
                var actual = PHPValue.Unserialize(stream, encoding);
                test(actual);
            }
        }

        /// <summary>
        ///Unserialize のテスト
        ///</summary>
        [TestMethod()]
        public void UnserializeBoolTest() {
            string value = "b:1";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
                    Assert.IsTrue(actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeFalseBoolTest() {
            string value = "b:0";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidBoolTest1() {
            string value = "b:";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidBoolTest2() {
            string value = "b 1";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
                    Assert.IsFalse(actual);
                }
            );
        }
        
        [TestMethod()]
        public void UnserializeDoubleTest() {
            string value = "d:1.5";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(1.5, (double)actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeNegativeDoubleTest() {
            string value = "d:-1.3";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(-1.3, (double)actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeZeroDoubleTest() {
            string value = "d:0";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(0.0, (double)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest1() {
            string value = "d:";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(0, (double)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest2() {
            string value = "d 1.2";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(1.2, (double)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest3() {
            string value = "d:1.1.1";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(0, (double)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest4() {
            string value = "d:a";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
                    Assert.AreEqual(0, (double)actual);
                }
            );
        }
        
        [TestMethod()]
        public void UnserializeIntegerTest() {
            string value = "i:10";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(10, (int)actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeNegativeIntegerTest() {
            string value = "i:-10";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(-10, (int)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest1() {
            string value = "i:";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(0, (int)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest2() {
            string value = "i 10";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(1.2, (double)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest3() {
            string value = "i:10.1";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(0, (int)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest4() {
            string value = "i:a";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
                    Assert.AreEqual(0, (int)actual);
                }
            );
        }

        [TestMethod()]
        public void UnserializeStringTest() {
            string value = "s:15:\"abcdefghij12345\"";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.AreEqual("abcdefghij12345", (string)actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeMultibyteStringTest() {
            string value = "s:9:\"テスト\"";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.AreEqual("テスト", (string)actual);
                }
            );
        }
        [TestMethod()]
        public void UnserializeEmptyStringTest() {
            string value = "s:0:\"\"";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.AreEqual(string.Empty, (string)actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest1() {
            string value = "s::\"\"";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest2() {
            string value = "b 1";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest3() {
            string value = "s:1:\"\"";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest4() {
            string value = "s:1:a";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (actual) => {
                    Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
                    Assert.IsFalse(actual);
                }
            );
        }

        [TestMethod()]
        public void UnserializeArrayTest() {
            string value = "a:2:{i:0;i:1000;i:1;s:4:\"1001\";}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsNotNull(actual);

                    Assert.IsTrue(actual.ContainsKey(0));
                    Assert.IsTrue(actual[0] as PHP.Internals.Integer);
                    Assert.AreEqual(1000, (int)actual[0]);

                    Assert.IsTrue(actual.ContainsKey(1));
                    Assert.IsTrue(actual[1] as PHP.Internals.String);
                    Assert.AreEqual("1001", (string)actual[1]);
                }
            );
        }
        [TestMethod()]
        public void UnserializeNestedArrayTest() {
            string value = "a:3:{i:0;i:1000;s:6:\"values\";a:1:{i:4;d:150.3;};i:1;s:4:\"1001\";}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsNotNull(actual);

                    Assert.IsTrue(actual.ContainsKey(0));
                    Assert.IsTrue(actual[0] is PHP.Internals.Integer);
                    Assert.AreEqual(1000, (int)actual[0]);

                    Assert.IsTrue(actual.ContainsKey(1));
                    Assert.IsTrue(actual[1] is PHP.Internals.String);
                    Assert.AreEqual("1001", (string)actual[1]);

                    Assert.IsTrue(actual.ContainsKey("values"));
                    Assert.IsTrue(actual["values"] is PHP.PHPArray);
                    var values = actual["values"] as PHPArray;
                    Assert.IsTrue(values.ContainsKey(4));
                    Assert.IsTrue(values[4] is PHP.Internals.Double);
                    Assert.AreEqual(150.3, (double)values[4]);
                }
            );
        }

        [TestMethod()]
        public void UnserializeEmptyArrayTest() {
            string value = "a:0:{}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsNotNull(actual);
                    Assert.AreEqual(0, actual.Count);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidArrayTest1() {
            string value = "a::{}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsInstanceOfType(actual, typeof(PHP.PHPArray));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidArrayTest2() {
            string value = "a:0:}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsInstanceOfType(actual, typeof(PHP.PHPArray));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidArrayTest3() {
            string value = "a:1:{}";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsInstanceOfType(actual, typeof(PHP.PHPArray));
                    Assert.IsFalse(actual);
                }
            );
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidArrayTest4() {
            string value = "a:1:{i:0;i:0;";
            UnserializeTest(
                value,
                System.Text.Encoding.UTF8,
                (_) => {
                    var actual = _ as PHPArray;
                    Assert.IsInstanceOfType(actual, typeof(PHP.PHPArray));
                    Assert.IsFalse(actual);
                }
            );
        }
    }
}

﻿using PHP;
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

        /// <summary>
        ///Unserialize のテスト
        ///</summary>
        [TestMethod()]
        public void UnserializeBoolTest() {
            string value = "b:1";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
            Assert.IsTrue(actual);
        }
        [TestMethod()]
        public void UnserializeFalseBoolTest() {
            string value = "b:0";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidBoolTest1() {
            string value = "b:";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidBoolTest2() {
            string value = "b 1";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Boolean));
            Assert.IsFalse(actual);
        }
        
        [TestMethod()]
        public void UnserializeDoubleTest() {
            string value = "d:1.5";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(1.5, (double)actual);
        }
        [TestMethod()]
        public void UnserializeNegativeDoubleTest() {
            string value = "d:-1.3";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(-1.3, (double)actual);
        }
        [TestMethod()]
        public void UnserializeZeroDoubleTest() {
            string value = "d:0";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(0.0, (double)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest1() {
            string value = "d:";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(0, (double)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest2() {
            string value = "d 1.2";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(1.2, (double)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest3() {
            string value = "d:1.1.1";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(0, (double)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidDoubleTest4() {
            string value = "d:a";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Double));
            Assert.AreEqual(0, (double)actual);
        }
        
        [TestMethod()]
        public void UnserializeIntegerTest() {
            string value = "i:10";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(10, (int)actual);
        }
        [TestMethod()]
        public void UnserializeNegativeIntegerTest() {
            string value = "i:-10";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(-10, (int)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest1() {
            string value = "i:";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(0, (int)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest2() {
            string value = "i 10";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(1.2, (double)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest3() {
            string value = "i:10.1";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(0, (int)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidIntegerTest4() {
            string value = "i:a";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.Integer));
            Assert.AreEqual(0, (int)actual);
        }

        [TestMethod()]
        public void UnserializeStringTest() {
            string value = "s:15:\"abcdefghij12345\"";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.AreEqual("abcdefghij12345", (string)actual);
        }
        [TestMethod()]
        public void UnserializeEmptyStringTest() {
            string value = "s:0:\"\"";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.AreEqual(string.Empty, (string)actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest1() {
            string value = "s::\"\"";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest2() {
            string value = "b 1";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest3() {
            string value = "s:1:\"\"";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void UnserializeInvalidStringTest4() {
            string value = "s:1:a";
            var actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.IsInstanceOfType(actual, typeof(PHP.Internals.String));
            Assert.IsFalse(actual);
        }
    }
}

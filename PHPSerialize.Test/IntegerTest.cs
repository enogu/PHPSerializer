﻿using PHP.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PHPSerialize.Test
{
    
    
    /// <summary>
    ///IntegerTest のテスト クラスです。すべての
    ///IntegerTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class IntegerTest {


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
        ///Integer コンストラクター のテスト
        ///</summary>
        [TestMethod()]
        public void IntegerConstructorTest() {
            Integer target = new Integer(1000);
            Assert.AreEqual(1000, (int)target); 
        }

        /// <summary>
        ///System.IConvertible.GetTypeCode のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void GetTypeCodeTest() {
            IConvertible target = new Integer(1000);
            TypeCode expected = TypeCode.Int64;
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
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            bool expected = true;
            bool actual;
            actual = target.ToBoolean(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToBoolean のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ZeroToBooleanTest() {
            IConvertible target = new Integer(0);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            bool expected = false;
            bool actual;
            actual = target.ToBoolean(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToByte のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToByteTest() {
            IConvertible target = new Integer(100);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            byte expected = 100;
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
            IConvertible target = new Integer(100);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            char expected = '\0';
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
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            DateTime expected = new DateTime();
            DateTime actual;
            actual = target.ToDateTime(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToDecimal のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToDecimalTest() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            Decimal expected = 1000m;
            Decimal actual;
            actual = target.ToDecimal(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToDouble のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToDoubleTest() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            double expected = 1000d;
            double actual;
            actual = target.ToDouble(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt16 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToInt16Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            short expected = 1000;
            short actual;
            actual = target.ToInt16(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt32 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToInt32Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            int expected = 1000;
            int actual;
            actual = target.ToInt32(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt64 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToInt64Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            long expected = 1000;
            long actual;
            actual = target.ToInt64(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToSByte のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToSByteTest() {
            IConvertible target = new Integer(100);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            sbyte expected = 100;
            sbyte actual;
            actual = target.ToSByte(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToSingle のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToSingleTest() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            float expected = 1000F;
            float actual;
            actual = target.ToSingle(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToString のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToStringTest() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            string expected = "1000";
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
            IConvertible target = new Integer(1000);
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
        public void ToUInt16Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ushort expected = 1000;
            ushort actual;
            actual = target.ToUInt16(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToUInt32 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToUInt32Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            uint expected = 1000;
            uint actual;
            actual = target.ToUInt32(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToUInt64 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void ToUInt64Test() {
            IConvertible target = new Integer(1000);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ulong expected = 1000;
            ulong actual;
            actual = target.ToUInt64(provider);
            Assert.AreEqual(expected, actual);
        }
    }
}

using PHP.Internals;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Target = PHP.Internals.Boolean;

namespace PHPSerialize.Test
{
    
    
    /// <summary>
    ///BooleanTest のテスト クラスです。すべての
    ///BooleanTest 単体テストをここに含めます
    ///</summary>
    [TestClass()]
    public class BooleanTest {


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
        ///Boolean コンストラクター のテスト
        ///</summary>
        [TestMethod()]
        public void BooleanConstructorTest() {
            Target target = new Target(true);
            Assert.IsTrue(target);
        }

        [TestMethod]
        public void SerializeTest() {
            Target target = new Target(true);
            var actual = new System.Text.StringBuilder();
            target.Serialize(actual, null);
            Assert.AreEqual("b:1", actual.ToString());
        }

        [TestMethod]
        public void SerializeFalseTest() {
            Target target = new Target(false);
            var actual = new System.Text.StringBuilder();
            target.Serialize(actual, null);
            Assert.AreEqual("b:0", actual.ToString());
        }

        /// <summary>
        ///System.IConvertible.GetTypeCode のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void GetTypeCodeTest() {
            IConvertible target = new Target(true);
            TypeCode expected = TypeCode.Boolean;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            bool expected = true;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            byte expected = 1;
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
            IConvertible target = new Target(true);
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
            IConvertible target = new Target(false);
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            Decimal expected = 1m;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            double expected = 1d;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            short expected = 1;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            int expected = 1;
            int actual;
            actual = target.ToInt32(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToInt32 のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void FalseToInt32Test() {
            IConvertible target = new Target(false);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            int expected = 0;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            long expected = 1;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            sbyte expected = 1;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            float expected = 1F;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            string expected = "true";
            string actual;
            actual = target.ToString(provider);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///System.IConvertible.ToString のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void FalseToStringTest() {
            IConvertible target = new Target(false);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            string expected = "false";
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
            IConvertible target = new Target(true); // TODO: 適切な値に初期化してください
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ushort expected = 1;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            uint expected = 1;
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
            IConvertible target = new Target(true);
            IFormatProvider provider = null; // TODO: 適切な値に初期化してください
            ulong expected = 1;
            ulong actual;
            actual = target.ToUInt64(provider);
            Assert.AreEqual(expected, actual);
        }
    }
}

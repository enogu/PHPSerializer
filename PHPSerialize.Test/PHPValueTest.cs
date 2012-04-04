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
        public void UnserializeTest() {
            string value = string.Empty; // TODO: 適切な値に初期化してください
            PHPValue expected = null; // TODO: 適切な値に初期化してください
            PHPValue actual;
            actual = PHPValue.Unserialize(value, System.Text.Encoding.UTF8);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
    }
}

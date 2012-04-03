using PHP;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Collections;

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
            Assert.Inconclusive("TODO: ターゲットを確認するためのコードを実装してください");
        }

        /// <summary>
        ///Add のテスト
        ///</summary>
        [TestMethod()]
        public void AddTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>(); // TODO: 適切な値に初期化してください
            target.Add(item);
            Assert.Inconclusive("値を返さないメソッドは確認できません。");
        }

        /// <summary>
        ///Add のテスト
        ///</summary>
        [TestMethod()]
        public void AddTest1() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            PHPValue key = null; // TODO: 適切な値に初期化してください
            PHPValue value = null; // TODO: 適切な値に初期化してください
            target.Add(key, value);
            Assert.Inconclusive("値を返さないメソッドは確認できません。");
        }

        /// <summary>
        ///Clear のテスト
        ///</summary>
        [TestMethod()]
        public void ClearTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            target.Clear();
            Assert.Inconclusive("値を返さないメソッドは確認できません。");
        }

        /// <summary>
        ///Contains のテスト
        ///</summary>
        [TestMethod()]
        public void ContainsTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>(); // TODO: 適切な値に初期化してください
            bool expected = false; // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.Contains(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///ContainsKey のテスト
        ///</summary>
        [TestMethod()]
        public void ContainsKeyTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            PHPValue key = null; // TODO: 適切な値に初期化してください
            bool expected = false; // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.ContainsKey(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///CopyTo のテスト
        ///</summary>
        [TestMethod()]
        public void CopyToTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            KeyValuePair<PHPValue, PHPValue>[] array = null; // TODO: 適切な値に初期化してください
            int arrayIndex = 0; // TODO: 適切な値に初期化してください
            target.CopyTo(array, arrayIndex);
            Assert.Inconclusive("値を返さないメソッドは確認できません。");
        }

        /// <summary>
        ///GetEnumerator のテスト
        ///</summary>
        [TestMethod()]
        public void GetEnumeratorTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            IEnumerator<KeyValuePair<PHPValue, PHPValue>> expected = null; // TODO: 適切な値に初期化してください
            IEnumerator<KeyValuePair<PHPValue, PHPValue>> actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Remove のテスト
        ///</summary>
        [TestMethod()]
        public void RemoveTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            PHPValue key = null; // TODO: 適切な値に初期化してください
            bool expected = false; // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.Remove(key);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Remove のテスト
        ///</summary>
        [TestMethod()]
        public void RemoveTest1() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            KeyValuePair<PHPValue, PHPValue> item = new KeyValuePair<PHPValue, PHPValue>(); // TODO: 適切な値に初期化してください
            bool expected = false; // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.Remove(item);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///System.Collections.IEnumerable.GetEnumerator のテスト
        ///</summary>
        [TestMethod()]
        [DeploymentItem("libphp.dll")]
        public void GetEnumeratorTest1() {
            IEnumerable target = new PHPArray(); // TODO: 適切な値に初期化してください
            IEnumerator expected = null; // TODO: 適切な値に初期化してください
            IEnumerator actual;
            actual = target.GetEnumerator();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///TryGetValue のテスト
        ///</summary>
        [TestMethod()]
        public void TryGetValueTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            PHPValue key = null; // TODO: 適切な値に初期化してください
            PHPValue value = null; // TODO: 適切な値に初期化してください
            PHPValue valueExpected = null; // TODO: 適切な値に初期化してください
            bool expected = false; // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.TryGetValue(key, out value);
            Assert.AreEqual(valueExpected, value);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Count のテスト
        ///</summary>
        [TestMethod()]
        public void CountTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            int actual;
            actual = target.Count;
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///IsReadOnly のテスト
        ///</summary>
        [TestMethod()]
        public void IsReadOnlyTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            bool actual;
            actual = target.IsReadOnly;
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Item のテスト
        ///</summary>
        [TestMethod()]
        public void ItemTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            PHPValue key = null; // TODO: 適切な値に初期化してください
            PHPValue expected = null; // TODO: 適切な値に初期化してください
            PHPValue actual;
            target[key] = expected;
            actual = target[key];
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Keys のテスト
        ///</summary>
        [TestMethod()]
        public void KeysTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            ICollection<PHPValue> actual;
            actual = target.Keys;
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }

        /// <summary>
        ///Values のテスト
        ///</summary>
        [TestMethod()]
        public void ValuesTest() {
            PHPArray target = new PHPArray(); // TODO: 適切な値に初期化してください
            ICollection<PHPValue> actual;
            actual = target.Values;
            Assert.Inconclusive("このテストメソッドの正確性を確認します。");
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace encrypt_decrypt.tests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
         #region Private Members
        private string DESKEY = "YEP!s8E4";

      
        private byte[] _DESkey;
        
        #endregion

        /// <summary>
        /// Constructor, very important to have these values converted to bytes in your code!
        /// </summary>
        public UnitTest1()
        {
        
            _DESkey = ASCIIEncoding.ASCII.GetBytes(DESKEY);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void DESEncryption()
        {
            Assert.AreEqual(DES.Encrypt("adventures with et rocks!", _DESkey),"N1LboTHKF5hkuJ0oum6AycE8tohUknyTMiuw1fbrJ1s=");
        }

        [TestMethod]
        public void DESDecryption()
        {
            Assert.AreEqual(DES.Decrypt("N1LboTHKF5hkuJ0oum6AycE8tohUknyTMiuw1fbrJ1s=", _DESkey), "adventures with et rocks!");
        }

    }
}

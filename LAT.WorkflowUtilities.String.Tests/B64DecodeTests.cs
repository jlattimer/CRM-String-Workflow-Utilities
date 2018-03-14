using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class B64DecodeTests
    {
        #region Test Initialization and Cleanup
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void ClassInitialize(TestContext testContext) { }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void ClassCleanup() { }

        // Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void TestMethodInitialize() { }

        // Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void TestMethodCleanup() { }
        #endregion

        [TestMethod]
        public void B64Decode_Given_EmptyString_Then_EmptyStringReturn()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToDecode", string.Empty },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<B64Decode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["B64DecodedString"]);
        }

        [TestMethod]
        public void B64Decode_Given_B64String_Then_StringReturn()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToDecode", "SGVsbG8gV29ybGQh" },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World!";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<B64Decode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["B64DecodedString"]);
        }
    }
}
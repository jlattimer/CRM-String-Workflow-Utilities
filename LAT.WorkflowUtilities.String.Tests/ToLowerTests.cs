using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class ToLowerTests
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
        public void StringNone()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToLower", "Hello World"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "hello world";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToLower>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["LoweredString"]);
        }

        [TestMethod]
        public void String_enUS()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToLower", "Hello World"}
            };
            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "hello world";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToLower>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["LoweredString"]);
        }
    }
}
using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class JoinTests
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
        public void StringStringSpace()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object> 
            {
                { "String1", "Hello"},
                { "String2", "World" },
                { "Joiner", " " }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Join>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["JoinedString"]);
        }

        [TestMethod]
        public void StringStringNull()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object> 
            {
                { "String1", "Hello"},
                { "String2", "World" },
                { "Joiner", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "HelloWorld";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Join>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["JoinedString"]);
        }
    }
}
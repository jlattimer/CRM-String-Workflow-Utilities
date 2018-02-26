using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class ToTitleCaseTests
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
        public void StringLower()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTitleCase", "hello world"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToTitleCase>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TitleCasedString"]);
        }

        [TestMethod]
        public void StringUpper()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTitleCase", "HELLO WORLD"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "HELLO WORLD";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToTitleCase>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TitleCasedString"]);
        }
        [TestMethod]
        public void StringMixed()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTitleCase", "hEllO WorLD"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ToTitleCase>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TitleCasedString"]);
        }
    }
}
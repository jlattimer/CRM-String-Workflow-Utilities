using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class StartsWithTests
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
        public void StringFoundCaseInsensitive()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello"},
                { "SearchFor", "HE" },
                { "CaseSensitive", false }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = true;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<StartsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["StartsWithString"]);
        }

        [TestMethod]
        public void StringNotFoundCaseSensitive()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello"},
                { "SearchFor", "he" },
                { "CaseSensitive", true }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = false;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<StartsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["StartsWithString"]);
        }

        [TestMethod]
        public void StringNotFound()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello"},
                { "SearchFor", "test" },
                { "CaseSensitive", false }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = false;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<StartsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["StartsWithString"]);
        }
    }
}
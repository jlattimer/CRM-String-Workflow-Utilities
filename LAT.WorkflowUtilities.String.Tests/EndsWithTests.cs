using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class EndsWithTests
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
        public void EndsWith_Case_Insensitive_String_Found()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello"},
                { "SearchFor", "LO" },
                { "CaseSensitive", false }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = true;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<EndsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["EndsWithString"]);
        }

        [TestMethod]
        public void EndsWith_Case_Sensitive_String_Not_Found()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello"},
                { "SearchFor", "Lo" },
                { "CaseSensitive", true }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = false;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<EndsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["EndsWithString"]);
        }

        [TestMethod]
        public void EndsWith_Case_Insensitive_String_Not_Found()
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
            var result = xrmFakedContext.ExecuteCodeActivity<EndsWith>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["EndsWithString"]);
        }
    }
}
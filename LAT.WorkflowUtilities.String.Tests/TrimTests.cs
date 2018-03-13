using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class TrimTests
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
        public void Trim_No_Spaces()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTrim", "Hello World" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Trim>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TrimmedString"]);
        }

        [TestMethod]
        public void Trim_Starts_With_Space()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTrim", " Hello World" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Trim>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TrimmedString"]);
        }

        [TestMethod]
        public void Trim_Ends_With_Space()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTrim", "Hello World " }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Trim>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TrimmedString"]);
        }

        [TestMethod]
        public void Trim_Starts_And_Ends_With_Spaces()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTrim", " Hello World " }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Trim>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TrimmedString"]);
        }

        [TestMethod]
        public void Trim_Null_String()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToTrim", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = null;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Trim>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["TrimmedString"]);
        }
    }
}
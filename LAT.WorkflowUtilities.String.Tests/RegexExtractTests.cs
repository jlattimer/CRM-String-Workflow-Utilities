using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RegexExtractTests
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
        public void NoMatchEmail()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test" },
                { "Pattern", @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = null;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }

        [TestMethod]
        public void OneMatchEmail()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test@test.com" },
                { "Pattern", @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "test@test.com";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }

        [TestMethod]
        public void TwoMatchEmail()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test@test.com and blah blah test2@test2.com" },
                { "Pattern", @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "test@test.com";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }

        [TestMethod]
        public void NoMatchIpAddress()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test" },
                { "Pattern", @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = null;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }

        [TestMethod]
        public void OneMatchIpAddress()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test 192.168.1.5" },
                { "Pattern", @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "192.168.1.5";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }

        [TestMethod]
        public void NoMatchInvalidIpAddress()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This is a test 300.168.1.5" },
                { "Pattern", @"\b(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = null;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexExtract>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ExtractedString"]);
        }
    }
}
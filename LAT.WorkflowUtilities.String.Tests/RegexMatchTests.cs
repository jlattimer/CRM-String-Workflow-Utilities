using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RegexMatchTests
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
        public void ContainsEmailAddress()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "test@test.com"},
                { "Pattern", @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = true;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexMatch>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ContainsPattern"]);
        }

        [TestMethod]
        public void DoesNotContainEmailAddress()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "test!test.com"},
                { "Pattern", @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = false;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexMatch>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ContainsPattern"]);
        }

        [TestMethod]
        public void ContainsUrl()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "http://www.bing.com"},
                { "Pattern", @"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = true;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexMatch>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ContainsPattern"]);
        }

        [TestMethod]
        public void ContainHtmlTag()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "<span>Hello World</span>"},
                { "Pattern", @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = true;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexMatch>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ContainsPattern"]);
        }

        [TestMethod]
        public void DoesNotContainHtmlTag()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello World"},
                { "Pattern", @"^<([a-z]+)([^<]+)*(?:>(.*)<\/\1>|\s+\/>)$" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const bool expected = false;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexMatch>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ContainsPattern"]);
        }
    }
}
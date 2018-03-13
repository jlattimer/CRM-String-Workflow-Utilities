using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RegexReplaceTests
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
        public void RegexReplace_Replace_Single()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is the first number"},
                { "ReplacementValue", "One" },
                { "Pattern", @"1" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "One is the first number";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void RegexReplace_Replace_Multiple()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is the first number, 1 is good"},
                { "ReplacementValue", "One" },
                { "Pattern", @"1" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "One is the first number, One is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void RegexReplace_Replace_Extra_White_Space()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is    the    first number,    1 is    good"},
                { "ReplacementValue", " " },
                { "Pattern", @"\s+" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1 is the first number, 1 is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void RegexReplace_Replace_Extra_White_Space_With_Null()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is    the    first number,    1 is    good"},
                { "ReplacementValue", null },
                { "Pattern", @"\s+" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1isthefirstnumber,1isgood";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void RegexReplace_Replace_Html_Tag()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "<span>Hello World</span>"},
                { "ReplacementValue", "" },
                { "Pattern", @"<[^>]*>" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void RegexReplace_Not_Replaced()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "Hello World!"},
                { "ReplacementValue", "" },
                { "Pattern", @"<[^>]*>" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World!";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }
    }
}
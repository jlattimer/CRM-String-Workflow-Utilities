using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RegexReplaceWithSpaceTests
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
        public void ReplaceSingle()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number"},
                { "NumberOfSpaces", 1 },
                { "Pattern", @"1" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "This is the first number";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceSingleWithMultipleSpaces()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number"},
                { "NumberOfSpaces", 3 },
                { "Pattern", @"1" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "This   is the first number";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceMultiple()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number,1is good"},
                { "NumberOfSpaces", 1 },
                { "Pattern", @"1" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "This is the first number, is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceExtraWhiteSpace()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is    the    first number,    1 is    good"},
                { "NumberOfSpaces", 1 },
                { "Pattern", @"\s+" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1 is the first number, 1 is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RegexReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }
    }
}
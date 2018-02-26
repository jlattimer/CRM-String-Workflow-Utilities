using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class WordCountTests
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
        public void OneWord()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToCount", "Hello"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 1;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<WordCount>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Count"]);
        }

        [TestMethod]
        public void MultipleWords()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToCount", "Hello World Test"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 3;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<WordCount>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Count"]);
        }

        [TestMethod]
        public void MultipleWordsWithTrailingSpaces()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToCount", "Hello World Test  "}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 3;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<WordCount>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["Count"]);
        }
    }
}
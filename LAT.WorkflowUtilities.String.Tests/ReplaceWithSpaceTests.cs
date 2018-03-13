using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class ReplaceWithSpaceTests
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
        public void ReplaceWithSpace_Replace_Single_Instance()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number"},
                { "ValueToReplace", "1" },
                { "NumberOfSpaces", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "This is the first number";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceWithSpace_Replace_Single_Instance_With_Null()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number"},
                { "ValueToReplace", "1" },
                { "NumberOfSpaces", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Thisis the first number";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceWithSpace_Replace_Multiple_Instances()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "This1is the first number,1is good"},
                { "ValueToReplace", "1" },
                { "NumberOfSpaces", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "This is the first number, is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }

        [TestMethod]
        public void ReplaceWithSpace_Not_Replaced()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToSearch", "1 is the first number, 1 is good"},
                { "ValueToReplace", "2" },
                { "NumberOfSpaces", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1 is the first number, 1 is good";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<ReplaceWithSpace>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["ReplacedString"]);
        }
    }
}
using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class PadRightTests
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
        public void PadRight_Single_Character_Length_0()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "0" },
                { "Length", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "123456";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRight_Single_Character_Length_1()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "0" },
                { "Length", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1234560";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRight_Single_Character_Length_5()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "0" },
                { "Length", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "12345600000";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRight_Multiple_Characters_Length_0()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "XX" },
                { "Length", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "123456";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRight_Multiple_Characters_Length_1()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "XX" },
                { "Length", 1 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "123456XX";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRight_Multiple_Characters_Length_5()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "123456"},
                { "PadCharacter", "XX" },
                { "Length", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "123456XXXXXXXXXX";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRight>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }
    }
}
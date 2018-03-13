using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class PadRightDynamicTests
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
        public void PadRightDynamic_Single_Character_Length_0()
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
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRightDynamic_Single_Character_Length_6()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "12345"},
                { "PadCharacter", "0" },
                { "Length", 6 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "123450";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRightDynamic_Single_Character_Length_8()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "1234"},
                { "PadCharacter", "0" },
                { "Length", 8 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "12340000";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRightDynamic_Multiple_Characters_Length_0()
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
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRightDynamic_Multiple_Characters_Length_6()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "12345"},
                { "PadCharacter", "XX" },
                { "Length", 6 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "12345XX";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }

        [TestMethod]
        public void PadRightDynamic_Multiple_Characters_Length_8()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToPad", "1234"},
                { "PadCharacter", "XX" },
                { "Length", 8 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "1234XXXX";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<PadRightDynamic>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PaddedString"]);
        }
    }
}
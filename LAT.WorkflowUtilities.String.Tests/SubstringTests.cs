using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class SubstringTests
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
        public void Substring_Start_0_Length_5()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToParse", "Hello World"},
                { "StartPosition", 0 },
                { "Length", 5 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Substring>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PartialString"]);
        }

        [TestMethod]
        public void Substring_Start_6_Length_Null()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToParse", "Hello World"},
                { "StartPosition", 6 },
                { "Length", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Substring>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PartialString"]);
        }

        [TestMethod]
        public void Substring_Start_Minus2_Length_Null()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToParse", "Hello World"},
                { "StartPosition", -2 },
                { "Length", 0 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Substring>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PartialString"]);
        }

        [TestMethod]
        public void Substring_Start_0_Length_100()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToParse", "Hello World"},
                { "StartPosition", 0 },
                { "Length", 100 }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Substring>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["PartialString"]);
        }
    }
}
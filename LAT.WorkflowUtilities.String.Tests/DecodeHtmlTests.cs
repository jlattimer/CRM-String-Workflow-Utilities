using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class DecodeHtmlTests
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
        public void DecodeHtml_Given_EmptyString_Then_EmptyStringReturn()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToDecode", string.Empty },
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<DecodeHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["DecodedString"]);
        }

        [TestMethod]
        public void DecodeHtml_Given_HtmlEncodedString_Then_DecodeSuccessfully()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToDecode", "Svendborg V&#230;rft A/S" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Svendborg Værft A/S";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<DecodeHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["DecodedString"]);
        }
    }
}
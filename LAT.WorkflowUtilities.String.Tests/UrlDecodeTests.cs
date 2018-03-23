using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class UrlDecodeTests
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
        public void UrlDecode_Given_EmptyString_Then_EmptyStringReturn()
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
            var result = xrmFakedContext.ExecuteCodeActivity<UrlDecode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["DecodedString"]);
        }

        [TestMethod]
        public void UrlDecode_Given_HtmlEncodedString_Then_DecodeSuccessfully()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "StringToDecode", "Seminar%20%2811-10-2017%29%3A%20Test%20foobar%20Dynamics%20365" }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Seminar (11-10-2017): Test foobar Dynamics 365";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<UrlDecode>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["DecodedString"]);
        }
    }
}
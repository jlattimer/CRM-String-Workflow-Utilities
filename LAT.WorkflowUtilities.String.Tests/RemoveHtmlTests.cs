using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RemoveHtmlTests
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
        public void RemoveHtml_Replace_Single_Tag()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "HtmlString", "<span>Hello World</span>"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RemoveHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["HtmlRemovedString"]);
        }

        [TestMethod]
        public void RemoveHtml_Replace_Multiple_Tags()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "HtmlString", "<span>Hello World</span> <span>Goodbye World</span>"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World Goodbye World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RemoveHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["HtmlRemovedString"]);
        }

        [TestMethod]
        public void RemoveHtml_Replace_Multiple_Tags_With_Line_Breaking_Tag()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "HtmlString", "<h3>Hello World</h3><span>Goodbye World</span>"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World<br />Goodbye World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RemoveHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["HtmlRemovedString"]);
        }

        [TestMethod]
        public void RemoveHtml_Clean_White_Space()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "HtmlString", "Hello World              Goodbye World"}
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const string expected = "Hello World Goodbye World";

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<RemoveHtml>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["HtmlRemovedString"]);
        }
    }
}
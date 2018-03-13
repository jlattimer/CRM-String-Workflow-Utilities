using FakeXrmEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Linq;

namespace LAT.WorkflowUtilities.String.Tests
{
    [TestClass]
    public class RandomTests
    {
        private const string Numbers = @"0123456789";
        private const string UpperCaseLetters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowerCaseLetters = @"abcdefghijklmnopqrstuvwxyz";
        private const string SpecialCharacters = @"!""#$%&'()*+,./:;<>?@[\]^_{|}~";

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
        public void Random_Has_Correct_Length()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", true },
                { "IncludeLowerCaseLetters", true },
                { "IncludeNumbers", true },
                { "IncludeSpecialCharacters", true },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            const int expected = 8;

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            Assert.AreEqual(expected, result["RandomString"].ToString().Length);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException), "Length must be greater than 0")]
        public void Random_Has_Invalid_Length()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Length", 0 },
                { "IncludeUpperCaseLetters", true },
                { "IncludeLowerCaseLetters", true },
                { "IncludeNumbers", true },
                { "IncludeSpecialCharacters", true },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidPluginExecutionException),
            "Choose to include Upper Case Letters, Lower Case Letters, Numbers, Special Characters, or supply a list of Allowed Characters")]
        public void Random_Has_Nothing_Selected()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            var inputs = new Dictionary<string, object>
            {
                { "Length", 4 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);
        }

        [TestMethod]
        public void Random_Only_Uses_Allowed_Characters_With_No_Others_Selected()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = "abcd";

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", allowedCharacters }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_Allowed_Characters_With_Others_Selected()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = "abcd";

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", true },
                { "IncludeSpecialCharacters", true },
                { "AllowedCharacters", allowedCharacters }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_UpperCase()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = UpperCaseLetters;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", true },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_LowerCase()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = LowerCaseLetters;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", true },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_Numbers()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = Numbers;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", true },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_SpecialCharacters()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = SpecialCharacters;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", true },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_Numbers_And_SpecialCharacters()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = SpecialCharacters + Numbers;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 8 },
                { "IncludeUpperCaseLetters", false },
                { "IncludeLowerCaseLetters", false },
                { "IncludeNumbers", true },
                { "IncludeSpecialCharacters", true },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Random_Only_Uses_LowerCase_And_UpperCase()
        {
            //Arrange
            XrmFakedWorkflowContext workflowContext = new XrmFakedWorkflowContext();

            const string allowedCharacters = LowerCaseLetters + UpperCaseLetters;

            var inputs = new Dictionary<string, object>
            {
                { "Length", 5 },
                { "IncludeUpperCaseLetters", true },
                { "IncludeLowerCaseLetters", true },
                { "IncludeNumbers", false },
                { "IncludeSpecialCharacters", false },
                { "AllowedCharacters", null }
            };

            XrmFakedContext xrmFakedContext = new XrmFakedContext();

            //Act
            var result = xrmFakedContext.ExecuteCodeActivity<Random>(workflowContext, inputs);

            //Assert
            bool valid = result["RandomString"].ToString().All(c => allowedCharacters.Contains(c));
            Assert.IsTrue(valid);
        }
    }
}
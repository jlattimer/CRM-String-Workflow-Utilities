using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Text;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable MemberCanBePrivate.Global

namespace LAT.WorkflowUtilities.String
{
    public class Random : WorkFlowActivityBase
    {
        public Random() : base(typeof(Random)) { }

        [RequiredArgument]
        [Input("Length")]
        public InArgument<int> Length { get; set; }

        [Input("Include Upper Case Letters")]
        [Default("True")]
        public InArgument<bool> IncludeUpperCaseLetters { get; set; }

        [Input("Include Lower Case Letters")]
        [Default("True")]
        public InArgument<bool> IncludeLowerCaseLetters { get; set; }

        [Input("Include Numbers")]
        [Default("True")]
        public InArgument<bool> IncludeNumbers { get; set; }

        [Input("Include Special Characters")]
        [Default("True")]
        public InArgument<bool> IncludeSpecialCharacters { get; set; }

        [Input("Allowed Characters")]
        public InArgument<string> AllowedCharacters { get; set; }

        [Output("Random String")]
        public OutArgument<string> RandomString { get; set; }

        protected override void ExecuteCrmWorkFlowActivity(CodeActivityContext context, LocalWorkflowContext localContext)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (localContext == null)
                throw new ArgumentNullException(nameof(localContext));

            const string numbers = @"0123456789";
            const string upperCaseLetters = @"ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowerCaseLetters = @"abcdefghijklmnopqrstuvwxyz";
            const string specialCharacters = @"!""#$%&'()*+,./:;<>?@[\]^_{|}~";

            int length = Length.Get(context);
            bool includeUpperCaseLetters = IncludeUpperCaseLetters.Get(context);
            bool includeLowerCaseLetters = IncludeLowerCaseLetters.Get(context);
            bool includeNumbers = IncludeNumbers.Get(context);
            bool includeSpecialCharacters = IncludeSpecialCharacters.Get(context);
            string allowedCharacters = AllowedCharacters.Get(context);
            if (!string.IsNullOrEmpty(allowedCharacters))
                allowedCharacters = allowedCharacters.Trim();

            if (length < 1)
                throw new InvalidPluginExecutionException("Length must be greater than 0");

            if (!includeUpperCaseLetters && !includeLowerCaseLetters && !includeNumbers && !includeSpecialCharacters && string.IsNullOrEmpty(allowedCharacters))
                throw new InvalidPluginExecutionException(
                    "Choose to include Upper Case Letters, Lower Case Letters, Numbers, Special Characters, or supply a list of Allowed Characters");

            var allowedValues = SetAllowedValues(allowedCharacters, includeLowerCaseLetters, lowerCaseLetters,
                includeUpperCaseLetters, upperCaseLetters, includeNumbers, numbers, includeSpecialCharacters, specialCharacters);

            var result = GenerateRandom(length, allowedValues);

            RandomString.Set(context, result.ToString());
        }

        private static string SetAllowedValues(string allowedCharacters, bool includeLowerCaseLetters, string lowerCaseLetters,
            bool includeUpperCaseLetters, string upperCaseLetters, bool includeNumbers, string numbers,
            bool includeSpecialCharacters, string specialCharacters)
        {
            string allowedValues = string.Empty;
            if (!string.IsNullOrEmpty(allowedCharacters))
            {
                allowedValues = allowedCharacters;
            }
            else
            {
                if (includeLowerCaseLetters)
                    allowedValues += lowerCaseLetters;
                if (includeUpperCaseLetters)
                    allowedValues += upperCaseLetters;
                if (includeNumbers)
                    allowedValues += numbers;
                if (includeSpecialCharacters)
                    allowedValues += specialCharacters;
            }

            return allowedValues;
        }

        private static StringBuilder GenerateRandom(int length, string allowedValues)
        {
            StringBuilder result = new StringBuilder();
            System.Random rnd = new System.Random();
            while (0 < length--)
            {
                result.Append(allowedValues[rnd.Next(allowedValues.Length)]);
            }

            return result;
        }
    }
}
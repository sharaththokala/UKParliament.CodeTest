using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Services.Validations
{
    public class ValidNameAttribute : ValidationAttribute
    {
        public ValidNameAttribute()
        {
            ErrorMessage = $"Invalid name.";
        }
        public ValidNameAttribute(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public override bool IsValid(object value)
        {
            var inputValue = value?.ToString();

            if (inputValue != null)
            {
                var invalidLists = new[] { "test" };

                foreach (var item in invalidLists)
                {
                    if (inputValue.Contains(item, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace UKParliament.CodeTest.Services.Validations;

public class NotInFutureDateAttribute : ValidationAttribute
{
    public NotInFutureDateAttribute()
    {
        ErrorMessage = $"The date cannot be in the future.";
    }

    public NotInFutureDateAttribute(string errorMessage)
    {
        ErrorMessage = errorMessage;
    }

    public override bool IsValid(object? value)
    {
        if (value != null)
        {
            var inputValue = value.ToString();

            if(DateTime.TryParse(inputValue, out var inputDate) &&
                inputDate > DateTime.Today) {
                return false;
            }
        }

        return true;
    }
}

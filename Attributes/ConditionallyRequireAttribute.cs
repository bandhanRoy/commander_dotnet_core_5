using System.ComponentModel.DataAnnotations;

namespace Commander.Attributes
{
    public class ConditionallyRequireAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var val = value as string;
            return val == "" ? new ValidationResult(validationContext.MemberName + "cannot be empty.") : ValidationResult.Success;
        }
    }
}

// ** Follow the below line for validation
// ** https://stackoverflow.com/questions/20642328/how-to-put-conditional-required-attribute-into-class-property-to-work-with-web-a
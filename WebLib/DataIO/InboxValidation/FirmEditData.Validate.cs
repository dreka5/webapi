using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebLib
{
    public partial class FirmEditData: IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var errors = new List<ValidationResult>();
            //                 throw new ICallValidationException(nameof(name), "Заполните ");
            return errors;
        }
    }
}
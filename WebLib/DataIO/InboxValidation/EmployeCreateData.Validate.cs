using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebLib.TechData.Error;

namespace WebLib
{
    public partial class EmployeCreateData: IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CheckData.Name(nameof(this.name),name,3,50);
            CheckData.Name(nameof(this.surName),surName, 3, 50);
            var errors = new List<ValidationResult>();
            return errors;
        }
    }
}
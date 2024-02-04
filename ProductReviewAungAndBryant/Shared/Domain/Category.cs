using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class Category : BaseDomainModel, IValidatableObject
    {
        [Required(ErrorMessage= "Please insert the category name.")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Please insert the category brand name name.")]
        public string CategoryBrandName { get; set; }

        public virtual List<CategoryPcPart>? CategoryPcParts { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(CategoryName))
            {
                yield return new ValidationResult("Please insert the values");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class PcPart : BaseDomainModel
    {       
        [Required(ErrorMessage ="Please insert the PcPart Name")]
        public string PcPartName { get; set; }

        [Required]
        [Range(0.01, float.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public float PcPartPrice { get; set; }

        public virtual List<CategoryPcPart>? CategoryPcParts { get; set; }

        //public virtual List<Review>? Reviews { get; set; }

        public virtual List<PcPartImage>? PcPartImages { get; set;}
    }
}

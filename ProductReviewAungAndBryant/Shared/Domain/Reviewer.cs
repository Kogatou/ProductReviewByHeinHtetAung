using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class Reviewer :BaseDomainModel
    {        
        public string ReviewerName { get; set; }

       public string? ReviewerEmail { get; set;}

       public virtual List<Review>? Reviews { get; set;}
    }
}

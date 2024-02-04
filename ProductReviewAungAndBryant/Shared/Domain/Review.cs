using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class Review : BaseDomainModel
    {        
        public string Name { get; set; }

        public string ReviewText {  get; set; }

        public DateTime ReviewDate { get; set; }

        public int PcPartId { get; set; }

        public int ReviewerId { get; set; }

        public virtual PcPart? PcPart { get; set; }

        public virtual Reviewer? Reviewer { get; set; }
    }
}

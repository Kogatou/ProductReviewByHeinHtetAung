using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class CategoryPcPart : BaseDomainModel
    {
        public int CategoryId { get; set; }
        public int PcPartId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual PcPart? PcPart { get; set; }
    }
}

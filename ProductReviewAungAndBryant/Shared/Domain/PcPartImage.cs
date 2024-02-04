using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.Domain
{
    public class PcPartImage : BaseDomainModel
    {
        public string base64data { get; set; }

        public string contentType { get; set; }

        public string fileName { get; set; }

        public int PcPartId { get; set; }

        public virtual PcPart? PcPart { get; set; }
    }
}

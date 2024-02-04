using ProductReviewAungAndBryant.Shared.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductReviewAungAndBryant.Shared.ViewModel
{
    public class PcpartViewModel
    {
        public string PcPartName { get; set; }

        public float PcPartPrice { get; set; }

        public List<Category>? Categories { get; set; }
    }
}

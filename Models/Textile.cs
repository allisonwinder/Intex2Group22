using System;
using System.Collections.Generic;

namespace Intex2Group22.Models
{
    public partial class Textile
    {
        public long Id { get; set; }
        public string? Locale { get; set; }
        public int? Textileid { get; set; }
        public string? Description { get; set; }
        public string? Burialnumber { get; set; }
        public string? Estimatedperiod { get; set; }
        public DateTime? Sampledate { get; set; }
        public DateTime? Photographeddate { get; set; }
        public string? Direction { get; set; }
    }
}

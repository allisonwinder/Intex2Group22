using System;
using System.Collections.Generic;

namespace Intex2Group22.Models
{
    public partial class Biological
    {
        public long Id { get; set; }
        public int? Racknumber { get; set; }
        public int? Bagnumber { get; set; }
        public string? Previouslysampled { get; set; }
        public string? Initials { get; set; }
        public int? Clusternumber { get; set; }
        public DateTime? Date { get; set; }
        public string? Notes { get; set; }
    }
}

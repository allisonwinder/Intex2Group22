using System;
using System.Collections.Generic;

namespace Intex2Group22.Models
{
    public partial class Photodatum
    {
        public long Id { get; set; }
        public string? Description { get; set; }
        public string? Filename { get; set; }
        public int? Photodataid { get; set; }
        public DateTime? Date { get; set; }
        public string? Url { get; set; }
    }
}

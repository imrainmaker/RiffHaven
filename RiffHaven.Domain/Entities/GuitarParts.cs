using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiffHaven.Domain.Entities
{
    public class GuitarParts
    {
        public List<string> Brands { get; set; }
        public List<string> Colors { get; set;}
        public List<string> Styles { get; set;}
        public List<string> Pickups { get; set; }
        public List<int> Scales { get; set;}
        public List<int> Frets { get; set;}
        public List<string> Tremolos { get; set;}
        public List<string> Woods { get; set;}
    }
}

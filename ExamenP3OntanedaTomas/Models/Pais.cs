using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenP3OntanedaTomas.Models
{
    public class NativeName
    {
        public string Official { get; set; }
        public string Common { get; set; }
    }

    public class Name
    {
        public string Common { get; set; }
        public string Official { get; set; }
        public Dictionary<string, NativeName> NativeName { get; set; }
    }

    public class Maps
    {
        public string GoogleMaps { get; set; }
        public string OpenStreetMaps { get; set; }
    }

    public class Pais
    {
        public Name Name { get; set; }
        public string Region { get; set; }
        public Maps Maps { get; set; }
    }

}

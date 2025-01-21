using SQLite;

namespace ExamenP3OntanedaTomas.Models
{
    public class PaisDB
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NombreComun { get; set; }
        public string NombreOficial { get; set; }
        public string Region { get; set; }
        public string GoogleMaps { get; set; }
        public string OpenStreetMaps { get; set; }
        public string NombreUsuario { get; set; }
    }

}

using ExamenP3OntanedaTomas.Models;
using ExamenP3OntanedaTomas.Repositories;
using System.Collections.ObjectModel;

namespace ExamenP3OntanedaTomas
{
    public partial class MainPage : ContentPage
    {
        PaisAPIRepository _paisAPIRepository;
        PaisSQLite _paisDatabase;
        ObservableCollection<Pais> paises = new ObservableCollection<Pais>();

        public MainPage()
        {
            InitializeComponent();
            _paisAPIRepository = new PaisAPIRepository();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Paises.db3");
            _paisDatabase = new PaisSQLite(dbPath);
        }

        private async void BuscarAPIClicked(object sender, EventArgs e)
        {
            string prompt = TOPrompt.Text;
            var paises = (await _paisAPIRepository.DevuelvePaisAsync(prompt)).ToList();
            var primerPais = paises.FirstOrDefault();
            if (primerPais != null)
            {
                var paisDB = new PaisDB
                {
                    NombreComun = primerPais.Name.Common,
                    NombreOficial = primerPais.Name.Official,
                    Region = primerPais.Region,
                    GoogleMaps = primerPais.Maps.GoogleMaps,
                    OpenStreetMaps = primerPais.Maps.OpenStreetMaps
                };
                await _paisDatabase.GuardarPaisAsync(paisDB);
                BindingContext = paisDB;
            }
        }

    }
}

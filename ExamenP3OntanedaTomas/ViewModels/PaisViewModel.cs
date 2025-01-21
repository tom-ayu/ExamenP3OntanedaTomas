using ExamenP3OntanedaTomas.Models;
using ExamenP3OntanedaTomas.Repositories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenP3OntanedaTomas.ViewModels
{
    public class PaisViewModel : INotifyPropertyChanged
    {
        private string _prompt;
        private PaisDB _paisSelec;

        public ObservableCollection<PaisDB> Paises { get; set; }
        public PaisAPIRepository PaisAPIRepository { get; set; }
        public PaisSQLite paisSQLite { get; set; }

        public string Prompt
        {
            get => _prompt;
            set
            {
                _prompt = value;
                OnPropertyChanged();
            }
        }

        public PaisDB paisSelec
        {
            get => _paisSelec;
            set
            {
                _paisSelec = value;
                OnPropertyChanged();
            }
        }

        public PaisViewModel()
        {
            PaisAPIRepository = new PaisAPIRepository();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Paises.db3");
            paisSQLite = new PaisSQLite(dbPath);
            Paises = new ObservableCollection<PaisDB>();
        }

        public async Task BuscarPaisAsync()
        {
            try
            {
                var paises = (await PaisAPIRepository.DevuelvePaisAsync(Prompt)).ToList();
                if (paises.Any())
                {
                    var primerPais = paises.First();
                    var paisDB = new PaisDB
                    {
                        NombreOficial = primerPais.Name.Official,
                        Region = primerPais.Region,
                        GoogleMaps = primerPais.Maps.GoogleMaps,
                        OpenStreetMaps = primerPais.Maps.OpenStreetMaps,
                        NombreUsuario = "TOntaneda"
                    };

                    await paisSQLite.GuardarPaisAsync(paisDB);
                    paisSelec = paisDB;
                    Paises.Add(paisDB);
                }
                else
                {
                    Prompt = "No se encontraron países.";
                }
            }catch(Exception ex)
            {
                Prompt = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

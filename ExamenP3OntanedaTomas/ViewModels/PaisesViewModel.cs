using ExamenP3OntanedaTomas.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ExamenP3OntanedaTomas.ViewModels
{
    public class PaisesViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PaisDB> _paises;
        private PaisSQLite _paisSQLite;

        public ObservableCollection<PaisDB> Paises
        {
            get => _paises;
            set
            {
                _paises = value;
                OnPropertyChanged();
            }
        }

        public PaisesViewModel()
        {
            _paises = new ObservableCollection<PaisDB>();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Paises.db3");
            _paisSQLite = new PaisSQLite(dbPath);
            LoadPaisesAsync();
        }

        private async Task LoadPaisesAsync()
        {
            var paises = await _paisSQLite.GetPaisesAsync();
            foreach (var pais in paises)
            {
                Paises.Add(pais);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

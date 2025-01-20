using ExamenP3OntanedaTomas.Models;
using ExamenP3OntanedaTomas.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenP3OntanedaTomas.ViewModels
{
    public class PaisViewModel : INotifyPropertyChanged
    {
        private List<Pais> _pais;
        private PaisAPIRespository _paisAPIRepository;

        public List<Pais> pais
        {
            get => _pais;
            set
            {
                if (_pais != value)
                {
                    _pais = value;
                    //OnPropertyChanged();
                }
            }
        }

        public ICommand CommandGuardarPais { get; set; }
        public event Action ShowAlert;

        public PaisViewModel()
        {
            CommandGuardarPais = new Command(GuardarPais);
        }

        public async void GuardarPais()
        {
            Pais pais = new Pais();

            _paisAPIRepository = new PaisAPIRespository();

        }



        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

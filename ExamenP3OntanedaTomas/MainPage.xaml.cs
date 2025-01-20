
using ExamenP3OntanedaTomas.Models;
using ExamenP3OntanedaTomas.Repositories;
using System.Collections.ObjectModel;

namespace ExamenP3OntanedaTomas
{
    public partial class MainPage : ContentPage
    {
        PaisAPIRespository _paisAPIRepository;
        Pais pais = new Pais();
        ObservableCollection<Pais> paises = new ObservableCollection<Pais>();
        public MainPage()
        {
            _paisAPIRepository = new PaisAPIRespository();   
            InitializeComponent();

 
        }
        private void BuscarAPIClicked(object sender, EventArgs e)
        {
            string _prompt = TO_prompt.Text;
            var pais = _paisAPIRepository.DevuelvePais(_prompt).ToList();
            BindingContext = this;
        }

        private void BorrarCampoClicked(object sender, EventArgs e)
        {

        }
    }

}

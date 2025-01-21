using ExamenP3OntanedaTomas.ViewModels;

namespace ExamenP3OntanedaTomas
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new PaisViewModel();
        }

        private async void BuscarAPIClicked(object sender, EventArgs e)
        {
            var vm = BindingContext as PaisViewModel;
            if (vm != null) 
            {
                await vm.BuscarPaisAsync();
            }
        }
    }
}

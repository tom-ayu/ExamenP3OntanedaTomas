namespace ExamenP3OntanedaTomas
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void BuscarAPIClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                TOBuscarAPI.Text = $"Clicked {count} time";
            else
                TOBuscarAPI.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(TOBuscarAPI.Text);
        }
    }

}

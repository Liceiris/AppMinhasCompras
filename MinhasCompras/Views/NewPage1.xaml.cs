namespace MinhasCompras.Views;

public partial class NewPage1 : ContentPage
{
    public NewPage1() // Corrigido o nome do construtor para corresponder ao nome da classe
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            DateTime inicio = dt_inicio.Date;
            DateTime fim = dt_fim.Date;

            var produtos = await App.Db.GetAll();

            var filtrados = produtos
                .Where(p => p.DataCadastro >= inicio && p.DataCadastro <= fim)
                .OrderBy(p => p.DataCadastro)
                .ToList();

            lst_relatorio.ItemsSource = filtrados;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}
    

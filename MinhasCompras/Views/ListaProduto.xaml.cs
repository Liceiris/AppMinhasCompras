using MinhasCompras.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace MinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
	ObservableCollection<Produto> lista= new ObservableCollection<Produto>();
    public ListaProduto()
	{
		InitializeComponent();

		lst_produtos.ItemsSource = lista;
    }
	List<Produto> listaOriginal = new List<Produto>();
    protected async	override void OnAppearing() 
	{
		lista.Clear();
		listaOriginal = await App.Db.GetAll();
		listaOriginal.ForEach(i => lista.Add(i));
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {
		try
		{
			Navigation.PushAsync(new Views.NovoProduto());

		}
		catch (Exception ex)
		{
			DisplayAlert("Ops", ex.Message, "OK");
		}

    }

    private  void	txt_search_TextChanged(object sender, TextChangedEventArgs e)
    {
        string query = e.NewTextValue?.ToLower() ?? "";
        var filtrados = listaOriginal
                        .Where(p => p.Descricao.ToLower().Contains(query))
                        .ToList();

        lista.Clear();
        filtrados.ForEach(p => lista.Add(p));
    }

    private void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
		double soma = lista.Sum(i => i.Total);

		string msg = $"O total da compra é {soma:C}";
	DisplayAlert("Total", msg, "OK");
    }

    private void MenuItem_Clicked(object sender, EventArgs e)
    {

    }
}
using MinhasCompras.Models;
using System.Threading.Tasks;

namespace MinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
	public NovoProduto()
	{
		InitializeComponent();
	}

    private async void ToolbarItem_Clicked_1(object sender, EventArgs e)
    {
        try
        {
            Produto p = new Produto
            {
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text)
            };

            await App.Db.Insert(p);
            await DisplayAlert("Sucesso!", "O Registro foi inserido", "OK");
            await Navigation.PopAsync();


        }
        catch(Exception ex)
        {
             await DisplayAlert("OPS", ex.Message, "OK");
        }
        
    }
}
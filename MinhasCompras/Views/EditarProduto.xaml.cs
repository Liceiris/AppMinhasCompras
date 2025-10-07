using MinhasCompras.Models;

namespace MinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
  
    public EditarProduto()
    {
        InitializeComponent();
    }

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        try
        {
            Produto produto_anexado = BindingContext as Produto;

            Produto p = new Produto
            {
                Id = produto_anexado.Id,
                Descricao = txt_descricao.Text,
                Quantidade = Convert.ToDouble(txt_quantidade.Text),
                Preco = Convert.ToDouble(txt_preco.Text),
                DataCadastro = dtp_dataCompra.Date,
            };

            await App.Db.Update(p);
            await DisplayAlert("Sucesso!", " Registro atualizado", "OK");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("OPS", ex.Message, "OK");
        }
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        Produto produto = BindingContext as Produto;
        if (produto != null)
            dtp_dataCompra.Date = produto.DataCadastro;
    }

}

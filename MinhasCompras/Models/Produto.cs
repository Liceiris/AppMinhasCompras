using SQLite;

namespace MinhasCompras.Models
{
    public class Produto
    {

        string _descricao;

        [PrimaryKey, AutoIncrement]

        public int Id { get; set; }
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (value == null)
                {
                    throw new Exception("A descrição é obrigatória");
                }

                _descricao = value;

            }
        }

        private double _quantidade;
        public double Quantidade
        {

            get => _quantidade;
            set
            {
                if (value < 0)
                {
                    throw new Exception("A quantidade não pode ser negativa");
                }
                _quantidade = value;
            }
        }
        private double _preco;
        public double Preco
        {
            get => _preco;
            set
            {
                if (value < 0)
                {
                    throw new Exception("O preço não pode ser negativo");
                }
                _preco = value;
            }
        }

        public double Total
        {
            get => Quantidade * Preco;
        }
        public DateTime DataCadastro { get; internal set; }
    }
}
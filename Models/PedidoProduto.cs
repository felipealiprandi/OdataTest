using System.ComponentModel.DataAnnotations;

namespace OdataTest.Models
{
    public class PedidoProduto
    {
        public int ID { get; set; }
        public int Pedido { get; set; }
        public int Produto { get; set; }

    }
}

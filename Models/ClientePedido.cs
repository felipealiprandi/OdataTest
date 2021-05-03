using System.ComponentModel.DataAnnotations;

namespace OdataTest.Models
{
    public class ClientePedido
    {
        public int ID { get; set; }
        public int Cliente { get; set; }
        public int Pedido { get; set; }

    }
}

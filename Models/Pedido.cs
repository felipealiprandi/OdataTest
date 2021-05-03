using System.ComponentModel.DataAnnotations;
using System;
namespace OdataTest.Models
{
    public class Pedido
    {
        public int ID { get; set; }
        public DateTime DataPedido { get; set; }
        public Double Total { get; set; }

    }
}

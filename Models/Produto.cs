using System.ComponentModel.DataAnnotations;
namespace OdataTest.Models
{
    public class Produto
    {
        public int ID { get; set; }
        
        [StringLength(int.MaxValue)]
        public string Nome { get; set; }
    }
}

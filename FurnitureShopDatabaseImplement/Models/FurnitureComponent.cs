using System.ComponentModel.DataAnnotations;

namespace FurnitureShopDatabaseImplement.Models
{
    public class FurnitureComponent
    {
        public int Id { get; set; }
        public int FurnitureId { get; set; }
        public int ComponentId { get; set; }
        [Required] public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Furniture Furnitures { get; set; }
    }
}
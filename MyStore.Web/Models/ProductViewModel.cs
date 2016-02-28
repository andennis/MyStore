using System.ComponentModel.DataAnnotations;
using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class ProductViewModel : BaseViewModel
    {
        public override int EntityId => ProductId;

        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Price, $")]
        public decimal? Price { get; set; }

        public string Description { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class BasketItemViewModel : BaseViewModel
    {
        public override int EntityId => BasketItemId;
        public override string DisplayName => "Basket Item";

        public int BasketItemId { get; set; }

        public int ClientId { get; set; }

        public int ProductId { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Product Price")]
        public string ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Amount should be a numeric value")]
        public int? Amount { get; set; }

    }
}

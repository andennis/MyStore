using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class OrderItemViewModel : BaseViewModel
    {
        public override int EntityId => OrderItemId;
        public override string DisplayName => "Order Item";

        public int OrderItemId { get; set; }

        public int OrderId { get; set; }

        [Required]
        public int? ProductId { get; set; }
        public IEnumerable<SelectListItem> Products { get; set; }
        public string ProductName { get; set; }

        [Display(Name = "Product Price, $")]
        public decimal ProductPrice { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Amount should be a numeric value")]
        public int? Amount { get; set; }

        [Display(Name = "Total Price, $")]
        public decimal TotalPrice { get; set; }

        public string Comment { get; set; }
    }
}
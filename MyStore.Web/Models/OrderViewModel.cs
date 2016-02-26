using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class OrderViewModel : BaseViewModel
    {
        public override int EntityId => OrderId;

        public int OrderId { get; set; }

        [Display(Name = "Ref Number")]
        public string OrderRefNumber { get; set; }

        public string Comment { get; set; }

        [Display(Name = "Client Name")]
        [Required]
        public int? ClientId { get; set; }

        [Display(Name = "Client Name")]
        public string ClientName { get; set; }

        public IEnumerable<SelectListItem> Clients { get; set; }

    }
}
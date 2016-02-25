﻿using System.ComponentModel.DataAnnotations;
using MyStore.Web.Common;

namespace MyStore.Web.Models
{
    public class ClientViewModel : BaseViewModel
    {
        public override int EntityId => ClientId;

        public int ClientId { get; set; }
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FullName => FirstName + " " + LastName;

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
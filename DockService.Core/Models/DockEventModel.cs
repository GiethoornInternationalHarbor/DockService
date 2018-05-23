using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DockService.Core.Models
{
    public class DockEventModel
    {
        [Required]
        public Guid ShipId { get; set; }
        [Required]
        public Guid CustomerId { get; set; }
    }
}

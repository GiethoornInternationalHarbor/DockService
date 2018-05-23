using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace DockService.Core.Models
{
   public class Ship
    {
        [Key]
        [IgnoreDataMember]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid DBKey { get; set; }
        [Required]
        public Guid Id { get; set; }
    }
}

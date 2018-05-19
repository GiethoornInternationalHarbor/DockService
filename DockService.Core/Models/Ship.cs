using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DockService.Core.Models
{
   public class Ship
    {

        [Key]
        public string Serial { get; set; }
        public string Name { get; set; }

        [IgnoreDataMember]
        public ShipType ShipType { get; set; }
        public DockingStatus DockingStatus { get; set; }
    }
}

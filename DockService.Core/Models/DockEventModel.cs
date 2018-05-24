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

		/// <summary>
		/// Gets or sets the name of the ship.
		/// </summary>
		public string ShipName { get; set; }

		/// <summary>
		/// Gets or sets the containers that are on the ship.
		/// </summary>
		public IEnumerable<Container> Containers { get; set; }
	}
}

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
		[Required]
		public Guid CustomerId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }
	}
}

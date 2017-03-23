using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebIP.Models
{
    public class Networking
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Network { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
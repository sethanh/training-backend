using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webapi.Models
{
    public class Phone
    {
        [Key]
        public long Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
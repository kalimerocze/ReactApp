using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReactApp.Models.Data
{
    /// <summary>
    /// Entita zaměstnance
    /// </summary>
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Surname { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Position { get; set; }

        [Column(TypeName = "nvarchar(10)")]
        public string ExpiryDateOfContract { get; set; }
    }
}

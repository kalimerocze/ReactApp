using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp.Models.Data
{
    /// <summary>
    /// Entita aktivita
    /// </summary>

    public class Activity
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Nazev { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Popis { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp.Models.Data
{
    /// <summary>
    /// Entita skupin uživatelů
    /// </summary>

    public class UserGroup
    {

        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Description { get; set; }




    }
}

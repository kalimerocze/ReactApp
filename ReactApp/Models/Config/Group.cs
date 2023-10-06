using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp.Models.Config
{
    public class Group : BaseEntity
    {
        ///hodnota muže být null nebo mít řetězec
        public string? Name { get; set; }
        [NotMapped]
        // Many-to-many relationship
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    }
    // Další vlastnosti
}


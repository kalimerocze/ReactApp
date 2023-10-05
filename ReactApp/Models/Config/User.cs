using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactApp.Models.Config
{
    public class User : BaseEntity
    {
        ///hodnota muže být null nebo mít řetězec
        public string? Name { get; set; }
        public string? Login { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public bool ActiveUser { get; set; }

        //list skupin
        [NotMapped]
        public List<string> Roles { get; set; } = new List<string>();
        //list skupin
        // Many-to-many relationship// Many-to-many relationship
        public ICollection<UserGroup> UserGroups { get; set; } = new List<UserGroup>();
    // Property to store selected group IDs
    [NotMapped]
    public List<int> SelectedGroups { get; set; } = new List<int>();
    // Další vlastnosti
}
}


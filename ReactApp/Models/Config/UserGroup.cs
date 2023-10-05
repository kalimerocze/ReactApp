namespace ReactApp.Models.Config
{
    //vazební tabulka
    public class UserGroup:BaseEntity
    {

            public int UserId { get; set; }
            public User User { get; set; }

            public int GroupId { get; set; }
            public Group Group { get; set; }
    }
}

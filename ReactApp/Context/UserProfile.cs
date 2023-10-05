using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using ReactApp.Models.Config;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ReactApp.Context
{
    public class UserProfile
    {
        public User User { get; set; } = new User();
        private readonly ApplicationContext _apx;
        public UserProfile(ApplicationContext apx, string name)
        { 
            _apx = apx;
            LoadUser(name);
            
        }

        protected void LoadUser(string login, User user = null) {
            var currentUser = _apx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb").UserSets.FirstOrDefault(x => x.Login == login);
            var userGroups = _apx.DbContexts.GetDbContext<ConfigDbContext>("ConfigDb")
    .GroupSets
    .Where(ug => ug.Id == currentUser.Id) // Předpokládáme, že 'Id' je identifikátor uživatele.
    .Select(ug => ug.Name)
    .ToList();


            if (currentUser == null)
            {
                User.Login = "no login";
                User.Email = "no email";
                User.Name = "Anonymous user";
                return;

            }
            User = currentUser;
        }
    }
}

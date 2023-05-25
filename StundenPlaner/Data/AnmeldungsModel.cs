using Microsoft.AspNetCore.Components;
using StundenPlanerDB.Models;

namespace StundenPlaner.Data
{
    public class AnmeldungsModel
    {
        public SP_Context context;
        public string Benutzername { get; set; }
        public string Passwort { get; set; }
        private readonly NavigationManager _navigationManager;



        public AnmeldungsModel(SP_Context Context, NavigationManager navigationManager)
        {
            context = Context;
            _navigationManager = navigationManager;
        }

        public void Anmelden()
        {

            string hashedpassword = context.Users.Where(u => u.UserName == Benutzername).Select(u=> u.HashedPassword).Single();
            PasswordHasher hasher = new PasswordHasher();
            bool passwordMatch = hasher.VerifyPassword(Passwort, hashedpassword);

            if (passwordMatch)
            {
                _navigationManager.NavigateTo("/stundenplan");
            }
            else
            {
                
            }
        }
    }
}

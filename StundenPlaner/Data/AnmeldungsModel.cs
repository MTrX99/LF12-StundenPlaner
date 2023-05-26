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

        public string Error { get; set; }

        public AnmeldungsModel(SP_Context Context, NavigationManager navigationManager)
        {
            context = Context;
            _navigationManager = navigationManager;
        }

        public void Anmelden()
        {
            if (!string.IsNullOrEmpty(Benutzername) || !string.IsNullOrEmpty(Passwort))
            {
                string? hashedpassword = context.Users.Where(u => u.UserName == Benutzername).Select(u => u.HashedPassword).SingleOrDefault();
                if (hashedpassword != null)
                {

                PasswordHasher hasher = new PasswordHasher();
                bool passwordMatch = hasher.VerifyPassword(Passwort, hashedpassword);

                if (passwordMatch)
                {
                    _navigationManager.NavigateTo("/stundenplan");
                }
                    else
                    {
                        Error = "Benutzername oder Passwort ist falsch";
                    }
                }
                else
                {
                    Error = "Benutzername oder Passwort ist falsch";
                }
            }
        }
    }
}

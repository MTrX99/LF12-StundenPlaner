using Microsoft.AspNetCore.Components;
using StundenPlanerDB.Models;

namespace StundenPlaner.Data
{
    public class RegistrierungsModel
    {
        public SP_Context context;
        private readonly NavigationManager _navigationManager;

        public string Benutzername { get; set; }
        public string Passwort { get; set; }

        public string Error { get; set; }
        public RegistrierungsModel(SP_Context Context, NavigationManager navigationManager)
        {
            context = Context;
            _navigationManager = navigationManager;
        }

        public void Registrieren()
        {

            if (!string.IsNullOrEmpty(Benutzername)|| !string.IsNullOrEmpty(Passwort))
            {
                if (!context.Users.Any(u => u.UserName == Benutzername))
                {

                PasswordHasher hasher = new PasswordHasher();
                context.Users.Add(new User {UserName = Benutzername ,HashedPassword = hasher.HashPassword(Passwort) });
                context.SaveChanges();
                    Error = default;
                    _navigationManager.NavigateTo("/anmeldung");
                }
                else
                {
                    Error = "Benutzername ist schon benutzt";
                }
            }
        }
    }
}

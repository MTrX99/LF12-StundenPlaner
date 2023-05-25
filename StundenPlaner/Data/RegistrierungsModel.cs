using StundenPlanerDB.Models;

namespace StundenPlaner.Data
{
    public class RegistrierungsModel
    {
        public SP_Context context;
        public string Benutzername { get; set; }
        public string Passwort { get; set; }

        public RegistrierungsModel(SP_Context Context)
        {
            context = Context;
        }

        public void Registrieren()
        {

            if (!string.IsNullOrEmpty(Benutzername)|| !string.IsNullOrEmpty(Passwort))
            {
            PasswordHasher hasher = new PasswordHasher();
            context.Users.Add(new User {UserName = Benutzername ,HashedPassword = hasher.HashPassword(Passwort) });
                context.SaveChanges();
            }
        }
    }
}

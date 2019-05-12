/* Données nécessaire pour le login d'une logopède utilisatrice
de l'application dans la partie front end. */

namespace Logotech.API.Dtos
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
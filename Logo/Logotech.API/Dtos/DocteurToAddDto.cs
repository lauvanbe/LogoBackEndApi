/* Données nécessaire pour l'ajout d'un docteur dans la partie front end. */

using Logotech.API.Models;

namespace Logotech.API.Dtos
{
    public class DocteurToAddDto
    {
        public int Id { get; set; }
        public int Inami { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Email { get; set; }
        public int TelFixe { get; set; }
        public int Gsm { get; set; }
        public string Specialisation { get; set; }
        public string Fonction { get; set; }       
    }
}
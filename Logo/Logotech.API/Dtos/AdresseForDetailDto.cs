/* Données nécessaire pour l'affichage de l'adresse dans la partie front end. */

namespace Logotech.API.Dtos
{
    public class AdresseForDetailDto
    {
        public int Id { get; set; }
        public string Rue { get; set; }
        public int NumeroRue { get; set; }
        public int? BoitePostal { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public string Pays { get; set; }        
    }
}
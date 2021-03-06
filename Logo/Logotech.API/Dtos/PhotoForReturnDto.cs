/* Données nécessaire pour l'affichage d'une photo
d'un patient dans la partie front end. */

using System;

namespace Logotech.API.Dtos
{
    public class PhotoForReturnDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }      
    }
}
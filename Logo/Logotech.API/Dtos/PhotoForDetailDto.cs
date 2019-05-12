/* Données nécessaire pour laffichage du détail de la photo 
d'un patient dans la partie front end. */

using System;

namespace Logotech.API.Dtos
{
    public class PhotoForDetailDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public bool IsMain { get; set; }
    }
}
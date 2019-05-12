/* Données nécessaire pour l'ajout d'une photo liée a 
un patient dans la partie front end. */

using System;
using Microsoft.AspNetCore.Http;

namespace Logotech.API.Dtos
{
    public class PhotoForCreationDto
    {
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string PublicId { get; set; }

        public PhotoForCreationDto()
        {
            DateAdded = DateTime.Now;
        }

    }
}
/* Cette classe reprends les données nécessaires pour la connection au compte
Cloudinary. Celui-ci nous sert a stocker les photos des patients plutôt que de 
les enregistrer sur notre base de données */

namespace Logotech.API.Helpers
{
    public class CloudinarySettings
    {
       public string CloudName { get; set; }
       public string ApiKey { get; set; }
       public string ApiSecret { get; set; } 
    }
}
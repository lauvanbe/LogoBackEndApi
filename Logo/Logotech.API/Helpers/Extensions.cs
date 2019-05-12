using Microsoft.AspNetCore.Http;

/* Classe permettant la transmission des erreurs de l'API back end vers la partie front end Angular. 
Ceci permet un meilleur contrôle des erreurs, 
et aussi permet de mieux les personnalisées par la transmission d'un message */

namespace Logotech.API.Helpers
{
    public static class Extensions
    {
        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("Access-Control-Expose-Headers", "Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}
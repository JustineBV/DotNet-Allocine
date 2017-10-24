using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Allociné.Model;
using Windows.UI.Popups;

namespace Allociné.Service
{
    public class WSService
    {

            static HttpClient client = new HttpClient();
            private static WSService _wsService;


            // Fonction pour garder le pattern du singleton en instanciant qu'une seule fois WSService.
            public static WSService GetInstance()
            {
                if (_wsService == null)
                {
                    client.BaseAddress = new Uri("http://localhost:62447/api/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    _wsService = new WSService();
                }
                return _wsService;
            }

            private WSService()
            {
            }


            public async Task<T_E_COMPTE_CPT> GetCompteMailAsync(string email)
            {
                T_E_COMPTE_CPT compteRecherche = new T_E_COMPTE_CPT();
                HttpResponseMessage response = await client.GetAsync(string.Concat("Compte?email=", email));
                if (response.IsSuccessStatusCode)
                {
                    compteRecherche = await response.Content.ReadAsAsync<T_E_COMPTE_CPT>();
                }
                return compteRecherche;
            }


            public async Task<T_E_COMPTE_CPT> PostCompteAsync(T_E_COMPTE_CPT cptNew)
            {
                try
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync("Compte/", cptNew);
                }
                catch(Exception e)
                {   
                    var messageDialog = new MessageDialog("Problème lors de l'ajout de l'utilisateur");
                    await messageDialog.ShowAsync();
                }
                return cptNew;

        }


    }
}

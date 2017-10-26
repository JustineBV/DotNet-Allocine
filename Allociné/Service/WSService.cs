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
            try{
                HttpResponseMessage response = await client.GetAsync(string.Concat("Compte?email=", email));
                if (response.IsSuccessStatusCode)
                {
                    compteRecherche = await response.Content.ReadAsAsync<T_E_COMPTE_CPT>();
                }                
            }
            catch (Exception e) {
                var messageDialog = new MessageDialog("Problème de connexion à la base de données");
                await messageDialog.ShowAsync();
            }

            return compteRecherche;
        }


        public async Task<T_E_COMPTE_CPT> PostCompteAsync(T_E_COMPTE_CPT cptNew)
        {
            try
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("Compte/", cptNew);

                if (!response.IsSuccessStatusCode) {
                    var messageDialog = new MessageDialog("Problème lors de l'ajout de l'utilisateur");
                    await messageDialog.ShowAsync();
                }
                else {
                    var messageDialog = new MessageDialog("Ajout de l'utilisateur terminé");
                    await messageDialog.ShowAsync();
                }
            }
            catch(Exception e)
            {   
                var messageDialog = new MessageDialog("Problème de connexion à la base de données");
                await messageDialog.ShowAsync();
            }
            return cptNew;
        }

        public async Task<T_E_COMPTE_CPT> PutCompteAsync(int id, T_E_COMPTE_CPT cptUpadted)
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(string.Concat("Compte/", id), cptUpadted);
                if (!response.IsSuccessStatusCode)
                {
                    var messageDialog = new MessageDialog("Problème lors de la modification de l'utilisateur");
                    await messageDialog.ShowAsync();
                }
                else
                {
                    var messageDialog = new MessageDialog("Modification de l'utilisateur terminé");
                    await messageDialog.ShowAsync();
                }
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Problème lors de la modification de l'utilisateur");
                await messageDialog.ShowAsync();
            }
            return cptUpadted;

        }


    }
}

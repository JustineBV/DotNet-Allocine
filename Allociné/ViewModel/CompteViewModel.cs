using Allociné.AppliPage;
using Allociné.Model;
using Allociné.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Allociné.ViewModel
{
    public class CompteViewModel : ViewModelBase
    {

        public ICommand BtnMailRecherche { get; private set; }
        public ICommand BtnModifyCompteCommand { get; private set; }
        public ICommand BtnClearCompteCommand { get; private set; }
        public ICommand BtnAddCompteCommand { get; private set; }

        private string _mailBoxRech;
        private T_E_COMPTE_CPT _cpt;


        public string MailBoxRech
        {
            get { return _mailBoxRech; }
            set
            {
                _mailBoxRech = value;
                RaisePropertyChanged();
            }
        }

        public T_E_COMPTE_CPT Compte
        {
            get { return _cpt; }
            set
            {
                _cpt = value;
                RaisePropertyChanged();
            }
        }





        /// <summary>
        /// Constructeur sans paramètre
        /// </summary>
        public CompteViewModel()
        {
            BtnMailRecherche = new RelayCommand(ActionMailRecherche);

            BtnModifyCompteCommand = new RelayCommand(ActionModifyCompteCommand);

            BtnClearCompteCommand = new RelayCommand(ActionClearCompteCommand);

            BtnAddCompteCommand = new RelayCommand(ActionAddCompteCommand);
        }


        /// <summary>
        /// Change to convertissor page = go to DeviseEuros
        /// </summary>
        private async void ActionMailRecherche()
        {
            WSService wsService = WSService.GetInstance();
            try
            {
                Compte = await wsService.GetCompteMailAsync(_mailBoxRech);
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Pas de connexion au webService concerné");
                await messageDialog.ShowAsync();
            }
        }

        private async void ActionModifyCompteCommand()
        {
            WSService wsService = WSService.GetInstance();
            try
            {
                Compte = await wsService.PutCompteAsync(_cpt.CPT_ID, _cpt);                
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Pas de connexion au webService concerné");
                await messageDialog.ShowAsync();
            }
        }

        
        private void ActionClearCompteCommand()
        {
            Compte = null;
        }

        private void ActionAddCompteCommand()
        {
            RootPage r = (RootPage)Window.Current.Content;
            SplitView sv = (SplitView)(r.Content);
            (sv.Content as Frame).Navigate(typeof(CreateAccountPage));
        }




    }
}

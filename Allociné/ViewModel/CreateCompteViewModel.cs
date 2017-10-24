using Allociné.Model;
using Allociné.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

namespace Allociné.ViewModel
{
    public class CreateCompteViewModel : ViewModelBase
    {

        public ICommand BtnCreateAccount { get; private set; }
        private T_E_COMPTE_CPT _cptNew = null;
        private string PasswordChp;



        public T_E_COMPTE_CPT Compte
        {
            get { return _cptNew; }
            set
            {
                _cptNew = value;
                RaisePropertyChanged();
            }
        }

        public string Password
        {
            [SecurityCriticalAttribute]
            get { return PasswordChp; }
            [SecurityCriticalAttribute]
            set
            {
                PasswordChp = value;
                RaisePropertyChanged();
            }
        }

        public CreateCompteViewModel()
        {
            BtnCreateAccount = new RelayCommand(ActionCreateAccount);
            _cptNew = new T_E_COMPTE_CPT();

        }


        private async void ActionCreateAccount()
        {
            WSService wsService = WSService.GetInstance();
            try
            {
                _cptNew.CPT_PWD = PasswordChp;
                await wsService.PostCompteAsync(_cptNew);
                var messageDialog = new MessageDialog("Nouvel utilisateur ajouté");
                await messageDialog.ShowAsync();
            }
            catch (Exception e)
            {
                var messageDialog = new MessageDialog("Pas de connexion au webService concerné");
                await messageDialog.ShowAsync();
            }

        }
    }
}

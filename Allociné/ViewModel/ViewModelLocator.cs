using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Allociné.ViewModel
{
    public class ViewModelLocator
    {
        /// <summary>     
        /// This class contains static references to all the view models in the     
        /// application and provides an entry point for the bindings. 
        ///</summary>   
        

            // Add each new ModelView
            static ViewModelLocator()
            {
                ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
                SimpleIoc.Default.Register<CompteViewModel>();
                SimpleIoc.Default.Register<CreateCompteViewModel>();
            }

        
            /// <summary>         
            /// Gets the Main property.         
            /// </summary>   
            /// For each new page we need to add this line which made link between the view and the modelview.
            public CompteViewModel Compte => ServiceLocator.Current.GetInstance<CompteViewModel>();
      
            public CreateCompteViewModel CreateCompte => ServiceLocator.Current.GetInstance<CreateCompteViewModel>();

    }
}

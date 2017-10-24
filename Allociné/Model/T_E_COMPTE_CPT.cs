using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Allociné.Model
{
    public class T_E_COMPTE_CPT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public T_E_COMPTE_CPT()
        {
            this.AvisCompte = new HashSet<T_E_AVIS_AVI>();
            this.FavorisCompte = new HashSet<T_E_FILM_FILM>();
        }

        public int CPT_ID { get; set; }
        public string CPT_NOM { get; set; }
        public string CPT_PRENOM { get; set; }
        public string CPT_TELPORTABLE { get; set; }
        public string CPT_MEL { get; set; }
        public string CPT_PWD { get; set; }
        public string CPT_RUE { get; set; }
        public string CPT_CP { get; set; }
        public string CPT_VILLE { get; set; }
        public string CPT_PAYS { get; set; }
        public Nullable<float> CPT_LATITUDE { get; set; }
        public Nullable<float> CPT_LONGITUDE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<T_E_AVIS_AVI> AvisCompte { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        private ICollection<T_E_FILM_FILM> FavorisCompte { get; set; }
    }
}

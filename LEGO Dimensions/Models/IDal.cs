using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEGO_Dimensions.Models
{
    public interface IDal : IDisposable
    {
        void CreerUnivers(string nom);
        void ModifierUnivers(int id, string nom);
        List<Univers> ObtientTousLesUnivers();
        Univers ObtientUnUnivers(int id);
        void SupprimerUnUnivers(int id); 

        void CreerPersonnage(string nom, Univers univers);
        void CreerPersonnage(Personnage personnage);
        void ModifierPersonnage(int id, string nom, int universId, List<Pouvoir> pouvoirs = null);
        List<Personnage> ObtientTousLesPersonnages();
        Personnage ObtientUnPersonnage(int id);
        void SupprimerUnPersonnage(int id);

        void CreerAccessoire(string nom);
        void CreerAccessoire(Accessoire accessoire);
        void ModifierAccessoire(int id, string nom, int personnageId, List<Pouvoir> pouvoirs = null);
        List<Accessoire> ObtientTousLesAccessoires();
        Accessoire ObtientUnAccessoire(int id);
        void SupprimerUnAccessoire(int id);

        void CreerPouvoir(string nom);
        void CreerPouvoir(Pouvoir pouvoir);
        void ModifierPouvoir(int id, string nom);
        List<Pouvoir> ObtientTousLesPouvoirs();
        Pouvoir ObtientUnPouvoir(int id);
        void SupprimerUnPouvoir(int id);

        void CreerUtilisateur(string nom, string motDePasse);
        void ModifierUtilisateur(string nom, string motDePasse);
        List<Utilisateur> ObtientTousLesUtilisateurs();
    }
}

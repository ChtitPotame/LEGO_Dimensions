using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LEGO_Dimensions.Models
{
    public class Dal : IDal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

        #region univers
        public void CreerUnivers(string nom)
        {
            bdd.Univers.Add(new Univers { Nom = nom});
            bdd.SaveChanges();
        }

        public void ModifierUnivers(int id, string nom)
        {
            Univers universTrouve = bdd.Univers.FirstOrDefault(u => u.UniversId == id);
            if (universTrouve != null)
            {
                universTrouve.Nom = nom;
                bdd.SaveChanges();
            }
        }

        public List<Univers> ObtientTousLesUnivers()
        {
            return bdd.Univers.ToList();
        }

        public Univers ObtientUnUnivers(int id)
        {
            return bdd.Univers.FirstOrDefault(u => u.UniversId == id);
        }

        public void SupprimerUnUnivers(int id)
        {
            Univers univers = ObtientUnUnivers(id);
            bdd.Univers.Remove(univers);
            bdd.SaveChanges();
        }
        #endregion

        #region Personnage
        public void CreerPersonnage(string nom, Univers univers)
        {
            bdd.Personnages.Add(new Personnage { Nom = nom, Univers = univers });
            bdd.SaveChanges();
        }

        public void CreerPersonnage(Personnage personnage)
        {
            bdd.Personnages.Add(personnage);
            bdd.SaveChanges();
        }

        public void ModifierPersonnage(int id, string nom, Univers univers, List<Pouvoir> pouvoirs = null)
        {
            Personnage personnageTrouve = bdd.Personnages.FirstOrDefault(p => p.PersonnageId == id);
            if (personnageTrouve != null)
            {
                personnageTrouve.Nom = nom;
                personnageTrouve.Univers = univers;
                personnageTrouve.Pouvoirs = pouvoirs;
                bdd.SaveChanges();
            }
        } 

        public List<Personnage> ObtientTousLesPersonnages()
        {
            return bdd.Personnages.Include("Univers").Include("Pouvoirs").ToList();
        }

        public Personnage ObtientUnPersonnage(int id)
        {
            return bdd.Personnages.Include("Univers").Include("Pouvoirs").FirstOrDefault(p => p.PersonnageId == id);
        }

        public void SupprimerUnPersonnage(int id)
        {
            Personnage personnage = ObtientUnPersonnage(id);
            bdd.Personnages.Remove(personnage);
            bdd.SaveChanges();
        }
        #endregion

        #region Accessoire
        public void CreerAccessoire(string nom)
        {
            bdd.Accessoires.Add(new Accessoire { Nom = nom });
            bdd.SaveChanges();
        }

        public void CreerAccessoire(Accessoire accessoire)
        {
            bdd.Accessoires.Add(accessoire);
            bdd.SaveChanges();
        }

        public void ModifierAccessoire(int id, string nom, List<Pouvoir> pouvoirs = null)
        {
            Accessoire accessoireTrouve = bdd.Accessoires.FirstOrDefault(a => a.AccessoireId == id);
            if (accessoireTrouve != null)
            {
                accessoireTrouve.Nom = nom;
                accessoireTrouve.Pouvoirs = pouvoirs;
                bdd.SaveChanges();
            }
        }

        public List<Accessoire> ObtientTousLesAccessoires()
        {
            return bdd.Accessoires.Include("PersonnageAssocie").Include("Pouvoirs").ToList();
        }

        public Accessoire ObtientUnAccessoire(int id)
        {
            return bdd.Accessoires.Include("PersonnageAssocie").Include("Pouvoirs").FirstOrDefault(a => a.AccessoireId == id);
        }

        public void SupprimerUnAccessoire(int id)
        {
            Accessoire accessoire = ObtientUnAccessoire(id);
            bdd.Accessoires.Remove(accessoire);
            bdd.SaveChanges();
        }
        #endregion

        #region Pouvoir
        public void CreerPouvoir(string nom)
        {
            bdd.Pouvoirs.Add(new Pouvoir { Nom = nom });
            bdd.SaveChanges();
        }

        public void CreerPouvoir(Pouvoir pouvoir)
        {
            bdd.Pouvoirs.Add(pouvoir);
            bdd.SaveChanges();
        }

        public void ModifierPouvoir(int id, string nom)
        {
            Pouvoir pouvoirTrouve = bdd.Pouvoirs.FirstOrDefault(p => p.PouvoirId == id);
            if (pouvoirTrouve != null)
            {
                pouvoirTrouve.Nom = nom;
                bdd.SaveChanges();
            }
        }

        public List<Pouvoir> ObtientTousLesPouvoirs()
        {
            return bdd.Pouvoirs.Include("Personnages").Include("Accessoires").ToList();
        }

        public Pouvoir ObtientUnPouvoir(int id)
        {
            return bdd.Pouvoirs.Include("Personnages").Include("Accessoires").FirstOrDefault(p => p.PouvoirId == id);
        }

        public void SupprimerUnPouvoir(int id)
        {
            Pouvoir pouvoir = ObtientUnPouvoir(id);
            bdd.Pouvoirs.Remove(pouvoir);
            bdd.SaveChanges();
        }
        #endregion

        #region Utilisateur
        public void CreerUtilisateur(string nom, string motDePasse)
        {
            bdd.Utilisateurs.Add(new Utilisateur { Nom = nom, MotDePasse = motDePasse });
            bdd.SaveChanges();
        }

        public void ModifierUtilisateur(string nom, string motDePasse)
        {
            Utilisateur utilisateurTrouve = bdd.Utilisateurs.FirstOrDefault(p => p.Nom == nom);
            if (utilisateurTrouve != null)
            {
                utilisateurTrouve.Nom = nom;
                utilisateurTrouve.MotDePasse = motDePasse;
                bdd.SaveChanges();
            }
        }

        public List<Utilisateur> ObtientTousLesUtilisateurs()
        {
            return bdd.Utilisateurs.ToList();
        }
        #endregion

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}
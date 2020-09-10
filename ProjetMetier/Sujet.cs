using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Sujet
    {
        private string nomSujet;
        private Blogger leCreateur;
        private List<Messsage> lesMessages;

        public Sujet(string unNomSujet , Blogger unCreateur)
        {
            NomSujet = unNomSujet;
            LeCreateur = unCreateur;
            LesMessages = new List<Messsage>(); //pour une liste on instancie avec new
        }



        public string NomSujet { get => nomSujet; set => nomSujet = value; }
        public Blogger LeCreateur { get => leCreateur; set => leCreateur = value; }
        public List<Messsage> LesMessages { get => lesMessages; set => lesMessages = value; }


        // methode void : ne retourne rien de tout 
        public void AjouterMessage(Messsage unNouveauMesssage)
        {
            lesMessages.Add(unNouveauMesssage);
        }


        // methode typés: retourne un type
        public int GetNbMessage()
        {
            return lesMessages.Count;
        }
    }
}

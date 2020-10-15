using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Sujet
    {
        private string nomSujet;
        private Blogger leCreateur;
        private List<Message> lesMessages;
        // public int MyProperty { get; set; }

        // constructeur
        public Sujet(string unNomSujet , Blogger unCreateur)
        {
            NomSujet = unNomSujet;
            LeCreateur = unCreateur;
            LesMessages = new List<Message>(); //pour une liste on instancie avec new
        }



        public string NomSujet { get => nomSujet; set => nomSujet = value; }
        public Blogger LeCreateur { get => leCreateur; set => leCreateur = value; }
        public List<Message> LesMessages { get => lesMessages; set => lesMessages = value; }


        // methode void : ne retourne rien de tout 
        public void AjouterMessage(Message unNouveauMesssage)
        {
            lesMessages.Add(unNouveauMesssage);
        }


        // methode typés: retourne un type
        public int GetNbMessage()
        {
            return lesMessages.Count;
        }

        // static method : on peut faire ceci sans instancier Sujet.getNb()
        //public static int getNb()
        //{
        //    return 1;
        //}
    }
}

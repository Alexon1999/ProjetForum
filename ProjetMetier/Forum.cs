using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Forum
    {
        private int idForum;
        private string nomForum;
        private List<Sujet> lesSujets;


        public Forum(int unId , string unNomForum)
        {
            IdForum = unId;
            NomForum = unNomForum;
            LesSujets = new List<Sujet>();
        }

        public int IdForum { get => idForum; set => idForum = value; }
        public string NomForum { get => nomForum; set => nomForum = value; }
        public List<Sujet> LesSujets { get => lesSujets; set => lesSujets = value; }

        public void AjouterSujet (Sujet unNouveauSujet)
        {
            lesSujets.Add(unNouveauSujet);
        }


        // Cette méthode retourne la liste de tous les messages
        // du sujet passé en paramètre
        public List<Message> GetLesMessagesDunSujet(Sujet unSujet)
        {
            List<Message> lesMessagesDuSujet = new List<Message>();
            // List<Message> lesMessagesDuSujet = null;


            foreach (Sujet sujet in lesSujets)
            {
                if(sujet.NomSujet == unSujet.NomSujet)
                {
                    //foreach(Messsage m in sujet.LesMessages)
                    //{
                    //    lesMessages.Add(m);
                    //}
                    lesMessagesDuSujet = sujet.LesMessages;
                    break;
                    
                }
            }
            return lesMessagesDuSujet;

            // Version 2 : LINQ
            //return lesSujets.Find(s => s.NomSujet == unSujet.NomSujet).LesMessages;

            // Version 3
            // return leSujet.lesMessages;
        }


        public int getNbMessagesDunBlogger(Blogger unBlogger)
        {
            int nbBlogger = 0;
            foreach(Sujet s in lesSujets)
            {
                foreach(Message m in s.LesMessages)
                {
                    if(m.LeBlogger.IdBlogger == unBlogger.IdBlogger)
                    {
                        nbBlogger++;
                    }
                }
            }

            return nbBlogger;
        }


        public int GetNbSujets()
        {
            return lesSujets.Count;
        }

        // Cette méthode permet de calculer le pourcentage de messages du sujet
        // passé en paramètre par rapport à l'ensemble des messages du forum/
        // Ce pourcentage permettra de connaître le sujet
        // pour lequel il y a le plus de messages 
        public double GetPourcentagesSujet(Sujet leSujet)
        {
            int countMessagesDuSujet = 0;
            int totaleMessages = 0;

            foreach(Sujet s in lesSujets)
            {
                // on compte les message de chaque sujet
                totaleMessages += s.GetNbMessage();

                //if(leSujet.NomSujet == s.NomSujet)
                //{
                //    countMessagesDuSujet += s.GetNbMessage();
                //}
            }
            bool contain =  lesSujets.Contains(leSujet);

            Sujet findedSujet = LesSujets.Find(sujet => sujet.NomSujet == leSujet.NomSujet);
            countMessagesDuSujet = findedSujet.GetNbMessage();

            int findedIndex =   lesSujets.FindIndex(sujet => sujet.NomSujet == leSujet.NomSujet);
            countMessagesDuSujet = lesSujets[findedIndex].GetNbMessage();

            // on peut stocker dans une variable de type Sujet, on peut faire ceci car lesSujets[findedIndex] est de type Sujet (il retourne un Sujet)
            Sujet s1 = lesSujets[findedIndex];

            //lesSujets.ForEach(sujet =>
            //{
            //    if (sujet.NomSujet == leSujet.NomSujet) countMessagesDuSujet = sujet.GetNbMessage();
            //});

            // double.Parse(string)
            // countMessagesDuSujet / totaleMessages * 100 : convertir ca en double
            double d = (double) countMessagesDuSujet / totaleMessages * 100;

            double pourcentage = Math.Round(Convert.ToDouble(d), 2);

            return pourcentage;

        }
    }
}

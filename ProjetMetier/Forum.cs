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

        public List<Messsage> GetLesMessagesDunSujet(Sujet unSujet)
        {

            List<Messsage> lesMessagesDuSujet = new List<Messsage>();

            foreach(Sujet sujet in lesSujets)
            {
                if(sujet.NomSujet == unSujet.NomSujet)
                {

                    //foreach(Messsage m in sujet.LesMessages)
                    //{
                    //    lesMessages.Add(m);
                    //}

                    lesMessagesDuSujet = sujet.LesMessages;
                }
            }
            return lesMessagesDuSujet;

            // return leSujet.lesMessages;
        }


        public int getNbMessagesDunBlogger(Blogger unBlogger)
        {
            int nbBlogger = 0;
            foreach(Sujet s in lesSujets)
            {
                foreach(Messsage m in s.LesMessages)
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
            foreach(Sujet s in lesSujets)
            {

            }
            return 0;
        }

        public double GetPourcentagesSujet(Sujet leSujet)
        {
            return 0;
        }
    }
}

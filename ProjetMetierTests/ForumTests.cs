using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetMetier;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier.Tests
{
    [TestClass()]
    public class ForumTests
    {
        [TestMethod()]
        public void GetLesMessagesDunSujetTest()
        {
            Blogger b1 = new Blogger(1, "Neymar", "Image");
            Blogger b2 = new Blogger(1, "Michael", "Image");

            Message m1 = new Message("Il est fort", "04/09/2020", b1);
            Message m2 = new Message("Alllez champion", "04/09/2020", b2);
            Message m3 = new Message("so comment", "04/09/2020", b2);
            Message m4 = new Message("so comment jagshj", "04/09/2020", b1);
            Message m5 = new Message("sblblblblblb", "04/09/2020", b2);


            Sujet s1 = new Sujet("Foot", b1);
            s1.LesMessages.Add(m1);
            s1.LesMessages.Add(m2);
            s1.LesMessages.Add(m3);

            Sujet s2 = new Sujet("Voiture", b1);
            s2.LesMessages.Add(m4);

            Sujet s3 = new Sujet("Appartement", b1);
            s3.LesMessages.Add(m5);

            // instancier  un objet de type Forum
            Forum f = new Forum(1, "PSG");
            f.LesSujets.Add(s1);
            f.LesSujets.Add(s2);
            f.LesSujets.Add(s3);

            int nbMessage = f.GetLesMessagesDunSujet(s1).Count;
            // Assert.AreEqual(2, f.GetLesMessagesDunSujet(s1).Count);
            Assert.AreEqual(3, nbMessage);

        }

        [TestMethod()]
        public void getNbMessagesDunBloggerTest()
        {
            Blogger b1 = new Blogger(1, "Neymar", "Image");
            Blogger b2 = new Blogger(2, "Michael", "Image");

            Message m1 = new Message("Il est fort", "04/09/2020", b1);
            Message m2 = new Message("Alllez champion", "04/09/2020", b2);
            Message m3 = new Message("so comment", "04/09/2020", b2);
            Message m4 = new Message("so comment jagshj", "04/09/2020", b1);
            Message m5 = new Message("sblblblblblb", "04/09/2020", b2);


            Sujet s1 = new Sujet("Foot", b1);
            s1.LesMessages.Add(m1);
            s1.LesMessages.Add(m2);
            s1.LesMessages.Add(m3);

            Sujet s2 = new Sujet("Voiture", b1);
            s2.LesMessages.Add(m4);

            Sujet s3 = new Sujet("Appartement", b1);
            s3.LesMessages.Add(m5);

            // instancier un un objet de type Forum
            Forum f = new Forum(1, "PSG");
            f.AjouterSujet(s1);
            f.AjouterSujet(s2);
            f.AjouterSujet(s3);
            //f.LesSujets.Add(s3);

            int nbMessages = f.getNbMessagesDunBlogger(b1);
            Assert.AreEqual(2, nbMessages);
        }

        [TestMethod()]
        public void GetNbSujetsTest()
        {
            


        }

        [TestMethod()]
        public void GetPourcentagesSujetTest()
        {
            Blogger b1 = new Blogger(1, "Neymar", "Image");
            Blogger b2 = new Blogger(2, "Michael", "Image");

            Message m1 = new Message("Il est fort", "04/09/2020", b1);
            Message m2 = new Message("Alllez champion", "04/09/2020", b2);
            Message m3 = new Message("so comment", "04/09/2020", b2);
            Message m4 = new Message("so comment jagshj", "04/09/2020", b1);
            Message m5 = new Message("sblblblblblb", "04/09/2020", b2);


            Sujet s1 = new Sujet("Foot", b1);
            s1.LesMessages.Add(m1);
            s1.LesMessages.Add(m2);
            s1.LesMessages.Add(m3);

            Sujet s2 = new Sujet("Voiture", b1);
            s2.LesMessages.Add(m4);

            Sujet s3 = new Sujet("Appartement", b1);
            s3.LesMessages.Add(m5);

            Sujet s4 = new Sujet("Appartement", b1);


            // afficher quelquechose dans debugger sortie sortie deboggage
            //s3.LesMessages.ForEach(d =>
            //{
            //   System.Diagnostics.Debug.WriteLine(d.Contenu);
            //});

            Forum f = new Forum(1, "PSG");
            f.AjouterSujet(s1);
            f.AjouterSujet(s2);
            f.AjouterSujet(s3);

            f.GetPourcentagesSujet(s4); // verify if f object contains s4

            Assert.AreEqual(20, f.GetPourcentagesSujet(s2));
            Assert.AreEqual(60, f.GetPourcentagesSujet(s1));

        }
    }
}
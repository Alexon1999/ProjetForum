using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjetMetier;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier.Tests
{
    [TestClass()]
    public class SujetTests
    {
        [TestMethod()]
        public void AjouterMessageTest()
        {
            Blogger b1 = new Blogger(1, "Neymar", "Image");
            Blogger b2 = new Blogger(1, "Michael", "Image");

            // + instancier un objet de la classe sujet
            Sujet s = new Sujet("foot", b1);
            // * s est donc un objet qui est de type Sujet

            Message m1 = new Message("Il est fort", "04/09/2020", b1);
            Message m2 = new Message("Alllez champion", "04/09/2020", b2);
            Message m3 = new Message("so comment", "04/09/2020", b2);

            s.AjouterMessage(m1);
            s.AjouterMessage(m2);
            s.AjouterMessage(m3);

            Assert.AreEqual(3, s.LesMessages.Count);
            //Assert.AreEqual(2, s.LesMessages.Count);
        }
    }
}
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
            // un objet de la class sujet
            Blogger b1 = new Blogger(1, "Neymar", "Image");
            Blogger b2 = new Blogger(1, "Michael", "Image");

            Sujet s = new Sujet("foot", b1);

            // s : est un objet qui est de type Sujet
            Messsage m1 = new Messsage("Il est fort", "04/09/2020", b1);
            Messsage m2 = new Messsage("Alllez champion", "04/09/2020", b2);
            Messsage m3 = new Messsage("so comment", "04/09/2020", b2);

            s.AjouterMessage(m1);
            s.AjouterMessage(m2);
            s.AjouterMessage(m3);

            Assert.AreEqual(3, s.LesMessages.Count);
            //Assert.AreEqual(2, s.LesMessages.Count);
        }
    }
}
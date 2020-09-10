using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetMetier
{
    public class Messsage
    {
        private string contenu;
        private string dateMessage;
        private Blogger leBlogger;

        public Messsage(string unContenu , string uneDate , Blogger unBlogger)
        {
            Contenu = unContenu;
            DateMessage = uneDate;
            LeBlogger = unBlogger;
        }

        public string Contenu { get => contenu; set => contenu = value; }
        public string DateMessage { get => dateMessage; set => dateMessage = value; }
        public Blogger LeBlogger { get => leBlogger; set => leBlogger = value; }
    }
}

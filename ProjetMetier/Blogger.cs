using System;

namespace ProjetMetier
{
    public class Blogger
    {
        private int idBlogger;
        private string pseudoBlogger;
        private string avatarBlogger;




        // Constructeur

        public Blogger(int unId ,string  unPseudo , string unAvatar)
        {
            IdBlogger = unId;
            PseudoBlogger = unPseudo;
            AvatarBlogger = unAvatar;
        }

        public int IdBlogger { get => idBlogger; set => idBlogger = value; }
        public string PseudoBlogger { get => pseudoBlogger; set => pseudoBlogger = value; }
        public string AvatarBlogger { get => avatarBlogger; set => avatarBlogger = value; }
    }
}

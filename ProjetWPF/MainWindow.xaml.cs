using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ProjetMetier;

namespace ProjetWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Global variables
        Forum monForum;
        List<Blogger> lesBloggers;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            monForum = new Forum(1, "foot");
            lesBloggers = new List<Blogger>();// instancier une liste de type Blogger

            Blogger bloggerPierre = new Blogger(1, "Pierrot", "Image/Pierrot.png");
            Blogger bloggerSabine = new Blogger(2, "Sabine", "Image/Sabine.png");
            Blogger bloggerVirginie = new Blogger(3, "Ninie", "Image/Ninie.png");
            Blogger bloggerPaul = new Blogger(4, "Paulo", "Image/Paulo.png");
            Blogger bloggerMathieu = new Blogger(5, "Mat", "Image/Mat.png");

            // On ajoute nos bloggers à une liste
            // pour remplir la combobox
            lesBloggers.Add(bloggerPierre); lesBloggers.Add(bloggerSabine);
            lesBloggers.Add(bloggerVirginie); lesBloggers.Add(bloggerPaul);
            lesBloggers.Add(bloggerMathieu);

            Sujet sujetFoot = new Sujet("Foot", bloggerPierre);
            Sujet sujetTennis = new Sujet("Tennis", bloggerSabine);
            Sujet sujetRugby = new Sujet("Rugby", bloggerPaul);
            Sujet sujetPhp = new Sujet("PHP", bloggerVirginie);

            Message m1 = new Message("PSG Champion", DateTime.Now.AddDays(3).ToShortDateString(), bloggerPaul);
            Message m2 = new Message("Lille Champion", DateTime.Now.ToShortDateString(), bloggerMathieu);
            Message m3 = new Message("Lyon Champion", DateTime.Now.AddDays(1).ToShortDateString(), bloggerSabine);
            Message m4 = new Message("Dijon Champion", DateTime.Now.AddDays(-3).ToShortDateString(), bloggerVirginie);
            Message m5 = new Message("Federer Champion", DateTime.Now.AddDays(-5).ToShortDateString(), bloggerMathieu);
            Message m6 = new Message("Nadal Champion", DateTime.Now.ToShortDateString(), bloggerPierre);
            Message m7 = new Message("Djoko Champion", DateTime.Now.ToShortDateString(), bloggerPaul);
            Message m8 = new Message("La Rochelle Champion", DateTime.Now.AddDays(2).ToShortDateString(), bloggerMathieu);
            Message m9 = new Message("Toulouse Champion", DateTime.Now.AddDays(4).ToShortDateString(), bloggerSabine);
            Message m10 = new Message("Toulon Champion", DateTime.Now.AddDays(1).ToShortDateString(), bloggerSabine);
            Message m11 = new Message("PHP que du bonheur", DateTime.Now.AddDays(3).ToShortDateString(), bloggerVirginie);
            Message m12 = new Message("Quel framework utilisez-vous ?", DateTime.Now.AddDays(5).ToShortDateString(), bloggerVirginie);
            Message m13 = new Message("Il faut faire un echo", DateTime.Now.AddDays(-1).ToShortDateString(), bloggerPaul);
            Message m14 = new Message("PDO vs MYSQLI", DateTime.Now.AddDays(-2).ToShortDateString(), bloggerMathieu);
            Message m15 = new Message("$_GET vs $_POST", DateTime.Now.AddDays(-4).ToShortDateString(), bloggerPierre);



            sujetFoot.AjouterMessage(m1); sujetFoot.AjouterMessage(m2); sujetFoot.AjouterMessage(m3); sujetFoot.AjouterMessage(m4);
            sujetTennis.AjouterMessage(m5); sujetTennis.AjouterMessage(m6); sujetTennis.AjouterMessage(m7);
            sujetRugby.AjouterMessage(m8); sujetRugby.AjouterMessage(m9); sujetRugby.AjouterMessage(m10);
            sujetPhp.AjouterMessage(m11); sujetPhp.AjouterMessage(m12); sujetPhp.AjouterMessage(m13);
            sujetPhp.AjouterMessage(m14); sujetPhp.AjouterMessage(m15);

            monForum.AjouterSujet(sujetFoot); monForum.AjouterSujet(sujetPhp);
            monForum.AjouterSujet(sujetRugby); monForum.AjouterSujet(sujetTennis);


            lvSujets.ItemsSource = monForum.LesSujets;
            txtNbSujets.Text = monForum.GetNbSujets().ToString();
            cboBloggers.ItemsSource = lesBloggers;
        }

        private void lvSujets_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // on peut stocker dans une variable de type Sujet, on peut faire ceci car lvSujets.SelectedItem est de type Sujet
            Sujet selectedSujet = lvSujets.SelectedItem as Sujet;
            if (selectedSujet != null)
            {
                //lvMessages.ItemsSource = selectedSujet.LesMessages;
                lvMessages.ItemsSource = monForum.GetLesMessagesDunSujet(selectedSujet);

                txtPourcentage.Text = monForum.GetPourcentagesSujet(selectedSujet).ToString();
                txtNbMessagesSujet.Text = selectedSujet.GetNbMessage().ToString();

            }

        }

        private void cboBloggers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboBloggers.SelectedItem != null)
            {
                txtNbMessagesBlogger.Text = monForum.getNbMessagesDunBlogger(cboBloggers.SelectedItem as Blogger).ToString();
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            // MessageBox.Show("Saisir qqc", "erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);

            if (txtContenuMessage.Text == "")
            {
                MessageBox.Show("Saisir un contenu pour le message", "Information erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (dpDateMesage.SelectedDate == null)
                {
                    MessageBox.Show("Sélectionner une date", "Information erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    if (cboBloggers.SelectedItem == null)
                    {
                        MessageBox.Show("Choisir un bloggeur", "Information erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    else
                    {
                        if (lvSujets.SelectedItem == null)
                        {
                            MessageBox.Show("Veuillez selectionner un sujet", "Erreur de saisie", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                        else
                        {
                            Blogger b = (cboBloggers.SelectedItem as Blogger);
                            DateTime dt = new DateTime();
                            Message newMessage = new Message(txtContenuMessage.Text, dpDateMesage.SelectedDate.Value.ToShortDateString(), b);

                            // il pointe vers le sujet selectionné
                            (lvSujets.SelectedItem as Sujet).AjouterMessage(newMessage);
                            MessageBox.Show("Message ajouté", "Information message", MessageBoxButton.OK, MessageBoxImage.Information);

                            // rafraichir la lvMessage listbox
                            //v1 -> rafraichir le listView
                            lvMessages.ItemsSource = null;
                            lvMessages.ItemsSource = monForum.GetLesMessagesDunSujet((lvSujets.SelectedItem as Sujet));

                            //lvMessages.ItemsSource = null;
                            //lvMessages.ItemsSource = (lvSujets.SelectedItem as Sujet).LesMessages;

                            //V2 -> rafraichir le listView
                            lvMessages.Items.Refresh();

                            txtPourcentage.Text = monForum.GetPourcentagesSujet((lvSujets.SelectedItem as Sujet)).ToString();
                            txtNbMessagesSujet.Text = (lvSujets.SelectedItem as Sujet).GetNbMessage().ToString();
                        }

                    }
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Reflection;

namespace Postevanka
{
    public partial class MainPage : ContentPage
    {
        ISimpleAudioPlayer Igralnik;
        Button Glavni_Gumb;
       
        public void Uredi()
        {
            Posast.Vrni_Prvo();
            Posast.Vrni_Drugo();
            Posast.Polni();
            G.Text = Convert.ToString(Posast.Prvo + "  •  " + Posast.Drugo);

            for (int indeks = 0; indeks < Panel.Children.Count; indeks++)
            {
                if (Panel.Children[indeks] is Button)
                {
                    Posast.Cifra = Posast.Nakljucno.Next(Posast.Stevilke.Count);
                    Glavni_Gumb = (Button)Panel.Children[indeks];
                    Glavni_Gumb.Text = Convert.ToString(Posast.Stevilke[Posast.Cifra]);
                    Posast.Stevilke.RemoveAt(Posast.Cifra);
                }
            }
        }

        Stream GetStreamFromFile(string filename)
        {
            var assembly = typeof(App).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Postevanka." + filename);
            return stream;
        }

        public MainPage()
        {
            InitializeComponent();
            Uredi();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Button Gumb = sender as Button;

            Posast.Moja_Izbira = Convert.ToInt32(Gumb.Text);

            if (Posast.Preveri_ustreznost())
            {
                var stream = GetStreamFromFile("ja.mp3");
                Igralnik = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                Igralnik.Load(stream);
                Igralnik.Play();
                DisplayAlert("Pošastko sporoča", "BRAVO! Pravilna rešitev!", "Nadaljuj");
                Uredi();
            }

            else
            {
                var stream = GetStreamFromFile("ne.mp3");
                Igralnik = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                Igralnik.Load(stream);
                Igralnik.Play();
                Slika.Source = "p2.png";
                Uredi();
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            var stream = GetStreamFromFile("cartoon.mp3");
            Igralnik = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
            Igralnik.Load(stream);
            Igralnik.Play();
            Uredi();
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {

        }
    }
}

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
                DisplayAlert("Pošastko sporoča", "NAROBE! Rešitev ni pravilna!", "Nadaljuj");
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
            Posast.Stevec++;

            if (Posast.Stevec % 2 == 0)
            {
                Gumbo.Text = "BOŽIČNI NAČIN";
                Slika.Source = "p1.png";
                G.BackgroundColor = Color.FromHex("#680580");
                GGG.BackgroundColor = Color.FromHex("#4B1758");
                Gumbo.BackgroundColor = Color.FromHex("#701187");
                Glavno.BackgroundColor = Color.FromHex("#EDA4FF");
                Panel.BackgroundColor = Color.FromHex("#EDA4FF");

                for (int indeks = 0; indeks < Panel.Children.Count; indeks++)
                {
                    if (indeks % 2 != 0)
                    {
                        Panel.Children[indeks].BackgroundColor = Color.FromHex("#701187");
                    }

                    else
                    {
                        Panel.Children[indeks].BackgroundColor = Color.FromHex("#C525ED");
                    }
                }
            }

            else
            {
                var stream = GetStreamFromFile("gu.mp3");
                Igralnik = CrossSimpleAudioPlayer.CreateSimpleAudioPlayer();
                Igralnik.Load(stream);
                Igralnik.Play();
                Gumbo.Text = "POŠASTKOV NAČIN";
                Slika.Source = "p2.png";
                G.BackgroundColor = Color.FromHex("#9A1B1B");
                GGG.BackgroundColor = Color.FromHex("#9A1B1B");
                Gumbo.BackgroundColor = Color.FromHex("#9A1B1B");
                Glavno.BackgroundColor = Color.FromHex("#FF8989");
                Panel.BackgroundColor = Color.FromHex("#FF8989");

                for (int indeks = 0; indeks < Panel.Children.Count; indeks++)
                {
                    if (indeks % 2 != 0)
                    {
                        Panel.Children[indeks].BackgroundColor = Color.FromHex("#BF0000");
                    }

                    else
                    {
                        Panel.Children[indeks].BackgroundColor = Color.FromHex("#F05D5D");
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_TP2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
        }

        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Random randCol = new Random();
            int randNB = randCol.Next(10,1000);

            //creation de colonnes
            for (int i = 10; i <= randNB; i++)
            {
                this.mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            //creation de lignes
            for (int i = 10; i <= randNB; i++)
            {
                this.mainGrid.RowDefinitions.Add(new RowDefinition());
            }

            // Coordonnées aléatoires du bouton
            Random rand = new Random();
            int yCol = rand.Next(0,1000);
            int xRow = rand.Next(0,1000);

            Grid.SetColumn(btn1, yCol);
            Grid.SetRow(btn1, xRow);

            btn1.PointerEntered += Btn1_PointerEntered;
        }

        private void Btn1_PointerEntered(object sender, PointerRoutedEventArgs e)
        {
            Random rand = new Random();
            int newYCol = rand.Next(0, 1000);
            int newXRow = rand.Next(0, 1000);

            //recupération de la dernière position
            Grid.GetColumn(btn1);
            Grid.GetRow(btn1);
        }
    }
}


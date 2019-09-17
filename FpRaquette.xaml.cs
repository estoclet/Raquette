namespace AppliRaquette
{
    /// <summary>
    /// Interaction logic for FpRaquette.xaml
    /// </summary>
    public partial class FpRaquette
    {
        private GetAxes Axes { get; set; }
        
        public FpRaquette()
        {
            //********
            //* TEST DE LA CLASSE GestAxes
            //********

            //  • instanciation d'un objet  GestAxes
            GetAxes Axes = new GetAxes(0, 0);
            //  • initialisation des axes x et y
            Axes.Initialise();
            //  • déplacement en AD à la vitesse de 200 pas / s
            Axes.SetSpeedY("200");
            Axes.RotationAD("10");
            //  • arrêt
            Axes.StopDECAD();
            //  • Déplacement en DEC à la vitesse de 700 pas / s
            Axes.SetSpeedX("700");
            Axes.RotationDEC("10");
            //  • arrêt
            Axes.StopDECAD();
            //********
            //* FIN DU TEST
            //********


            InitializeComponent();
        }

        // LISTE DES COMMANDES
        private void BoutDECPlus_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutDECMoins_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutADPlus_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutADMoins_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutStop_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutInit_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BoutSuivi_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void VitX_Scroll_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void VitY_Scroll_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
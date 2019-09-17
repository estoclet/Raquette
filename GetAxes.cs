using System;
using System.Windows.Navigation;
using System.Configuration;
using System.IO.Ports;

namespace AppliRaquette
{
    public class GetAxes
    {
        private SerialPort Liaison { get; set; }
        private string NomPort { get; set; }
        private int DEC { get; set; }
        private int AD { get; set; }
        private string Vitesse { get; set; }
        private string Format { get; set; }
        private string TestParite { get; set; }
        private string Stop { get; set; }
        private string SpeedX { get; set; }
        private string SpeedY { get; set; }
        private string Erreur { get; set; }

        public GetAxes(int dec, int ad)
        {
            //Initialise les attributs de la classe
            DEC = dec;
            AD = ad;

            //Instancie un objet SerialPort qui sera initialisé avec les paramètres de configuration contenus dans App.config
            NomPort = ConfigurationManager
                .AppSettings
                    ["NomduPort"]; // On met l'attribut Nomport à jour avec la valeur contenue dans le fichier XML App.config.
            Liaison = new SerialPort(
                NomPort); // On instancie un objet SerialPort nommé Liaison et qui utilise le port COM16
            //Configure l'objet SerialPort avec les paramètres de configuration contenus dans le fichier App.config
        }

        public void StopDECAD()
        {
            string Message = null;

            Message = "k" + '\r'; // Stop both motors
            Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
            try
            {
                Liaison.Open(); // on ouvre la liaison série
                Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                Liaison.Close();
            } // on ferme la liaison série
            catch
            {
                Erreur =
                    "Impossible d'acceder à la liaison serie, le port est peut etre utilise par une autre application !";
            }

        }

        public void StopDEC()
        {
            string Message = null;

            Message = "kx" + '\r'; // Stop both motors
            Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
            try
            {
                Liaison.Open(); // on ouvre la liaison série
                Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                Liaison.Close();
            } // on ferme la liaison série
            catch
            {
                Erreur =
                    "Impossible d'acceder à la liaison serie, le port est peut etre utilise par une autre application !";
            }
        }

        public void StopAD()
        {
            string Message = null;

            Message = "ky" + '\r'; // Stop both motors
            Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
            try
            {
                Liaison.Open(); // on ouvre la liaison série
                Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                Liaison.Close();
            } // on ferme la liaison série
            catch
            {
                Erreur =
                    "Impossible d'acceder à la liaison serie, le port est peut etre utilise par une autre application !";
            }
        }

        public void RotationAD(string a)
        {
            int numPosition = Int32.Parse(a);

            if (numPosition > -644999 && numPosition < 639999)
            {
                string Message = null;

                Message = "X" + a + '\r';
                Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
                try
                {
                    Liaison.Open(); // on ouvre la liaison série
                    Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                    Liaison.Close();
                } // on ferme la liaison série
                catch
                {
                    Erreur =
                        "Impossible d'accèder à la liaison série, le port est peut-être utilisé par une autre application !";
                }
            }
        }

        public void RotationDEC(string b)
        {
            int numPosition = Int32.Parse(b);

            if (numPosition > -644999 && numPosition < 639999)
            {
                string Message = null;

                Message = "Y" + b + '\r';
                Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
                try
                {
                    Liaison.Open(); // on ouvre la liaison série
                    Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                    Liaison.Close();
                } // on ferme la liaison série
                catch
                {
                    Erreur =
                        "Impossible d'accèder à la liaison série, le port est peut-être utilisé par une autre application !";
                }
            }
        }

        public void Initialise()
        {
            string Message = null;

            Message = "fx,0" + '\r'; // Init Axe X
            Message = Message + "fy,0" + '\r'; // Init Axe X et Y
            Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
            try
            {
                Liaison.Open(); // on ouvre la liaison série
                Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                Liaison.Close();
            } // on ferme la liaison série
            catch
            {
                Erreur =
                    "Impossible d'acceder à la liaison serie, le port est peut etre utilise par une autre application !";
            }
        }

        public string GetCurrentPosition()
        {

            string Message = null;

            Message = "";
            Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
            try
            {
                Liaison.Open(); // on ouvre la liaison série
                Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                Liaison.Read(Donnees, 0, Donnees.Length);
                Liaison.Close();
                Message = System.Text.Encoding.ASCII.GetString(Donnees);

            } // on ferme la liaison série
            catch
            {
                Erreur =
                    "Impossible d'acceder à la liaison serie, le port est peut etre utilise par une autre application !";
            }

            return Message;

        }

        public void SetSpeedX(string n)
        {
            // Commande SX,n (n micro-steps)
            int numN = Int32.Parse(n);

            if (numN < 0)
            {
                string Message = null;

                Message = "sx" + n + '\r';
                Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
                try
                {
                    Liaison.Open(); // on ouvre la liaison série
                    Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                    Liaison.Close();
                } // on ferme la liaison série
                catch
                {
                    Erreur =
                        "Impossible d'accèder à la liaison série, le port est peut-être utilisé par une autre application !";
                }
            }
        }

        public void SetSpeedY(string n)
        {
            int numN = Int32.Parse(n);

            if (numN < 0)
            {
                string Message = null;

                Message = "sy" + n + '\r';
                Byte[] Donnees = System.Text.Encoding.ASCII.GetBytes(Message);
                try
                {
                    Liaison.Open(); // on ouvre la liaison série
                    Liaison.Write(Donnees, 0, Donnees.Length); // on envoie les données
                    Liaison.Close(); // on ferme la liaison série
                }
                catch
                {
                    Erreur =
                        "Impossible d'accèder à la liaison série, le port est peut-être utilisé par une autre application !";
                }

            }
        }
    }
}
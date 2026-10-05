using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pcdogagyakorlo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void VetelValidacio(object sender, RoutedEventArgs e)
        {
            if (checkFeltetel.IsChecked == true)
            {
                string hibak = "";
                Random r = new Random();
                string stringNev = textNev.ToString();

                if (stringNev == "")
                {
                    hibak += "Név\n";
                }

                bool eletkorSzamE = true;
                int intEletkor = 0;
                try
                {
                    intEletkor = Convert.ToInt32(textEletkor.Text);
                } 
                catch (FormatException)
                {
                    hibak += "Életkor\n";
                    eletkorSzamE |= false;
                }
                if (eletkorSzamE)
                {
                    if (intEletkor < 14)
                    {
                        hibak += "Életkor\n";
                    }
                }


                string stringEmail = textEmail.ToString();
                if (stringEmail == "" || !stringEmail.Contains("@") )
                {
                    hibak += "E-mail\n";
                }

                string stringProciNev = "";
                int intProciAr = 0;
                if (comboProci.Text != "")
                {
                    string[] stringProciLista = comboProci.Text.Split(" – ");

                    if (stringProciLista.Length == 0)
                    {
                        hibak += "Processzor\n";
                    } else
                    {
                        stringProciNev = stringProciLista[0];
                        string intProciArSeged = stringProciLista[1].Replace(" Ft", "").Replace(" ", "");
                        intProciAr = Convert.ToInt32(intProciArSeged);
                    }
                } else
                {
                    hibak += "Processzor\n";
                }



                int intKartyaAr = 0;
                string stringKartyaNev = "";
                if (radioRtx4060.IsChecked == true)
                {
                    intKartyaAr = 130000;
                    stringKartyaNev = "RTX4060";
                } 
                else if (radioRtx4070.IsChecked == true)
                {
                    intKartyaAr = 220000;
                    stringKartyaNev = "RTX4070";
                }
                else if (radioRtx4080.IsChecked == true)
                {
                    intKartyaAr = 400000;
                    stringKartyaNev = "RTX4080";
                } else
                {
                    hibak += "Videókártya\n";
                }

                int intRamAr = 0;
                string stringRamNev = "";
                if (radio16gb.IsChecked == true)
                {
                    intRamAr = 20000;
                    stringRamNev = "16 GB";
                }
                else if (radio32gb.IsChecked == true)
                {
                    intRamAr = 35000;
                    stringRamNev = "32 GB";
                }
                else if (radio64gb.IsChecked == true)
                {
                    intRamAr = 65000;
                    stringRamNev = "64 GB";
                }
                else
                {
                    hibak += "Memória\n";
                }

                int intDarab = 0;
                bool darabJoE = true;
                try
                {
                    intDarab = Convert.ToInt32(textDarab.Text);
                }
                catch (FormatException)
                {
                    hibak += "Darabszám\n";
                    darabJoE= false;
                }
                if (darabJoE)
                {
                    if (intDarab < 1 || intDarab > 5)
                    {
                        hibak += "Darabszám\n";
                    }
                }

                string stringExtrak = "";
                int intExtrak = 0;
                if (checkRgb.IsChecked == true)
                {
                    stringExtrak += "RGB világítás";
                    intExtrak += 15000;
                }

                if (checkWin11.IsChecked == true)
                {
                    
                    if (stringExtrak != "")
                    {
                        stringExtrak += ", ";
                    }
                    stringExtrak += "Windows 11";
                    intExtrak += 45000;
                }

                if (checkBillentyuzet.IsChecked == true)
                {
                    if (stringExtrak != "")
                    {
                        stringExtrak += ", ";
                    }
                    stringExtrak += "Gamer billentyűzet";
                    intExtrak += 125000;
                }

                if (checkEger.IsChecked == true)
                {
                    if (stringExtrak != "")
                    {
                        stringExtrak += ", ";
                    }
                    stringExtrak += "Gamer egér";
                    intExtrak += 18000;
                }

                int intGarancia = 0;
                string stringGarancia = "";
                if (comboGarancia.Text != "")
                {
                    string[] stringGaranciaLista = comboGarancia.Text.Split(" – +");

                    if (stringGaranciaLista.Length == 0)
                    {
                        hibak += "Garancia\n";
                    }
                    else
                    {
                        stringGarancia = stringGaranciaLista[0];
                        string intArSeged = stringGaranciaLista[1].Replace(" Ft", "").Replace(" ", "");
                        intGarancia = Convert.ToInt32(intArSeged);
                    }
                } else
                {
                    hibak += "Garancia\n";
                }



                


                if (hibak != "")
                {
                    MessageBox.Show($"A rendelésben a következő helyeken hibá(ka)t találtunk:\n\n{hibak}", "Rendelési hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                } else
                {
                    double ossz = (intProciAr + intKartyaAr + intRamAr + intExtrak + intGarancia) * intDarab;
                    if (ossz > 500000)
                    {
                        ossz = ossz * 0.95;
                    }
                    MessageBox.Show($"Sikeres rendelés!\n\nNév: {stringNev}\nE-mail: {stringEmail}\nProcesszor: {stringProciNev}\nVideókártya: {stringKartyaNev}\nMemória: {stringRamNev}\nDarabszám: {intDarab}\nExtrák: {stringExtrak}\nGarancia:{stringGarancia}\n\nFizetendő: {ossz} Ft\nRendelési azonosító: {r.Next(10000,99999)}", "Sikeres rendelés!", MessageBoxButton.OK, MessageBoxImage.Information);
                }








            } else
            {
                MessageBox.Show("Vásárláshoz fogadja el a vásárlási feltételeket", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
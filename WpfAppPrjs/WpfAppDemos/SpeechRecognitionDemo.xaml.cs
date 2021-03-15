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
using System.Windows.Shapes;
using System.Speech.Synthesis;
using System.IO;

namespace WpfAppDemos
{
    /// <summary>
    /// Interaction logic for SpeechRecognitionDemo.xaml
    /// </summary>
    public partial class SpeechRecognitionDemo : Window
    {
        public SpeechRecognitionDemo()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            string data = GetDataForSpeechRec();
            //data = "Hi ankit ! Mutual funds investments are subject to market risk. Please read all the documents carefully.";
            SpeechSynthesizer ss = new SpeechSynthesizer();
            //ss.Rate = -1; or 
            ss.SpeakAsync(data);
            //ss.Speak(data);
        }

        private static string GetDataForSpeechRec()
        {
            string data = "";
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();
            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                var fileName = openFileDlg.FileName;
                data = File.ReadAllText(fileName);
            }
            return data;
        }
    }
}

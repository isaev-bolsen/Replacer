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

namespace Replacer
    {
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
        {

        private Microsoft.Win32.OpenFileDialog OpenFileDlg = new Microsoft.Win32.OpenFileDialog()
        {
            Filter = "MS Word documents (*.doc;*.docx)|*.doc;*.docx",
            Multiselect = true,
            CheckFileExists = true
        };

        private FileProcessor FileProcessor = new FileProcessor();

        public MainWindow()
            {
            InitializeComponent();
            }

        private void OpenFiles(object sender, RoutedEventArgs e)
            {
            OpenFileDlg.ShowDialog(this);
            FileProcessor.SetFiles(OpenFileDlg.FileNames);
            }
        }
    }

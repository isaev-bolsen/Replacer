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

        private System.Windows.Forms.FolderBrowserDialog SetDirectoryDlg = new System.Windows.Forms.FolderBrowserDialog();

        private FileProcessor FileProcessor;

        public MainWindow()
            {
            InitializeComponent();
            FileProcessor = new FileProcessor(new Lister(ItemsList));
            }

        private void OpenFiles(object sender, RoutedEventArgs e)
            {
            var dlgRes = OpenFileDlg.ShowDialog(this);
            if (!dlgRes.HasValue) return;
            if (dlgRes.Value) FileProcessor.ScanFiles(OpenFileDlg.FileNames);
            }

        private void Flush(object sender, RoutedEventArgs e)
            {
            if (SetDirectoryDlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            }
        }
    }

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
    class Record : StackPanel
        {
        private TextBox TB = new TextBox() { MinWidth = 100 };

        public Record(string key)
            {
            this.Orientation = Orientation.Horizontal;
            this.Children.Add(new Label() { Content = key, MinWidth = 100 });
            this.Children.Add(TB);
            }

        public string DesiredValue
            {
            get { return TB.Text; }
            }
        }
    }

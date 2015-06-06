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
    class Lister
        {
        private StackPanel Panel;
        private Dictionary<string, Record> Records = new Dictionary<string, Record>();

        public Lister(StackPanel panel)
            {
            this.Panel = panel;
            }

        public void addKey(string key)
            {
            if (Records.ContainsKey(key)) return;
            var record = new Record(key);
            Panel.Children.Add(record);
            Records.Add(key, record);
            }

        //public Dictionary<string, string> GetInput()
        //    {

        //    }
        }
    }

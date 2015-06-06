using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Replacer
    {
    class FileProcessor
        {
        private Dictionary<string, string> Fields;
        private Application wordapp = new Application();
        private Regex regex = new Regex("{}");

        public void AddFiles(IEnumerable<string> paths)
            {
            foreach (string path in paths)
                {
                var doc = wordapp.Documents.Open(path);
                foreach (Range sent in doc.Sentences)
                    foreach (Match match in regex.Matches(sent.Text))
                        {

                        }
                }
            }
        }
    }
    

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
        private Lister Lister;
        private Regex regex = new Regex("{[\\w]+}");
        private HashSet<string> CollectedFiles = new HashSet<string>();

        public FileProcessor(Lister lister)
            {
            Lister = lister;
            }

        public async void ScanFiles(IEnumerable<string> Paths)
            {
            foreach (string path in Paths)
                {
                if (CollectedFiles.Contains(path)) continue;
                Application wordapp = new Application();

                CollectedFiles.Add(path);
                var doc = wordapp.Documents.Open(path);
                foreach (Range sent in doc.Sentences)
                    foreach (Match match in regex.Matches(sent.Text))
                        Lister.addKey(match.Value);
                doc.Close(false);
                wordapp.Quit();
                }
            }
        }
    }
    

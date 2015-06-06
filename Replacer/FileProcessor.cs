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

        private async System.Threading.Tasks.Task FlushFile(string Path, Dictionary<string, string> dict)
            {
            Application wordapp = new Application();
            var doc = wordapp.Documents.Open(Path);
            foreach (var pair in dict)
                FindAndReplace(wordapp, pair.Key, pair.Value);
            doc.Close(true);
            wordapp.Quit();
            }

        public async void Flush(string resultPath)
            {
            var Values = Lister.GetInput();
            foreach (var file in CollectedFiles)
                {
                string DestPath=Path.Combine(resultPath, Path.GetFileName(file));
                if (File.Exists(DestPath)) File.Delete(DestPath);
                File.Copy(file, DestPath);
                await FlushFile(DestPath, Values);
                }
            }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
            {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
            }
        }
    }
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Replacer
    {
    class FileProcessor
        {
        private IEnumerable<FileInfo> Files;

        public void SetFiles(IEnumerable<string> paths)
            {
            Files = paths.Select(p => new FileInfo(p));
            }
        }
    }

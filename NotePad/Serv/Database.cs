using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicData;
using NotePad.Models;
namespace NotePad.Serv
{
    public class Database
    {
        public static string fullPath = Path.GetFullPath(@"../../../");
        public string[] files = Directory.GetFiles(fullPath);
        public FileModel save;
        public int i = 0;


        public IEnumerable<FileModel> GetFiles() => new List<FileModel>()
            {
                
            };
    }
}

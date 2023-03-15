using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Utilities;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotePad.Models;

namespace NotePad.ViewModels
{
    public partial class UserControl3 : ViewModelBase
    {
        public ObservableCollection<FileModel> Files { get; }
        public ObservableCollection<DirModel> Dires { get; }

        public UserControl3(IEnumerable<FileModel> file, IEnumerable<DirModel> file2)
        {
            Files = new ObservableCollection<FileModel>(file);
            Dires = new ObservableCollection<DirModel>(file2);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NotePad.Models;

namespace NotePad.ViewModels
{
    public partial class UserControl1 : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Items))]
        public static string fullPath = Path.GetFullPath(@"../../../");
        [ObservableProperty]
        public string[] files = Directory.GetFiles(fullPath);
        public string[] Dires = Directory.GetDirectories(fullPath);
        [RelayCommand]
        public void ComClick()
        {
            Items.Clear();
            fullPath = (@"../../");
            files = Directory.GetFiles(fullPath);
            Dires = Directory.GetDirectories(fullPath);
            for (int i = 0; i < files.Count(); i++)
            {
                Items.Add(new fileModel { PATH = files[i], DIR = Dires[i] });
            }
        }
        public ObservableCollection<fileModel> Items { get; }

        public UserControl1(IEnumerable<fileModel> file)
        {
            Items = new ObservableCollection<fileModel>(file);
        }
    }
}

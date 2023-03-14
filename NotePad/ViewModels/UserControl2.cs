using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotePad.Models;

namespace NotePad.ViewModels
{
    public partial class UserControl2 : ViewModelBase
    {
        public ObservableCollection<fileModel> Items { get; }

        public UserControl2()
        {
            
        }
    }
}

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
        public string text;
        public string Text 
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        public UserControl2(string stringArg)
        {
            Text = stringArg;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;


namespace DeskNote
{
    public class DeskNoteViewModel
    {
        public ObservableCollection<WebApp> Apps { get; set; }

        public DeskNoteViewModel()
        {
            DataListen.Apps.Subscribe(x => Apps.Add(x));
            Apps = new ObservableCollection<WebApp>();            
            DataListen.Add("Keep", "http://drive.google.com/keep");
        }
    }
}

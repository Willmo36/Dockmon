using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace DeskNote
{
    public static class DataListen
    {
        private static Subject<WebApp> subject = new Subject<WebApp>();
        private static List<WebApp> app = new List<WebApp>();
        public static IObservable<WebApp> Apps = app.ToObservable().Concat(subject);

        public static void Add(string name, string url)
        {
            subject.OnNext(new WebApp()
                {
                    Name = name,
                    URL = url
                });
        }
    }
}

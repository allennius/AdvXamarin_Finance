using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using Finance.Model;

namespace Finance.ViewModel
{
    public class MainVM : INotifyPropertyChanged
    {

        public Posts Blog { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainVM()
        {
            ReadRss();
        }

        private void ReadRss()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Posts));

            using (WebClient client = new WebClient())
            {
                string xml = Encoding.Default.GetString(client.DownloadData("https://www.latimes.com/local/rss2.0.xml"));

                using(Stream reader = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    Blog = (Posts)serializer.Deserialize(reader);
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}


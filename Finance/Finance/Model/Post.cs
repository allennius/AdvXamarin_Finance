using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Xml.Serialization;

namespace Finance.Model
{
    [XmlRoot(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
    public class MediaContent
    {
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
    }

    [XmlRoot(ElementName = "item")]
    public class Item
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "description")]
        public string Description { get; set; }
        [XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/") ]
        public string Creator { get; set; }
        [XmlElement(ElementName = "pubDate")]
        public string PubDate { get; set; }
        //public string PubDate
        //{
        //    get { return pubDate; }
        //    set
        //    {
        //        pubDate = value;
                //PublishedDate = DateTime.ParseExact(PubDate, "ddd, d, MMM, YYYY, HH:MM:SS GMT", CultureInfo.InvariantCulture);
        //    }
        //}

        public DateTime PublishedDate { get; set; }

        [XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
        public MediaContent MediaContent { get; set; }

        [XmlElement(ElementName = "link")]
        public string Link { get; set; }

    }

    [XmlRoot(ElementName = "channel")]
    public class Channel
    {
        [XmlElement(ElementName = "item")]
        public ObservableCollection<Item> Items { get; set; }
    }

    [XmlRoot(ElementName = "rss")]
    public class Posts
    {
        [XmlElement(ElementName = "channel")]
        public Channel Channel { get; set; }
    }
}


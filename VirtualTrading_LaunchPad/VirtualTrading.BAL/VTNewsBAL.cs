using System;
using System.Collections.Generic;
using System.Text;
using VirtualTrading.Model;
using Newtonsoft.Json;
using System.Xml;

namespace VirtualTrading.BAL
{
    public class VTNewsBAL
    {
        // Here parse the xml from this URL "https://www.nasdaq.com/feed/rssoutbound?category=Markets"
        // Create a News object

        public List<News> GetNyseNews()
        {
            List<News> newsList = new List<News>();

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("https://www.cnbc.com/id/10000664/device/rss/rss.html");

                News newObj;

                //try to use for each loop and de serilise the xml into news object
                for (int i = 1; i < xmlDoc.GetElementsByTagName("title").Count; i++)
                {
                    newObj = new News();
                    newObj.title = (xmlDoc.GetElementsByTagName("title")[i]).InnerText.Trim();
                    newObj.link = (xmlDoc.GetElementsByTagName("link")[i]).InnerText.Trim();
                    newObj.description = (xmlDoc.GetElementsByTagName("description")[i]).InnerText.Trim();
                    newObj.pubDate = (xmlDoc.GetElementsByTagName("pubDate")[i]).InnerText.Trim();

                    newsList.Add(newObj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("        Error to load URL");
                Console.WriteLine("        Message: " + e.Message);
            }

            return newsList;
        }
    }
}

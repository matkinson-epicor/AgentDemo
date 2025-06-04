using System;

namespace AgentDemo.Models
{
    public class NewsArticleViewModel
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
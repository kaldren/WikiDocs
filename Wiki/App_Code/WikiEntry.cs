using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Wiki.App_Code
{
    public class WikiEntry
    {
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Content { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public string UpdatedBy { get; private set; }
        public List<Category> Categories { get; private set; }
        public List<Tag> Tags { get; private set; }

        public WikiEntry(string title, string content, string createdby,
            DateTimeOffset createdat, DateTimeOffset updatedat, string updatedby, List<Category> categories, List<Tag> tags)
        {
            Title = title;
            Content = content;
            CreatedBy = createdby;
            CreatedAt = createdat;
            UpdatedAt = updatedat;
            UpdatedBy = updatedby;
            Categories = categories;
            Tags = tags;
        }
    }

    public class Category
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }

    public class Tag
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
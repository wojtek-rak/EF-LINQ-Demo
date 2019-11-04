using System;
using System.Collections.Generic;

namespace AzureDemo
{
    public partial class Posts
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

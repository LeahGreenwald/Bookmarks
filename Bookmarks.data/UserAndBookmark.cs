using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Bookmarks.data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public List<Bookmark> Bookmarks { get; set; }
    }
    public class Bookmark
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User User { get; set; }
    }
    public class TopUrl
    {
        public string Url { get; set; }
        public int Count { get; set; }
    }
}


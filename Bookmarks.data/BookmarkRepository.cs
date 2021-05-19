using Bookmarks.data.ReactAuthDemo.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookmarks.data
{
    public class BookmarkRepository
    {
        private readonly string _connectionString;
        public BookmarkRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void AddBookmark(Bookmark bookmark)
        {
            var ctx = new BookmarksContext(_connectionString);
            ctx.Bookmarks.Add(bookmark);
            ctx.SaveChanges();
        }
        public List<Bookmark> GetBookmarks(int Id)
        {
            var ctx = new BookmarksContext(_connectionString);
            return ctx.Bookmarks.Where(b => b.UserId == Id).ToList();
        }
        public void Delete(int id)
        {
            var ctx = new BookmarksContext(_connectionString);
            ctx.Database.ExecuteSqlInterpolated($"DELETE FROM Bookmarks WHERE Id = {id}");
        }
        public void Update(string title, int id)
        {
            using var context = new BookmarksContext(_connectionString);
            context.Database.ExecuteSqlInterpolated($"UPDATE Bookmarks SET Title = {title} WHERE Id = {id}");
        }
        public List<TopUrl> GetTop5()
        {
            using var ctx = new BookmarksContext(_connectionString);
            return ctx.Bookmarks.GroupBy(b => b.Url).OrderByDescending(b => b.Count()).Take(5).Select(b => new TopUrl { Count = b.Count(), Url = b.Key}).ToList(); ;

           // var TopUrls = ctx.Database.ExecuteSqlInterpolated($"select Url, COUNT(*) as count from Bookmarks group by Url").ToList();
        }
    }
}

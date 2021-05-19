using Bookmarks.data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookmarks.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarksController : ControllerBase
    {
        private readonly string _connectionString;
        public BookmarksController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }
        [HttpPost]
        [Route("addbookmark")]
        public void AddBookmark(Bookmark bookmark)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.AddBookmark(bookmark);
        }
        [HttpGet]
        [Route("getbookmarks")]
        public List<Bookmark> GetBookmarks(int Id)
        {
            var repo = new BookmarkRepository(_connectionString);
            return repo.GetBookmarks(Id);
        }
        [HttpPost]
        [Route("delete")]
        public void Delete(int id)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.Delete(id);
        }
        [HttpPost]
        [Route("update")]
        public void Update(int id, string title)
        {
            var repo = new BookmarkRepository(_connectionString);
            repo.Update(title, id);

        }
        [HttpGet]
        [Route("gettop5")]
        public List<TopUrl> GetTop5()
        {
            var repo = new BookmarkRepository(_connectionString);
            return repo.GetTopUrls();
        }
    }
}

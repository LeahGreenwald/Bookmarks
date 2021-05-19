using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookmarks.data
{
    namespace ReactAuthDemo.Data
    {
        public class BookmarksContext : DbContext
        {
            private readonly string _connectionString;

            public BookmarksContext(string connectionString)
            {
                _connectionString = connectionString;
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }

            public DbSet<User> Users { get; set; }
            public DbSet<Bookmark> Bookmarks { get; set; }
        }
    }
}

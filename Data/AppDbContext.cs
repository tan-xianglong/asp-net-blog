using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 1,
                Title = "Man must explore, and this is exploration at its greatest",
                Subtitle = "Problems look mighty small from 150 miles up",
                Content = "Loren Ipsum",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 2,
                Title = "I believe every human has a finite number of heartbeats. I don't intend to waste any of mine.",
                Content = "Loren Ipsum",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Post>().HasData(new Post
            {
                PostId = 3,
                Title = "Science has not yet mastered prophecy",
                Subtitle = "We predict too much for the next year and yet far too little for the next ten.",
                Content = "Loren Ipsum",
                CreateDate = DateTime.Now
            });

            modelBuilder.Entity<Contact>().HasData(new Contact
            {
                ContactId = 1,
                Name = "John Piper",
                Email = "john@mail.com",
                PhoneNumber = "12345",
                Message = "Please contact me.",
                CreateDate = DateTime.Now
            });
        }
    }
}

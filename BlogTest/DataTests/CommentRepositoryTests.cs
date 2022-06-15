using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest.DataTests
{
    public class CommentRepositoryTests
    {
        private CommentRepository _commentRepository;

        public CommentRepositoryTests()
        {
            //Creating MockDbContext using Sqlite
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection);

            var mockDbContext = new AppDbContext(optionsBuilder.Options);
            mockDbContext.Database.EnsureCreated();

            //Initialize repository
            _commentRepository = new CommentRepository(mockDbContext);
        }

        [Fact]
        public async Task CommitAsync_SaveChanges_MustReturnInt()
        {
            //Arrange

            //Act
            var result = await _commentRepository.CommitAsync();

            //Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task DeleteAsync_ExistingCommentId_MustReturnPost()
        {
            //Arrange
            var commentId = 1;

            //Act
            var result = await _commentRepository.DeleteAsync(commentId);

            //Assert
            Assert.IsType<Comment>(result);
        }

        [Fact]
        public async Task DeleteAsync_NoneExistingCommentId_MustReturnNull()
        {
            //Arrange
            var commentId = 999;

            //Act
            var result = await _commentRepository.DeleteAsync(commentId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetCommentByIdAsync_ExistingCommentId_MustReturnPost()
        {
            //Arrange
            var commentId = 1;

            //Act
            var result = await _commentRepository.GetCommentByIdAsync(commentId);

            //Assert
            Assert.IsType<Comment>(result);
        }

        [Fact]
        public async Task GetCommentByIdAsyncc_NoneExistingCommentId_MustReturnNull()
        {
            //Arrange
            var commentId = 999;

            //Act
            var result = await _commentRepository.GetCommentByIdAsync(commentId);

            //Assert
            Assert.Null(result);
        }
    }
}

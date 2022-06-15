using Data;
using Data.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class PostRepositoryTests
    {
        [Fact]
        public async Task GetPostByIdAsync_InputPostId_ShouldReturnPostWithComments()
        {
            //Arrange
            //Creating MockDbContext using Sqlite
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlite(connection);

            var mockDbContext = new AppDbContext(optionsBuilder.Options);
            mockDbContext.Database.EnsureCreated();

            //setting up expected value
            var postId = 1;
            var expectedNumOfComments = await mockDbContext.Comments
                .Where(c => c.PostId == postId)
                .CountAsync();

            var postRepository = new PostRepository(mockDbContext);

            //Act
            var post = await postRepository.GetPostByIdAsync(postId);

            //Assert
            var returnPost = Assert.IsType<Post>(post);
            Assert.Equal(expectedNumOfComments, returnPost.Comments.Count);
        }
    }
}

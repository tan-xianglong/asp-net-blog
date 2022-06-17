using Data;
using Data.Entities;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class CommentServicesWebApiTests
    {
        [Fact]
        public async Task DeleteCommentAsync_ShouldCallDeleteAndCommitCommand()
        {
            //Arrange
            var commentRepositoryMock = Substitute.For<ICommentRepository>();
            var commentService = new CommentServicesWebApi(commentRepositoryMock);

            //Act
            await commentService.DeleteCommentAsync(default);

            //Assert
            await commentRepositoryMock.Received().DeleteAsync(default);
            await commentRepositoryMock.Received().CommitAsync();
        }
        
        [Fact]
        public async Task DeleteCommentAsync_ExistingCommentId_ShouldReturnFoundComment()
        {
            //Arrange

            var commentRepositoryMock = Substitute.For<ICommentRepository>();
            commentRepositoryMock.DeleteAsync(default)
                .ReturnsForAnyArgs(new Comment());

            var commentService = new CommentServicesWebApi(commentRepositoryMock);
            var commendId = 1;
            //Act
            var result = await commentService.DeleteCommentAsync(commendId);

            //Assert
            Assert.IsType<Comment>(result);
        }

        [Fact]
        public async Task DeleteCommentAsync_NonExistentCommentId_ShouldReturnNull()
        {
            //Arrange

            var commentRepositoryMock = Substitute.For<ICommentRepository>();
            commentRepositoryMock.DeleteAsync(default)
                .ReturnsNull();

            var commentService = new CommentServicesWebApi(commentRepositoryMock);
            var commendId = 1;
            //Act
            var result = await commentService.DeleteCommentAsync(commendId);

            //Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task SaveCommentAsync_ShouldReturnIntUponSave()
        {
            //Arrange
            var commentRepositoryMock = Substitute.For<ICommentRepository>();
            commentRepositoryMock.CommitAsync().Returns(1);
            var commentViewModel = new CommentViewModel
            {
                PostId = 1,
                Author = "Jack",
                Body = "Test",
                Email = "a@a.com"
            };

            var commentService = new CommentServicesWebApi(commentRepositoryMock);

            //Act
            var result = await commentService.SaveCommentAsync(commentViewModel);

            //Assert
            Assert.IsType<int>(result);
        }

        [Fact]
        public async Task SaveCommentAsync_ShouldCallAddAndCommitCommand()
        {
            //Arrange
            var commentRepositoryMock = Substitute.For<ICommentRepository>();
            var commentService = new CommentServicesWebApi(commentRepositoryMock);
            var commentViewModelMock = new CommentViewModel
            {
                Author = "Author",
                Body = "Test",
                Email = "a@a.com",
                PostId = 1,
            };

            //Act
            var result = await commentService.SaveCommentAsync(commentViewModelMock);

            //Assert
            commentRepositoryMock.ReceivedWithAnyArgs().Add(default);
            await commentRepositoryMock.Received().CommitAsync();
        }
    }
}

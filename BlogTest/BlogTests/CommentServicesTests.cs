using Blog.Models.ViewModels.Comments;
using Blog.Models.ViewModels.Posts;
using Blog.Services;
using BlogTest.Utilities.HttpMessageHandlers;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest.BlogTests
{
    public class CommentServicesTests
    {   
        private SaveCommentHandler messageHandler = new SaveCommentHandler();

        [Fact]
        public async Task SaveCommentAsync_SuccessfulSave_MustReturnCommentSaveMessage()
        {
            //Arrange
            var expectedMessageReceived = "Comment has been saved.";
            var postViewModel = new PostViewModel
            {
                Comment = new CommentViewModel
                {
                    Author = "MockAuthor",
                    CommentId = 1,
                    Body = "MockContent",
                    Email = "a@mock.com"
                }
            };
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.CreateClient(default)
                .ReturnsForAnyArgs(new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri("https://example.com/")
                });

            var commentServices = new CommentServices(httpClientFactory);

            //Act
            var result = await commentServices.SaveCommentAsync(postViewModel);

            //Assert
            Assert.Equal(expectedMessageReceived, result);
        }

        [Fact]
        public async Task SaveCommentAsync_FailedSave_MustReturnCommentSaveMessage()
        {
            //Arrange
            var expectedMessageReceived = "Comment has not been found.";
            var postViewModel = new PostViewModel();
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.When(x => x.CreateClient(default))
                .Do(x => { throw new Exception(); });

            var commentServices = new CommentServices(httpClientFactory);

            //Act
            var result = await commentServices.SaveCommentAsync(postViewModel);

            //Assert
            Assert.Equal(expectedMessageReceived, result);
        }

        [Fact]
        public async Task DeleteCommentAsync_SuccessfulDelete_MustReturnCommentDeleted()
        {
            //Arrange
            var expectedMessageReceived = "Comment deleted.";
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.CreateClient(default)
                .ReturnsForAnyArgs(new HttpClient(messageHandler)
                {
                    BaseAddress = new Uri("https://example.com/")
                });

            var commentServices = new CommentServices(httpClientFactory);
            var dummyCommentId = 1;

            //Act
            var result = await commentServices.DeleteCommentAsync(dummyCommentId);

            //Assert
            Assert.Equal(result, expectedMessageReceived);
        }

        [Fact]
        public async Task DeleteCommentAsync_FailedDelete_MustReturnCommentNotFound()
        {
            //Arrange
            var expectedMessageReceived = "Comment not found.";
            var httpClientFactory = Substitute.For<IHttpClientFactory>();
            httpClientFactory.When(x => x.CreateClient(default))
                .Do(x => { throw new Exception(); });

            var commentServices = new CommentServices(httpClientFactory);
            var dummyCommentId = 1;

            //Act
            var result = await commentServices.DeleteCommentAsync(dummyCommentId);

            //Assert
            Assert.Equal(result, expectedMessageReceived);
        }
    }
}

using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class CommentControllerWebApiTests
    {
        [Fact]
        public async Task SaveComment_SaveSuccess_MustReturnOk()
        {
            //Arrange
            var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
            commentServicesMock.SaveCommentAsync(default)
                .ReturnsForAnyArgs(Task.FromResult(1));

            var commentController = new CommentController(commentServicesMock);

            //Act
            var result = await commentController.SaveComment(default);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task SaveComment_SaveFail_MustReturnError500()
        {
            //Arrange
            var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
            commentServicesMock
                .When(x => x.SaveCommentAsync(default))
                .Do(x => { throw new Exception(); });

            var commentController = new CommentController(commentServicesMock);
            var statusCodeError = 500;

            //Act
            //Func<Task> action = async () => await commentController.SaveComment(default);
            var result = await commentController.SaveComment(default);

            //Assert
            //var caughtException = await Assert.ThrowsAsync<Exception>(action);
            //Assert.Contains("Database Failure", caughtException.Message);
            var ObjResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(statusCodeError, ObjResult.StatusCode);

        }

        //[Fact]
        //public async Task SaveComment_InvalidModel_MustReturnBadRequest()
        //{
        //    //Arrange
        //    var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
        //    var commentViewModelMock = new CommentViewModel
        //    {
        //        Author = "TestTest10TestTest10TestTest10TestTest10TestTest10TestTest10"
        //    };

        //    var commentController = new CommentController(commentServicesMock);

        //    //Act
        //    var result = await commentController.SaveComment(commentViewModelMock);

        //    //Assert
        //    Assert.IsType<BadRequestObjectResult>(result);
        //}

        [Fact]
        public async Task DeleteComment_ValidCommentIdDeleteSuccess_MustReturnOk()
        {
            //Arrange
            var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
            commentServicesMock.DeleteCommentAsync(default)
                .Returns(Task.FromResult(new Comment()));

            var commentController = new CommentController(commentServicesMock);

            //Act
            var result = await commentController.DeleteComment(default);


            //Assert
            Assert.IsType<OkResult>(result);


        }

        [Fact]
        public async Task DeleteComment_InvalidCommentIdDeleteFail_MustReturnNotFound()
        {
            //Arrange
            var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
            commentServicesMock.DeleteCommentAsync(default)
                .ReturnsNull();

            var commentController = new CommentController(commentServicesMock);

            //Act
            var result = await commentController.DeleteComment(default);

            //Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteComment_DeleteError_MustReturnError500()
        {
            //Arrange
            var commentServicesMock = Substitute.For<ICommentServicesWebApi>();
            commentServicesMock
                .When(x => x.DeleteCommentAsync(default))
                .Do(x => { throw new Exception(); });

            var commentController = new CommentController(commentServicesMock);
            var statusCodeError = 500;

            //Act
            //Func<Task> action = async () => await commentController.DeleteComment(default);
            var result = await commentController.DeleteComment(default);

            //Assert
            //var caughtException = await Assert.ThrowsAsync<Exception>(action);
            //Assert.Contains("Database Failure", caughtException.Message);
            var ObjResult = Assert.IsType<ObjectResult>(result);
            Assert.Equal(statusCodeError, ObjResult.StatusCode);

        }
    }
}

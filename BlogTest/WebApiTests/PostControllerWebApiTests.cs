using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class PostControllerWebApiTests
    {
        private PostController CreateDefaultPostController()
        {
            var postServicesMock = Substitute.For<IPostServicesWebApi>();
            postServicesMock.GetPostViewModelAsync(1)
                .Returns(Task.FromResult(
                    new PostViewModel
                    {
                        PostId = 1,
                        Content = "Lorem Ipsum",
                        Title = "Test 1",
                        Subtitle = "test",
                        CreateDate = DateTime.Now,
                        Comments = new List<CommentViewModel>
                        {
                            new CommentViewModel()
                            {
                                CommentId = 1,
                                Author = "Jack",
                                Body = "Lorem Ipsum",
                                Email = "a@a.com",
                                CreateDate= DateTime.Now,
                            },
                            new CommentViewModel()
                            {
                                CommentId = 2,
                                Author = "John",
                                Body = "Lorem Ipsum",
                                Email = "a@a.com",
                                CreateDate= DateTime.Now,
                            }
                        }
                    }));
            return new PostController(postServicesMock);
        }

        [Fact]
        public async Task GetPost_ValidPostId_MustReturnOkWithPostViewModel()
        {
            //Arrange
            var postController = CreateDefaultPostController();
            var validPostId = 1;

            //Act
            var result = await postController.GetPost(validPostId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PostViewModel>>(result);

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task GetPost_InValidPostId_MustReturnNotFound()
        {
            //Arrange
            var postController = CreateDefaultPostController();
            var invalidPostId = 2;

            //Act
            var result = await postController.GetPost(invalidPostId);

            //Assert
            var actionResult = Assert.IsType<ActionResult<PostViewModel>>(result);

            Assert.IsType<NotFoundResult>(actionResult.Result);
        }
    }
}

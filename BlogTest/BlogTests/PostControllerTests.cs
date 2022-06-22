using Blog.Controllers;
using Blog.Models.ViewModels.Comments;
using Blog.Models.ViewModels.Posts;
using Blog.Services;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest.BlogTests
{
    public class PostControllerTests
    {
        [Fact]
        public async Task GetDetail_PostFound_MustReturnViewWithPostViewModelObject()
        {
            //Arrange
            var postServicesMock = Substitute.For<IPostServices>();
            postServicesMock.GetPostViewModelAsync(default)
                .ReturnsForAnyArgs(new PostViewModel());

            var postController = new PostsController(postServicesMock);
            var dummyPostId = 1;

            //Act
            var result = await postController.Detail(dummyPostId);


            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<PostViewModel>(viewResult.Model);

        }


        [Fact]
        public async Task GetDetail_PostNotFound_MustRedirectToIndex()
        {
            //Arrange
            PostViewModel postViewModel = null;
            var expectedActionName = "Index";
            var postServicesMock = Substitute.For<IPostServices>();
            postServicesMock.GetPostViewModelAsync(default)
                .ReturnsForAnyArgs(postViewModel);

            var postController = new PostsController(postServicesMock);
            var dummyPostId = 1;

            //Act
            var result = await postController.Detail(dummyPostId);


            //Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(expectedActionName, viewResult.ActionName);

        }
    }
}

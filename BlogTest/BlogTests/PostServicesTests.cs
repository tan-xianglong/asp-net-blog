using Blog.Models;
using Blog.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.BlogTests
{
    public class PostServicesTests
    {
        [Fact]
        public void GetPostViewModel_ExistingPost_ReturnExistingPostViewModel()
        {
            //Arrange

            var expectedPostTitle = "Man must explore, and this is exploration at its greatest";

            var postRepositoryMock = new Mock<IPostRepository>();
            postRepositoryMock.Setup(method => method.GetPostByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(new Post()
            {
                PostId = 1,
                Title = "Man must explore, and this is exploration at its greatest",
                Subtitle = "Problems look mighty small from 150 miles up",
                Content = "Loren Ipsum",
                CreateDate = DateTime.Now
            });

            var postService = new PostServicesWebAPI(postRepositoryMock.Object);
            //Act

            var postViewModel = postService.GetPostViewModelAsync(3);

            //Assert
            var viewModel = Assert.IsType<PostViewModel>(postViewModel.Result);
            Assert.Equal(expectedPostTitle, viewModel.Title);
        }

        [Fact]
        public void GetPostViewModel_NoPostIdProvided_ReturnNewPostViewModel()
        {
            //Arrange
            var postService = new PostServices();
            //Act

            var postViewModel = postService.GetPostViewModelAsync(null);

            //Assert
            var viewModel = Assert.IsType<Blog.Models.ViewModels.Posts.PostViewModel>(postViewModel.Result);
            Assert.Null(viewModel.Title);
        }
    }
}

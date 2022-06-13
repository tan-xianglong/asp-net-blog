using Data;
using Data.Entities;
using Moq;
using System;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class PostServicesWebApiTests
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

            var postService = new PostServicesWebApi(postRepositoryMock.Object);
            //Act

            var postViewModel = postService.GetPostViewModelAsync(3);

            //Assert
            var viewModel = Assert.IsType<PostViewModel>(postViewModel.Result);
            Assert.Equal(expectedPostTitle, viewModel.Title);
        }
    }
}

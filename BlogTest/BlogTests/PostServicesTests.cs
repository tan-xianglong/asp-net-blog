using Blog.Models;
using Blog.Models.ViewModels.Posts;
using Blog.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BlogTest.BlogTests
{
    public class PostServicesTests
    {
        [Fact]
        public void GetCurrentSearch_HasNewSearch_CurrentSearchMustUpdate()
        {
            //Arrange
            var postRepositoryMock = new Mock<IPostRepository>();

            var newSearch = "new search";
            var currentSearch = "current search";

            var postService = new PostServices(postRepositoryMock.Object);
            //Act

            var searchString = postService.GetCurrentSearch(newSearch, currentSearch);
            
            //Assert
            Assert.Equal(newSearch, searchString);
        }

        [Fact]
        public void GetCurrentSearch_NoNewSearch_CurrentSearchRemains()
        {
            //Arrange
            var postRepositoryMock = new Mock<IPostRepository>();

            string newSearch = null;
            var currentSearch = "current search";

            var postService = new PostServices(postRepositoryMock.Object);
            //Act

            var searchString = postService.GetCurrentSearch(newSearch, currentSearch);

            //Assert
            Assert.Equal(currentSearch, searchString);
        }

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

            var postService = new PostServices(postRepositoryMock.Object);
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
            var postRepositoryMock = new Mock<IPostRepository>();
            var postService = new PostServices(postRepositoryMock.Object);
            //Act

            var postViewModel = postService.GetPostViewModelAsync(null);

            //Assert
            var viewModel = Assert.IsType<PostViewModel>(postViewModel.Result);
            Assert.Null(viewModel.Title);
        }
    }
}

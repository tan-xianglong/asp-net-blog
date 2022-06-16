using Data;
using Data.Entities;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Services;
using WebAPI.ViewModels;
using Xunit;

namespace BlogTest.WebApiTests
{
    public class PostServicesWebApiTests
    {
        private PostServicesWebApi CreateDefaultPostServices()
        {
            var postRepositoryMock = Substitute.For<IPostRepository>();
            postRepositoryMock.GetPostByIdAsync(default)
                .ReturnsForAnyArgs(new Post()
                {
                    PostId = 1,
                    Title = "Man must explore, and this is exploration at its greatest",
                    Subtitle = "Problems look mighty small from 150 miles up",
                    Content = "Loren Ipsum",
                    CreateDate = DateTime.Now,
                    Comments = new List<Comment>
                    {
                        new Comment()
                        {
                            CommentId = 1,
                            Author = "Jack",
                            Body = "Lorem Ipsum",
                            Email = "a@a.com",
                            CreateDate= DateTime.Now,
                            PostId = 1
                        },
                        new Comment()
                        {
                            CommentId = 2,
                            Author = "John",
                            Body = "Lorem Ipsum",
                            Email = "a@a.com",
                            CreateDate= DateTime.Now,
                            PostId = 1
                        }
                    }
                });

            return new PostServicesWebApi(postRepositoryMock);
        }

        [Fact]
        public async Task GetPostViewModel_ExistingPost_ReturnExistingPostViewModel()
        {
            //Arrange

            var expectedPostTitle = "Man must explore, and this is exploration at its greatest";

            var postService = CreateDefaultPostServices();

            //Act

            var postViewModel = await postService.GetPostViewModelAsync(3);

            //Assert 
            var viewModel = Assert.IsType<PostViewModel>(postViewModel);
            Assert.Equal(expectedPostTitle, viewModel.Title);
        }

        [Fact]
        public async Task GetPostViewModel_ExistingPost_ReturnExistingPostViewModelWithComments()
        {
            //Arrange
            var expectedNumOfComments = 2;

            var postService = CreateDefaultPostServices();

            //Act
            var postViewModel = await postService.GetPostViewModelAsync(3);

            //Assert
            Assert.Equal(expectedNumOfComments, postViewModel.Comments.Count());

        }
    }
}

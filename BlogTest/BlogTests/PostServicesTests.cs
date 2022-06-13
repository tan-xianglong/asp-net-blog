using Blog.Services;
using Xunit;

namespace BlogTest.BlogTests
{
    public class PostServicesTests
    {
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

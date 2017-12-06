using Microsoft.AspNetCore.Mvc;
using SampleApp.Api.Controllers;
using Xunit;

namespace SampleApp.Api.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _controller = new HomeController();
        }

        [Fact]
        public void TestGet()
        {
            var actionResult = _controller.Get();

            var objectResult = Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            var value = Assert.IsAssignableFrom<string>(objectResult.Value);
            Assert.Equal("Hello World!", value);
        }
    }
}

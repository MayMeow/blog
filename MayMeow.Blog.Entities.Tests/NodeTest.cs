using System;
using MayMeow.Blog.Entities.Content;
using Xunit;

namespace MayMeow.Blog.Entities.Tests
{
    public class NodeTest
    {
        [Fact]
        public void TestModel()
        {
            var model =  new Node
            {
                Id = 1,
                Title = "Model title",
                Body = "Some text in body",
                CreatedAt = DateTime.Now,
                ModifiedAt = DateTime.Now
            };
            
            Assert.Equal("Model title", model.Title);
            Assert.Equal("Some text in body", model.Body);
        }
    }
}
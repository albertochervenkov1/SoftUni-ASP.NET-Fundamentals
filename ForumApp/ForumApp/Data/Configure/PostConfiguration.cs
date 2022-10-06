using ForumApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ForumApp.Data.Configure
{
    public class PostConfiguration:IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            List<Post> posts = GetPost();
            builder.HasData(posts);
        }

        private List<Post> GetPost()
        {
            return new List<Post>()
            {
                new Post()
                {
                    Id = 1,
                    Title = "First Post",
                    Content = "Content first post"
                },
                new Post()
                {
                    Id = 2,
                    Title = "Second Post",
                    Content = "Content second post"
                },
                new Post()
                {
                    Id = 3,
                    Title = "Third Post",
                    Content = "Content third post"
                }
            };
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniBlog.Core.Models.Entity;

namespace UniBlog.DataAccess.DataConfiguration;

public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.HasOne<User>().WithMany(user => user.Posts).HasForeignKey(post => post.AuthorId);
    }
}
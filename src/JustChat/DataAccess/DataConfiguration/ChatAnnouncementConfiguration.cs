using JustChat.Core.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JustChat.DataAccess.DataConfiguration;

public class ChatAnnouncementConfiguration : IEntityTypeConfiguration<GroupAnnouncement>
{
    public void Configure(EntityTypeBuilder<GroupAnnouncement> builder)
    {
        builder.HasOne<GroupChat>().WithMany(groupChat => groupChat.Announcements).HasForeignKey(announcement => announcement.GroupId);
    }
}
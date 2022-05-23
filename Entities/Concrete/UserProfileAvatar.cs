using Core.Entities;

namespace Entities.Concrete
{
    public class UserProfileAvatar : IEntity
    {
        public int UserProfileAvatarId { get; set; }
        public string ProfileAvatarPath { get; set; }
    }
}

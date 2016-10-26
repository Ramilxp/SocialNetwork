using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Domain;

namespace BusinessLogic.Implementations
{
    public class EFAvatarsRepository: IAvatarsRepository
    {
        private EFDbContext context;
        public EFAvatarsRepository(EFDbContext context)
        {
            this.context = context;
        }
        public Domain.Entities.Avatar GetAvatarByUserId(int userId)
        {
            return context.Avatars.FirstOrDefault(x => x.UserId == userId);
        }

        public void SaveAvatar(Domain.Entities.Avatar avatar)
        {
            if (avatar.Id == 0)
                context.Avatars.Add(avatar);
            else
                context.Entry(avatar).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteAvatar(Domain.Entities.Avatar avatar)
        {
            context.Avatars.Remove(avatar);
            context.SaveChanges();
        }
    }
}

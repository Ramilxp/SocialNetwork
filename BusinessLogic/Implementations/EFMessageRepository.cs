using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Interfaces;
using Domain;
using Domain.Entities;

namespace BusinessLogic.Implementations
{
    public class EFMessageRepository : IMessageRepository
    {
        private EFDbContext context;
        public EFMessageRepository(EFDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Message> GetMessages()
        {
            return context.Messages;
        }

        public IEnumerable<Message> GetIncomingMessagesByUserId(int userId)
        {
            return context.Messages.Where(x => x.UserId == userId);
        }

        public IEnumerable<Message> GetOutgoingMessagesByUserId(int userId)
        {
            return context.Messages.Where(x => x.UserFromId == userId);
        }

        public IEnumerable<Message> GetUserChat(int userId,int userToId)
        {
            return context.Messages.Where(x => x.UserId == userId && x.UserFromId == userToId || 
                                         x.UserId == userToId && x.UserFromId == userId);
        }

        public void SaveMessage(Message message)
        {
            if (message.Id == 0)
                context.Messages.Add(message);
            else
                context.Entry(message).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteMessage(Message message)
        {
            context.Messages.Remove(message);
            context.SaveChanges();
        }

    }
}

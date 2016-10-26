using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IMessageRepository
    {
        IEnumerable<Message> GetMessages();
        IEnumerable<Message> GetIncomingMessagesByUserId(int userId);
        IEnumerable<Message> GetOutgoingMessagesByUserId(int userId);
        IEnumerable<Message> GetUserChat(int userId, int userToId);
        void SaveMessage(Message message);
        void DeleteMessage(Message message);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    //Класс, через который централизованно происходит обмен данными в приложении
    public class DataManager
    {
        private IUsersRepository usersRepository;
        private IFriendsRepository friendsRepository;
        private IFriendRequestsRepository friendRequestsRepository;
        private IMessagesRepository messagesRepository;
        private IMessageRepository messageRepository;
        private PrimaryMembershipProvider provider;
        private IAvatarsRepository avatarsRepository;

        public DataManager(IUsersRepository usersRepository,
                           IFriendsRepository friendsRepository,
                           IFriendRequestsRepository friendRequestsRepository,
                           IMessagesRepository messagesRepository,
                           IMessageRepository messageRepository, 
                           PrimaryMembershipProvider provider,
                           IAvatarsRepository avatarsRepository)
        {
            this.usersRepository = usersRepository;
            this.friendsRepository = friendsRepository;
            this.friendRequestsRepository = friendRequestsRepository;
            this.messagesRepository = messagesRepository;
            this.messageRepository = messageRepository;
            this.provider = provider;
            this.avatarsRepository = avatarsRepository;
        }

        public IUsersRepository Users { get { return usersRepository; } }
        public IFriendsRepository Friends { get { return friendsRepository; } }
        public IFriendRequestsRepository FriendRequests { get { return friendRequestsRepository; } }
        public IMessagesRepository Messages { get { return messagesRepository; } }
        public IMessageRepository Messagess { get { return messageRepository; } }
        public PrimaryMembershipProvider MembershipProvider { get { return provider; } }
        public IAvatarsRepository Avatars {get { return avatarsRepository; }
        }
    }
}

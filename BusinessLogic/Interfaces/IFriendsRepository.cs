using System.Collections.Generic;
using Domain.Entities;

namespace BusinessLogic.Interfaces
{
    public interface IFriendsRepository
    {
        IEnumerable<Friend> GetFriends();
        //Проверяем, являются ли два пользователя друзьями
        bool UsersAreFriends(int userId, int user2Id);
        void AddFriend(Friend friend);
        void DeleteFriend(Friend friend);
    }
}

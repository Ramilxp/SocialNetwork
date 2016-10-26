using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class FriendsViewModel
    {
        public IEnumerable<User> Friends { get; set; }

        //Входящие заявки в друзья
        public IEnumerable<User> IncomingRequests { get; set; }

        //Исходящие заявки в друзья
        public IEnumerable<User> OutgoingRequests { get; set; } 
    }
}
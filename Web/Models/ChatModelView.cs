using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class ChatModelView
    {
        public User MeUser;
        public User UserFrom;

        public List<Message> Chat = new List<Message>();
    }
}
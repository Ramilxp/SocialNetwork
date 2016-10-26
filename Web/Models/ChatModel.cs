using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class ChatModel
    {
        // Все пользователи чата
        public List<User> Users;
        // все сообщения
        public List<ChatMessage> Messages;

        public ChatModel()
        {
            Users = new List<User>();
            Messages = new List<ChatMessage>();

            Messages.Add(new ChatMessage()
            {
                Text = "Чат запущен " + DateTime.Now
            });
        }
    }

    public class ChatMessage
    {
        // автор сообщения, если null - автор сервер
        public User AutorMessage;
        public User UserFrom;
        // время сообщения
        public DateTime Date = DateTime.Now;
        // текст
        public string Text = "";

    }
}
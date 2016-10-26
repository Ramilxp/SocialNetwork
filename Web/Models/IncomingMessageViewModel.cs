using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class IncomingMessageViewModel
    {
        public Message Message { get; set; }

        //Автор
        public User UserFrom { get; set; }
    }
}
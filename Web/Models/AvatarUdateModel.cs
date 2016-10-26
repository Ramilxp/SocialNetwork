using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;

namespace Web.Models
{
    public class AvatarUdateModel
    {
        public Avatar Avatar { get; set; }
        public int UserId { get; set; }
    }
}
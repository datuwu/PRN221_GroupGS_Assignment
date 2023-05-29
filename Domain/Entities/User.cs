﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }

        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<Comment> CommentGroups { get; set; }
    }
}

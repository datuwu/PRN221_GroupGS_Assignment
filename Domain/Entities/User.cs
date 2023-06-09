﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
      
        public int?  RoleId { get; set; }
        public Role Role { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsDisabled { get; set; }

        public ICollection<UserGroup>? UserGroups { get; set; }
        public ICollection<Comment>? CommentGroups { get; set; }
    }
}

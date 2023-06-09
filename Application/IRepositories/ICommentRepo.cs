﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IRepositories
{
    public interface ICommentRepo : IGenericRepo<Comment>
    {
        Task<List<Comment>> GetAllCommentByPostId(int postId);
        Task<List<Comment>> GetAllCommentByGroupId(int groupId);
    }

}

﻿using Application.IRepositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infracstuructures.Repositories
{
    public class PostRepo : GenericRepo<Post>, IPostRepo
    {
        private  readonly AppDbContext _appDbContext;
        public PostRepo(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<List<Post>> GetSearchPost(string content)
        {
            var searchPost=await _appDbContext.Posts.Where(x=>x.Content.Contains(content)).ToListAsync();
            return searchPost;
        }

        public async Task<List<Post>> SortPostByCreateDate(int groupId)
        {
            var sortedPosts = await _appDbContext.Posts
                .Where(p => p.GroupId == groupId && (p.PostStatusId == 1 || p.PostStatusId == 4))
                .OrderByDescending(p => p.CreateTime)
                .ToListAsync();

            return sortedPosts;
        }

        public async Task<int> GetPostAmountInGroup(int groupId)
        {
            int postAmount = await _appDbContext.Posts.CountAsync(p => p.GroupId == groupId);
            return postAmount;
        }

		public async Task<List<Post>> GetPostsByGroupId(int groupId)
		{
			var posts = await _appDbContext.Posts
				.Include(p => p.User) // Eager loading of the User navigation property
				.Where(p => p.GroupId == groupId)
				.OrderByDescending(p => p.CreateTime)
				.ToListAsync();

			return posts;
		}


		public async Task<List<Post>> GetPostsByUserId(int userId, int groupId)
        {
            return await _appDbContext.Posts
                .Where(p => p.CreateUserId == userId && p.GroupId == groupId && (p.PostStatusId == 1 || p.PostStatusId == 4))
                .ToListAsync();
        }
        public async Task<List<Post>> GetPostsPendingByUserId(int userId, int groupId)
        {
            return await _appDbContext.Posts
                .Where(p => p.CreateUserId == userId && p.GroupId == groupId && p.PostStatusId == 2)
                .ToListAsync();
        }
        public async Task<List<Post>> GetPostsBannedByUserId(int userId, int groupId)
        {
            return await _appDbContext.Posts
                .Where(p => p.CreateUserId == userId && p.GroupId == groupId && p.PostStatusId == 3)
                .ToListAsync();
        }
    }
}

﻿using ClassLibrary.Repositories.GenericRep;
using Discord_Copycat.Data;
using Discord_Copycat.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Repositories.UserRep
{
    internal class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(DiscordContext discordContext) : base(discordContext) { }

        public async Task<User?> GetWithLogsAsync(Guid id, Guid friendId)
        {
            User friend1 = await _table.Where(u => u.Id == id)
                .Include(u => u.FirstFriend)
                .ThenInclude(f => f.Logs)
                .FirstAsync();

            friend1.FirstFriend = friend1.FirstFriend.Where(f => f.User2Id == friendId).ToList();

            if (friend1.FirstFriend.Count == 1)
            {
                return friend1;
            }

            User friend2 = await _table.Where(u => u.Id == id)
                .Include(u => u.SecondFriend)
                .ThenInclude(f => f.Logs)
                .FirstAsync();

            friend2.SecondFriend = friend2.SecondFriend.Where(f => f.User1Id == friendId).ToList();

            if (friend2.SecondFriend.Count == 1)
            {
                return friend2;
            }

            return null;
        }

        public async Task<User> GetWithFriendsAsync(Guid id)
        {
            User friends = await _table.Where(u => u.Id == id)
                .Include(u => u.FirstFriend)
                .ThenInclude(f => f.User2)
                .Include(u => u.SecondFriend)
                .ThenInclude(f => f.User1)
                .FirstAsync();

            return friends;
        }

        public async Task<User> GetWithServersAsync(Guid id)
        {
            User servers = await _table.Where(u => u.Id == id)
                .Include(u => u.Servers)
                .ThenInclude(s => s.Server)
                .FirstAsync();

            return servers;
        }
    }
}

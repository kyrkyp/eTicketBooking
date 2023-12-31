﻿using eTicketBooking.Data.Base;
using eTicketBooking.Data.Services.Contracts;
using eTicketBooking.Models;

namespace eTicketBooking.Data.Services
{
    public class ActorsService : BaseRepository<Actor>, IActorsService
    {
        public ActorsService(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
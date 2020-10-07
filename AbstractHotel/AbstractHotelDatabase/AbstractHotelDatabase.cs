using AbstractHotelDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractHotelDatabaseImplement
{
    public class AbstractHotelDatabaseImplement : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(@"Server=(local)\SQLEXPRESS;Initial Catalog=AbstractHotel;Integrated Security=True;MultipleActiveResultSets=True;");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public virtual DbSet<Client> Clients { set; get; }
        public virtual DbSet<Сonference> Сonferences { set; get; }
        public virtual DbSet<Room> Rooms { set; get; }
        public virtual DbSet<СonferenceRoom> СonferenceRooms { set; get; }
        public virtual DbSet<Lunch> Lunches { set; get; }
        public virtual DbSet<LunchRoom> LunchRooms { set; get; }
        public virtual DbSet<Request> Requests { set; get; }
        public virtual DbSet<RequestLunch> RequestLunches { set; get; }
    }
}

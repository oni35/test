using DomainModel;
using Microsoft.EntityFrameworkCore;
using System;

namespace Dal
{
    public class BlueContext : DbContext
    {
		#region Attributs
		private DbSet<Address> addresses;
		private DbSet<Booking> bookings;
		private DbSet<Customer> customers;
		private DbSet<Hotel> hotels;
		private DbSet<Room> rooms;
        #endregion

        #region Properties
        public DbSet<Address> Addresses
		{
			get { return addresses; }
			set { addresses = value; }
		}

		public DbSet<Booking> Bookings
		{
			get { return bookings; }
			set { bookings = value; }
		}

		public DbSet<Customer> Customers
		{
			get { return customers; }
			set { customers = value; }
		}

		public DbSet<Room> Rooms
		{
			get { return rooms; }
			set { rooms = value; }
		}

		public DbSet<Hotel> Hotels
		{
			get { return hotels; }
			set { hotels = value; }
		}
		#endregion

		#region Constructors
		public BlueContext() : base()
		{

		}

		public BlueContext(DbContextOptions options) : base (options)
		{

		}
		#endregion

		#region Functions
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localDB)\mssqllocaldb; Initial Catalog =BlueDb; Integrated Security=true; ");//("chaine de connection")
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hotel>()
				.HasMany(h => h.Rooms) //aller : 1 hotel vers pls rooms
				.WithOne(r => r.Hotel);//retour (optinnel) : des rooms vers 1 hotel
			modelBuilder.Entity<Hotel>()
				.HasOne(h => h.Address);
			modelBuilder.Entity<Customer>()
				.HasMany(c => c.Bookings)
				.WithOne(b => b.Customer);
			modelBuilder.Entity<Customer>()
				.HasOne(c => c.Address);
			modelBuilder.Entity<Booking>()
				.HasMany(b => b.BookingRooms)
				.WithOne(br => br.Booking);
			modelBuilder.Entity<Room>()
				.HasMany(r => r.BookingRooms)
				.WithOne(b => b.Room);

			modelBuilder.Entity<BookingRoom>()
				.HasKey();

			base.OnModelCreating(modelBuilder);
		}
        #endregion
    }
}

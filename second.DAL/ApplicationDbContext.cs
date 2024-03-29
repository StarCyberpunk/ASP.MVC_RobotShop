﻿using Microsoft.EntityFrameworkCore;
using second.Domain.Entity;
using second.Domain.Enum;
using second.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;



namespace second.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
       : base(options)
        {
            
           
        }
        public DbSet<Robot> Robot { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Admin
            modelBuilder.Entity<User>(builder =>
            {
                

                builder.HasData(new User
                {
                    Id = 1,
                    Login = "Admin",
                    Password = HashPasswordHelper.HashPassword("123456"),
                    Role = Role.Admin
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();

                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Login).HasMaxLength(100).IsRequired();

                builder.HasOne(x => x.Profile)
                     .WithOne(x => x.User)
                     .HasPrincipalKey<User>(x => x.Id)
                     .OnDelete(DeleteBehavior.Cascade);

                builder.HasOne(x => x.Basket)
                    .WithOne(x => x.User)
                    .HasPrincipalKey<User>(x => x.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            //DefaultUser
            modelBuilder.Entity<User>(builder =>
            {
                

                builder.HasData(new User
                {
                    Id = 2,
                    Login = "DefaultUser",
                    Password = HashPasswordHelper.HashPassword("654321"),
                    Role = Role.User
                });

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Password).IsRequired();
                builder.Property(x => x.Login).HasMaxLength(100).IsRequired();
            });
            //Роботы
            modelBuilder.Entity<Robot>(builder =>
            {
               

                builder.HasData(new Robot
                {
                    Id = 1,
                    Name = "Robot1",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Speed = 230,
                    Model = "awda",
                    TypeRobot = TypeRobot.HomeRobot
                });
            });
            modelBuilder.Entity<Robot>(builder =>
            {
                

                builder.HasData(new Robot
                {
                    Id = 2,
                    Name = "Robot2",
                    Description = new string('A', 50),
                    DateCreate = DateTime.Now,
                    Speed = 23,
                    Model = "awdass",
                    TypeRobot = TypeRobot.PromshRobot
                });
            });

            modelBuilder.Entity<Profile>(builder =>
            {
               

                builder.Property(x => x.Id).ValueGeneratedOnAdd();
                builder.Property(x => x.Age);
                builder.Property(x => x.Address).HasMaxLength(200).IsRequired(false);

                builder.HasData(new Profile()
                {
                    Id = 1,
                    UserId = 1
                });
            });

            modelBuilder.Entity<Basket>(builder =>
            {
                builder.ToTable("Baskets").HasKey(x => x.Id);

                builder.HasData(new Basket()
                {
                    Id = 1,
                    UserId = 1
                });
            });

            modelBuilder.Entity<Order>(builder =>
            {
                builder.ToTable("Orders").HasKey(x => x.Id);

                builder.HasOne(r => r.Basket).WithMany(t => t.Orders)
                    .HasForeignKey(r => r.BasketId);
            });
        }
       
    }
}

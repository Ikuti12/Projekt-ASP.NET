﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateYourEntertainment.Auth;

namespace RateYourEntertainment.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Game> Games { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<GameReview> GameReviews { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

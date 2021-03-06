﻿using Microsoft.EntityFrameworkCore;

namespace egrihakarya
{
    public partial class ClassroomContext : DbContext
    {
        public ClassroomContext()
        {
        }

        public ClassroomContext(DbContextOptions<ClassroomContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Assignments> Assignments { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<UserAssignments> UserAssignments { get; set; }
        public virtual DbSet<UserClasses> UserClasses { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        public DbQuery<ClassView> ClassViews { get; set; }
        public DbQuery<CommentView> CommentViews { get; set; }
        public DbQuery<JoinClass> JoinClasses { get; set; }
        public DbQuery<UserAssignment> UsersAssignments { get; set; }
        public DbQuery<UserAssignmentAdmin> UserAssignmentAdmins { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}
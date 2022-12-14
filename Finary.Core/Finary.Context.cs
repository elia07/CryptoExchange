//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Finary.Core
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class FinaryEntities : DbContext
    {
        public FinaryEntities()
            : base("name=FinaryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<AdminRole> AdminRole { get; set; }
        public virtual DbSet<Exchange> Exchange { get; set; }
        public virtual DbSet<FacilitatorTransaction> FacilitatorTransaction { get; set; }
        public virtual DbSet<FileData> FileData { get; set; }
        public virtual DbSet<LoginHistory> LoginHistory { get; set; }
        public virtual DbSet<PrivateMessage> PrivateMessage { get; set; }
        public virtual DbSet<RefferalShareHistory> RefferalShareHistory { get; set; }
        public virtual DbSet<RefferalWallet> RefferalWallet { get; set; }
        public virtual DbSet<RefferalWithdrawal> RefferalWithdrawal { get; set; }
        public virtual DbSet<RialGateway> RialGateway { get; set; }
        public virtual DbSet<RialTransaction> RialTransaction { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<Signal> Signal { get; set; }
        public virtual DbSet<SystemFile> SystemFile { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserBankAccount> UserBankAccount { get; set; }
        public virtual DbSet<Withdrawal> Withdrawal { get; set; }
    }
}

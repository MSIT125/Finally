﻿//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebIndexHotel.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class dbHotelTest_3_2_2020Entities : DbContext
    {
        public dbHotelTest_3_2_2020Entities()
            : base("name=dbHotelTest_3_2_2020Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Administrator> Administrator { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<DiscountCode> DiscountCode { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<HotelImage> HotelImage { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PayInfo> PayInfo { get; set; }
        public virtual DbSet<RoomImage> RoomImage { get; set; }
        public virtual DbSet<RoomInformation> RoomInformation { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WoMoCo.Data;

namespace WoMoCo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WoMoCo.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("About");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CurrentJobTitle");

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("Employer");

                    b.Property<string>("FirstName");

                    b.Property<int?>("InterestId");

                    b.Property<string>("LastName");

                    b.Property<string>("Location");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserImage");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("InterestId");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WoMoCo.Models.CalenderEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<DateTime>("EventDateTime");

                    b.Property<string>("EventOwnerId");

                    b.Property<string>("EventType");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.HasIndex("EventOwnerId");

                    b.ToTable("CalenderEvents");
                });

            modelBuilder.Entity("WoMoCo.Models.Comm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CommType");

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("HasBeenViewed");

                    b.Property<int?>("InboxId");

                    b.Property<string>("Msg");

                    b.Property<string>("RecId");

                    b.Property<string>("ReceivingUserId");

                    b.Property<string>("SendingUserId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("InboxId");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SendingUserId");

                    b.ToTable("Comms");
                });

            modelBuilder.Entity("WoMoCo.Models.EventAlarm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AlarmMethod");

                    b.Property<DateTime>("AlarmTime");

                    b.Property<int?>("EventId");

                    b.Property<string>("Name");

                    b.Property<string>("OwnerId");

                    b.Property<bool>("isActive");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("OwnerId");

                    b.ToTable("EventAlarms");
                });

            modelBuilder.Entity("WoMoCo.Models.Inbox", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("HasBeenViewed");

                    b.Property<string>("Msg");

                    b.Property<string>("RecId");

                    b.Property<string>("ReceivingUserId");

                    b.Property<string>("SendingUserId");

                    b.Property<string>("Subject");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SendingUserId");

                    b.ToTable("Inboxes");
                });

            modelBuilder.Entity("WoMoCo.Models.Interest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BadgeImage");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("WoMoCo.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateSent");

                    b.Property<bool>("HasBeenViewed");

                    b.Property<string>("Msg");

                    b.Property<string>("RecId");

                    b.Property<string>("ReceivingUserId");

                    b.Property<string>("SendingUserId");

                    b.Property<string>("Status");

                    b.Property<string>("Subject");

                    b.HasKey("Id");

                    b.HasIndex("ReceivingUserId");

                    b.HasIndex("SendingUserId");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WoMoCo.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WoMoCo.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WoMoCo.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WoMoCo.Models.ApplicationUser", b =>
                {
                    b.HasOne("WoMoCo.Models.Interest")
                        .WithMany("Users")
                        .HasForeignKey("InterestId");
                });

            modelBuilder.Entity("WoMoCo.Models.CalenderEvent", b =>
                {
                    b.HasOne("WoMoCo.Models.ApplicationUser", "EventOwner")
                        .WithMany()
                        .HasForeignKey("EventOwnerId");
                });

            modelBuilder.Entity("WoMoCo.Models.Comm", b =>
                {
                    b.HasOne("WoMoCo.Models.Inbox")
                        .WithMany("Comms")
                        .HasForeignKey("InboxId");

                    b.HasOne("WoMoCo.Models.ApplicationUser", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId");

                    b.HasOne("WoMoCo.Models.ApplicationUser", "SendingUser")
                        .WithMany()
                        .HasForeignKey("SendingUserId");
                });

            modelBuilder.Entity("WoMoCo.Models.EventAlarm", b =>
                {
                    b.HasOne("WoMoCo.Models.CalenderEvent", "Event")
                        .WithMany("EventAlarms")
                        .HasForeignKey("EventId");

                    b.HasOne("WoMoCo.Models.ApplicationUser", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("WoMoCo.Models.Inbox", b =>
                {
                    b.HasOne("WoMoCo.Models.ApplicationUser", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId");

                    b.HasOne("WoMoCo.Models.ApplicationUser", "SendingUser")
                        .WithMany()
                        .HasForeignKey("SendingUserId");
                });

            modelBuilder.Entity("WoMoCo.Models.Message", b =>
                {
                    b.HasOne("WoMoCo.Models.ApplicationUser", "ReceivingUser")
                        .WithMany()
                        .HasForeignKey("ReceivingUserId");

                    b.HasOne("WoMoCo.Models.ApplicationUser", "SendingUser")
                        .WithMany()
                        .HasForeignKey("SendingUserId");
                });
        }
    }
}

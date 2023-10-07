using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Charity.Core.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Charitys> Charities { get; set; }

    public virtual DbSet<CharityCategory> CharityCategories { get; set; }

    public virtual DbSet<CharityContact> CharityContacts { get; set; }

    public virtual DbSet<CharityDonation> CharityDonations { get; set; }

    public virtual DbSet<CharityIssue> CharityIssues { get; set; }

    public virtual DbSet<CharityNotification> CharityNotifications { get; set; }

    public virtual DbSet<CharityPage> CharityPages { get; set; }

    public virtual DbSet<CharityRole> CharityRoles { get; set; }

    public virtual DbSet<CharityTestimonial> CharityTestimonials { get; set; }

    public virtual DbSet<CharityUser> CharityUsers { get; set; }


    public virtual DbSet<CharityVisaCard> CharityVisaCards { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("USER ID=mohammad;PASSWORD=mohammad1999;DATA SOURCE=localhost:1521/orcl");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("MOHAMMAD")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Charitys>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007819");

            entity.ToTable("CHARITY");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.Categoryid)
                .HasColumnType("NUMBER")
                .HasColumnName("CATEGORYID");
            entity.Property(e => e.Charityname)
                .HasMaxLength(255)
                .HasColumnName("CHARITYNAME");
            entity.Property(e => e.Goalprice)
                .HasPrecision(10)
                .HasColumnName("GOALPRICE");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Latitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LATITUDE");
            entity.Property(e => e.Longitude)
                .HasColumnType("NUMBER")
                .HasColumnName("LONGITUDE");
            entity.Property(e => e.Minprice)
                .HasPrecision(10)
                .HasColumnName("MINPRICE");
            entity.Property(e => e.Mission)
                .HasMaxLength(255)
                .HasColumnName("MISSION");
            entity.Property(e => e.Price)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("PRICE");
            entity.Property(e => e.Createddate)
                .HasColumnType("DATE")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Totalprice)
                .HasPrecision(10)
                .HasColumnName("TOTALPRICE");
            entity.Property(e => e.Userid)
               .HasColumnType("NUMBER")
               .HasColumnName("USERID");


            entity.HasOne(d => d.Category).WithMany(p => p.Charities)
                .HasForeignKey(d => d.Categoryid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007820");

            entity.HasOne(d => d.User).WithMany(p => p.Charities)
              .HasForeignKey(d => d.Userid)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("CHARITY_FK1");
        });

        modelBuilder.Entity<CharityCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007817");

            entity.ToTable("CHARITY_CATEGORY");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Categoryname)
                .HasMaxLength(255)
                .HasColumnName("CATEGORYNAME");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
        });

        modelBuilder.Entity<CharityContact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007808");

            entity.ToTable("CHARITY_CONTACT");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Contactname)
                .HasMaxLength(255)
                .HasColumnName("CONTACTNAME");
            entity.Property(e => e.Datecreated)
                .HasColumnType("DATE")
                .HasColumnName("DATECREATED");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .HasColumnName("MESSAGE");
            entity.Property(e => e.Pageid)
                .HasColumnType("NUMBER")
                .HasColumnName("PAGEID");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("PHONE");
            entity.Property(e => e.Subject)
                .HasMaxLength(255)
                .HasColumnName("SUBJECT");

            entity.HasOne(d => d.Page).WithMany(p => p.CharityContacts)
                .HasForeignKey(d => d.Pageid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007809");
        });

        modelBuilder.Entity<CharityDonation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007826");

            entity.ToTable("CHARITY_DONATION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.Charityid)
                .HasColumnType("NUMBER")
                .HasColumnName("CHARITYID");
            entity.Property(e => e.Donationdate)
                .HasColumnType("DATE")
                .HasColumnName("DONATIONDATE");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.Charity).WithMany(p => p.CharityDonations)
                .HasForeignKey(d => d.Charityid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CHARITY_DONATION_FK1");

            entity.HasOne(d => d.User).WithMany(p => p.CharityDonations)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CHARITY_DONATION_FK2");
        });

        modelBuilder.Entity<CharityIssue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007835");

            entity.ToTable("CHARITY_ISSUE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Datereported)
                .HasColumnType("DATE")
                .HasColumnName("DATEREPORTED");
            entity.Property(e => e.Issuedescription)
                .HasMaxLength(255)
                .HasColumnName("ISSUEDESCRIPTION");
            entity.Property(e => e.Response)
                .HasMaxLength(255)
                .HasColumnName("RESPONSE");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.CharityIssues)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007836");
        });

        modelBuilder.Entity<CharityNotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007832");

            entity.ToTable("CHARITY_NOTIFICATION");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Notification)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("NOTIFICATION");
            entity.Property(e => e.Notificationdate)
                .HasColumnType("DATE")
                .HasColumnName("NOTIFICATIONDATE");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.CharityNotifications)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007833");
        });

        modelBuilder.Entity<CharityPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007806");

            entity.ToTable("CHARITY_PAGES");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Content)
                .HasMaxLength(255)
                .HasColumnName("CONTENT");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("LOCATION");
            entity.Property(e => e.Logo)
                .HasMaxLength(255)
                .HasColumnName("LOGO");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Slide1)
                .HasMaxLength(255)
                .HasColumnName("SLIDE1");
            entity.Property(e => e.Slide2)
                .HasMaxLength(255)
                .HasColumnName("SLIDE2");
            entity.Property(e => e.Slide3)
                .HasMaxLength(255)
                .HasColumnName("SLIDE3");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("TITLE");
        });

        modelBuilder.Entity<CharityRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007440");

            entity.ToTable("CHARITY_ROLE");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Rolename)
                .HasMaxLength(255)
                .HasColumnName("ROLENAME");
        });

        modelBuilder.Entity<CharityTestimonial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007814");

            entity.ToTable("CHARITY_TESTIMONIAL");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Datetestimonial)
                .HasColumnType("DATE")
                .HasColumnName("DATETESTIMONIAL");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .HasColumnName("STATUS");
            entity.Property(e => e.Testimonial)
                .HasMaxLength(255)
                .HasColumnName("TESTIMONIAL");
            entity.Property(e => e.Userid)
                .HasColumnType("NUMBER")
                .HasColumnName("USERID");

            entity.HasOne(d => d.User).WithMany(p => p.CharityTestimonials)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007815");
        });

        modelBuilder.Entity<CharityUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007811");

            entity.ToTable("CHARITY_USER");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("EMAIL");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .HasColumnName("IMAGE");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Roleid)
                .HasColumnType("NUMBER")
                .HasColumnName("ROLEID");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .HasColumnName("USERNAME");
            entity.Property(e => e.Verificationcode)
                .HasMaxLength(255)
                .HasColumnName("VERIFICATIONCODE");
            entity.Property(e => e.Verificationcodeexpiration)
                .HasColumnType("DATE")
                .HasColumnName("VERIFICATIONCODEEXPIRATION");

            entity.HasOne(d => d.Role).WithMany(p => p.CharityUsers)
                .HasForeignKey(d => d.Roleid)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("SYS_C007812");
        });


        modelBuilder.Entity<CharityVisaCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SYS_C007830");

            entity.ToTable("CHARITY_VISA_CARD");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Balance)
                .HasColumnType("NUMBER(10,2)")
                .HasColumnName("BALANCE");
            entity.Property(e => e.Cardholdernumber)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("CARDHOLDERNUMBER");
            entity.Property(e => e.Cardnumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CARDNUMBER");
            entity.Property(e => e.Cvv)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.Expirationdate)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("EXPIRATIONDATE");
        });


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

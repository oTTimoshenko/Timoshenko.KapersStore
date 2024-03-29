﻿using KapersStore.Domain.CartManagement;
using KapersStore.Domain.KaperManagement;
using KapersStore.Domain.MailManagement;
using KapersStore.Domain.PurchaseManagement;
using KapersStore.Domain.UserManagement;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace KapersStore.DataAccess
{
    public static class EntityMappingConfig
    {
        public static void BuildUser(this ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<User>();

            userEntity.HasKey(entity => entity.Id);

            userEntity.Property(entity => entity.Code).HasMaxLength(10);
            userEntity.Property(entity => entity.Code).IsRequired();

            userEntity.Property(entity => entity.Nickname).HasMaxLength(18);
            userEntity.Property(entity => entity.Nickname).IsRequired();

            userEntity.Property(entity => entity.Email).HasMaxLength(50);
            userEntity.Property(entity => entity.Email).IsRequired();

            userEntity.Property(entity => entity.IsConfirmed).IsRequired().HasDefaultValue(false);
            userEntity.Property(entity => entity.Email).IsRequired();

            userEntity
                .HasOne(entity => entity.Cart)
                .WithOne(entity => entity.User)
                .HasForeignKey<Cart>(x => x.UserId);
        }

        public static void BuildKaper(this ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<Kaper>();

            userEntity.HasKey(entity => entity.Id);

            userEntity.Property(entity => entity.Name).HasMaxLength(100);
            userEntity.Property(entity => entity.Name).IsRequired();

            userEntity.Property(entity => entity.DescriptionRU).HasMaxLength(500);
            userEntity.Property(entity => entity.DescriptionRU).IsRequired();
            userEntity.Property(entity => entity.DescriptionUA).HasMaxLength(500);
            userEntity.Property(entity => entity.DescriptionUA).IsRequired();

            userEntity.Property(entity => entity.ImageSource).HasMaxLength(500);
            userEntity.Property(entity => entity.ImageSource).IsRequired();

            userEntity.Property(entity => entity.ImageAltText).HasMaxLength(50);

            userEntity.HasData(new List<Kaper>()
            {
                new Kaper { Id = 1, Name = "Kaper1", DescriptionRU = "Description of Kaper1", DescriptionUA = "Description of Kaper1", ImageSource = "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", ImageAltText = "Kaper1" },
                new Kaper { Id = 2, Name = "Kaper2", DescriptionRU = "Description of Kaper2", DescriptionUA = "Description of Kaper2", ImageSource = "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", ImageAltText = "Kaper2" },
                new Kaper { Id = 3, Name = "Kaper3", DescriptionRU = "Description of Kaper3", DescriptionUA = "Description of Kaper3", ImageSource = "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", ImageAltText = "Kaper3" },
                new Kaper { Id = 4, Name = "Kaper4", DescriptionRU = "Description of Kaper4", DescriptionUA = "Description of Kaper4", ImageSource = "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", ImageAltText = "Kaper4" },
                new Kaper { Id = 5, Name = "Kaper5", DescriptionRU = "Description of Kaper5", DescriptionUA = "Description of Kaper5", ImageSource = "https://avatars0.githubusercontent.com/u/9064066?v=4&s=460", ImageAltText = "Kaper5" },
            });
        }

        public static void BuildSubscription(this ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<Subscription>();

            userEntity.HasKey(entity => entity.Id);

            userEntity.Property(entity => entity.Name).HasMaxLength(100);
            userEntity.Property(entity => entity.Name).IsRequired();

            userEntity.Property(entity => entity.DescriptionRU).HasMaxLength(500);
            userEntity.Property(entity => entity.DescriptionRU).IsRequired();
            userEntity.Property(entity => entity.DescriptionUA).HasMaxLength(500);
            userEntity.Property(entity => entity.DescriptionUA).IsRequired();

            userEntity.Property(entity => entity.Price).IsRequired();
            userEntity.Property(entity => entity.KaperId).IsRequired();

            userEntity.Property(entity => entity.Days).HasDefaultValue(1);

            userEntity.HasData(new List<Subscription>()
            {
                new Subscription { Id = 1, Name = "Subscription1", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 1200, KaperId = 1 },
                new Subscription { Id = 2, Name = "Subscription2", DescriptionRU = "Description2", DescriptionUA = "Description1", Days = 1, Price = 1999, KaperId = 1 },
                new Subscription { Id = 3, Name = "Subscription3", DescriptionRU = "Description3", DescriptionUA = "Description1", Days = 10, Price = 1500, KaperId = 1 },
                new Subscription { Id = 4, Name = "Subscription4", DescriptionRU = "Description4", DescriptionUA = "Description1", Days = 31, Price = 1200, KaperId = 2 },
                new Subscription { Id = 5, Name = "Subscription5", DescriptionRU = "Description5", DescriptionUA = "Description1", Days = 21, Price = 1200, KaperId = 2 },
                new Subscription { Id = 6, Name = "Subscription6", DescriptionRU = "Description6", DescriptionUA = "Description1", Days = 14, Price = 1999, KaperId = 2 },
                new Subscription { Id = 7, Name = "Subscription7", DescriptionRU = "Description7", DescriptionUA = "Description1", Days = 1, Price = 1500, KaperId = 3 },
                new Subscription { Id = 8, Name = "Subscription8", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 1500, KaperId = 3 },
                new Subscription { Id = 9, Name = "Subscription9", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 2000, KaperId = 3 },
                new Subscription { Id = 10, Name = "Subscription10", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 14, Price = 1200, KaperId = 4 },
                new Subscription { Id = 11, Name = "Subscription11", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 1, Price = 1999, KaperId = 4 },
                new Subscription { Id = 12, Name = "Subscription12", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 1200, KaperId = 4 },
                new Subscription { Id = 13, Name = "Subscription13", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 21, Price = 1500, KaperId = 5 },
                new Subscription { Id = 14, Name = "Subscription14", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 2000, KaperId = 5 },
                new Subscription { Id = 15, Name = "Subscription15", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 1, Price = 1200, KaperId = 5  },
                new Subscription { Id = 16, Name = "Subscription16", DescriptionRU = "Description1", DescriptionUA = "Description1", Days = 7, Price = 1500, KaperId = 5 }
            });
        }

        public static void BuildComment(this ModelBuilder modelBuilder)
        {
            var userEntity = modelBuilder.Entity<Comment>();

            userEntity.HasKey(entity => entity.Id);

            userEntity.Property(entity => entity.Text).HasMaxLength(500);
            userEntity.Property(entity => entity.Text).IsRequired();

            userEntity.Property(entity => entity.Date).IsRequired();

            userEntity.Property(entity => entity.UserId).IsRequired();
            userEntity.Property(entity => entity.KaperId).IsRequired();

            //userEntity.HasOne(x => x.Parent).WithMany(x => x.Children).OnDelete(DeleteBehavior.Cascade);
        }

        public static void BuildCart(this ModelBuilder modelBuilder)
        {
            var cartEntity = modelBuilder.Entity<Cart>();

            cartEntity.HasKey(entity => entity.Id);

            cartEntity.Property(entity => entity.UserId).IsRequired();
            cartEntity.Ignore(entity => entity.TotalPrice);
        }

        public static void BuildCartSubscription(this ModelBuilder modelBuilder)
        {
            var cartSubscription = modelBuilder.Entity<CartSubscription>();

            cartSubscription.HasKey(entity => new { entity.CartId, entity.SubscriptionId });

            cartSubscription
                .HasOne(cs => cs.Cart)
                .WithMany(css => css.CartSubscriptions)
                .HasForeignKey(cs => cs.CartId);

            cartSubscription
                .HasOne(cs => cs.Subscription)
                .WithMany(css => css.CartSubscriptions)
                .HasForeignKey(cs => cs.SubscriptionId);

            cartSubscription.Property(entity => entity.SubscriptionsCount).HasDefaultValue(1);
        }

        public static void BuildPurchase(this ModelBuilder modelBuilder)
        {
            var purchaseEntity = modelBuilder.Entity<Purchase>();

            purchaseEntity.HasKey(entity => entity.Id);

            purchaseEntity.Property(entity => entity.UserId).IsRequired();
            purchaseEntity.Property(entity => entity.TotalPrice).IsRequired();
        }

        public static void BuildPurchaseSubscription(this ModelBuilder modelBuilder)
        {
            var purchaseSubscription = modelBuilder.Entity<PurchaseSubscription>();

            purchaseSubscription.HasKey(entity => new { entity.PurchaseId, entity.SubscriptionId });

            purchaseSubscription
                .HasOne(cs => cs.Purchase)
                .WithMany(css => css.PurchaseSubscriptions)
                .HasForeignKey(cs => cs.PurchaseId);

            purchaseSubscription
                .HasOne(cs => cs.Subscription)
                .WithMany(css => css.PurchaseSubscriptions)
                .HasForeignKey(cs => cs.SubscriptionId);

            purchaseSubscription.Property(entity => entity.SubscriptionCount).IsRequired();
            purchaseSubscription.Property(entity => entity.SubscriptionPrice).IsRequired();
        }

        public static void BuildMail(this ModelBuilder modelBuilder)
        {
            var mail = modelBuilder.Entity<Mail>();

            mail.HasKey(entity => entity.Id);

            mail.Property(entity => entity.Subject).HasMaxLength(100).IsRequired();
            mail.Property(entity => entity.Body).HasMaxLength(700).IsRequired();
            mail.Property(entity => entity.SubscriptionId).IsRequired();
        }

        public static void BuildMailUser(this ModelBuilder modelBuilder)
        {
            var mailUser = modelBuilder.Entity<MailUser>();

            mailUser.HasKey(entity => new { entity.MailId, entity.UserId });

            mailUser
                .HasOne(cs => cs.Mail)
                .WithMany(css => css.MailUsers)
                .HasForeignKey(cs => cs.MailId);

            mailUser
                .HasOne(cs => cs.User)
                .WithMany(css => css.MailUsers)
                .HasForeignKey(cs => cs.UserId);

            mailUser.Property(entity => entity.IsSent).HasDefaultValue(false).IsRequired();
        }
    }
}

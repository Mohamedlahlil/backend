using GPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GPI.Data
{
    public class GPIContext : DbContext
    {
        public GPIContext(DbContextOptions<GPIContext> opt) : base(opt)
        {

        }

        public DbSet<Fournisseur> Fournisseurs { get; set; }
        public DbSet<Ville> villes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Centre> Centres { get; set; }
        public DbSet<SousCategorie> SousCategories { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Roleuser> Roleusers { get; set; }
        public DbSet<AffArticle> AffArticles { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<AffTelephonie> AffTelephonies { get; set; }
        public DbSet<AffLogiciel> AffLogiciels { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Telephonie> Telephonies { get; set; }
        public DbSet<Logiciel> Logiciels { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Pauses> Pausess { get; set; }
        public DbSet<Reparation> Reparations { get; set; }
        public DbSet<AffHistorique> AffHistoriques { get; set; }
        public DbSet<TypeCategorie> TypeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Centre>()
                .HasOne(p => p.Ville)
                .WithMany(b => b.Centres)
                .HasForeignKey(p => p.IdVille);

            modelBuilder.Entity<SousCategorie>()
                .HasOne(p => p.Categorie)
                .WithMany(b => b.SousCategories)
                .HasForeignKey(p => p.IdCategorie);

            modelBuilder.Entity<SousCategorie>()
                .HasOne(p => p.TypeCategorie)
                .WithMany(b => b.SousCategories)
                .HasForeignKey(p => p.IdTypeCategorie);

            modelBuilder.Entity<Service>()
                .HasOne(p => p.Centre)
                .WithMany(b => b.Services)
                .HasForeignKey(p => p.IdCentre);

            modelBuilder.Entity<User>()
                .HasOne(p => p.Service)
                .WithMany(b => b.Users)
                .HasForeignKey(p => p.IdService);
            modelBuilder.Entity<Roleuser>()
                .HasOne(p => p.User)
                .WithMany(b => b.Roleusers)
                .HasForeignKey(p => p.IdUser);
            modelBuilder.Entity<Roleuser>()
                .HasOne(p => p.Role)
                .WithMany(b => b.Roleusers)
                .HasForeignKey(p => p.IdRole);

            modelBuilder.Entity<AffArticle>()
                .HasOne(p => p.User)
                .WithMany(b => b.AffArticles)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.ClientNoAction);
            modelBuilder.Entity<AffArticle>()
                .HasOne(p => p.Service)
                .WithMany(b => b.AffArticles)
                .HasForeignKey(p => p.IdService);

            modelBuilder.Entity<AffTelephonie>()
                .HasOne(p => p.Centre)
                .WithMany(b => b.AffTelephonies)
                .HasForeignKey(p => p.IdCentre);

            modelBuilder.Entity<AffLogiciel>()
                .HasOne(p => p.User)
                .WithMany(b => b.AffLogiciels)
                .HasForeignKey(p => p.IdUser);

            modelBuilder.Entity<Article>()
                .HasOne(p => p.Type)
                .WithMany(b => b.Articles)
                .HasForeignKey(p => p.IdType);

            modelBuilder.Entity<Article>()
                .HasOne(p => p.AffArticle)
                .WithMany(b => b.Articles)
                .HasForeignKey(p => p.IdAffArticle);

            modelBuilder.Entity<Article>()
                .HasOne(p => p.Fournisseur)
                .WithMany(b => b.Articles)
                .HasForeignKey(p => p.IdFournisseur);

            modelBuilder.Entity<Telephonie>()
                .HasOne(p => p.AffTelephonie)
                .WithMany(b => b.Telephonies)
                .HasForeignKey(p => p.IdAffTelephonie);

            modelBuilder.Entity<Logiciel>()
                .HasOne(p => p.AffLogiciel)
                .WithMany(b => b.Logiciels)
                .HasForeignKey(p => p.IdAffLogiciel);

            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Article)
                .WithMany(b => b.Tickets)
                .HasForeignKey(p => p.IdArticle)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Ticket>()
               .HasOne(p => p.SousCategorie)
               .WithMany(b => b.Tickets)
               .HasForeignKey(p => p.IdSousCat)
               .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Logiciel)
                .WithMany(b => b.Tickets)
                .HasForeignKey(p => p.IdLogiciel)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.Telephonie)
                .WithMany(b => b.Tickets)
                .HasForeignKey(p => p.IdTelephonie)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Ticket>()
                .HasOne(p => p.User)
                .WithMany(b => b.Tickets)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Pauses>()
                .HasOne(p => p.Ticket)
                .WithMany(b => b.Pausess)
                .HasForeignKey(p => p.IdTicket)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Reparation>()
                .HasOne(p => p.Fournisseur)
                .WithMany(b => b.Reparations)
                .HasForeignKey(p => p.IdFournisseur)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Reparation>()
                .HasOne(p => p.Article)
                .WithMany(b => b.Reparations)
                .HasForeignKey(p => p.IdArticle)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<AffHistorique>()
                .HasOne(p => p.Article)
                .WithMany(b => b.AffHistoriques)
                .HasForeignKey(p => p.IdArticle)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<AffHistorique>()
                .HasOne(p => p.Logiciel)
                .WithMany(b => b.AffHistoriques)
                .HasForeignKey(p => p.IdLogiciel)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<AffHistorique>()
                .HasOne(p => p.Telephonie)
                .WithMany(b => b.AffHistoriques)
                .HasForeignKey(p => p.IdTelephonie)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<AffHistorique>()
                .HasOne(p => p.User)
                .WithMany(b => b.AffHistoriques)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }

    }
}
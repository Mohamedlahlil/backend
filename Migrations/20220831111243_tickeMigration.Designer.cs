﻿// <auto-generated />
using System;
using GPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GPI.Migrations
{
    [DbContext(typeof(GPIContext))]
    [Migration("20220831111243_tickeMigration")]
    partial class tickeMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GPI.Models.AffArticle", b =>
                {
                    b.Property<int>("IdAffArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typeaffectation")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("dateaffectation")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAffArticle");

                    b.HasIndex("IdService");

                    b.HasIndex("IdUser");

                    b.ToTable("AffArticles");
                });

            modelBuilder.Entity("GPI.Models.AffHistorique", b =>
                {
                    b.Property<int>("IdHistorique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAffectation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Daterecuperation")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdLogiciel")
                        .HasColumnType("int");

                    b.Property<int>("IdTelephonie")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeAffectation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdHistorique");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdLogiciel");

                    b.HasIndex("IdTelephonie");

                    b.HasIndex("IdUser");

                    b.ToTable("AffHistoriques");
                });

            modelBuilder.Entity("GPI.Models.AffLogiciel", b =>
                {
                    b.Property<int>("IdAffLogiciel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdLogiciel")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAffLogiciel");

                    b.HasIndex("IdLogiciel");

                    b.HasIndex("IdUser");

                    b.ToTable("AffLogiciels");
                });

            modelBuilder.Entity("GPI.Models.AffTelephonie", b =>
                {
                    b.Property<int>("IdAffTelephonie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCentre")
                        .HasColumnType("int");

                    b.Property<int>("IdTelephonie")
                        .HasColumnType("int");

                    b.Property<string>("Observation")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdAffTelephonie");

                    b.HasIndex("IdCentre");

                    b.HasIndex("IdTelephonie");

                    b.ToTable("AffTelephonies");
                });

            modelBuilder.Entity("GPI.Models.Article", b =>
                {
                    b.Property<int>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeInterne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodeLicence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAffArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdFournisseur")
                        .HasColumnType("int");

                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<bool>("Licence")
                        .HasColumnType("bit");

                    b.Property<string>("NumCommande")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumFacture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numserie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Prix")
                        .HasColumnType("real");

                    b.Property<string>("Reference")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Reforme")
                        .HasColumnType("bit");

                    b.HasKey("IdArticle");

                    b.HasIndex("IdAffArticle");

                    b.HasIndex("IdFournisseur");

                    b.HasIndex("IdType");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("GPI.Models.Categorie", b =>
                {
                    b.Property<int>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("GPI.Models.Centre", b =>
                {
                    b.Property<int>("IdCentre")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdVille")
                        .HasColumnType("int");

                    b.Property<string>("NomCentre")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCentre");

                    b.HasIndex("IdVille");

                    b.ToTable("Centres");
                });

            modelBuilder.Entity("GPI.Models.Fournisseur", b =>
                {
                    b.Property<int>("IdFournisseur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomFournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("RefFournisseur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFournisseur");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("GPI.Models.Logiciel", b =>
                {
                    b.Property<int>("IdLogiciel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Licence")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdLogiciel");

                    b.ToTable("Logiciels");
                });

            modelBuilder.Entity("GPI.Models.Pauses", b =>
                {
                    b.Property<int>("IdPauses")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Datefin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dateouverture")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTicket")
                        .HasColumnType("int");

                    b.Property<string>("Raison")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdPauses");

                    b.HasIndex("IdTicket");

                    b.ToTable("Pausess");
                });

            modelBuilder.Entity("GPI.Models.Reparation", b =>
                {
                    b.Property<int>("IdReparation")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateReception")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dateenvoie")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionReparation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EtatReparation")
                        .HasColumnType("bit");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdFournisseur")
                        .HasColumnType("int");

                    b.Property<float>("MontantReparation")
                        .HasColumnType("real");

                    b.Property<string>("Pieceenvoie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaisieLe")
                        .HasColumnType("datetime2");

                    b.HasKey("IdReparation");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdFournisseur");

                    b.ToTable("Reparations");
                });

            modelBuilder.Entity("GPI.Models.Role", b =>
                {
                    b.Property<int>("IdRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("IdRole");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("GPI.Models.Roleuser", b =>
                {
                    b.Property<int>("IdRoleuser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.HasKey("IdRoleuser");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdUser");

                    b.ToTable("Roleusers");
                });

            modelBuilder.Entity("GPI.Models.Service", b =>
                {
                    b.Property<int>("IdService")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCentre")
                        .HasColumnType("int");

                    b.Property<string>("NomService")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("IdService");

                    b.HasIndex("IdCentre");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("GPI.Models.SousCategorie", b =>
                {
                    b.Property<int>("IdSousCat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<int>("IdTypeCategorie")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdSousCat");

                    b.HasIndex("IdCategorie");

                    b.HasIndex("IdTypeCategorie");

                    b.ToTable("SousCategories");
                });

            modelBuilder.Entity("GPI.Models.Telephonie", b =>
                {
                    b.Property<int>("IdTelephonie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Autreinformations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lignesupport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Typeliaison")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTelephonie");

                    b.ToTable("Telephonies");
                });

            modelBuilder.Entity("GPI.Models.Ticket", b =>
                {
                    b.Property<int>("IdTicket")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AffArticleIdAffArticle")
                        .HasColumnType("int");

                    b.Property<string>("Creepar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateDemande")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dateouverture")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdArticle")
                        .HasColumnType("int");

                    b.Property<int>("IdLogiciel")
                        .HasColumnType("int");

                    b.Property<int>("IdSousCat")
                        .HasColumnType("int");

                    b.Property<int>("IdTelephonie")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<string>("Lieu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Priorite")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdTicket");

                    b.HasIndex("AffArticleIdAffArticle");

                    b.HasIndex("IdArticle");

                    b.HasIndex("IdLogiciel");

                    b.HasIndex("IdSousCat");

                    b.HasIndex("IdTelephonie");

                    b.HasIndex("IdUser");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("GPI.Models.Type", b =>
                {
                    b.Property<int>("IdType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Designation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdType");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("GPI.Models.TypeCategorie", b =>
                {
                    b.Property<int>("IdTypeCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TypeCat")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("IdTypeCategorie");

                    b.ToTable("TypeCategories");
                });

            modelBuilder.Entity("GPI.Models.User", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Dispo")
                        .HasColumnType("int");

                    b.Property<int>("IdService")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NomUser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Passe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poste")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Privilege")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("updated_at")
                        .HasColumnType("datetime2");

                    b.HasKey("IdUser");

                    b.HasIndex("IdService");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GPI.Models.Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomVille")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("villes");
                });

            modelBuilder.Entity("GPI.Models.AffArticle", b =>
                {
                    b.HasOne("GPI.Models.Service", "Service")
                        .WithMany("AffArticles")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.User", "User")
                        .WithMany("AffArticles")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.AffHistorique", b =>
                {
                    b.HasOne("GPI.Models.Article", "Article")
                        .WithMany("AffHistoriques")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.Logiciel", "Logiciel")
                        .WithMany("AffHistoriques")
                        .HasForeignKey("IdLogiciel")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.Telephonie", "Telephonie")
                        .WithMany("AffHistoriques")
                        .HasForeignKey("IdTelephonie")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.User", "User")
                        .WithMany("AffHistoriques")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.AffLogiciel", b =>
                {
                    b.HasOne("GPI.Models.Logiciel", "Logiciel")
                        .WithMany("AffLogiciels")
                        .HasForeignKey("IdLogiciel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.User", "User")
                        .WithMany("AffLogiciels")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.AffTelephonie", b =>
                {
                    b.HasOne("GPI.Models.Centre", "Centre")
                        .WithMany("AffTelephonies")
                        .HasForeignKey("IdCentre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.Telephonie", "Telephonie")
                        .WithMany("AffTelephonies")
                        .HasForeignKey("IdTelephonie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Article", b =>
                {
                    b.HasOne("GPI.Models.AffArticle", "AffArticle")
                        .WithMany("Articles")
                        .HasForeignKey("IdAffArticle")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.Fournisseur", "Fournisseur")
                        .WithMany("Articles")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.Type", "Type")
                        .WithMany("Articles")
                        .HasForeignKey("IdType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Centre", b =>
                {
                    b.HasOne("GPI.Models.Ville", "Ville")
                        .WithMany("Centres")
                        .HasForeignKey("IdVille")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Pauses", b =>
                {
                    b.HasOne("GPI.Models.Ticket", "Ticket")
                        .WithMany("Pausess")
                        .HasForeignKey("IdTicket")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Reparation", b =>
                {
                    b.HasOne("GPI.Models.Article", "Article")
                        .WithMany("Reparations")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.Fournisseur", "Fournisseur")
                        .WithMany("Reparations")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Roleuser", b =>
                {
                    b.HasOne("GPI.Models.Role", "Role")
                        .WithMany("Roleusers")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.User", "User")
                        .WithMany("Roleusers")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Service", b =>
                {
                    b.HasOne("GPI.Models.Centre", "Centre")
                        .WithMany("Services")
                        .HasForeignKey("IdCentre")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.SousCategorie", b =>
                {
                    b.HasOne("GPI.Models.Categorie", "Categorie")
                        .WithMany("SousCategories")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GPI.Models.TypeCategorie", "TypeCategorie")
                        .WithMany("SousCategories")
                        .HasForeignKey("IdTypeCategorie")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.Ticket", b =>
                {
                    b.HasOne("GPI.Models.AffArticle", null)
                        .WithMany("Tickets")
                        .HasForeignKey("AffArticleIdAffArticle");

                    b.HasOne("GPI.Models.Article", "Article")
                        .WithMany("Tickets")
                        .HasForeignKey("IdArticle")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.Logiciel", "Logiciel")
                        .WithMany("Tickets")
                        .HasForeignKey("IdLogiciel")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.SousCategorie", "SousCategorie")
                        .WithMany("Tickets")
                        .HasForeignKey("IdSousCat")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.Telephonie", "Telephonie")
                        .WithMany("Tickets")
                        .HasForeignKey("IdTelephonie")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.HasOne("GPI.Models.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("GPI.Models.User", b =>
                {
                    b.HasOne("GPI.Models.Service", "Service")
                        .WithMany("Users")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

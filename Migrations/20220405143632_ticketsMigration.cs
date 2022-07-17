using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPI.Migrations
{
    public partial class ticketsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    IdCategorie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.IdCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    IdFournisseur = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomFournisseur = table.Column<string>(maxLength: 250, nullable: false),
                    RefFournisseur = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.IdFournisseur);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRole = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(maxLength: 250, nullable: false),
                    Admin = table.Column<string>(nullable: false),
                    Utilisateur = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRole);
                });

            migrationBuilder.CreateTable(
                name: "TypeCategories",
                columns: table => new
                {
                    IdTypeCategorie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeCat = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCategories", x => x.IdTypeCategorie);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    IdType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "villes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomVille = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_villes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SousCategories",
                columns: table => new
                {
                    IdSousCat = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false),
                    IdTypeCategorie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SousCategories", x => x.IdSousCat);
                    table.ForeignKey(
                        name: "FK_SousCategories_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "IdCategorie",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SousCategories_TypeCategories_IdTypeCategorie",
                        column: x => x.IdTypeCategorie,
                        principalTable: "TypeCategories",
                        principalColumn: "IdTypeCategorie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Centres",
                columns: table => new
                {
                    IdCentre = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomCentre = table.Column<string>(maxLength: 250, nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    Telephone = table.Column<string>(nullable: false),
                    IdVille = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Centres", x => x.IdCentre);
                    table.ForeignKey(
                        name: "FK_Centres_villes_IdVille",
                        column: x => x.IdVille,
                        principalTable: "villes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffTelephonies",
                columns: table => new
                {
                    IdAffTelephonie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdCentre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffTelephonies", x => x.IdAffTelephonie);
                    table.ForeignKey(
                        name: "FK_AffTelephonies_Centres_IdCentre",
                        column: x => x.IdCentre,
                        principalTable: "Centres",
                        principalColumn: "IdCentre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    IdService = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomService = table.Column<string>(maxLength: 250, nullable: false),
                    IdCentre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.IdService);
                    table.ForeignKey(
                        name: "FK_Services_Centres_IdCentre",
                        column: x => x.IdCentre,
                        principalTable: "Centres",
                        principalColumn: "IdCentre",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Telephonies",
                columns: table => new
                {
                    IdTelephonie = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lignesupport = table.Column<string>(nullable: false),
                    Typeliaison = table.Column<string>(nullable: false),
                    Autreinformations = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdAffTelephonie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telephonies", x => x.IdTelephonie);
                    table.ForeignKey(
                        name: "FK_Telephonies_AffTelephonies_IdAffTelephonie",
                        column: x => x.IdAffTelephonie,
                        principalTable: "AffTelephonies",
                        principalColumn: "IdAffTelephonie",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(maxLength: 250, nullable: false),
                    NomUser = table.Column<string>(nullable: false),
                    Passe = table.Column<string>(nullable: false),
                    Privilege = table.Column<string>(nullable: false),
                    Poste = table.Column<string>(nullable: false),
                    Dispo = table.Column<int>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    UUID = table.Column<string>(nullable: false),
                    IdService = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_Users_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AffArticles",
                columns: table => new
                {
                    IdAffArticle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Typeaffectation = table.Column<string>(maxLength: 250, nullable: false),
                    dateaffectation = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(nullable: false),
                    IdService = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffArticles", x => x.IdAffArticle);
                    table.ForeignKey(
                        name: "FK_AffArticles_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "IdService",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AffArticles_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "AffLogiciels",
                columns: table => new
                {
                    IdAffLogiciel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Observation = table.Column<string>(maxLength: 250, nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffLogiciels", x => x.IdAffLogiciel);
                    table.ForeignKey(
                        name: "FK_AffLogiciels_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Roleusers",
                columns: table => new
                {
                    IdRoleuser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(nullable: false),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roleusers", x => x.IdRoleuser);
                    table.ForeignKey(
                        name: "FK_Roleusers_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "IdRole",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Roleusers_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    IdArticle = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeInterne = table.Column<string>(nullable: false),
                    Reference = table.Column<string>(nullable: false),
                    Numserie = table.Column<string>(nullable: false),
                    CodeLicence = table.Column<string>(nullable: false),
                    Licence = table.Column<bool>(nullable: false),
                    Prix = table.Column<float>(nullable: false),
                    DateAchat = table.Column<DateTime>(nullable: false),
                    Reforme = table.Column<bool>(nullable: false),
                    NumCommande = table.Column<string>(nullable: false),
                    NumFacture = table.Column<string>(nullable: false),
                    IdType = table.Column<int>(nullable: false),
                    IdAffArticle = table.Column<int>(nullable: false),
                    IdFournisseur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.IdArticle);
                    table.ForeignKey(
                        name: "FK_Articles_AffArticles_IdAffArticle",
                        column: x => x.IdAffArticle,
                        principalTable: "AffArticles",
                        principalColumn: "IdAffArticle",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "IdFournisseur",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Types_IdType",
                        column: x => x.IdType,
                        principalTable: "Types",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logiciels",
                columns: table => new
                {
                    IdLogiciel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false),
                    Licence = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdAffLogiciel = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logiciels", x => x.IdLogiciel);
                    table.ForeignKey(
                        name: "FK_Logiciels_AffLogiciels_IdAffLogiciel",
                        column: x => x.IdAffLogiciel,
                        principalTable: "AffLogiciels",
                        principalColumn: "IdAffLogiciel",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reparations",
                columns: table => new
                {
                    IdReparation = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pieceenvoie = table.Column<string>(nullable: false),
                    DescriptionReparation = table.Column<string>(nullable: false),
                    EtatReparation = table.Column<bool>(nullable: false),
                    MontantReparation = table.Column<float>(nullable: false),
                    DateReception = table.Column<DateTime>(nullable: false),
                    Dateenvoie = table.Column<DateTime>(nullable: false),
                    SaisieLe = table.Column<DateTime>(nullable: false),
                    IdArticle = table.Column<int>(nullable: false),
                    IdFournisseur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reparations", x => x.IdReparation);
                    table.ForeignKey(
                        name: "FK_Reparations_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                    table.ForeignKey(
                        name: "FK_Reparations_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "IdFournisseur");
                });

            migrationBuilder.CreateTable(
                name: "AffHistoriques",
                columns: table => new
                {
                    IdHistorique = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeAffectation = table.Column<string>(nullable: false),
                    Observation = table.Column<string>(nullable: false),
                    Daterecuperation = table.Column<DateTime>(nullable: false),
                    DateAffectation = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdArticle = table.Column<int>(nullable: false),
                    IdLogiciel = table.Column<int>(nullable: false),
                    IdTelephonie = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AffHistoriques", x => x.IdHistorique);
                    table.ForeignKey(
                        name: "FK_AffHistoriques_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                    table.ForeignKey(
                        name: "FK_AffHistoriques_Logiciels_IdLogiciel",
                        column: x => x.IdLogiciel,
                        principalTable: "Logiciels",
                        principalColumn: "IdLogiciel");
                    table.ForeignKey(
                        name: "FK_AffHistoriques_Telephonies_IdTelephonie",
                        column: x => x.IdTelephonie,
                        principalTable: "Telephonies",
                        principalColumn: "IdTelephonie");
                    table.ForeignKey(
                        name: "FK_AffHistoriques_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    IdTicket = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: false),
                    Statut = table.Column<string>(nullable: false),
                    Priorite = table.Column<string>(nullable: false),
                    Titre = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Dateouverture = table.Column<DateTime>(nullable: false),
                    DateFin = table.Column<DateTime>(nullable: false),
                    DateDemande = table.Column<DateTime>(nullable: false),
                    Solution = table.Column<string>(nullable: false),
                    Lieu = table.Column<string>(nullable: false),
                    Creepar = table.Column<string>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    IdArticle = table.Column<int>(nullable: false),
                    IdLogiciel = table.Column<int>(nullable: false),
                    IdTelephonie = table.Column<int>(nullable: false),
                    IdSousCat = table.Column<int>(nullable: false),
                    AffArticleIdAffArticle = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.IdTicket);
                    table.ForeignKey(
                        name: "FK_Tickets_AffArticles_AffArticleIdAffArticle",
                        column: x => x.AffArticleIdAffArticle,
                        principalTable: "AffArticles",
                        principalColumn: "IdAffArticle",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tickets_Articles_IdArticle",
                        column: x => x.IdArticle,
                        principalTable: "Articles",
                        principalColumn: "IdArticle");
                    table.ForeignKey(
                        name: "FK_Tickets_Logiciels_IdLogiciel",
                        column: x => x.IdLogiciel,
                        principalTable: "Logiciels",
                        principalColumn: "IdLogiciel");
                    table.ForeignKey(
                        name: "FK_Tickets_SousCategories_IdSousCat",
                        column: x => x.IdSousCat,
                        principalTable: "SousCategories",
                        principalColumn: "IdSousCat");
                    table.ForeignKey(
                        name: "FK_Tickets_Telephonies_IdTelephonie",
                        column: x => x.IdTelephonie,
                        principalTable: "Telephonies",
                        principalColumn: "IdTelephonie");
                    table.ForeignKey(
                        name: "FK_Tickets_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "Pausess",
                columns: table => new
                {
                    IdPauses = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Raison = table.Column<string>(maxLength: 250, nullable: false),
                    Dateouverture = table.Column<DateTime>(nullable: false),
                    Datefin = table.Column<DateTime>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    IdTicket = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pausess", x => x.IdPauses);
                    table.ForeignKey(
                        name: "FK_Pausess_Tickets_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "Tickets",
                        principalColumn: "IdTicket");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AffArticles_IdService",
                table: "AffArticles",
                column: "IdService");

            migrationBuilder.CreateIndex(
                name: "IX_AffArticles_IdUser",
                table: "AffArticles",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_AffHistoriques_IdArticle",
                table: "AffHistoriques",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_AffHistoriques_IdLogiciel",
                table: "AffHistoriques",
                column: "IdLogiciel");

            migrationBuilder.CreateIndex(
                name: "IX_AffHistoriques_IdTelephonie",
                table: "AffHistoriques",
                column: "IdTelephonie");

            migrationBuilder.CreateIndex(
                name: "IX_AffHistoriques_IdUser",
                table: "AffHistoriques",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_AffLogiciels_IdUser",
                table: "AffLogiciels",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_AffTelephonies_IdCentre",
                table: "AffTelephonies",
                column: "IdCentre");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdAffArticle",
                table: "Articles",
                column: "IdAffArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdFournisseur",
                table: "Articles",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_IdType",
                table: "Articles",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_Centres_IdVille",
                table: "Centres",
                column: "IdVille");

            migrationBuilder.CreateIndex(
                name: "IX_Logiciels_IdAffLogiciel",
                table: "Logiciels",
                column: "IdAffLogiciel");

            migrationBuilder.CreateIndex(
                name: "IX_Pausess_IdTicket",
                table: "Pausess",
                column: "IdTicket");

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_IdArticle",
                table: "Reparations",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Reparations_IdFournisseur",
                table: "Reparations",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Roleusers_IdRole",
                table: "Roleusers",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Roleusers_IdUser",
                table: "Roleusers",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdCentre",
                table: "Services",
                column: "IdCentre");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_IdCategorie",
                table: "SousCategories",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_SousCategories_IdTypeCategorie",
                table: "SousCategories",
                column: "IdTypeCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Telephonies_IdAffTelephonie",
                table: "Telephonies",
                column: "IdAffTelephonie");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AffArticleIdAffArticle",
                table: "Tickets",
                column: "AffArticleIdAffArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdArticle",
                table: "Tickets",
                column: "IdArticle");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdLogiciel",
                table: "Tickets",
                column: "IdLogiciel");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdSousCat",
                table: "Tickets",
                column: "IdSousCat");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdTelephonie",
                table: "Tickets",
                column: "IdTelephonie");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_IdUser",
                table: "Tickets",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdService",
                table: "Users",
                column: "IdService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AffHistoriques");

            migrationBuilder.DropTable(
                name: "Pausess");

            migrationBuilder.DropTable(
                name: "Reparations");

            migrationBuilder.DropTable(
                name: "Roleusers");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Logiciels");

            migrationBuilder.DropTable(
                name: "SousCategories");

            migrationBuilder.DropTable(
                name: "Telephonies");

            migrationBuilder.DropTable(
                name: "AffArticles");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "AffLogiciels");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "TypeCategories");

            migrationBuilder.DropTable(
                name: "AffTelephonies");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Centres");

            migrationBuilder.DropTable(
                name: "villes");
        }
    }
}

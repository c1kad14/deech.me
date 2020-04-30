﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

using deech.me.data.context;

namespace deech.me.api.Migrations
{
    [DbContext(typeof(DeechMeDataContext))]
    [Migration("20200422062033_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("deech.me.data.entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContentId")
                        .HasColumnType("int");

                    b.Property<int?>("PublishId")
                        .HasColumnType("int");

                    b.Property<int?>("TitleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ContentId");

                    b.HasIndex("PublishId");

                    b.HasIndex("TitleId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("deech.me.data.entities.BookContent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("Content")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("BookContents");
                });

            modelBuilder.Entity("deech.me.data.entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("deech.me.data.entities.Language", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("deech.me.data.entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("deech.me.data.entities.PublishInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BookName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Publisher")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PublishInfos");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Annotation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenreId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TranslatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GenreId");

                    b.HasIndex("LanguageId");

                    b.HasIndex("SourceLanguageId");

                    b.HasIndex("TranslatorId");

                    b.ToTable("TitleInfos");
                });

            modelBuilder.Entity("deech.me.data.entities.Book", b =>
                {
                    b.HasOne("deech.me.data.entities.BookContent", "Content")
                        .WithMany()
                        .HasForeignKey("ContentId");

                    b.HasOne("deech.me.data.entities.PublishInfo", "Publish")
                        .WithMany()
                        .HasForeignKey("PublishId");

                    b.HasOne("deech.me.data.entities.TitleInfo", "Title")
                        .WithMany()
                        .HasForeignKey("TitleId");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfo", b =>
                {
                    b.HasOne("deech.me.data.entities.Person", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");

                    b.HasOne("deech.me.data.entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId");

                    b.HasOne("deech.me.data.entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageId");

                    b.HasOne("deech.me.data.entities.Language", "SourceLanguage")
                        .WithMany()
                        .HasForeignKey("SourceLanguageId");

                    b.HasOne("deech.me.data.entities.Person", "Translator")
                        .WithMany()
                        .HasForeignKey("TranslatorId");
                });
#pragma warning restore 612, 618
        }
    }
}

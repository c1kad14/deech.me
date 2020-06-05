﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using deech.me.data.context;

namespace deech.me.api.migrations
{
    [DbContext(typeof(DeechMeDataContext))]
    partial class DeechMeDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("deech.me.data.entities.Annotation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Annotations");
                });

            modelBuilder.Entity("deech.me.data.entities.Author", b =>
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

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("deech.me.data.entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("CustomInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("PublishInfoId")
                        .HasColumnType("int");

                    b.Property<int?>("TitleInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomInfoId");

                    b.HasIndex("PublishInfoId");

                    b.HasIndex("TitleInfoId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("deech.me.data.entities.BookCollection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Updated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookCollections");
                });

            modelBuilder.Entity("deech.me.data.entities.Bookmark", b =>
                {
                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.Property<int>("UserBookId")
                        .HasColumnType("int");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserBookId1")
                        .HasColumnType("int");

                    b.HasKey("ParagraphId", "UserBookId");

                    b.HasIndex("UserBookId");

                    b.HasIndex("UserBookId1");

                    b.ToTable("Bookmarks");
                });

            modelBuilder.Entity("deech.me.data.entities.Citation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.Property<int>("UserBookId")
                        .HasColumnType("int");

                    b.Property<int?>("UserBookId1")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParagraphId");

                    b.HasIndex("UserBookId");

                    b.HasIndex("UserBookId1");

                    b.ToTable("Citations");
                });

            modelBuilder.Entity("deech.me.data.entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AssociatedId")
                        .HasColumnType("int");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AssociatedId");

                    b.HasIndex("ParagraphId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("deech.me.data.entities.CustomInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CustomInfos");
                });

            modelBuilder.Entity("deech.me.data.entities.FavouriteBook", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId", "UserId");

                    b.ToTable("FavouriteBooks");
                });

            modelBuilder.Entity("deech.me.data.entities.Genre", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("deech.me.data.entities.Keyword", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Code");

                    b.ToTable("Keywords");
                });

            modelBuilder.Entity("deech.me.data.entities.Language", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Code");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("deech.me.data.entities.Note", b =>
                {
                    b.Property<int>("ParagraphId")
                        .HasColumnType("int");

                    b.Property<int>("UserBookId")
                        .HasColumnType("int");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserBookId1")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ParagraphId", "UserBookId");

                    b.HasIndex("UserBookId");

                    b.HasIndex("UserBookId1");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("deech.me.data.entities.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Sequence")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Paragraphs");
                });

            modelBuilder.Entity("deech.me.data.entities.PublishInfo", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

                    b.Property<int?>("AnnotationId")
                        .HasColumnType("int");

                    b.Property<int?>("BookCollectionId")
                        .HasColumnType("int");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SourceLanguageCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AnnotationId");

                    b.HasIndex("BookCollectionId");

                    b.HasIndex("LanguageCode");

                    b.HasIndex("SourceLanguageCode");

                    b.ToTable("TitleInfos");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("TitleInfoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TitleInfoId");

                    b.ToTable("TitleInfoAuthors");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoGenre", b =>
                {
                    b.Property<int>("TitleInfoId")
                        .HasColumnType("int");

                    b.Property<string>("GenreCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TitleInfoId", "GenreCode");

                    b.HasIndex("GenreCode");

                    b.ToTable("TitleInfoGenres");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoKeyword", b =>
                {
                    b.Property<int>("TitleInfoId")
                        .HasColumnType("int");

                    b.Property<string>("KeywordCode")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TitleInfoId", "KeywordCode");

                    b.HasIndex("KeywordCode");

                    b.ToTable("TitleInfoKeywords");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoTranslator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TitleInfoId")
                        .HasColumnType("int");

                    b.Property<int>("TranslatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TitleInfoId");

                    b.HasIndex("TranslatorId");

                    b.ToTable("TitleInfoTranslators");
                });

            modelBuilder.Entity("deech.me.data.entities.Translator", b =>
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

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Translators");
                });

            modelBuilder.Entity("deech.me.data.entities.UserBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Created")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Updated")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("BookId", "UserId");

                    b.ToTable("UserBooks");
                });

            modelBuilder.Entity("deech.me.data.entities.Book", b =>
                {
                    b.HasOne("deech.me.data.entities.CustomInfo", "CustomInfo")
                        .WithMany()
                        .HasForeignKey("CustomInfoId");

                    b.HasOne("deech.me.data.entities.PublishInfo", "PublishInfo")
                        .WithMany()
                        .HasForeignKey("PublishInfoId");

                    b.HasOne("deech.me.data.entities.TitleInfo", "TitleInfo")
                        .WithMany()
                        .HasForeignKey("TitleInfoId");
                });

            modelBuilder.Entity("deech.me.data.entities.Bookmark", b =>
                {
                    b.HasOne("deech.me.data.entities.Paragraph", "Paragraph")
                        .WithMany()
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", "UserBook")
                        .WithMany()
                        .HasForeignKey("UserBookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", null)
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserBookId1");
                });

            modelBuilder.Entity("deech.me.data.entities.Citation", b =>
                {
                    b.HasOne("deech.me.data.entities.Paragraph", "Paragraph")
                        .WithMany()
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", "UserBook")
                        .WithMany()
                        .HasForeignKey("UserBookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", null)
                        .WithMany("Citations")
                        .HasForeignKey("UserBookId1");
                });

            modelBuilder.Entity("deech.me.data.entities.Comment", b =>
                {
                    b.HasOne("deech.me.data.entities.Comment", "Associated")
                        .WithMany()
                        .HasForeignKey("AssociatedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("deech.me.data.entities.Paragraph", "Paragraph")
                        .WithMany("Comments")
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.FavouriteBook", b =>
                {
                    b.HasOne("deech.me.data.entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.Note", b =>
                {
                    b.HasOne("deech.me.data.entities.Paragraph", "Paragraph")
                        .WithMany()
                        .HasForeignKey("ParagraphId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", "UserBook")
                        .WithMany()
                        .HasForeignKey("UserBookId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.UserBook", null)
                        .WithMany("Notes")
                        .HasForeignKey("UserBookId1");
                });

            modelBuilder.Entity("deech.me.data.entities.Paragraph", b =>
                {
                    b.HasOne("deech.me.data.entities.Book", "Book")
                        .WithMany("Paragraphs")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfo", b =>
                {
                    b.HasOne("deech.me.data.entities.Annotation", "Annotation")
                        .WithMany()
                        .HasForeignKey("AnnotationId");

                    b.HasOne("deech.me.data.entities.BookCollection", null)
                        .WithMany("TitleInfos")
                        .HasForeignKey("BookCollectionId");

                    b.HasOne("deech.me.data.entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode");

                    b.HasOne("deech.me.data.entities.Language", "SourceLanguage")
                        .WithMany()
                        .HasForeignKey("SourceLanguageCode");
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoAuthor", b =>
                {
                    b.HasOne("deech.me.data.entities.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.TitleInfo", "TitleInfo")
                        .WithMany("Authors")
                        .HasForeignKey("TitleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoGenre", b =>
                {
                    b.HasOne("deech.me.data.entities.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.TitleInfo", "TitleInfo")
                        .WithMany("Genres")
                        .HasForeignKey("TitleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoKeyword", b =>
                {
                    b.HasOne("deech.me.data.entities.Keyword", "Keyword")
                        .WithMany()
                        .HasForeignKey("KeywordCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.TitleInfo", "TitleInfo")
                        .WithMany("Keywords")
                        .HasForeignKey("TitleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.TitleInfoTranslator", b =>
                {
                    b.HasOne("deech.me.data.entities.TitleInfo", "TitleInfo")
                        .WithMany("Translators")
                        .HasForeignKey("TitleInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deech.me.data.entities.Translator", "Translator")
                        .WithMany()
                        .HasForeignKey("TranslatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deech.me.data.entities.UserBook", b =>
                {
                    b.HasOne("deech.me.data.entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

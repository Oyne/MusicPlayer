﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spotify.Models;

#nullable disable

namespace Spotify.Migrations
{
    [DbContext(typeof(PlayerContext))]
    partial class PlayerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Spotify.Models.AlbumModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("album_id");

                    b.Property<Guid>("ArtistId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("album_artist_id");

                    b.Property<string>("Cover")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("album_cover");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("album_release_date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("albumt_title");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("albums");
                });

            modelBuilder.Entity("Spotify.Models.ArtistModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("artist_id");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artist_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("artist_name");

                    b.HasKey("Id");

                    b.ToTable("artists");
                });

            modelBuilder.Entity("Spotify.Models.FavoriteModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<Guid>("TrackId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("track_id");

                    b.HasKey("UserId", "TrackId");

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.ToTable("favorites");
                });

            modelBuilder.Entity("Spotify.Models.PlaylistModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("playlist_id");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("playlist_image");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("playlist_title");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("playlists");
                });

            modelBuilder.Entity("Spotify.Models.PlaylistTrackModel", b =>
                {
                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("playlist_id");

                    b.Property<Guid>("TrackId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("track_id");

                    b.HasKey("PlaylistId", "TrackId");

                    b.HasIndex("PlaylistId")
                        .IsUnique();

                    b.HasIndex("TrackId")
                        .IsUnique();

                    b.ToTable("playlist_tracks");
                });

            modelBuilder.Entity("Spotify.Models.TrackModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("track_id");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("track_album_id");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("track_duration");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("track_source");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("track_title");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("tracks");
                });

            modelBuilder.Entity("Spotify.Models.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("user_id");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_email");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_image");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Spotify.Models.AlbumModel", b =>
                {
                    b.HasOne("Spotify.Models.ArtistModel", "Artist")
                        .WithMany("Albums")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });

            modelBuilder.Entity("Spotify.Models.FavoriteModel", b =>
                {
                    b.HasOne("Spotify.Models.TrackModel", "Track")
                        .WithOne("Favorite")
                        .HasForeignKey("Spotify.Models.FavoriteModel", "TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spotify.Models.UserModel", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Track");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Spotify.Models.PlaylistModel", b =>
                {
                    b.HasOne("Spotify.Models.UserModel", "User")
                        .WithMany("Playlists")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Spotify.Models.PlaylistTrackModel", b =>
                {
                    b.HasOne("Spotify.Models.PlaylistModel", "Playlist")
                        .WithOne("PlaylistTrack")
                        .HasForeignKey("Spotify.Models.PlaylistTrackModel", "PlaylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Spotify.Models.TrackModel", "Track")
                        .WithOne("PlaylistTrack")
                        .HasForeignKey("Spotify.Models.PlaylistTrackModel", "TrackId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("Track");
                });

            modelBuilder.Entity("Spotify.Models.TrackModel", b =>
                {
                    b.HasOne("Spotify.Models.AlbumModel", "Album")
                        .WithMany("Tracks")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("Spotify.Models.AlbumModel", b =>
                {
                    b.Navigation("Tracks");
                });

            modelBuilder.Entity("Spotify.Models.ArtistModel", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("Spotify.Models.PlaylistModel", b =>
                {
                    b.Navigation("PlaylistTrack");
                });

            modelBuilder.Entity("Spotify.Models.TrackModel", b =>
                {
                    b.Navigation("Favorite");

                    b.Navigation("PlaylistTrack");
                });

            modelBuilder.Entity("Spotify.Models.UserModel", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}

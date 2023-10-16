﻿using ImageGallery.Application.Context;
using ImageGallery.Application.Entities.Files.Domains;
using ImageGallery.Application.Entities.Friends.Domains;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImageGallery.Persistence;

/// <summary>
/// Class ImageGalleryDbContext.
/// Implements the <see cref="DbContext" />
/// Implements the <see cref="IImageGalleryContext" />
/// </summary>
/// <seealso cref="DbContext" />
/// <seealso cref="IImageGalleryContext" />
public class ImageGalleryDbContext : DbContext, IImageGalleryContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageGalleryDbContext" /> class.
    /// </summary>
    /// <param name="options">The options.</param>
    public ImageGalleryDbContext(DbContextOptions<ImageGalleryDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Override this method to further configure the model that was discovered by convention from the entity types
    /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
    /// and re-used for subsequent instances of your derived context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
    /// define extension methods on this object that allow you to configure aspects of the model that are specific
    /// to a given database.</param>
    /// <remarks><para>
    /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
    /// then this method will not be run. However, it will still run when creating a compiled model.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-modeling">Modeling entity types and relationships</see> for more information and
    /// examples.
    /// </para></remarks>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FriendUserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    /// <summary>
    /// Override this method to configure the database (and other options) to be used for this context.
    /// This method is called for each instance of the context that is created.
    /// The base implementation does nothing.
    /// </summary>
    /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
    /// typically define extension methods on this object that allow you to configure the context.</param>
    /// <remarks><para>
    /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
    /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
    /// the options have already been set, and skip some or all of the logic in
    /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
    /// </para>
    /// <para>
    /// See <see href="https://aka.ms/efcore-docs-dbcontext">DbContext lifetime, configuration, and initialization</see>
    /// for more information and examples.
    /// </para></remarks>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
        optionsBuilder
            .ConfigureWarnings(x => x.Ignore(RelationalEventId.MultipleCollectionIncludeWarning));
    }

    /// <summary>
    /// Gets or sets the image files.
    /// </summary>
    /// <value>The image files.</value>
    public DbSet<ImageFile> ImageFiles { get; set; }

    /// <summary>
    /// Gets or sets the friends.
    /// </summary>
    /// <value>The friends.</value>
    public DbSet<Friend> Friends { get; set; }

    /// <summary>
    /// Gets or sets the users.
    /// </summary>
    /// <value>The users.</value>
    public DbSet<User> Users { get; set; }
}

/// <summary>
/// Class FriendUserConfiguration.
/// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
/// </summary>
/// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{ImageGallery.Application.Entities.FriendUsers.Domains.FriendUser}" />
public class FriendUserConfiguration : IEntityTypeConfiguration<FriendUser>
{
    /// <summary>
    /// Configures the entity of type <typeparamref name="TEntity" />.
    /// </summary>
    /// <param name="builder">The builder to be used to configure the entity type.</param>
    public void Configure(EntityTypeBuilder<FriendUser> builder)
    {
        builder.HasKey(fu => new { fu.FriendId, fu.UserId });

        builder.HasOne(fu => fu.Friend)
            .WithMany(u => u.FriendUsers)
            .HasForeignKey(fu => fu.FriendId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(fu => fu.User)
            .WithMany(u => u.FriendUsers)
            .HasForeignKey(fu => fu.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
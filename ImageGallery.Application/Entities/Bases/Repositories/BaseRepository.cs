using System.Linq.Expressions;
using ImageGallery.Application.Bases.Interfaces.IHaves;
using ImageGallery.Application.Entities.Bases.Filters;
using ImageGallery.Application.Entities.Bases.Interfaces;
using ImageGallery.Application.Entities.FriendUsers.Domains;
using ImageGallery.Application.Entities.Users.Domains;
using Microsoft.EntityFrameworkCore;

namespace ImageGallery.Application.Entities.Bases.Repositories;

/// <summary>
/// Class BaseRepository.
/// Implements the <see cref="IBaseRepository{T}" />
/// </summary>
/// <typeparam name="T"></typeparam>
/// <seealso cref="IBaseRepository{T}" />
public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class, IHaveId, IHaveName
{
    /// <summary>
    /// The context
    /// </summary>
    protected readonly DbContext Context;

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseRepository{T}" /> class.
    /// </summary>
    /// <param name="context">The context.</param>
    protected BaseRepository(DbContext context)
    {
        Context = context;
    }

    /// <summary>
    /// Gets the by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>Task&lt;System.Nullable&lt;T&gt;&gt;.</returns>
    public async Task<T?> GetById(int id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    /// <summary>
    /// Gets all.
    /// </summary>
    /// <returns>Task&lt;System.Nullable&lt;IEnumerable&lt;T&gt;&gt;&gt;.</returns>
    public async Task<IEnumerable<T>?> GetAll()
    {
        return await Context.Set<T>().ToListAsync();
    }

    /// <summary>
    /// Gets all by filter.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>Task&lt;System.Nullable&lt;IEnumerable&lt;T&gt;&gt;&gt;.</returns>
    public async Task<IEnumerable<T>?> GetAllByFilter(string query)
    {
        return await Context.Set<T>()
            .Where(t => t.Name == query)
            .ToListAsync();
    }

    /// <summary>
    /// Gets all by filter.
    /// </summary>
    /// <param name="query">The query.</param>
    /// <returns>Task&lt;System.Nullable&lt;IEnumerable&lt;T&gt;&gt;&gt;.</returns>
    public virtual async Task<IEnumerable<T>?> GetAllByFilter(FilterParams query)
    {
        var result = await Filter<T>.FilteredData(new List<FilterParams> { query }, await GetAll() ?? Array.Empty<T>());
        return result;
    }

    /// <summary>
    /// Finds the specified expression.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>Task&lt;System.Nullable&lt;IEnumerable&lt;T&gt;&gt;&gt;.</returns>
    public Task<IEnumerable<T>?> Find(Expression<Func<T, bool>> expression)
    {
        return Task.FromResult<IEnumerable<T>?>(Context?.Set<T>().Where(expression));
    }

    /// <summary>
    /// Adds the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Add(T entity)
    {
        Context.Set<T>().Add(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Update(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Removes the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns>Task.</returns>
    public async Task Remove(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    /// <summary>
    /// Add friendship as an asynchronous operation.
    /// </summary>
    /// <param name="firstFriendId">The first friend identifier.</param>
    /// <param name="secondFriendId">The second friend identifier.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> AddFriendshipAsync(int firstFriendId, int secondFriendId)
    {
        try
        {
            var firstFriend = await Context.Set<User>().FindAsync(firstFriendId);
            var secondFriend = await Context.Set<User>().FindAsync(secondFriendId);

            if (firstFriend != null && secondFriend != null)
            {
                var friendUser = new FriendUser
                {
                    FirstFriend = firstFriend,
                    SecondFriend = secondFriend
                };

                Context.Set<FriendUser>().Add(friendUser);
                await Context.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    /// <summary>
    /// Remove friendship as an asynchronous operation.
    /// </summary>
    /// <param name="firstFriendId">The first friend identifier.</param>
    /// <param name="secondFriendId">The second friend identifier.</param>
    /// <returns>A Task&lt;System.Boolean&gt; representing the asynchronous operation.</returns>
    public async Task<bool> RemoveFriendshipAsync(int firstFriendId, int secondFriendId)
    {
        try
        {
            var firstFriend = await Context.Set<User>().FindAsync(firstFriendId);
            var secondFriend = await Context.Set<User>().FindAsync(secondFriendId);

            if (firstFriend != null && secondFriend != null)
            {
                var friendUser = new FriendUser
                {
                    FirstFriend = firstFriend,
                    SecondFriend = secondFriend
                };

                Context.Set<FriendUser>().Remove(friendUser);
                await Context.SaveChangesAsync();

                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework.DbContexts;

/// <summary>
/// Базовый контекст работы с базой данных.
/// </summary>
/// <param name="options">Опции контекста работы с базой данных, которые определяют конфигурацию подключения и поведение.</param>
/// <remarks>
/// Предоставляет общие методы для добавления, обновления и удаления сущностей в базе данных,
/// а также управляет состоянием сущностей. Он наследуется от <see cref="DbContext"/> 
/// и предназначен для использования в производных классах, которые реализуют конкретные контексты базы данных.
/// </remarks>
public abstract class DbContextBase(DbContextOptions options) : DbContext(options)
{
    #region Методы

    /// <summary>
    /// Добавляет сущность в базу данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип данных добавляемой сущности.</typeparam>
    /// <param name="entity">Добавляемая сущность.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public virtual async Task AddEntityAsync<TEntity>(TEntity entity) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        await AddAsync(entity);

        try
        {
            await SaveChangesAsync();
        }
        finally
        {
            Entry(entity).State = EntityState.Detached;
        }
    }

    /// <summary>
    /// Обновляет сущность в базе данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип данных обновляемой сущности.</typeparam>
    /// <param name="entity">Обновляемая сущность.</param>
    /// <param name="updatedProperties">Перечень обновляемых свойств сущности. Если <c>null</c>, обновляются все свойства.</param>
    /// <returns>Задача, представляющая асинхронную операцию.</returns>
    public virtual async Task UpdateEntityAsync<TEntity>(TEntity entity, IEnumerable<string>? updatedProperties = null) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        if (updatedProperties is null || !updatedProperties.Any())
        {
            Update(entity);
        }
        else
        {
            foreach (var propertyName in updatedProperties)
            {
               Entry(entity).Property(propertyName).IsModified = true;
            }
        }

        try
        {
            await SaveChangesAsync();
        }
        finally
        {
            Entry(entity).State = EntityState.Detached;
        }
    }

    /// <summary>
    /// Удаляет сущность из базы данных.
    /// </summary>
    /// <typeparam name="TEntity">Тип данных удаляемой сущности.</typeparam>
    /// <param name="entity">Удаляемая сущность.</param>
    /// <returns/>
    public virtual async Task RemoveEntityAsync<TEntity>(TEntity entity) where TEntity : class
    {
        ArgumentNullException.ThrowIfNull(entity);

        Remove(entity);

        try
        {
            await SaveChangesAsync();
        }
        finally
        {
            Entry(entity).State = EntityState.Detached;
        }
    }

    #endregion
}

using AutoMapper;
using awyer.api.clients.application.Contracts.Interfases.Persistence.Common;
using lawyer.api.clients.datastore.mssql.DatabaseContext;
using lawyer.api.clients.datastore.mssql.Model.Common;
using lawyer.api.clients.domain.Common;

namespace lawyer.api.clients.datastore.mssql.Repositories.Common;

public class CommandRepository <T,TEntity>: ICommandRepository<T> 
    where T : BaseEntity  
    where TEntity : EFEntity
{
    private readonly LawyersContext _dbContext;
    private readonly IMapper _mapper;
    public CommandRepository(LawyersContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task CreateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        
        Console.WriteLine($"Datos antes de guardar: {System.Text.Json.JsonSerializer.Serialize(dbEntity)}");

        _dbContext.Add((object)dbEntity);
        await _dbContext.SaveChangesAsync();

        // Asignar el ID generado a la entidad original
        _mapper.Map(dbEntity, entity);
    }

    public async Task UpdateAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Update(dbEntity);
        //_dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        var dbEntity = _mapper.Map<TEntity>(entity);
        _dbContext.Remove(dbEntity);
        await _dbContext.SaveChangesAsync();
    }
    
}
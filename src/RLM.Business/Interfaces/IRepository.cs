using RLM.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RLM.Business.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity:Entity
    {
        Task<IEnumerable<TEntity>>Buscar(Expression<Func<TEntity,bool>> predicate);
        Task<TEntity> ObterPorId(Guid id);
        Task<IEnumerable<TEntity>> ObterTodos();
        Task Adicionar(TEntity entity);
        Task Atualizar(TEntity entity);
        Task Remover(TEntity entity);
        Task<int> SaveChanges();
    }
}

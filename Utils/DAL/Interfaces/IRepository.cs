﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

namespace DAL.Interfaces
{    
    internal interface IRepository<TEntity, TModel>
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        IEnumerable<TModel> GetWithParse(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetByID(Expression<Func<TEntity, bool>> filter = null);
        TModel GetByIDWithParse(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter = null);
        void InsertFromEntity(TEntity entity);
        void InsertFromModel(TModel model);
        void Delete(Expression<Func<TEntity, bool>> filter = null);
        void DeleteFromEntity(TEntity entity);
        void DeleteFromModel(TModel model);
        void Update(TEntity entity);
        void UpdateFromModel(TModel model);
        void Save();
        void discardChanges<TEntityes>(TEntityes entity) where TEntityes : class;
    }
}

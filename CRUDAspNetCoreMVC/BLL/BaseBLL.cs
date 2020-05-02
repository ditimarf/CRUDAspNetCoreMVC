using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRUDAspNetCoreMVC.BLL
{
    public class BaseBLL<T> where T : class
    {
        private DAL.CRUDContext context;
        public BaseBLL(DAL.CRUDContext context)
        {
            this.context = context;
        }

        public List<T> RetornarLista()
        {
            return context.Set<T>().ToList();
        }

        public T Retornar(int codigo)
        {
            return context.Set<T>().Find(codigo);
        }
        
        public T Inserir(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
            return item;
        }

        public T Editar(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
            return item;
        }

        public bool Remover(T item)
        {
            try
            {
                context.Entry(item).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        #region Protected
        protected List<T> RetornarLista(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression).ToList();
        }

        protected T Retornar(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().FirstOrDefault(expression);
        }

        #endregion
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CRUDAspNetCoreMVC.BLL
{
    public class BaseBLL<T> where T : class
    {
        protected DAL.CRUDContext contexto;
        public BaseBLL(DAL.CRUDContext context)
        {
            this.contexto = context;
        }

        public List<T> RetornarLista()
        {
            return contexto.Set<T>().ToList();
        }

        public T Retornar(int codigo)
        {
            return contexto.Set<T>().Find(codigo);
        }

        public T Inserir(T item)
        {
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
            return item;
        }

        public List<T> Inserir(List<T> itens)
        {
            var _return = new List<T>();

            foreach (var i in itens)
                _return.Add(Inserir(i));

            return _return;
        }

        public T Editar(T item)
        {
            contexto.Entry(item).State = EntityState.Modified;
            contexto.SaveChanges();
            return item;
        }

        public List<T> Editar(List<T> itens)
        {
            var _return = new List<T>();

            foreach (var i in itens)
                _return.Add(Editar(i));

            return _return;
        }

        public bool Remover(T item)
        {
            try
            {
                contexto.Entry(item).State = EntityState.Deleted;
                contexto.SaveChanges();
                return true;
            }
            catch { }

            return false;
        }

        public void Remover(List<T> itens)
        {
            foreach (var i in itens)
                Remover(i);
        }

        #region Protected
        protected List<T> RetornarLista(Expression<Func<T, bool>> expression)
        {
            return contexto.Set<T>().Where(expression).ToList();
        }

        protected T Retornar(Expression<Func<T, bool>> expression)
        {
            return contexto.Set<T>().FirstOrDefault(expression);
        }

        #endregion
    }
}

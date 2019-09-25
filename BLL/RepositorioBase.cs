using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto _contexto;
        public RepositorioBase(Contexto contexto)
        {
            _contexto = contexto;
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;
            try
            {
                if (_contexto.Set<T>().Add(entity) != null)
                {
                    paso = _contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;

            }

            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;
            try
            {
                _contexto.Entry(entity).State = EntityState.Modified;
                paso = _contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }
        public virtual bool Eliminar(int id)
        {
            bool paso = false;
            try
            {
                T entity = _contexto.Set<T>().Find(id);
                _contexto.Set<T>().Remove(entity);
                paso = _contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual T Buscar(int id)
        {
            T entity;
            try
            {
                entity = _contexto.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;

            }
            return entity;
        }

        public List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();
            try
            {
                Lista = _contexto.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}


/* public class RepositorioPago : RepositorioBase<Pago>
    {
        public RepositorioPago(Contexto contexto) : base(contexto)
        {

        }
        public override bool Guardar(Pago pago)
        {

            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                if (contexto.pago.Add(pago) != null)
                {
                    foreach (var item in pago.DetallePagos)
                    {
                        contexto.analisis.Find(item.AnalisisId).Balance += (decimal)item.MontoPagado;

                    }

                    contexto.SaveChanges(); //Guardar los cambios
                    paso = true;
                }
                //siempre hay que cerrar la conexion
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }
        public override Pago Buscar(int id)
        {
            Pago analisis = new Pago();
            try
            {
                analisis = _contexto.pago.Find(id);

                analisis.DetallePagos.Count();//Cargar la lista en este punto porque         //luego de hacer Dispose() el Contexto           //no sera posible leer la lista


            }
            catch (Exception)
            {

                throw;
            }
            return analisis;
        }

        public override bool Eliminar(int id)
        {
            bool paso = false;

            Contexto contexto = new Contexto();
            try
            {
                Pago ventas = contexto.pago.Find(id);

                foreach (var item in ventas.DetallePagos)
                {
                    var balance = contexto.analisis.Find(item.DetallePagoId);
                    balance.Balance -= (decimal)item.MontoPagado;
                }

                contexto.pago.Remove(ventas);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
            return paso;
        }

        public override bool Modificar(Pago analsis)
        {
            bool paso = false;
            try
            {
                //buscar las entidades que no estan para removerlas
                var Anterior = _contexto.analisis.Find(analsis.AnalisisId);
                foreach (var item in Anterior.Detalles)
                {
                    /*if (!analsis.Detalles.Exists(d => d.AnalisisId == item.AnalisisId))
                    {
                        _contexto.Entry(item).State = EntityState.Deleted;
                    }
                }

                //recorrer el detalle
                foreach (var item in analsis.DetallePagos)
                {
                    /*
                    //Muy importante indicar que pasara con la entidad del detalle
                    var estado = item.AnalisisId > 0 ? EntityState.Modified : EntityState.Added;
                    _contexto.Entry(item).State = estado;
                }

                //Idicar que se esta modificando el encabezado
                _contexto.Entry(analsis).State = EntityState.Modified;

                if (_contexto.SaveChanges() > 0)
                    paso = true;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }*/

using Microsoft.EntityFrameworkCore;
using RegistroCompra.DAL;
using RegistroCompra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace RegistroCompra.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Ordenes orden)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                if (db.Ordenes.Add(orden) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Ordenes orden)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM OrdenesDetalle Where OrdenId = {orden.OrdenId}");

                foreach (var item in orden.Detalle)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(orden).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            Contexto db = new Contexto();
            bool paso = false;

            try
            {
                var eliminar = OrdenesBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Ordenes Buscar(int id)
        {
            Contexto db = new Contexto();
            Ordenes orden = new Ordenes();

            try
            {
                orden = db.Ordenes.Include(o => o.Detalle).Where(o => o.OrdenId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return orden;
        }

        public static List<Ordenes> GetList(Expression<Func<Ordenes, bool>> orden)
        {
            Contexto db = new Contexto();
            List<Ordenes> Lista = new List<Ordenes>();

            try
            {
                Lista = db.Ordenes.Where(orden).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}

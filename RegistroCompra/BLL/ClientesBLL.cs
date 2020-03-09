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
    public class ClientesBLL
    {
        
            public static bool Guardar(Clientes cliente)
            {
                Contexto db = new Contexto();
                bool paso = false;

                try
                {
                    if (db.Clientes.Add(cliente) != null)
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

            public static bool Modificar(Clientes cliente)
            {
                Contexto db = new Contexto();
                bool paso = false;

                try
                {
                    db.Entry(cliente).State = EntityState.Modified;
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
                    var eliminar = ClientesBLL.Buscar(id);
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

            public static Clientes Buscar(int id)
            {
                Contexto db = new Contexto();
                Clientes cliente = new Clientes();

                try
                {
                    cliente = db.Clientes.Find(id);
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    db.Dispose();
                }
                return cliente;
            }

            public static List<Clientes> GetList(Expression<Func<Clientes, bool>> cliente)
            {
                Contexto db = new Contexto();
                List<Clientes> Lista = new List<Clientes>();

                try
                {
                    Lista = db.Clientes.Where(cliente).ToList();
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

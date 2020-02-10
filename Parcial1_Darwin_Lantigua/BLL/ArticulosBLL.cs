using System;
using System.Collections.Generic;
using System.Text;
using Parcial1_Darwin_Lantigua.Entidades;
using Parcial1_Darwin_Lantigua.DAL;
using Microsoft.EntityFrameworkCore;

namespace Parcial1_Darwin_Lantigua.BLL
{
    public class ArticulosBLL
    {
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Articulos.Add(articulos) != null)
                    paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Entry(articulos).State = EntityState.Modified;
                paso = (db.SaveChanges() > 0);
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
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = db.Articulos.Find(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = (db.SaveChanges() > 0);
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }

            return paso;
        }

        public static Articulos Buscar(int id)
        {

        }
    }
}

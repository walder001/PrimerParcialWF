using BLL;
using DAL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    
        public class RepositorioEvaluacion : RepositorioBase<Evaluacion>
        {
            public RepositorioEvaluacion(Contexto contexto) : base(contexto)
            {

            }
            
            public override Evaluacion Buscar(int id)
            {
                Evaluacion analisis = new Evaluacion();
                try
                {
                    analisis = _contexto.Evaluacion.Find(id);

                    analisis.Detalles.Count();       //no sera posible leer la lista


                }
                catch (Exception)
                {

                    throw;
                }
                return analisis;
            }

            

        }
    }

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
    public class Evaluacion
    {
        [Key]
        public int EvalucionId { get; set; }
        public int ClienteId { get; set; }
        public decimal Total { get; set; }

        public DateTime Fecha { get; set; }


        public virtual List<DetalleEvaluacion> Detalles { get; set; }

        public Evaluacion()
        {
            this.Detalles = new List<DetalleEvaluacion>();

        }

        public Evaluacion(int evalucionId, int clienteId, decimal total, DateTime fecha)
        {
            EvalucionId = evalucionId;
            ClienteId = clienteId;
            Total = total;
            Fecha = fecha;
            this.Detalles = new List<DetalleEvaluacion>();

        }
        public void Agregar(int detalleEvalucionId, int evaluacionId, string categoria, decimal valor, decimal logrado, decimal perdido)
        {
            this.Detalles.Add(new DetalleEvaluacion(detalleEvalucionId,evaluacionId,categoria, valor,logrado,perdido));

        }
    }
}

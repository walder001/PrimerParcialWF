using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Serializable]
   public class DetalleEvaluacion
    {
        [Key]
        public int DetalleEvalucionId { get; set; }
        public int EvaluacionId { get; set; }
        public string Categoria { get; set; }
        public decimal Valor { get; set; }
        public decimal Logrado { get; set; }
        public decimal Perdido { get; set; }

        public DetalleEvaluacion()
        {

            DetalleEvalucionId = 0;
            EvaluacionId = 0;
            Categoria = string.Empty;
            Valor = 0;
            Logrado = 0;
            Perdido = 0;

        }
        public DetalleEvaluacion(int detalleEvalucionId, int evaluacionId, string categoria, decimal valor, decimal logrado, decimal perdido)
        {
            DetalleEvalucionId = detalleEvalucionId;
            EvaluacionId = evaluacionId;
            Categoria = categoria;
            Valor = valor;
            Logrado = logrado;
            Perdido = perdido;
        }
    }
}

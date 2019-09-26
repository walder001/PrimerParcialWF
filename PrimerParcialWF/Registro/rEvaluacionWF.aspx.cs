using BLL;
using DAL;
using Entidades;
using PrimerParcialWF.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrimerParcialWF.Registro
{
    public partial class rEvaluacionWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                base.ViewState["Evaluacion"] = new Evaluacion();
                FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
     
                this.BindGrid();
            }

        }
        
      
        public void CaculoTotal()
        {
            decimal logro = 0, valor =0 , total = 0;
            decimal totalGeneral = 0, mont = 0;

            valor = Utils.ToDecimal(ValorTextBox.Text);

            logro = Utils.ToDecimal(LogradoTextBox.Text);

            total = valor - logro;

            mont = Utils.ToDecimal(TotalTextBox.Text);
            totalGeneral = mont + total;
            TotalTextBox.Text = totalGeneral.ToString();
        }

        protected void BindGrid()
        {
            GridView1.DataSource = ((Evaluacion)base.ViewState["Evaluacion"]).Detalles;
            GridView1.DataBind();
        }
        public void LimpiarObjeto()
        {
            EvaluacionTextBox.Text = string.Empty;
            EstudianteDropDownList.Enabled = true;
            CategoriaTextBox.Text = string.Empty;
            ValorTextBox.Text = string.Empty;
            LogradoTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-mm-dd");
            base.ViewState["Evaluacion"] = new Evaluacion();
            this.BindGrid();
        }


        public Evaluacion LLenaClase()
        {
            Evaluacion evaluacion = new Evaluacion();
            evaluacion = (Evaluacion)ViewState["Evaluacion"];

            evaluacion.EvalucionId = Utils.ToInt(EvaluacionTextBox.Text);
            evaluacion.ClienteId = Utils.ToInt(EstudianteDropDownList.SelectedValue);
            evaluacion.Fecha = Utils.ToDateTime(FechaTextBox.Text);
            evaluacion.Total = Utils.ToDecimal(TotalTextBox.Text);

            return evaluacion;
        }

        public void LLenaCampo(Evaluacion evaluacion)
        {
            LimpiarObjeto();
            ((Evaluacion)ViewState["Evaluacion"]).Detalles = evaluacion.Detalles;
            EvaluacionTextBox.Text = evaluacion.EvalucionId.ToString();
            EstudianteDropDownList.SelectedValue = evaluacion.ClienteId.ToString();
            TotalTextBox.Text = evaluacion.Total.ToString();
            FechaTextBox.Text = evaluacion.Fecha.ToString();
            this.BindGrid();
        }
        private bool HayErrores()
        {
            bool paso = false;
            if (String.IsNullOrEmpty(EvaluacionTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese un Id');</script>");
                paso = true;
            }
            if (String.IsNullOrEmpty(CategoriaTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese una cantidad');</script>");
                paso = true;
            }
            if (String.IsNullOrEmpty(ValorTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese el valor');</script>");
                paso = true;
            }
            if (String.IsNullOrEmpty(LogradoTextBox.Text))
            {
                Response.Write("<script>alert('Ingrese logro');</script>");
                paso = true;
            }
            if (GridView1.Columns.Count == 0)
            {
                Response.Write("<script>alert('El detalle está vacío');</script>");
                paso = true;
            }
            return paso;
        }

        private void LlenarValores()
        {
            List<DetalleEvaluacion> detalle = new List<DetalleEvaluacion>();


            if (GridView1.DataSource != null)
            {
                detalle = (List<DetalleEvaluacion>)GridView1.DataSource;
            }

        }
        protected void Limpiar_Click(object sender, EventArgs e)
        {
            LimpiarObjeto();

        }

        protected void Guardar_Click(object sender, EventArgs e)
        {
            bool paso = false;
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            Evaluacion evaluacion = new Evaluacion();
            if (HayErrores())
                return;
            else

                evaluacion = LLenaClase();
            if (Utils.ToInt(EvaluacionTextBox.Text) == 0)
            {
                repositorio.Guardar(evaluacion);
            }
            else
            {
                repositorio.Buscar(Utils.ToInt(EvaluacionTextBox.Text));
                if (repositorio != null)
                {
                    paso = repositorio.Modificar(evaluacion);
                }
                else
                {
                    Response.Write("<script>alert('Id no existe');</script>");
                }
            }
            if (paso)
            {
                Utils.ShowToastr(this, "Exito", "Existo", "success");
                LimpiarObjeto();
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error", "success");


            }


        }

        protected void Eliminar_Click(object sender, EventArgs e)
        {

            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            Evaluacion evaluacion = new Evaluacion();


            if (repositorio.Eliminar(Convert.ToInt32(EvaluacionTextBox.Text)))
            {

                Utils.ShowToastr(this, "Registro eliminado", "Exito", "success");
                LimpiarObjeto();
            }
            else
            {
                Utils.ShowToastr(this, "Registro eliminado", "Error", "success");


            }



        }

        protected void Buscar_Click(object sender, EventArgs e)
        {
            RepositorioEvaluacion repositorio = new RepositorioEvaluacion(new Contexto());
            var buscar = repositorio.Buscar(Utils.ToInt(EvaluacionTextBox.Text));
            if (buscar != null)
            {
                LLenaCampo(buscar);
                Utils.ShowToastr(this, "Exito", "Exito");
            }
            else
            {
                Utils.ShowToastr(this, "Error", "Error");


            }

        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            CaculoTotal();

            Evaluacion evaluacion = new Evaluacion();
            evaluacion = (Evaluacion)base.ViewState["Evaluacion"];
            decimal perdiada = 0;
            perdiada = Utils.ToDecimal(ValorTextBox.Text) - Utils.ToDecimal(LogradoTextBox.Text);
            evaluacion.Agregar(0, Utils.ToInt(EvaluacionTextBox.Text),EstudianteDropDownList.SelectedValue, Utils.ToDecimal(ValorTextBox.Text), Utils.ToDecimal(LogradoTextBox.Text),perdiada);
            ViewState["Evaluacion"] = evaluacion;
            this.BindGrid();
            LlenarValores();
        }
    }
}
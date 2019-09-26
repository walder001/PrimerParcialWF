<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="rEvaluacionWF.aspx.cs" Inherits="PrimerParcialWF.Registro.rEvaluacionWF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="form-group">   


               <%-- Fecha Id--%>
            <div class="row">
                <div class="form-group col-lg-6">
                    <asp:Label ID="Fecha" runat="server" Text="Fecha"></asp:Label>
                    <asp:TextBox ID="FechaTextBox" runat="server" TextMode="Date" CssClass="col-lg-12 "></asp:TextBox>
                </div>
            </div>
     <%-- EvaluacionId --%>
            <div class="form-group">
                <label for="EvaluacionIdTextBox" class="col-md-3 control-label input-sm" style="font-size: small">EvaluacionId</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="EvaluacionTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="EvaluacionTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" OnClick="Buscar_Click" />
                </div>
            </div>

            
           

          
            <%--Estudiante--%>
            <div class="form-group">
                <label for="EstudianteDropDownList" class="col-md-3 control-label input-sm" style="font-size: small">Estudiante</label>
                <div class="col-md-6">
                    <asp:DropDownList ID="EstudianteDropDownList" runat="server" Class="form-control input-sm" Style="font-size: small">
                        <asp:ListItem Selected="True">Walder</asp:ListItem>
                        <asp:ListItem>Maria</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>

            <%--Categoria--%>
            <div class="form-group">
                <label for="CategoriaTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >Categoria</label>
                <div class="col-md-6">
                    <asp:TextBox ID="CategoriaTextBox" runat="server"  onkeypress="return isLetterKey(event)" placeholder="Ej. Juan Perez" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Categoria&quot; esta vacio" ControlToValidate="CategoriaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Categoria es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
          <%--Valor--%>
            <div class="form-group">
                <label for="ValorTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >Valor</label>
                <div class="col-md-6">
                    <asp:TextBox ID="ValorTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El campo &quot;Categoria&quot; esta vacio" ControlToValidate="ValorTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Categoria es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>
      <%--Logrado--%>
            <div class="form-group">
                <label for="Logrado" class="col-md-3 control-label input-sm" style="font-size: small" >Logrado</label>
                <div class="col-md-6">
                    <asp:TextBox ID="LogradoTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="El campo &quot;Logado&quot; esta vacio" ControlToValidate="LogradoTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Logrado es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>


            <asp:GridView ID="GridView1" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:HyperLinkField ControlStyle-ForeColor="#0094ff"
                        HeaderText="Opciones"
                        DataNavigateUrlFields="DetalleEvalucionId"
                        DataNavigateUrlFormatString="/Registro/rEvaluacionWF.aspx?Id={0}"
                        Text="Eliminar"></asp:HyperLinkField>
                </Columns>
                <HeaderStyle BackColor="#0094ff" Font-Bold="true" ForeColor="black" />
                <RowStyle BackColor="#EFF3FB" />
            </asp:GridView>

                      <div> 
                          <asp:Button ID="Agregar" runat="server" Text="Agregar" OnClick="Agregar_Click" />


            <asp:Label ID="Label2" runat="server" Text="Total"></asp:Label>
            <asp:TextBox ID="TotalTextBox" runat="server"></asp:TextBox>

            <asp:Button ID="Limpiar" runat="server" Text="Limpiar" OnClick="Limpiar_Click" />
            <asp:Button ID="Guardar" runat="server" Text="Guardar" OnClick="Guardar_Click" />
            <asp:Button ID="Eliminar" runat="server" Text="Elimnar" OnClick="Eliminar_Click"/>
          </div>

            </div>
   



        </div>
       


</asp:Content>

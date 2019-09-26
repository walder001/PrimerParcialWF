<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PrimerParcialWF.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="panel" style="background-color: #0094ff">
        <div class="panel-heading" style="font-family: Arial Black; font-size: 20px; text-align:center; color: Black">Registro de Usuarios</div>
    </div>
    <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">

            <div class="container">
            <%--UsuarioId--%>
            <div class="form-group">
                <label for="UsuarioIdTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Usuario Id</label>
                <div class="col-md-1 ">
                    <asp:TextBox ID="UsuarioIdTextBox" runat="server" placeholder="0" class="form-control input-sm" Style="font-size: small" TextMode="Number"></asp:TextBox>
                </div>
                <asp:RegularExpressionValidator ID="ValidaID" runat="server" ErrorMessage='Campo "ID" solo acepta numeros' ControlToValidate="UsuarioIdTextBox" ValidationExpression="^[0-9]*" Text="*" ForeColor="Red" Display="Dynamic" ToolTip="Entrada no valida" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                <div class="col-md-1 ">
                    <asp:Button ID="BuscarButton" runat="server" Text="Buscar" class="btn btn-primary" />
                </div>
            </div>

            <%-- Nombres--%>
            <div class="form-group">
                <label for="NombresTextBox" class="col-md-3 control-label input-sm" style="font-size: small" >Nombres</label>
                <div class="col-md-6">
                    <asp:TextBox ID="NombresTextBox" runat="server"  onkeypress="return isLetterKey(event)" placeholder="Ej. Juan Perez" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="Valida" runat="server" ErrorMessage="El campo &quot;Nombres&quot; esta vacio" ControlToValidate="NombresTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Nombres es obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

            <%--Usuario--%>
            <div class="form-group">
                <label for="NombreUsuarioTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Usuario</label>
                <div class="col-md-6">
                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server"  class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="ValidaUser" runat="server" ControlToValidate="NombreUsuarioTextBox" ForeColor="Red" Display="Dynamic" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

            <%--Contraseña--%>
            <div class="form-group">
                <label for="ContraseñaTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Contraseña</label>
                <div class="col-md-6">
                    <asp:TextBox type="password" ID="ContraseñaTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:RequiredFieldValidator ID="ValidaContraseña" runat="server" ErrorMessage="El campo &quot;Contraseña&quot; esta vacio" ControlToValidate="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

            <%--Confirmar Contraseña--%>
            <div class="form-group">
                <label for="ConfirmarContraseñaTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Confirmar Contraseña</label>
                <div class="col-md-6">
                    <asp:TextBox type="password" ID="ConfirmarContraseñaTextBox" runat="server" class="form-control input-sm" Style="font-size: small"></asp:TextBox>
                </div>
                <asp:CompareValidator ID="ComparaContraseñas" runat="server" ErrorMessage="Las Contraseñas no son iguales" ControlToValidate="ConfirmarContraseñaTextBox" ControlToCompare="ContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Las Contraseñas no son iguales" ValidationGroup="Guardar">*</asp:CompareValidator>
                <asp:RequiredFieldValidator ID="ValidaConfirmarContraseña" runat="server" ErrorMessage="El campo &quot;Nombres&quot; estas vacio" ControlToValidate="ConfirmarContraseñaTextBox" ForeColor="Red" Display="Dynamic" ToolTip="Campo Confirmar Contraseña obligatorio" ValidationGroup="Guardar">*</asp:RequiredFieldValidator>
            </div>

            <%--Tipo Usuario--%>
            <div class="form-group">
                <label for="TipoUsuarioDropDownList" class="col-md-3 control-label input-sm" style="font-size: small">Tipo Usuario</label>
                <div class="col-md-6">
                    <asp:DropDownList ID="TipoUsuarioDropDownList" runat="server" Class="form-control input-sm" Style="font-size: small">
                        <asp:ListItem Selected="True">Administrador</asp:ListItem>
                        <asp:ListItem>Cajero</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
                <div class="form-group">
                    <label for="PacienteId" class="col-md-3 control-label input-sm">Paciente</label>
                    <div class="col-md-8">
                        <asp:DropDownList runat="server" ID="PacienteDropDown" CssClass="form-control input-sm"></asp:DropDownList>

                    </div>
                </div> 
                <div class="table-responsive">
                    <asp:GridView ID="DatosGridView" runat="server" class="table table-condensed  table-responsive" CellPadding="6" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:HyperLinkField ControlStyle-ForeColor="#0094ff"
                                HeaderText="Opciones"
                                DataNavigateUrlFields="DetallePagoId"
                                DataNavigateUrlFormatString="/PagoWF.aspx?Id={0}"
                                Text="Eliminar"></asp:HyperLinkField>
                        </Columns>
                        <HeaderStyle BackColor="#0094ff" Font-Bold="true" ForeColor="black" />
                        <RowStyle BackColor="#EFF3FB" />
                    </asp:GridView>
                </div>
            <%--Total Vendido--%>
            <div class="form-group">
                <label for="TotalVendidoTextBox" class="col-md-3 control-label input-sm" style="font-size: small">Total Ventas</label>
                <div class="col-md-6">
                    <asp:TextBox  ID="TotalVendidoTextBox" runat="server" class="form-control input-sm" Style="font-size: small" ReadOnly="true"></asp:TextBox>
                </div>
            </div>

            <%--Fecha--%>
            <div class="form-group">
                <div class="col-md-6">
                    <asp:TextBox ID="FechaTextBox" TextMode="Date" runat="server" class="form-control input-sm" Style="font-size: small" Visible="false"></asp:TextBox>
                </div>
            </div>
            <br />

            <%--Botones--%>
            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-primary"/>
                        <asp:Button ID="GuardarButton" runat="server" Text="Guardar" class="btn btn-success" ValidationGroup="Guardar"  />
                        <asp:Button ID="EliminarButton" runat="server" Text="Eliminar" class="btn btn-danger" />
                    </div>
                </div>
            </div>
        </div>
            </div>
    </div>
</asp:Content>

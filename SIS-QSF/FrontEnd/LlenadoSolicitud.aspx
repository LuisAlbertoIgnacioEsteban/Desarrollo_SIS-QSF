<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LlenadoSolicitud.aspx.cs" Inherits="FrontEnd.LlenadoSolicitud" %>

<!DOCTYPE html>

<html>
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
    <title>Formulario QSF</title>
    <link rel=icon type="image/jpg" href="Imagenes/itsur.jpg">
    <link rel="stylesheet" href="css/bootstrap.css"/>
    <link rel="stylesheet" href="css/estilo.css"/>
</head>
<body>
   <nav class="navbar navbar-expand-md navbar-dark fixed-top bg-dark">
        <h1><img src="Imagenes/sisqsf.png"/></h1>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <h4 style="color:white;">Sistema de Quejas, Sugerencias y/o Felicitaciones</h4>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <div class="collapse navbar-collapse" id="navbarMenu">
            <ul class="navbar-nav mr-auto" style="border:solid; border-color:aqua;">
                <li class="nav-item">
                    <a href="LlenadoSolicitud.aspx" class="nav-link"><h6 style="color:white;">Llenar Solicitud</h6></a>
                </li>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <li class="nav-item">
                    <a href="MonitoreoSolicitud.aspx" class="nav-link"><h6 style="color:white;">Monitorear Solicitud</h6></a>
                </li>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <li class="nav-item">
                    <a href="Admin-Solicitudes/visualizarQSF.aspx" class="nav-link"><h6 style="color:white;">Administración</h6></a>
                </li>
                <li class="nav-item">
                    <a href="Admin-Solicitudes/GenerarReportes.aspx" class="nav-link"><h6 style="color:white;">Generar Reportes</h6></a>
                </li>
            </ul>
        </div>
    </nav>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <div class="col-12">
        <h5>
            Con el propósito de mejorar la calidad del Servicio Educativo del ITSUR, se pone a su disposición a los alumnos(as)
            y partes interesadas este formato, se considerarán solamente aquellas Quejas, Sugerencias y/o Felicitaciones que tengan
            impacto al Servicio Educativo que ofrece el ITSUR y será válida si presenta los siguinetes datos:
        </h5>
        <div class="row">
          <form class="mt-5 col-12" runat="server">
            <div class="col-12"> 
                    <div class="input-group col-12">
                        <p>*&nbsp;Nombre&nbsp;&nbsp;&nbsp;</p>
                        <asp:TextBox ID="txtnombre" class="form-control" placeholder="Nombre del alumno" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;
                        <p>Teléfono&nbsp;&nbsp;&nbsp;</p>
                        <asp:TextBox ID="txttelefono" class="form-control" placeholder="Teléfono del alumno" runat="server"></asp:TextBox>       
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>Correo electronico&nbsp;&nbsp;&nbsp;</p>
                        <asp:TextBox ID="txtcorreo" class="form-control" placeholder="Correo electronico del alumno" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <p>Tipo de Servicio: &nbsp;&nbsp;&nbsp;</p>
                        <asp:RadioButtonList ID="rblista" runat="server" CellSpacing = "10"  RepeatDirection="Horizontal">
                            <asp:ListItem Text="Queja" Value="1" ></asp:ListItem>
                            <asp:ListItem Text="Sugerencia" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Felicitación" Value="3"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <br />
                    <div class="input-group col-12">
                        <p>*&nbsp;Alumno:&nbsp;&nbsp;&nbsp;</p>
                        <asp:RadioButtonList ID="rblista2" runat="server" RepeatDirection="Horizontal" CellSpacing="10">
                            <asp:ListItem Text="Si" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="2"></asp:ListItem>
                        </asp:RadioButtonList>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <p>No.Control&nbsp;&nbsp;&nbsp;</p>
                        <asp:TextBox ID="txtnocontrol" class="form-control" placeholder="No.Control del alumno" runat="server"></asp:TextBox> 
                    </div>                  
            </div>
            <br />
            <br />
            <div class="input-group col-12">
                <asp:TextBox ID="txtdescripcion" class="form-control" placeholder="* Descripción de la problematica" runat="server" TextMode="MultiLine" Height="120px" Width="404px"></asp:TextBox>
            </div>
            <br>
            <center>
                <div class="col-md-3 col-sm-3 col-xs-3 pad-adjust">
                    <asp:Button ID="btnregistrar" class="btn btn-block" runat="server" style="background-color:lightblue" Text="Generar Registro" OnClick="btnregistrar_Click" />
                </div>
            </center>
            </form>
        </div>
    </div>
    <br />
</body>
</html>

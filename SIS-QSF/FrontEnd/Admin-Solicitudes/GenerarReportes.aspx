<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerarReportes.aspx.cs" Inherits="FrontEnd.Admin_Solicitudes.GenerarReportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.8.1/css/all.css" integrity="sha384-50oBUHEmvpQ+1lW4y57PTFmhCaXp0ML5d60M1M7uH2+nqUivzIebhndOJK28anvf" crossorigin="anonymous">
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" integrity="sha384-JcKb8q3iqJ61gNV9KGb8thSsNjpSL0n8PARn9HuZOnIxN0hoP+VmmDGMN5t9UJ0Z" crossorigin="anonymous">
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.22/css/dataTables.bootstrap4.min.css">
    <title></title>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {

        var data = google.visualization.arrayToDataTable(<%=TiposdeSolicitud()%>);

        var options = {
            title: 'Reporte',
            is3D: true
        };

          var chart = new google.visualization.PieChart(document.getElementById('piechart_3d'));

        chart.draw(data, options);
      }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable(<%=TiposdeSolicitud()%>);

            var options = {
                title: 'Reportes por puntos',
                curveType: 'function',
                legend: { position: 'bottom' }
            };
            var chart = new google.visualization.LineChart(document.getElementById('curve_chart'));

            chart.draw(data, options);
        }
    </script>
</head>
<body>
    <form id="form3" runat="server">
    <!--NavBar-->
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark" >
        <a class="navbar-brand" href="#"><h1><img style="width:6em" src="../Imagenes/sisqsf.png"/></h1></a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
        <ul class="navbar-nav mr-auto">
            <li class="nav-item">
            <a class="nav-link" href="visualizarQSF.aspx">Administrar solicitudes</a>
            </li>
            <li class="nav-item">
            <a class="nav-link active" href="GenerarReportes.aspx">Reportes</a>
            </li>
            
        </ul>
        <ul class="navbar-nav form-inline my-lg-0 nav-item">

            <asp:Button ID="Button1" runat="server"  Text="Cerrar Sesion" class="btn btn-outline-danger" OnClick="Button1_Click"/>
        &nbsp;</ul>
        </div>
    </nav>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-md-4 justify-content-md-center">
                <div class="card" style="width: 18rem;">
                  <div class="card-header text-center">
                    Opciones para realizar filtrado de reportes
                  </div>
                  <ul class="list-group list-group-flush">
                      <li class="list-group-item">
                        <h5 class="card-title">Por servicio</h5>
                        <hr />
                                <form>
                                      <div class="form-group">
                                        <label for="cboServicios">Selecciona un servicio</label><br />
                                        <select class="form-control btn btn-secondary dropdown-toggle"  id="cboServicios">
                                          <option>Queja</option>
                                          <option>Sugerencia</option>
                                          <option>Felicitacion</option>
                                        </select>
                                      </div>
                                </form>
                    </li>
                    <li class="list-group-item">
                        <h5 class="card-title">Por departamento</h5>
                        <hr />
                            
                              <label for="DropDownList1">Selecciona un departamento:</label><br />
                              <asp:DropDownList 
                                  ID="DropDownList1" class="btn btn-secondary dropdown-toggle" runat="server" AutoPostBack="True" 
                                  OnSelectedIndexChanged="CambioSeleccion" data-toggle="dropdown" aria-haspopup="true" 
                                  aria-expanded="false">
                                        <asp:ListItem>Academico</asp:ListItem>
                                         <asp:ListItem>Vinculacion</asp:ListItem>
                                         <asp:ListItem>Planeacion</asp:ListItem>
                                         <asp:ListItem>Calidad</asp:ListItem>
                                         <asp:ListItem>Administracion</asp:ListItem>
                              </asp:DropDownList>
                            
                    </li>
                    <li class="list-group-item">
                        <h5 class="card-title">Por fecha</h5>
                        <hr />
                        <form id="form2">
                            <label for="dtInicio">Fecha de inicio:</label><br />
                            <input type="date" id="dtInicio" name="trip-start"
                                   value="2018-07-22" class="btn btn-secondary dropdown-toggle" /><br /><br />
                            <label for="dtFin">Fecha de fin:</label><br />
                                <input type="date" id="dtFin" name="trip-start"
                                       value="2018-07-22" class="btn btn-secondary dropdown-toggle"/>
                       </form>
                    </li>
                  </ul>
                </div>
            </div>
            <div class="col-md-8 justify-content-md-center">
                <div class="card">
                    <div class="card-header text-center">
                            Visualizar de manera grafica la cantidad de solicitudes generadas por los usuarios
                      </div>
                    <div class="card-body">
                        <div id="piechart_3d" style="width: 100%;"></div>
                        <br />
                        <div id="curve_chart" style="width: 100%;"></div>
                     </div>
                 </div>
            </div>
          </div>
    </div>
    <br />
    <br />
    <script src="../jss/bootstrap.js"></script>
    <script src="../jss/jquery-3.4.1.js"></script>
    <script src="../jss/datatables.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js" integrity="sha384-B4gt1jrGC7Jh4AgTPSdUtOBvfO8shuf57BaghqFfPlYxofvL8/KUEfYiJOMMV+rV" crossorigin="anonymous"></script>
    <script src="https://cdn.datatables.net/1.10.22/js/dataTables.bootstrap4.min.js"></script>

</form>
</body>
</html>

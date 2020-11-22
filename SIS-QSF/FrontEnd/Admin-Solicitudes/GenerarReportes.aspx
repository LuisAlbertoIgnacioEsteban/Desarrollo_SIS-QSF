<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerarReportes.aspx.cs" Inherits="FrontEnd.Admin_Solicitudes.GenerarReportes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {

        var data = google.visualization.arrayToDataTable(<%=TiposdeSolicitud()%>);

        var options = {
          title: 'Reporte'
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
      }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
     

  <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CambioSeleccion">
            <asp:ListItem>Academico</asp:ListItem>
             <asp:ListItem>Vinculacion</asp:ListItem>
             <asp:ListItem>Planeacion</asp:ListItem>
             <asp:ListItem>Calidad</asp:ListItem>
             <asp:ListItem>Administracion</asp:ListItem>
        </asp:DropDownList>
</form>
    <div id="piechart" style="width: 900px; height: 500px;"></div>
</body>
</html>

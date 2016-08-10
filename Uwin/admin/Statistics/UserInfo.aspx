<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="Uwin.admin.Statistics.UserInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<script type="text/javascript" src="../js/jQuery.js"></script>
<script type="text/javascript" src="../js/jqplot.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
       
        var data = [[<%=MemeberNum%>]];
        var data_max = 30; 
        var line_title = ["注册用户数量"];
        var y_label = "注册用户数量"; 
        var x_label = "时间"; 
        var x = [<%=RowsDay%>]; 
        var title = "最近20天每日注册用户数量统计"; 
        j.jqplot.diagram.base("chart1", data, line_title, "最近20天每日注册用户数量统计", x, x_label, y_label, data_max, 1);
      
    });
</script>
   
</head>
<body>
    <form id="form1" runat="server">
   <table width="100%" border="0">
  <tr>
    <td colspan="5"><div id="chart1"></div></td>
  </tr>
  <tr>
    <td  height="20px;" colspan="5">&nbsp;</td>
  </tr>
  <tr >
  	<td width="10%">&nbsp;</td>
    
    
    <td colspan="3">
        <div  style="width:500px; height:300px; font-family:微软雅黑; font-size:16px;">
            
    </div></td>
	<td width="10%">&nbsp;</td>
  </tr>
</table>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsInfo.aspx.cs" Inherits="Uwin.admin.Statistics.ItemsInfo" %>

<!DOCTYPE html>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script type="text/javascript" src="../js/jQuery.js"></script>
<script type="text/javascript" src="../js/jqplot.js"></script>
<script type="text/javascript">
    $(document).ready(function () {
       
        var data = [[<%=ItemsNum%>], [<%=ItemsTriNum%>], [<%=ItemsSecNum%>]];
        var data_max = 30; 
        var line_title = ["普通商品", "试用商品","秒杀商品"];
        var y_label = "新增商品数目"; 
        var x_label = "时间"; 
        var x = [<%=RowsDay%>]; 
        var title = "最近20天每日新增商品统计"; 
        j.jqplot.diagram.base("chart1", data, line_title, "最近20天每日新增商品统计", x, x_label, y_label, data_max, 1);
      
    });
</script>
   <script>
        
       function drawCircle(canvasId, data_arr, color_arr, text_arr) {
           var c = document.getElementById(canvasId);
           var ctx = c.getContext("2d");

           var radius = c.height / 2 - 20; 
           var ox = radius + 20, oy = radius + 20;   

           var width = 30, height = 10; 
           var posX = ox * 2 + 20, posY = 30;    
           var textX = posX + width + 5, textY = posY + 10;

           var startAngle = 0;   
           var endAngle = 0;  
           for (var i = 0; i < data_arr.length; i++) {
             
               endAngle = endAngle + data_arr[i] * Math.PI * 2;   
               ctx.fillStyle = color_arr[i];
               ctx.beginPath();
               ctx.moveTo(ox, oy);  
               ctx.arc(ox, oy, radius, startAngle, endAngle, false);
               ctx.closePath();
               ctx.fill();
               startAngle = endAngle; 

               
               ctx.fillStyle = color_arr[i];
               ctx.fillRect(posX, posY + 20 * i, width, height);
               ctx.moveTo(posX, posY + 20 * i);
               ctx.font = 'bold 12px 微软雅黑';     
               ctx.fillStyle = color_arr[i];  
               var percent = text_arr[i] + "：" + 100 * data_arr[i] + "%";
               ctx.fillText(percent, textX, textY + 20 * i);
           }
       }

       function init() {
           var totle= <%=ItemsCount %> ;
           var itemco =<%=ItemsCount%> - <%=ItemsTriCount%>-<%=ItemsSecCount%>;
           var itemper = (itemco / totle).toFixed(3);
           var itemTri=<%=ItemsTriCount %> ;
           var itemSec=<%=ItemsSecCount %> ;
           var itemtriper = (itemTri / totle).toFixed(3);
           var itemsecper = (itemSec / totle).toFixed(3);
           var data_arr = [itemper, itemtriper, itemsecper];
           var color_arr = [ "#5FAB78", "#EAA228", "#C5B47F"];
           var text_arr = [ "普通商品", "试用商品", "秒杀产品"];

           drawCircle("canvas_circle", data_arr, color_arr, text_arr);
       }

       window.onload = init;
        </script>  
</head>
<body>
    <table width="100%" border="0">
  <tr>
    <td colspan="5"><div id="chart1"></div></td>
  </tr>
  <tr>
    <td  height="20px;" colspan="5">&nbsp;</td>
  </tr>
  <tr >
  	<td width="10%">&nbsp;</td>
    <td width="35%" height="300px;"><p>  
            <canvas id="canvas_circle" width="500" height="300" >  
                浏览器不支持canvas  
            </canvas>  
        </p> </td>
    <td width="10%">&nbsp;</td>
    <td width="35%">
        <div  style="width:500px; height:300px; font-family:微软雅黑; font-size:16px;">
            <br /><br />
       总共统计商品数量：<%=ItemsCount %>件
            <br /><br />
            其中：<br /><br />
            &nbsp;&nbsp;&nbsp;普通商品数量：<%=ItemsCommCount%>件
            <br /><br />
            &nbsp;&nbsp;&nbsp;试用商品数量：<%=ItemsTriCount%>件
            <br /><br />
            &nbsp;&nbsp;&nbsp;秒杀商品数量：<%=ItemsSecCount%>件
            <br />
    </div></td>
	<td width="10%">&nbsp;</td>
  </tr>
</table>
   
    

    
</body>
</html>

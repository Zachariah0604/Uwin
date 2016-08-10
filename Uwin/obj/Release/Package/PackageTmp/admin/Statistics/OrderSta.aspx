<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderSta.aspx.cs" Inherits="Uwin.admin.Statistics.OrderSta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .wrap{width:100%;max-width:720px;margin:0 auto}
        .wrap .col4{width:33%;float:left;box-sizing:border-box}
        .wrap svg{width:33%;float:left}
        .clearfix:after{content:"";clear:both;display:block;overflow:none;height:0}
        .clearfix{zoom:1}
    </style>
<script type="text/javascript" src="../js/jQuery.js"></script>
<script type="text/javascript" src="../js/jqplot.js"></script>
<script type="text/javascript">
    $(document).ready(function () {

        var data = [[<%=OrdersNum%>], [<%=OrderTriNum%>]];
        var data_max = 30;
        var line_title = ["普通订单", "试用订单"];
        var y_label = "新增订单数目";
        var x_label = "时间";
        var x = [<%=RowsDay%>];
        var title = "最近20天每日新增订单统计";
        j.jqplot.diagram.base("chart1", data, line_title, "最近20天每日新增订单统计", x, x_label, y_label, data_max, 1);

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
            var totle1= <%=PaidCount%>+<%=NotPaidCount%> ;
          
           var paid=<%=PaidCount%>;
            var notpaid=<%=NotPaidCount%>;
           var paidper = (paid / totle1).toFixed(3);
           var notpaidper = (notpaid / totle1).toFixed(3);
           var data_arr = [paidper, notpaidper];
           var color_arr = [ "#5FAB78",  "#C5B47F"];
           var text_arr = [ "已支付(<%=PaidCount%>)",  "未支付(<%=NotPaidCount%>)"];

           drawCircle("canvas_circle1", data_arr, color_arr, text_arr);


           var totle2 = <%=DeliveredCount%>+<%=NotDeliverCount%>;

           var delivered = <%=DeliveredCount%>;
            var notdeliver = <%=NotDeliverCount%>;
           var deliveredper = (delivered / totle2).toFixed(3);
           var notdeliverper = (notdeliver / totle2).toFixed(3);
           var data_arr = [deliveredper, notdeliverper];
           var color_arr = ["#5FAB78", "#EAA228"];
           var text_arr = ["已发货(<%=DeliveredCount%>)", "备货中(<%=NotDeliverCount%>)"];

           drawCircle("canvas_circle2", data_arr, color_arr, text_arr);


           var totle3 = <%=ApplyForRefundCount%>+<%=AcceptForRefundCount%>+<%=BeRefundCount%>;

           var applyforrefund = <%=ApplyForRefundCount%>;
            var acceptforrefund = <%=AcceptForRefundCount%>;
            var berefund = <%=BeRefundCount%>;
           var applyforrefundper = (applyforrefund / totle3).toFixed(3);
           var acceptforrefundper = (acceptforrefund / totle3).toFixed(3);
           var berefundper = (berefund / totle3).toFixed(3);
           var data_arr = [applyforrefundper, acceptforrefundper, berefundper];
           var color_arr = ["#EAA228", "#C5B47F", "#5FAB78"];
           var text_arr = ["申请退款(<%=ApplyForRefundCount%>)", "退款受理(<%=AcceptForRefundCount%>)", "已退款(<%=BeRefundCount%>)"];

           drawCircle("canvas_circle3", data_arr, color_arr, text_arr);
        }

        

        window.onload = init;
       
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
         <tr><td height="50px;"></td></tr>
  <tr >
  	<td width="5%">&nbsp;</td>
    <td width="30%" height="300px;">
        <canvas id="canvas_circle1" width="500px" height="300" >  
                浏览器不支持canvas  
            </canvas>  
    </td>
    <td width="30%">
        <canvas id="canvas_circle2" width="500px" height="300" >  
                浏览器不支持canvas  
            </canvas>  
    </td>
    <td width="30%">
         <canvas id="canvas_circle3" width="500px" height="300" >  
                浏览器不支持canvas  
            </canvas>

    </td>
	<td width="5%">&nbsp;</td>
  </tr>
</table>
        
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerchantInfo.aspx.cs" Inherits="Uwin.admin.Statistics.MerchantInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<style>

body {
  background: #fff;
  color: #333;
  font-family: "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
  font-size: 0.9em;
  padding: 40px;
}

.wideBox {
  clear: both;
  text-align: center;
  margin-bottom: 50px;
  padding: 10px;
  background: #ebedf2;
  border: 1px solid #333;
  line-height: 80%;
}

#container {
  width: 900px;
  margin: 0 auto;
}

#chart, #chartData {
 
}

#chart {
  display: block;
  margin: 0 0 50px 0;
  float: left;
  cursor: pointer;
}

#chartData {
  width: 200px;
  margin: 0 40px 0 0;
  float: right;
  border-collapse: collapse;
  box-shadow: 0 0 1em rgba(0, 0, 0, 0.5);
  -moz-box-shadow: 0 0 1em rgba(0, 0, 0, 0.5);
  -webkit-box-shadow: 0 0 1em rgba(0, 0, 0, 0.5);
  background-position: 0 -100px;
}

#chartData th, #chartData td {
  padding: 0.5em;
  border: 1px dotted #666;
  text-align: left;
}

#chartData th {
  border-bottom: 2px solid #333;
  text-transform: uppercase;
}

#chartData td {
  cursor: pointer;
}

#chartData td.highlight {
  background: #e8e8e8;
}

#chartData tr:hover td {
  background: #f0f0f0;
}

</style>

<script src="../js/jquery.min.js"></script>

<script>

    $(pieChart);

    function pieChart() {

        var chartSizePercent = 55;                        
        var sliceBorderWidth = 1;                        
        var sliceBorderStyle = "#fff";                   
        var sliceGradientColour = "#ddd";                
        var maxPullOutDistance = 25;                     
        var pullOutFrameStep = 4;                         
        var pullOutFrameInterval = 40;                    
        var pullOutLabelPadding = 65;                    
        var pullOutLabelFont = "bold 16px 'Trebuchet MS', Verdana, sans-serif";  
        var pullOutValueFont = "bold 12px 'Trebuchet MS', Verdana, sans-serif"; 
        var pullOutValuePrefix = "";                    
        var pullOutShadowColour = "rgba( 0, 0, 0, .5 )";  
        var pullOutShadowOffsetX = 5;                     
        var pullOutShadowOffsetY = 5;                     
        var pullOutShadowBlur = 5;                       
        var pullOutBorderWidth = 2;                   
        var pullOutBorderStyle = "#333";                
        var chartStartAngle = -.5 * Math.PI;             

        var canvas;                       
        var currentPullOutSlice = -1;     
        var currentPullOutDistance = 0;   
        var animationId = 0;             
        var chartData = [];              
        var chartColours = [];           
        var totalValue = 0;             
        var canvasWidth;               
        var canvasHeight;               
        var centreX;                      
        var centreY;                      
        var chartRadius;                 

        init();

        function init() {

            canvas = document.getElementById('chart');

            if (typeof canvas.getContext === 'undefined') return;

            canvasWidth = canvas.width;
            canvasHeight = canvas.height;
            centreX = canvasWidth / 2;
            centreY = canvasHeight / 2;
            chartRadius = Math.min(canvasWidth, canvasHeight) / 2 * (chartSizePercent / 100);

            var currentRow = -1;
            var currentCell = 0;

            $('#chartData td').each(function () {
                currentCell++;
                if (currentCell % 2 != 0) {
                    currentRow++;
                    chartData[currentRow] = [];
                    chartData[currentRow]['label'] = $(this).text();
                } else {
                    var value = parseFloat($(this).text());
                    totalValue += value;
                    value = value.toFixed(2);
                    chartData[currentRow]['value'] = value;
                }

              
                $(this).data('slice', currentRow);
                $(this).click(handleTableClick);

                
                if (rgb = $(this).css('color').match(/rgb\((\d+), (\d+), (\d+)/)) {
                    chartColours[currentRow] = [rgb[1], rgb[2], rgb[3]];
                } else if (hex = $(this).css('color').match(/#([a-fA-F0-9]{2})([a-fA-F0-9]{2})([a-fA-F0-9]{2})/)) {
                    chartColours[currentRow] = [parseInt(hex[1], 16), parseInt(hex[2], 16), parseInt(hex[3], 16)];
                } else {
                    alert("Error: Colour could not be determined! Please specify table colours using the format '#xxxxxx'");
                    return;
                }

            });


            var currentPos = 0; 

            for (var slice in chartData) {
                chartData[slice]['startAngle'] = 2 * Math.PI * currentPos;
                chartData[slice]['endAngle'] = 2 * Math.PI * (currentPos + (chartData[slice]['value'] / totalValue));
                currentPos += chartData[slice]['value'] / totalValue;
            }

            drawChart();
            $('#chart').click(handleChartClick);
        }


        function handleChartClick(clickEvent) {

            var mouseX = clickEvent.pageX - this.offsetLeft;
            var mouseY = clickEvent.pageY - this.offsetTop;

            var xFromCentre = mouseX - centreX;
            var yFromCentre = mouseY - centreY;
            var distanceFromCentre = Math.sqrt(Math.pow(Math.abs(xFromCentre), 2) + Math.pow(Math.abs(yFromCentre), 2));

            if (distanceFromCentre <= chartRadius) {


                var clickAngle = Math.atan2(yFromCentre, xFromCentre) - chartStartAngle;
                if (clickAngle < 0) clickAngle = 2 * Math.PI + clickAngle;

                for (var slice in chartData) {
                    if (clickAngle >= chartData[slice]['startAngle'] && clickAngle <= chartData[slice]['endAngle']) {

                        toggleSlice(slice);
                        return;
                    }
                }
            }

            pushIn();
        }



        function handleTableClick(clickEvent) {
            var slice = $(this).data('slice');
            toggleSlice(slice);
        }

        function toggleSlice(slice) {
            if (slice == currentPullOutSlice) {
                pushIn();
            } else {
                startPullOut(slice);
            }
        }



        function startPullOut(slice) {

            if (currentPullOutSlice == slice) return;

            currentPullOutSlice = slice;
            currentPullOutDistance = 0;
            clearInterval(animationId);
            animationId = setInterval(function () { animatePullOut(slice); }, pullOutFrameInterval);

            $('#chartData td').removeClass('highlight');
            var labelCell = $('#chartData td:eq(' + (slice * 2) + ')');
            var valueCell = $('#chartData td:eq(' + (slice * 2 + 1) + ')');
            labelCell.addClass('highlight');
            valueCell.addClass('highlight');
        }


        function animatePullOut(slice) {

            currentPullOutDistance += pullOutFrameStep;

            if (currentPullOutDistance >= maxPullOutDistance) {
                clearInterval(animationId);
                return;
            }

            drawChart();
        }


        function pushIn() {
            currentPullOutSlice = -1;
            currentPullOutDistance = 0;
            clearInterval(animationId);
            drawChart();
            $('#chartData td').removeClass('highlight');
        }


        function drawChart() {

            var context = canvas.getContext('2d');

            context.clearRect(0, 0, canvasWidth, canvasHeight);

            for (var slice in chartData) {
                if (slice != currentPullOutSlice) drawSlice(context, slice);
            }

            if (currentPullOutSlice != -1) drawSlice(context, currentPullOutSlice);
        }


        function drawSlice(context, slice) {

            var startAngle = chartData[slice]['startAngle'] + chartStartAngle;
            var endAngle = chartData[slice]['endAngle'] + chartStartAngle;

            if (slice == currentPullOutSlice) {


                var midAngle = (startAngle + endAngle) / 2;
                var actualPullOutDistance = currentPullOutDistance * easeOut(currentPullOutDistance / maxPullOutDistance, .8);
                startX = centreX + Math.cos(midAngle) * actualPullOutDistance;
                startY = centreY + Math.sin(midAngle) * actualPullOutDistance;
                context.fillStyle = 'rgb(' + chartColours[slice].join(',') + ')';
                context.textAlign = "center";
                context.font = pullOutLabelFont;
                context.fillText(chartData[slice]['label'], centreX + Math.cos(midAngle) * (chartRadius + maxPullOutDistance + pullOutLabelPadding), centreY + Math.sin(midAngle) * (chartRadius + maxPullOutDistance + pullOutLabelPadding));
                context.font = pullOutValueFont;
                context.fillText(pullOutValuePrefix + chartData[slice]['value'] + " (" + (parseInt(chartData[slice]['value'] / totalValue * 100 + .5)) + "%)", centreX + Math.cos(midAngle) * (chartRadius + maxPullOutDistance + pullOutLabelPadding), centreY + Math.sin(midAngle) * (chartRadius + maxPullOutDistance + pullOutLabelPadding) + 20);
                context.shadowOffsetX = pullOutShadowOffsetX;
                context.shadowOffsetY = pullOutShadowOffsetY;
                context.shadowBlur = pullOutShadowBlur;

            } else {

                startX = centreX;
                startY = centreY;
            }

            var sliceGradient = context.createLinearGradient(0, 0, canvasWidth * .75, canvasHeight * .75);
            sliceGradient.addColorStop(0, sliceGradientColour);
            sliceGradient.addColorStop(1, 'rgb(' + chartColours[slice].join(',') + ')');

            context.beginPath();
            context.moveTo(startX, startY);
            context.arc(startX, startY, chartRadius, startAngle, endAngle, false);
            context.lineTo(startX, startY);
            context.closePath();
            context.fillStyle = sliceGradient;
            context.shadowColor = (slice == currentPullOutSlice) ? pullOutShadowColour : "rgba( 0, 0, 0, 0 )";
            context.fill();
            context.shadowColor = "rgba( 0, 0, 0, 0 )";

            if (slice == currentPullOutSlice) {
                context.lineWidth = pullOutBorderWidth;
                context.strokeStyle = pullOutBorderStyle;
            } else {
                context.lineWidth = sliceBorderWidth;
                context.strokeStyle = sliceBorderStyle;
            }

            context.stroke();
        }


        function easeOut(ratio, power) {
            return (Math.pow(1 - ratio, power) + 1);
        }

    };

</script>
</head>
<body>
    <form id="form1" runat="server">
   
<div id="container">

  <canvas id="chart" width="600" height="500"></canvas>
    
  <table id="chartData">

    <tr>
      <th>分站地区</th><th>商户数量</th>
     </tr>
      <asp:Repeater ID="Repeater1" runat="server"><ItemTemplate>
    <tr  id="Station<%#Eval("Dates") %>">

      <td><%#StationName(Eval("Dates").ToString()) %></td><td><%#Eval("total") %></td>
    </tr>

          </ItemTemplate></asp:Repeater>
  </table>

    <script type="text/javascript">
        
      

            var tr = document.getElementsByTagName("tr");


            for (var i = 0; i < tr.length; i++) {
                var str = "0123456789abcdef";
                var t = "#";
                for (j = 0; j < 6; j++)
                { t = t + str.charAt(Math.random() * str.length); }

                tr[i].style.color = t;
            }

       
    </script>
</div>
    </form>
</body>
</html>


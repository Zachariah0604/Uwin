<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="Uwin.admin.admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta charset="utf-8" />

	<link href="css/bootstrap.min.css" rel="stylesheet" media="screen" />
	<link href="css/font-awesome.min.css" rel="stylesheet" media="screen" />
	<link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.circliful.css" rel="stylesheet" type="text/css" />

<script type="text/javascript" src="js/jquery-1.10.2.min.js"></script>
<script type="text/javascript" src="js/jquery.circliful.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
		<div class="pad20">

			<div class="stats-cont row mart20">
				<div class="col-sm-3 ">
					<div class="stats-panel stats-blue clear">
						<div class="left"><img src="images/stats1.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>订单总数</p>
							<p class="stats-num"><a href="#"><asp:Label ID="OrderCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="Orders/OrderManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-red clear">
						<div class="left"><img src="images/stats2.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>注册用户</p>
							<p class="stats-num"><a href="#"><asp:Label ID="UserCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="Users/MemberManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-green clear">
						<div class="left"><img src="images/stats3.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>商品总数</p>
							<p class="stats-num"><a href="#"><asp:Label ID="ItemsCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="Items/ItemsManage.aspx" target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
				<div class="col-sm-3 ">
					<div class="stats-panel stats-purple clear">
						<div class="left"><img src="images/stats4.png" height="104" width="83" alt=""></div>
						<div class="auto stats-txt">
							<p>文章数量</p>
							<p class="stats-num"><a href="#"><asp:Label ID="ArticleCount" runat="server" Text="Label"></asp:Label></a></p>
						</div>
						<a href="ArticleManage/ActicleList.aspx"  target="menuFrame" class="more clear"><span class="left">More</span> <i class="right fa fa-angle-right"></i></a>
					</div>
				</div>
			</div>

			<div class="chart mart20">
				<div class="tit1 clear">
					<span class="left txt-left txt-red"><i class="fa fa-share-alt"></i>订单统计</span>
					<div class="right chart-tit-date">
						
					</div>
				</div>

				<div class="padt10">
					<div class="chart-tag"><a href="#" class="active">日成交量</a><a href="#">月成交量</a></div>
					<div class="chart-box padt10">
						<div id="chart-container" class="chart-container"></div>
					</div>
				</div>
			</div>

			<div class="sales-list row mart20">
				<div class="col-sm-9">
					<div class="pad20 bgf">
						<div class="tit1 clear">
							<span class="left txt-left txt-blue"><i class="ico i-rank"></i>最新添加</span>
							<div class="right ">
								
							</div>
						</div>
						<div class="tab">
						
							<ul class="nav nav-tabs sale-tabs" role="tablist">
								<li class="active"><a href="#tab1"  role="tab" data-toggle="tab">最新商品</a></li>
                                
								<li><a href="#tab2"  role="tab" data-toggle="tab">最新用户</a></li>
								<li><a href="#tab3"  role="tab" data-toggle="tab">最新商户</a></li>
								<li><a href="#tab4"  role="tab" data-toggle="tab">最新文章</a></li>
								
							</ul>

						
							<div class="tab-content">
								
                                <div role="tabpanel" class="tab-pane active" id="tab1">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="ItemsRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">商品ID</td>
												<td width="30%">商品名称</td>
												<td width="15%">销售价</td>
												<td width="15%">库存量</td>
												<td width="20%">销量</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate><ItemTemplate>
											<tr>
												<td><%#Eval("itemsID")%></td>
												<td><%#Eval("itemName") %></td>
												<td><%#Eval("itemSalePrice") %></td>
												<td><%#Eval("itemStock") %></td>
												<td><%#Eval("itemSaleNum") %></td>
												<td><a href="#">查看详情</a></td>
											</tr>
                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>

							
								<div role="tabpanel" class="tab-pane" id="tab2">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                                            <asp:Repeater runat="server" ID="UserRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">用户ID</td>
												<td width="30%">用户名</td>
												<td width="25%">用户昵称</td>
												<td width="25%">电子邮件</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate>
                                                                <ItemTemplate>
											<tr>
												<td><%#Eval("userID")%></td>
												<td><%#Eval("userName") %></td>
												<td><%#Eval("nickName") %></td>
												<td><%#Eval("userEmail") %></td>
												<td><a href="#">查看详情</a></td>
											</tr>
                                                                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>
							
								<div role="tabpanel" class="tab-pane" id="tab3">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="MerchantRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">商户ID</td>
												<td width="30%">商户名称</td>
												<td width="25%">所属分站</td>
												<td width="25%">商户地址</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate><ItemTemplate>
											<tr>
												<td><%#Eval("MerchantID")%></td>
												<td><%#Eval("MerchantName") %></td>
												<td><%#Eval("AffliStation") %></td>
												<td><%#Eval("MerchantAddress") %></td>
												<td><a href="#">查看详情</a></td>
											</tr>
                    </ItemTemplate></asp:Repeater>
											
										</table>
									</div>
								</div>
							
								

                                <div role="tabpanel" class="tab-pane" id="tab4">
									<div class="table-responsive mart20 sale-table">
										<table class="table table-bordered table-striped">
                                            <asp:Repeater runat="server" ID="ArticleRepeter">
            <HeaderTemplate>
											<tr>
												<td width="10%">文章ID</td>
												<td width="30%">文章标题</td>
												<td width="15%">所属分类</td>
												<td width="15%">作者</td>
												<td width="20%">点击数</td>
												<td>操作</td>
											</tr>
                </HeaderTemplate>
                                                <ItemTemplate>
											<tr>
												<td><%#Eval("NewsId") %></td>
												<td><a href="#"><%#Eval("Title") %></a></td>
												<td><%#Eval("TypeId") %></td>
												<td><%#Eval("Author") %></td>
												<td><%#Eval("Click") %></td>
												<td><a href="#">查看详情</a></td>
											</tr>
                                                     </ItemTemplate>
            </asp:Repeater>
											
										</table>
									</div>
								</div>

								
							</div>
						</div>
					</div>
				</div>
				<div class="col-sm-3">
					<div class="pad20 bgf">
						<div class="tit1 clear">
							<span class="left txt-left txt-blue"><i class="ico i-rank"></i>系统状态</span>
						</div>
						<div class="report-list ">
                            <asp:Label ID="IpAddress" runat="server" Text="Label"></asp:Label><br /><br /><br />
							<asp:Label ID="serverName" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverNet" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverSession" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            <asp:Label ID="serverIIS" runat="server" Text="Label"></asp:Label><br /><br /><br />
                            
						</div>
					</div>
				</div>
			</div>



		</div>

		
	</div>



        <script src="js/jquery-1.9.1.min.js"></script> 
	<script src="js/bootstrap.min.js"></script> 
	<script src="js/highcharts.js"></script> 
	<script src="js/admin.js"></script>
	<script type="text/javascript">
	    $(function () {
	        $('#chart-container').highcharts({
	            chart: {
	                type: 'area',
	                spacingBottom: 30
	            },
	            title: {
	                text: ''
	            },
	            subtitle: {
	                text: '',
	                floating: true,
	                align: 'right',
	                verticalAlign: 'bottom',
	                y: 15
	            },
	            legend: {
	                layout: 'vertical',
	                align: 'left',
	                verticalAlign: 'top',
	                x: 150,
	                y: 100,
	                floating: true,
	                borderWidth: 1,
	                backgroundColor: '#FFFFFF'
	            },
	            xAxis: {
	                categories: [<%=RowsDay%>]
	            },
	            yAxis: {
	                title: {
	                    text: '下单数'
	                },
	                labels: {
	                    formatter: function () {
	                        return this.value;
	                    }
	                }
	            },
	            tooltip: {
	                formatter: function () {
	                    return '<b>' + this.series.name + '</b><br/>' +
                        this.x + ': ' + this.y;
	                }
	            },
	            plotOptions: {
	                area: {
	                    fillOpacity: 0.5
	                }
	            },
	            credits: {
	                enabled: false
	            },
	            series: [{
	                name: '数量',
	                data: [<%=OrdersNum%>]
	            }]
	        });
	    });
</script>
    </form>
</body>
</html>

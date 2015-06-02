<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Distributed Store</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="App_WebResources/bootstrap.min.css" rel="stylesheet" />

    <style>
        .navbar 
        {
            box-shadow: 0px 2px 2px #2196F3;
        }

        .well 
        {
            padding-bottom: 0px;
        }

        .btn 
        {
            margin-top: 10px;
        }

        .status-label 
        {
            display: block;
            font-weight: bold;
        }

        #orderList th:nth-child(5),
        #orderList td:nth-child(5),
        #orderList th:nth-child(6),
        #orderList td:nth-child(6),
        #orderList th:nth-child(7),
        #orderList td:nth-child(7),
        #orderList th:nth-child(9),
        #orderList td:nth-child(9),
        #orderList th:nth-child(10),
        #orderList td:nth-child(10) 
        {
            display: none;
        }
    </style>
</head>

<body>
    <!-- navbar -->
    <div class="navbar navbar-default navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <a href="../index.aspx" class="navbar-brand">TDIN 14/15</a>
                <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
            </div>
            <div class="navbar-collapse collapse" id="navbar-main">
                <ul class="nav navbar-nav">
                    <li>
                        <a href="#">About</a>
                    </li>
                    <li>
                        <a href="#">Help</a>
                    </li>
                </ul>
                <ul class="nav navbar-nav navbar-right">
                    <li><a href="#" target="_blank">Built by Hugo Cardoso and Vasco Gomes</a></li>
                </ul>
            </div>
        </div>
    </div>

    <!-- page container -->
    <div class="container" style="margin-top: 80px">

        <!-- page banner -->
        <div class="page-header" id="banner">
            <div class="row">
                <div class="col-lg-8 col-md-7 col-sm-6">
                    <h1>Distributed Store</h1>
                    <p class="lead">Created in C# using ASP.NET</p>
                </div>
            </div>
        </div>

        <!-- forms -->
        <form id="form1" runat="server" class="form-horizontal">
            <div class="row">

                <!-- new order -->
                <div class="col-md-8">
                    <div class="well">
                        <h4>New Order</h4>
                        <p style="font-weight: bold;">Complete all the fields, and have your order ready in a matter of seconds</p>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Book ID</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="bookId" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Quantity</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="bookQuantity" runat="server"></asp:TextBox>
                            </div>
                        </div>
                  
                        <div class="form-group">
                            <label class="col-lg-2 control-label">Name</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="clientName" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Address</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="clientAddress" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Email</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="clientEmail" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Label ID="submitOrderStatus" runat="server" CssClass="status-label"></asp:Label>
                                <asp:Button ID="submitOrderBtn" runat="server" OnClick="submitOrderBtn_Click" CssClass="btn btn-primary" Text="Submit" />
                            </div>
                        </div>

                        <div class="col-lg-12" style="margin-top: 20px">
                            <h4>Available books</h4>
                            <p style="font-weight: bold;">We have a large collection available, take a look around</p>

                            <asp:GridView ID="bookList" runat="server" CssClass="table table-bordered table-hover"></asp:GridView>
                        </div>
                    </div>
                </div>

                <!-- check order status -->
                <div class="col-md-4">
                    <div class="well">
                        <h4>Order status</h4>
                        <p style="font-weight: bold;">NEW: check where your order is and when it is expected to arrive</p>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">Email</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="orderEmail" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-lg-2 control-label">ID</label>
                            <div class="col-lg-10">
                                <asp:TextBox ID="orderId" runat="server"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-lg-10 col-lg-offset-2">
                                <asp:Label ID="checkOrderStatus" runat="server" CssClass="status-label"></asp:Label>
                                <asp:Button ID="checkOrderBtn" runat="server" OnClick="checkOrderBtn_Click" CssClass="btn btn-default" Text="Check status" />
                            </div>
                        </div>

                        <div class="col-lg-12">
                            <asp:GridView ID="orderList" runat="server" Visible="False" CssClass="table table-bordered table-hover"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </form>
    </div>
</body>
</html>

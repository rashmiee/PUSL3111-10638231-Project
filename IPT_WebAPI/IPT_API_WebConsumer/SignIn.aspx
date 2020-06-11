<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="IPT_API_WebConsumer.SignIn" %>


<html class="no-js" lang="en">
<!--<![endif]-->

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>IPT - NSBM</title>
    <meta name="description" content="Sufee Admin - HTML5 Admin Template">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <link rel="apple-touch-icon" href="apple-icon.png">
    <link rel="shortcut icon" href="favicon.ico">


    <link rel="stylesheet" href="vendors/bootstrap/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="vendors/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="vendors/themify-icons/css/themify-icons.css">
    <link rel="stylesheet" href="vendors/flag-icon-css/css/flag-icon.min.css">
    <link rel="stylesheet" href="vendors/selectFX/css/cs-skin-elastic.css">

    <link rel="stylesheet" href="assets/css/style.css">

    <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,600,700,800' rel='stylesheet' type='text/css'>



</head>

<body class="bg-dark">
    <form id="form1" runat="server">

    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <div class="login-title"> 
                        <p>IPT - NSBM</p>
                    </div>
                </div>
                <div class="login-form">
                    
                        <div class="form-group">
                            <label>Email address</label>

                            <asp:TextBox ID="email" class="form-control" runat="server"></asp:TextBox>
                        </div>
                            <div class="form-group">
                                <label>Password</label>
                             <asp:TextBox ID="pass" class="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            <label for="type">Choose your type</label>
                            

                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem Value="STD">Student</asp:ListItem>
                        <asp:ListItem Value="ITE">Expert</asp:ListItem>
                    </asp:DropDownList>
                                
                        </div>
                            <div class="checkbox">
                                <label>

                                    <input type="checkbox"> Remember Me
                                </label>
                                <label class="pull-right">
                                    <a href="#">Forgotten Password?</a>
                                </label>
                            </div>
                            <br>
<asp:Button ID="Button1" class="btn btn-success btn-flat m-b-30 m-t-30" runat="server" Text="Sign in" OnClick="Button1_Click" />
                                <div class="register-link m-t-15 text-center">
                                    <p>Don't have account ? <a href="#"> Sign Up Here</a></p>
                                </div>
                    
                </div>
            </div>
        </div>
    </div>


    <script src="vendors/jquery/dist/jquery.min.js"></script>
    <script src="vendors/popper.js/dist/umd/popper.min.js"></script>
    <script src="vendors/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="assets/js/main.js"></script>

</form>
</body>

</html>


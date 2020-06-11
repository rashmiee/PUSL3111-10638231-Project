<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentRegister.aspx.cs" Inherits="IPT_API_WebConsumer.StudentRegister" %>

<html class="no-js" lang="en">
<!--<![endif]-->

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <title>IPT - Student Register</title>
    <meta name="description" content="IPT - NSBM">
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
    <form runat="server" id="form1">

    <div class="sufee-login d-flex align-content-center flex-wrap">
        <div class="container">
            <div class="login-content">
                <div class="login-logo">
                    <p>IPT Programme NSBM - NSBM - Student Registration</p>
                </div>
                <div class="login-form">
                    
                        <div class="form-group">
                            <label>Student Full Name</label>
<asp:TextBox ID="txtStdName" class="form-control" placeholder="Student Full Name" runat="server"></asp:TextBox>
                           
                        </div>
                            <div class="form-group">
                                <label>Student ID</label>
        <asp:TextBox ID="txtStudentID" class="form-control" placeholder="Student ID" runat="server"></asp:TextBox>
                        </div>
                                <div class="form-group">
                                    <label>Username</label>
 <asp:TextBox ID="txtStudentUsername" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
                        
                        </div>
                                <div class="form-group">
                                    <label>Email</label>
<asp:TextBox ID="txtEmail" class="form-control" placeholder="Email" runat="server"></asp:TextBox>
           
                        </div>
                                
                                <div class="form-group">
                                    <label>Degree Programme</label>
<asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>BSc in Software Engineering (PLY) </asp:ListItem>
     <asp:ListItem>BSc in Computer Security (PLY) </asp:ListItem>
     <asp:ListItem> BSc (Hons) in Management Information Systems (UGC)</asp:ListItem>
     <asp:ListItem>BSc (Hons) in Software Engineering (UGC) </asp:ListItem>
     <asp:ListItem> BSc (Hons) in Computer Science (UGC)</asp:ListItem>
     <asp:ListItem>BSc (Hons) in Computer Networks (UGC) </asp:ListItem>
     <asp:ListItem>BSc in Multimedia (UGC) </asp:ListItem>
     <asp:ListItem> BSc in Computer Networks (PLY)</asp:ListItem>
</asp:DropDownList>

                        </div>
                        <div>
                            <label for="img">Select a profile photo:</label>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                            
                        </div>
                        <br>
                        <div class="form-group">
                            <label>Password</label>
                           <asp:TextBox ID="txtPassword" class="form-control" TextMode="Password" placeholder="*********" runat="server"></asp:TextBox>
                </div>
                                <br>
                          <asp:Button ID="btnPost" class="btn btn-primary btn-flat m-b-30 m-t-30" runat="server" Text="Register" OnClick="btnPost_Click" />
                                  
                                    <div class="register-link m-t-15 text-center">
                                        <p>Already have account ? <a href="page-login.html"> Sign in</a></p>
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

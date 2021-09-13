<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ShoeStore.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h3 class="text-center mb-5">Register Yourself !</h3>
         <div class="col-md-8 mx-auto">

             <div class="form-group row">
                <label class="col-sm-4 text-right">Name</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtName" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Name"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">Email</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtEmail" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Email"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">Contact</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtContact" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Contact"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">User Name</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtUserName" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Username"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">Password</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtPassword" TextMode="Password" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">Confirm Password</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtConfirmPassword" TextMode="Password" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Confirm your Password"></asp:TextBox>
                </div>
            </div>

             <div class="form-group text-center">
                 <asp:Button Class="btn btn-info" OnClick="Button1_Click" ID="Button1" runat="server" Text="Register" />
             </div>
         </div>   
          
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoeStore.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.6.3/css/all.css" integrity="sha384-UHRtZLI+pbxtHCWp1t77Bi1L4ZtiqrqD80Kn4Z8NTSRyMA2Fd33n5dQ8lWUE00s/" crossorigin="anonymous" />
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="col-md-6 mx-auto">
            <h3 class="text-center my-5 ">Login</h3>
            <div class="form-group row">
                <label class="col-sm-4 text-right">User Name</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtUsername" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Username"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-sm-4 text-right">Password</label>
                <div class="col-sm-8">
                    <asp:TextBox ID="TxtPassword" TextMode="Password" AutoCompleteType="Disabled" class="form-control" runat="server" placeholder="Enter your Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group text-center">
                 <asp:Button Class="btn btn-primary" OnClick="Button1_Click1" ID="Button1" runat="server" Text="Login" />
             </div>
            <div class="form-group text-center">
                <asp:Label ID="lbl_error" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label> 
             </div>
            
        </div>
        
    </form>
</body>
</html>

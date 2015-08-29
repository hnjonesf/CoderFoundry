<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        C# Exercises in Web Forms</div>
        <p>
            What is your First Name?
            <asp:TextBox ID="firstNameTextBox" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </p>
        <p>
            What is your Last Name?
            <asp:TextBox ID="lastNameCheckBox" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="okButton" runat="server" Text="Click Me" />
        </p>
        <p>
&nbsp;<asp:Label ID="resultLabel" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

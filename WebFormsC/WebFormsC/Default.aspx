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
        <p>
            &nbsp;</p>
        <p>
            Lesson #2</p>
        <p>
            How old are you?
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            How much $ do you have?
            <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Fortune" />
        </p>
        <p>
            At
            <asp:Label ID="Label1" runat="server"></asp:Label>
            , I would have expected you to have more than $<asp:Label ID="Label2" runat="server"></asp:Label>
            .</p>
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>

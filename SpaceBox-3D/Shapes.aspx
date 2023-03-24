<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Shapes.aspx.cs" Inherits="SpaceBox_3D.Shapes" %>

<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8" />
    <link href="./Content/styles.css" rel="stylesheet" />
    <link href="https://cdn.tailwindcss.com" rel="stylesheet">
     <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Readex+Pro:wght@200;300;400;500;600;700&display=swap" rel="stylesheet">

    <title>Shapes</title>
</head>
<body>

    <form id="form1" runat="server">
        <div class="container">
           
        <asp:Label ID="Label1" runat="server"  Style="position: absolute; top: 50px; left: 470px;"  Font-Names="readex pro deca medium" Font-Size="96px" class="Font-Bold" ForeColor="#E6A02D" Height="120px" Text="SpaceBox-3D" Width="606px" Font-Bold="True"></asp:Label>
       
            </div>
        <asp:DropDownList ID="SelectShape" runat="server" BackColor="#3B3B3B"  ForeColor="#FFCB74" Height="50px" Width="200px" Font-Size="20px">
            <asp:ListItem>Select Shape</asp:ListItem>
            <asp:ListItem>Circle</asp:ListItem>
            <asp:ListItem>Rectangle</asp:ListItem>
            <asp:ListItem>Triangle</asp:ListItem>
        </asp:DropDownList>
    </form>

</body>
</html>

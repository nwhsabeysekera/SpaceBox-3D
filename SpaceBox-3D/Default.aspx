<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpaceBox_3D._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="./Content/styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Readex+Pro:wght@200;300;400;500;600;700&display=swap" rel="stylesheet">

    <main>
        
        <div class="flex flex-col justify-center items-center h-screen gap-20">

            <asp:Label ID="Label1" runat="server" Text="SpaceBox 3D" Font-Names="Readex Pro Deca Medium" Font-Size="120px" ForeColor="#E6A02D"></asp:Label>
    
            <p class="flex justify-center gap-32">

                <asp:Button ID="btnShapes" runat="server" Text="Shapes" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca Medium" Font-Size="24pt" ForeColor="#2F2F2F" Height="80px" Width="240px" style="border-radius: 30px;" />
                <asp:Button ID="btnBraille" runat="server" Text="Braille" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca Medium" Font-Size="24pt" ForeColor="#FFCB74" Height="80px" Width="240px" style="border-radius: 30px;"/>

            </p>
        </div>
               
    </main>
</asp:Content>

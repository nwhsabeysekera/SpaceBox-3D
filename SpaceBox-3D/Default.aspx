<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SpaceBox_3D._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">>

        <style>
            body::before {
                content: "";
                background-image: url('Images/background.png');
                background-size: cover;
                position: fixed;
                top: 0;
                left: 0;
                width: 100%;
                height: 100%;
                opacity: 0.5;
                z-index: -1              
            }
        </style>

        
        <div class="flex flex-col justify-center items-center h-screen gap-20">

            <asp:Label ID="Label1" runat="server" Text="SpaceBox 3D" Font-Names="Readex Pro Deca Medium" Font-Size="120px" ForeColor="#E6A02D"></asp:Label>
    
            <p class="flex justify-center gap-32">

                <asp:Button ID="btnShapes" runat="server" Text="Shapes" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca Medium" Font-Size="24pt" ForeColor="#2F2F2F" Height="80px" Width="240px" style="border-radius: 30px;" OnClick="btnShapes_Click"/>
                <asp:Button ID="btnBraille" runat="server" Text="Braille" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca Medium" Font-Size="24pt" ForeColor="#FFCB74" Height="80px" Width="240px" style="border-radius: 30px;" OnClick="btnBraille_Click" />

            </p>
        </div>
               
    </main>
</asp:Content>

<%@ Page Title="404" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SpaceBox_3D._404" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <div class="flex h-screen items-center">
            <div class="flex flex-col pl-32 justify-center z-20">

                <asp:Label ID="spacebox3d" runat="server" Text="SpaceBox 3D" Font-Names="Readex Pro Deca Medium" Font-Size="30pt" ForeColor="#E6A02D" CssClass="pb-10 pt-0"></asp:Label>
                <asp:Label ID="oops" runat="server" Text="OOPS..." Font-Names="Readex Pro Deca Medium" Font-Size="55pt" ForeColor="White"></asp:Label>
                <asp:Label ID="pageNotFound" runat="server" Text="Page Not Found" Font-Names="Readex Pro Deca Medium" Font-Size="25pt" ForeColor="White" CssClass="pb-10"></asp:Label>

                <p class="paragraph-custom pb-20">
                    The page you are looking for doesn't exist or any other error eccurred, go back to the home page.
                </p>
                <asp:Button ID="btnHome" runat="server" Text="Home" CssClass="btn-custom z-30" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Bold="False" Font-Names="Readex Pro Deca Medium" Font-Size="16pt" ForeColor="#2F2F2F" Height="40px" OnClick="btnHome_Click" Width="120px" />

            </div>
        </div>

        <div class="absolute inset-0 z-0">
            <asp:Image ID="bgImage" runat="server" Height="100%" Width="60%" ImageUrl="~/Images/404-background.png" CssClass="absolute top-0 right-0" />
        </div>

        <div class="absolute inset-0 flex items-center justify-end z-10">
            <asp:Image ID="Image1" runat="server" Width="46%" ImageUrl="~/Images/404.png" CssClass="m-20"/>
        </div>

    </main>
</asp:Content>

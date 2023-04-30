<%@ Page Title="Printing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="SpaceBox_3D.Print" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <script>
            function updateProgress(progress) {
                var progressBar = document.getElementById("progressbar");
                progressBar.value = progress;
            }
        </script>

        <div class="flex flex-col justify-center items-center h-screen">

            <asp:Label ID="Label1" runat="server" Text="SpaceBox 3D" Font-Names="Readex Pro Deca Medium" Font-Size="120px" ForeColor="#E6A02D"></asp:Label>

            <p class="print-custom">Printing in progress...</p>
    
            <progress id="progressbar" value="0" max="100"></progress>
    
        </div>

    </main>

</asp:Content>

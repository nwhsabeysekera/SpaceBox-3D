<%@ Page Title="Printing" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Print.aspx.cs" Inherits="SpaceBox_3D.Print" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <script>
            var i = 0;
            function move() {
                if (i == 0) {
                    i = 1;
                    var elem = document.getElementById("myBar");
                    var width = 1;
                    var id = setInterval(frame, 30);
                    function frame() {
                        if (width >= 100) {
                            clearInterval(id);
                            i = 0;
                        } else {
                            width++;
                            elem.style.width = width + "%";
                        }
                    }
                }
            }

            window.onload = move;
        </script>

        <style>
            #myProgress {
              width: 700px;
              background-color: #686868;
              border-radius: 15px;
            }

            #myBar {
              width: 1%;
              height: 15px;
              background-color: #E6A02D;
              border-radius: 15px;
            }
        </style>

        <div class="flex flex-col justify-center items-center h-screen">

            <asp:Label ID="Label1" runat="server" Text="SpaceBox 3D" Font-Names="Readex Pro Deca Medium" Font-Size="120px" ForeColor="#E6A02D" CssClass="pb-20"></asp:Label>

            <p class="print-custom pb-10">Printing in progress...</p>
    
            <div id="myProgress">
              <div id="myBar"></div>
            </div>

            <br /><br /><br />

            <div class="flex flex-row gap-20 justify-center">
                <asp:Button ID="btnPause" runat="server" Text="Pause" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#2F2F2F" Height="40px" Width="120px" style="border-radius: 30px;" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#FFCB74" Height="40px" Width="120px" style="border-radius: 30px;" OnClick="btnCancel_Click"/>        
            </div>
    
        </div>

    </main>

</asp:Content>

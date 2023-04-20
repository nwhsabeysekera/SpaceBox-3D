<%@ Page Title="Braille" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Braille.aspx.cs" Inherits="SpaceBox_3D.Braille" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title"">
        <div class="container mx-auto px-4" style="max-width: 900px;">
            <div class="flex flex-col gap-20 justify-center">
                <div class="flex justify-center">
                    <asp:Button ID="btnHome" runat="server" Text="spaceBox 3D" BackColor="#2F2F2F" Font-Names="Readex Pro Deca" Font-Size="60pt" ForeColor="#E6A02D" Height="116px" Width="519px" style="border-radius: 30px;" OnClick="btnHome_Click" />
                </div>                   

                <div class="flex text-[14px] justify-center font-readex"> 

                    <asp:TextBox ID="txtInput" runat="server" CssClass="bg-primary-grey border-0 border-primary-grey shadow-sm focus:outline-none focus:ring-2 focus:ring-primary-grey focus:border-primary-grey" placeholder="Write text here" style="font-family: 'Readex Pro'; font-size: 14px; color: #FFCB74; background-color: #3B3B3B;" TextMode="MultiLine" Height="150px" Width="500px"></asp:TextBox>

                </div>

                <div class="flex flex-row gap-20 justify-center">
                    <asp:Button ID="btnConvert" runat="server" Text="Convert" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#2F2F2F" Height="40px" Width="120px" style="border-radius: 30px;" OnClick="btnConvert_Click" />
                    <asp:Button ID="btnClear" runat="server" Text="Clear" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#FFCB74" Height="40px" Width="120px" style="border-radius: 30px;" OnClick="btnClear_Click" />                  
                </div>

                <div class="justify-center mt-2">
                    
                    <div class="flex gap-2">
                        <asp:Label ID="lblDotAmount" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Dot Amount :"></asp:Label>
                        <asp:Label ID="lblDisplayDotAmount" runat="server" Font-Names="Readex Pro Deca" ForeColor="White" Font-Size="12"></asp:Label>
                    </div>

                    <div class="flex flex-row mt-2">
                        <asp:Panel ID="braillePreviewPanel" runat="server" BackColor="#3B3B3B" Height="300px" Width="900px">
                            <asp:Label ID="lblBraillePreview" runat="server" Font-Names="Readex Pro Deca" Font-Size="20pt" ForeColor="White" CssClass="mt-5 flex justify-center"></asp:Label>
                        </asp:Panel>
                    </div>

                </div>


                <div class="flex flex-row gap-20 justify-center mb-5">
                    <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#2F2F2F" Height="40px" Width="120px" style="border-radius: 30px;" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#FFCB74" Height="40px" Width="120px" style="border-radius: 30px;" OnClick="btnCancel_Click"/>        
                </div>
                
            </div>
        </div>
                
    </main>

</asp:Content>

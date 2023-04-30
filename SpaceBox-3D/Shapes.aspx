<%@ Page Title="Shapes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shapes.aspx.cs" Inherits="SpaceBox_3D.Shapes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main aria-labelledby="title">

        <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
        <script type="text/javascript">
            $(document).ready(function () {
                $('.txt').focusin(function () {
                    $(this).css("background-color", "#686868");
                });
                $('.txt').focusout(function () {
                    $(this).css("background-color", "#3B3B3B");
                });
            });
        </script>
        <div class="flex justify-center">     
                    <asp:Button ID="btnHome" runat="server" Text="SpaceBox 3D" BackColor="#2F2F2F" Font-Names="Readex Pro Deca" Font-Size="60pt" ForeColor="#E6A02D" Height="116px" Width="519px" style="border-radius: 30px;" OnClick="btnHome_Click" />
        </div>

        <br />
        <br />

        <div class="container mx-auto px-4" style="max-width: 900px;">

            <div class="flex flex-col gap-5">

                <div class="flex justify-between gap-20">

                    <div class="flex flex-col bg-primary-grey mt-4 top-rounded border-b-2 border-primary-yellow" style="height: 67px;">
                            <asp:Label ID="Label2" runat="server" ForeColor="#FFCB74" Text="Select a Shape" Font-Names="Readex Pro Deca Light" CssClass="px-5 mt-2" Font-Size="9pt"></asp:Label>

                            <asp:DropDownList ID="SelectShape" runat="server" BackColor="#3B3B3B" DataTextField="Select a shape" ForeColor="White" Width="294px" CssClass="p-4 border-t-0 border-r-0 border-l-0 border-b-2 border-primary-yellow shadow-sm focus:outline-none focus:ring-primary-yellow mr-2" Height="45px" AutoPostBack="True" OnSelectedIndexChanged="SelectShape_SelectedIndexChanged" Font-Names="Readex Pro Deca" Font-Size="12pt">
                                <asp:ListItem CssClass="hover:bg-secondary-grey">Circle</asp:ListItem>
                                <asp:ListItem CssClass="hover:bg-secondary-grey">Triangle</asp:ListItem>
                                <asp:ListItem CssClass="hover:bg-secondary-grey">Rectangle</asp:ListItem>
                            </asp:DropDownList>                       
                    </div>

                    <div class="flex flex-col gap-4">

                        <div class="flex flex-col gap-1">

                            <!-- Rectangle -->

                            <div class="flex flex-col gap-2 mb-5" id="rectangle" runat="server">
                
                                <asp:Label ID="lblLength" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Length"></asp:Label>

                                <asp:TextBox ID="Length" runat="server" BackColor="#3B3B3B" ForeColor="White" Width="294px" Height="40px" Font-Names="readex pro deca medium" Font-Size="14px" TextMode="Number"  PlaceHolder="Length || 0mm" CssClass="txt txt-custom txt-custom:focus" AutoPostBack="True"></asp:TextBox>

                                <asp:Label ID="lblLengthValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                                <asp:Label ID="lblWidth" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Width" CssClass="mt-2"></asp:Label>
               
                                <asp:TextBox ID="Width" runat="server" BackColor="#3B3B3B" ForeColor="White" Width="294px" Height="40px" Font-Names="readex pro deca medium" Font-Size="14px" TextMode="Number" PlaceHolder="Width || 0mm" CssClass="txt txt-custom txt-custom:focus" AutoPostBack="True"></asp:TextBox>

                                <asp:Label ID="lblWidthValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F" ></asp:Label>

                            </div>


                            <!-- Circle -->

                            <div class="flex flex-col gap-2 mb-5" id="circle" runat="server">

                                <asp:Label ID="lblRadius" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Radius"></asp:Label>

                                <asp:TextBox ID="Radius" runat="server" BackColor="#3B3B3B" ForeColor="White" Width="294px" Height="40px" Font-Names="readex pro deca medium" Font-Size="14px" TextMode="Number" PlaceHolder="Radius || 0mm" CssClass="txt txt-custom txt-custom:focus" AutoPostBack="True"></asp:TextBox>

                                <asp:Label ID="lblRadiusValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                                <asp:Label ID="lblCenterPoint" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Center Point"></asp:Label>
              
                                            
                                <div class="flex flex-row max-w-[240px] justify-between gap-2">
                                    
                                    <asp:TextBox ID="CenterX" runat="server" BackColor="#3B3B3B" ForeColor="White" Width="140px" Height="40px" Font-Names="readex pro deca medium" Font-Size="14px" TextMode="Number" PlaceHolder="X axis" CssClass="txt txt-custom txt-custom:focus"></asp:TextBox>

                                    <asp:TextBox ID="CenterY" runat="server" BackColor="#3B3B3B" ForeColor="White" Width="140px" Height="40px" Font-Names="readex pro deca medium" Font-Size="14px" TextMode="Number" PlaceHolder="Y axis" CssClass="txt txt-custom txt-custom:focus"></asp:TextBox>         
                                   
                               </div>
                                
                                <asp:Label ID="lblCenterPointValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                            </div>

            
                            <!-- Triangle -->

                            <div class="flex flex-col gap-2 mb-5" id="triangle" runat="server">

                                <asp:Label ID="lblSide_a" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Side A"></asp:Label>

                                <asp:TextBox ID="SideALength" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Width="294px" Height="40px" TextMode="Number" ForeColor="White" PlaceHolder="Side A | mm" BorderColor="#686868" CssClass="txt txt-custom txt-custom:focus" ></asp:TextBox>
                
                                <asp:Label ID="lblSideALengthValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                                <asp:Label ID="lblSide_b" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Side B" CssClass="mt-2"></asp:Label>                            

                                <asp:TextBox ID="SideBLength" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Height="40px" TextMode="Number" Width="294px" ForeColor="White" PlaceHolder="Side B || mm" BorderColor="#3B3B3B" CssClass="txt txt-custom txt-custom:focus" ></asp:TextBox>

                                <asp:Label ID="lblSideBLengthValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                                <asp:Label ID="lblSide_c" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Side C" CssClass="mt-2"></asp:Label>

                                <asp:TextBox ID="SideCLength" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Height="40px" TextMode="Number" Width="294px" ForeColor="White" PlaceHolder="Side C || mm" BorderColor="#686868" CssClass="txt txt-custom txt-custom:focus" ></asp:TextBox>

                                <asp:Label ID="lblSideCLengthValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>
                                
                                <asp:Label ID="lblAngles" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Angles" CssClass="mt-2"></asp:Label>

                              
                                <div class="flex flex-row max-w-[240px] justify-between gap-2">

                                    <asp:Label ID="lblAngleA" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="A" CssClass="mt-2"></asp:Label>

                                    <asp:TextBox ID="txtAngleA" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Height="45px" TextMode="Number" Width="80px" ForeColor="White" PlaceHolder="0°" BorderColor="#686868" CssClass="txt txt-custom txt-custom:focus" OnTextChanged="txtAngleA_TextChanged" ></asp:TextBox>

                                    <asp:Label ID="lblAngleB" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="B" CssClass="mt-2"></asp:Label>

                                    <asp:TextBox ID="txtAngleB" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Height="45px" TextMode="Number" Width="80px" ForeColor="White" PlaceHolder="0°" BorderColor="#686868" CssClass="txt txt-custom txt-custom:focus" OnTextChanged="txtAngleB_TextChanged" ></asp:TextBox>

                                    <asp:Label ID="lblAngleC" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="C" CssClass="mt-2"></asp:Label>

                                    <asp:TextBox ID="txtAngleC" runat="server" BackColor="#3B3B3B" Font-Names="readex pro deca medium" Height="45px" TextMode="Number" Width="80px" ForeColor="White" PlaceHolder="0°" BorderColor="#686868" CssClass="txt txt-custom txt-custom:focus" ReadOnly="true"></asp:TextBox>

                                </div>

                                <asp:Label ID="lblAnglesValidate" runat="server" Width="294px" Height="15px" Font-Names="Readex Pro Deca" Font-Size="12px" ForeColor="#E84E4F"></asp:Label>

                            </div>

                        </div>

                        <div class="flex flex-row justify-center gap-20">
                            <asp:Button ID="btnApply" runat="server" BackColor="#FFCB74" BorderColor="#FFCB74" Text="Apply" CssClass="btn-custom" Height="40px" Width="120px" Font-Names="readex pro deca medium" Font-Size="15px" OnClick="btnApply_Click" />

                            <asp:Button ID="btnClear" runat="server" BackColor="#3B3B3B" BorderColor="#FFCB74" Text="Clear" CssClass="btn-custom" Height="40px" Width="120px" ForeColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="readex pro deca medium" Font-Size="15px" OnClick="btnClear_Click" />
                        </div>

                    </div>
            
                </div>

                <div class="justify-center mt-2 mb-5">

                    <div class="flex gap-2">
                        <asp:Label ID="lblDotAmount" runat="server" Font-Names="Readex Pro Deca" Font-Size="12pt" ForeColor="White" Text="Dot Amount :"></asp:Label>
                        <asp:Label ID="lblDisplayDotAmount" runat="server" Font-Names="Readex Pro Deca" ForeColor="White" Font-Size="12"></asp:Label>
                    </div>

                    <div class="flex flex-row mt-2">
                        <asp:Panel ID="PreveiwPanel" runat="server" BackColor="#3B3B3B" Height="300px" Width="900px">
                            <asp:Label ID="LabelPreview" runat="server" Font-Names="Readex Pro Deca" Font-Size="20pt" ForeColor="White" CssClass="mt-5 flex justify-center"></asp:Label>
                        </asp:Panel>
                    </div>

                </div>

                <div class="flex flex-row gap-20 justify-center mb-5">

                   <asp:Button ID="btnPrint" runat="server" Text="Print" BackColor="#FFCB74" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#2F2F2F" Height="40px" Width="120px" CssClass="btn-custom" OnClick="btnPrint_Click" />
                         
                  <asp:Button ID="btnCancel" runat="server" Text="Cancel" BackColor="#3B3B3B" BorderColor="#FFCB74" BorderStyle="Solid" BorderWidth="1px" Font-Names="Readex Pro Deca" Font-Size="Medium" ForeColor="#FFCB74" Height="40px" Width="120px" CssClass="btn-custom" OnClick="btnCancel_Click" />

                </div>  
            
            </div>
            
        </div>
 
    </main>

</asp:Content>
    


<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddSparePart.aspx.cs" Inherits="FinalProject.AddSparePart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-5">

                <div class="card">
                    <div class="card-body">

                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Spare Part Details</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="images/SparePart.png" />
                                       
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Spare Part Name"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Function</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox2" runat="server" placeholder="Function"></asp:TextBox>

                                </div>
                            </div>
                        </div>

                             <div class="row">
                            <div class="col-md-4">
                                <label>Dimension</label>
                                <div class="form-group">
                                    <asp:DropDownList CssClass="form-control" ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                    <asp:ListItem Text="Circular" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Flat" Value="2"></asp:ListItem>
                                    </asp:DropDownList>

                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Radius\Length</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Radius\Length"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>Height</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox5" runat="server" placeholder="Height"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <div class="col-md-8">
                                <label>Width</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox6" runat="server" placeholder="Width"></asp:TextBox>

                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label></label>Price
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Price"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>ManufacturerID</label>
                                <div class="form-group">
                                    <asp:TextBox CssClass="form-control" ID="TextBox8" runat="server" placeholder="ManufactureId"></asp:TextBox>
                               </div>
                            </div>
                            
                        </div>
                        <div class="row">
                            <div class="col-md-9">
                                <label></label>Quantity
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox7" runat="server" placeholder="Quantity"></asp:TextBox>
                                    </div>
                                </div>
                            
                        </div>
                        


                        <div class="row">
                            
                            <div class="col-4">
                                <asp:Button ID="Button1" class="btn btn-lg btn-block btn-success" runat="server" Text="ADD" OnClick="Button1_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button2" class="btn btn-lg btn-block btn-warning" runat="server" Text="UPDATE" OnClick="Button2_Click" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-danger" runat="server" Text="DELETE" OnClick="Button3_Click" />
                            </div>
                        </div>



                    </div>
                </div>

                <a href="homepage.aspx"><< Back to Home</a><br>
                <br>
            </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">



                        <div class="row">
                            <div class="col">
                                <center>
                                        <h4>Spare Parts List</h4>
                                    </center>
                            </div>
                        </div>

                       

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>


                    </div>
                </div>


            </div>

        </div>
    </div>

</asp:Content>

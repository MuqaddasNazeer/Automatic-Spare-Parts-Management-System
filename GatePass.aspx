<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="GatePass.aspx.cs" Inherits="FinalProject.GatePass" %>
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
                                        <h4>Gate Pass</h4>
                                    </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                        <img width="100px" src="images/GatePass.jpg" />
                                       
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Order No</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox4" runat="server" placeholder="Order No"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                             <div class="col-md-6">
                                <label>Product Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                      <asp:TextBox CssClass="form-control" ID="TextBox3" runat="server" placeholder="Product Name"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                         </div>
                          <div class="col-md-6">
                                <label>Quantity</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" placeholder="Quantity"></asp:TextBox>
                                    </div>
                                </div>
                            </div>  
                          <div class="col-md-6">
                            <div class="form-group form-inline">
                                <label style="margin-right: 10px;">Missing</label>
                                <div class="input-group">
                                    <label class="radio-inline" style="margin-right: 10px; width: 81px;"><input type="radio" name="missing" value="yes">Yes</label>
                                    <label class="radio-inline" style="margin-left: 10px;"><input type="radio" name="missing" value="no">No</label>
                                </div>
                            </div>
                          </div>

                        
                             

                        <div class="col-md-6">
                        <div class="form-group form-inline">
                            <label style="margin-right: 10px;">Defected</label>
                            <div class="input-group">
                                <label class="radio-inline" style="margin-right: 10px;"><input type="radio" name="defected" value="yes">Yes</label>
                                <label class="radio-inline" style="margin-left: 10px;"><input type="radio" name="defected" value="no">No</label>
                            </div>
                        </div>
                       </div>

                           

                        <div class="row">                            
                            <div class="col-4">
                                <asp:Button ID="Button3" class="btn btn-lg btn-block btn-warning" runat="server" Text="Add" OnClick="Button3_Click" />
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
                                        <h4>Gate Pass List</h4>
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


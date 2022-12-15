<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
            <div class="row">
            
              <div class="col-lg-12">
                <div class="p-5">
                  <div class="text-center pb-4">
                    <h2 class="gradient-text font-weight-bold">LJ HOSTELS</h2>
                    <h6 class="text-dark font-weight-bold">Stay Like Your Own Home</h6>
                  </div>
                  <form id="Form1" class="user"  runat="server">
                    <div class="form-group wrap-input100 validate-input m-b-26">
                        <asp:TextBox ID="email" runat="server" class="form-control form-control-user" Placeholder="Email Address" type="email" required="true"  onkeydown="limit(this,50);" onkeyup="limit(this,50);"></asp:TextBox>
                    </div>
                    <div class="form-group wrap-input100 validate-input m-b-26">
                        <asp:TextBox ID="password" runat="server" class="form-control form-control-user" Placeholder="Password" type="password" required="true"  onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                    </div>
                  <asp:Button ID="Button1" runat="server" Text="Login" 
                        class="btn btn-ljcca btn-user btn-block " onclick="login_Click" Font-Size="Medium" />
                  <hr>
                  <div class="text-center">
                      <asp:LinkButton ID="LinkButton1" runat="server" class="small text-ljcca" OnClick="forgot_pass_Click">Forgot Password?</asp:LinkButton>
                  </div>
                  <div class="text-center pt-1">
                  <a href="Registration1" class="small text-ljcca">Register Your Entry</a>
                  </div>
                  </form>
                </div>
              </div>
            </div>

          </div>
        </div>

      </div>

    </div>
    <div class="row justify-content-center" runat="server" id="Empty_Email" visible="false">
        <div class="col-xl-5 custom-alert"> 
        Enter Email first to change password!
        </div>
    </div>
    <div class="row justify-content-center" runat="server" id="Invailed" visible="false">
        <div class="col-xl-5 custom-alert"> 
        Invailed Email address or Password!
        </div>
    </div>
    <div class="row justify-content-center" runat="server" id="Invailed_Email" visible="false">
        <div class="col-xl-5 custom-alert"> 
        Invailed Email address!
        </div>
    </div>
</asp:Content>


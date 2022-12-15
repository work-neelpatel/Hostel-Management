<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Forgot Password</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
            <div class="row">
              <div class="col-lg-12">
                <div class="p-5">

                  <div class="text-center pb-4">
                    <h1 class="h3 font-weight-bold text-ljcca">Change Password</h1>
                    <h6 class="text-gray font-weight-bold">We Sent OTP On Your Email Address.</h6>
                  </div>
                  <form id="Form2" class="user"  runat="server">
                    <div class="form-group wrap-input100 validate-input m-b-26" data-validate="Enter Perfect formate">
                        <asp:TextBox ID="otp" runat="server" class="form-control form-control-user" Placeholder="OTP" type="number" required="true" min="0" onkeydown="limit(this,6);" onkeyup="limit(this,6);"></asp:TextBox>
                    </div>
                    <div class="form-group wrap-input100 validate-input m-b-26" data-validate="Enter Password">
                        <asp:TextBox ID="password" runat="server" class="form-control form-control-user" Placeholder="New Password" type="password" onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                    </div>
                    <div class="form-group wrap-input100 validate-input m-b-26" data-validate="Enter Password">
                        <asp:TextBox ID="cpassword" runat="server" class="form-control form-control-user" Placeholder="Confirm New Password" type="password" onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                    </div>

                  <asp:Button ID="Change_Password" runat="server" Text="Change Password" 
                        class="btn btn-ljcca btn-user btn-block " Font-Size="Medium" 
                        onclick="Change_Password_Click" />
                  <hr>
                  <div class="text-center">
                      <asp:LinkButton ID="LinkButton1" runat="server" class="small text-ljcca" >Send OTP on Recovery Email Address!</asp:LinkButton>
                  </div>

                  </form>
                </div>

              </div>
            </div>
          </div>
        </div>

      </div>

    </div>
    <div class="row justify-content-center" runat="server" id="Invailed_OTP" visible="false">
        <div class="col-xl-5 custom-alert"> 
        Invailed OTP!
        </div>
    </div>
    <div class="row justify-content-center" runat="server" id="Pass_match" visible="false">
        <div class="col-xl-5 custom-alert"> 
        Password doesn't match!
        </div>
    </div>
</asp:Content>


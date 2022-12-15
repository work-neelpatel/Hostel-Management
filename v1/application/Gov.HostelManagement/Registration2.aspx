<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Registration2.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <title>Registration Phase 2</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
            <div class="row">
            
              <div class="col-lg-12">
                <div class="p-5">
              <div class="text-center pb-4">
                <h1 class="h3 font-weight-bold text-ljcca">Regestration Phase-2</h1>
              </div>

                 <form id="Form1" class="user" runat="server">
                    <div class="form-group pb-1">
                        <p class="p-0 m-2">Email Address</p>
                        <asp:TextBox ID="email" runat="server" type="email" class="form-control form-control-user"  aria-describedby="emailHelp" placeholder="Your Email Address" required="true"></asp:TextBox>
                    </div>
                    <div class=" form-group wrap-input100 pb-1">                        
                        <p class="p-0 m-2">Password</p>
                        <asp:TextBox ID="passwordfield" runat="server" class="form-control form-control-user"  type="password" placeholder="Password" required="true"></asp:TextBox>						
			        </div>
                     <div class="wrap-input100 form-group pb-1" data-validate = "Password is required">                        
                        <p class="p-0 m-2">Confirm Password</p>
                        <asp:TextBox ID="cpasswordfield" runat="server" class="form-control form-control-user"  type="password" placeholder="Confirm Password" required="true"></asp:TextBox>
					</div>
                    <div class="form-group pb-1">
                        <p class="p-0 m-2">Recovery Email Address<span class="small pl-1">(It helps you when your first Email is not working.)</span></p>
                        <asp:TextBox ID="remail" runat="server" type="email" class="form-control form-control-user"  aria-describedby="emailHelp" placeholder="Your Recovery Email Address" required="true"></asp:TextBox>
                    </div>
                    <div class="form-group pb-3">
                        <p class="p-0 m-2">Your Photo<span class="small pl-1">(Make sure Your Photo size must be less than 1 MB.)</span></p>
                        <asp:FileUpload ID="StudImg" runat="server" class="btn btn-primary col-12 m-1" style="border-radius:20px" required />
                    </div>
                    
                  <asp:Button ID="Button1" runat="server" Text="Register Entry" class="btn btn-ljcca btn-user btn-block" onclick="next2_Click" Font-Size="Medium"/>
                           
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>
</asp:Content>


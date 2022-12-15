<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Registration1.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <title>Registration Phase 1</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" Runat="Server">
        <div class="row">
          <div class="col-lg-12">

            <div class="p-5">
              <div class="text-center pb-4">
                <h1 class="h3 font-weight-bold text-ljcca">Regestration Phase-1</h1>
              </div>

              <form id="Form1" class="user"  runat="server">
                <div class="form-group row mb-3">
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Enrollment No.</p>
                      <asp:TextBox ID="enroll" runat="server" class="form-control form-control-user"  placeholder="Enrollment No."  required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6 dropdown" >
                      <p class="ml-2 m-0">College</p>                        
                      <asp:DropDownList ID="college" runat="server" AutoPostBack="true" 
                          class="btn btn-primary dropdown-toggle p-0" role="button" data-toggle="dropdown" aria-haspopup="true" 
                      style="width: 200px; border-radius:25px; height:50px; text-indent:5%" 
                          onselectedindexchanged="college_SelectedIndexChanged" required="true"> 
                      </asp:DropDownList>
                
                  </div>
                </div>
                 <div class="form-group row mb-3" >
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">Current College Semester</p>
                      <asp:TextBox ID="curr_clg_sem" runat="server" type="number" class="form-control form-control-user"  placeholder="Current College Semester" required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">College DOJ</p>
                     <asp:TextBox ID="clg_doj" runat="server" type="text" class="form-control form-control-user"  placeholder="College DOJ" required="true"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row mb-3" >
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Department</p>
                     <asp:TextBox ID="dept" runat="server" type="text" class="form-control form-control-user"  placeholder="Department"  required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Department Duration</p>
                     <asp:TextBox ID="Dept_Due" runat="server" type="text" class="form-control form-control-user"  placeholder="Department Duration"  required="true"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row mb-3" >
                    <div class="col-sm-6">
                      <p class="ml-2 m-0">Percentage</p>
                     <asp:TextBox ID="parc" runat="server" type="number" class="form-control form-control-user"  placeholder="Parcentage" style="border-radius:20px;" required="true"></asp:TextBox>
                  </div>
                </div>

                   <div >
                <hr />
                <div class="form-group row mb-3"   >
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">First Name</p>
                      <asp:TextBox ID="fname" runat="server" type="text" class="form-control form-control-user"  placeholder="First Name"  required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Last Name</p>
                     <asp:TextBox ID="lname" runat="server" type="text" class="form-control form-control-user"  placeholder="Last Name"  required="true"></asp:TextBox>
                  </div>
                </div>
                 <div class="form-group row mb-3" >
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">DOB</p>
                      <asp:TextBox ID="dob" runat="server" type="text" class="form-control form-control-user"  placeholder="DOB" required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Mobile</p>
                     <asp:TextBox ID="mobile" runat="server" type="number" class="form-control form-control-user"  placeholder="Mobile"  required="true"  onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                  </div>
                </div>
                 <div class="form-group row mb-3" >
                  <div class="col-sm-6 dropdown" >
                      <p class="ml-2 m-0">Gender</p>                        
                      <asp:DropDownList ID="gen" runat="server" class="btn btn-primary dropdown-toggle p-0" role="button" data-toggle="dropdown" aria-haspopup="true" style="width: 200px; border-radius:25px; height:50px;text-indent: 5%;" required="true"> 
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem>
                      </asp:DropDownList>
                  </div>
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">Category</p>
                      <asp:TextBox ID="category" runat="server" type="text" class="form-control form-control-user"  placeholder="Category"  required="true"></asp:TextBox>
                  </div>
                </div>
                 <div class="form-group row mb-3" >
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Father Name</p>
                     <asp:TextBox ID="faname" runat="server" type="text" class="form-control form-control-user"  placeholder="Father Name"  required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">Father Mobile</p>
                      <asp:TextBox ID="famobile" runat="server" type="number" class="form-control form-control-user"  placeholder="Father Mobile"  required="true"  onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                  </div>
                </div>
                 <div class="form-group row mb-3" >
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Mother Name</p>
                     <asp:TextBox ID="mname" runat="server" type="text" class="form-control form-control-user"  placeholder="Mother Name"  required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6 mb-sm-0">
                      <p class="ml-2 m-0">Mother Mobile</p>
                      <asp:TextBox ID="mmobile" runat="server" type="number" class="form-control form-control-user"  placeholder="Mother Mobile"  required="true"  onkeydown="limit(this,10);" onkeyup="limit(this,10);"></asp:TextBox>
                  </div>
                </div>
                <div class="form-group row mb-3" >
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">Area</p>
                     <asp:TextBox ID="add_area" runat="server" type="text" class="form-control form-control-user"  placeholder="Area" required="true"></asp:TextBox>
                  </div>
                  <div class="col-sm-6">
                      <p class="ml-2 m-0">City</p>
                     <asp:TextBox ID="city" runat="server" type="text" class="form-control form-control-user"  placeholder="City" required="true"></asp:TextBox>
                  </div>                
                </div>
                <div class="form-group row mb-5 " >
                  <div class="col-sm-12 mb-sm-0">
                  <p class="ml-2 m-0">Address</p>
                  <asp:TextBox ID="add" runat="server" type="text" class="form-control form-control-user"  placeholder="Address" TextMode="MultiLine"  required="true"></asp:TextBox>
                </div>
              </div>
               <div class="form-group row mb-5" style="display:none">
                  <p class="col-sm-3" runat="server" id="area_id"></p>
                  <p class="col-sm-3" runat="server" id="clg_id"></p>
                  <p class="col-sm-3" runat="server" id="dept_id"></p>
                  <p class="col-sm-3" runat="server" id="cat_id"></p>
              </div>

              <asp:Button ID="Button1" runat="server" Text="Next"  class="btn btn-ljcca btn-user btn-block" style="border-radius:20px;" onclick="next_Click1"/>
              </div>
              </form>
              
             
            </div>
          </div>
        </div>
          </div>
        </div>

      </div>

    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="AddNotice.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Add Notice</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="slidebar" Runat="Server">
      
      <li class="nav-item">
        <a class="nav-link" href="MessageBox">
          <i class="fas fa-fw fa-inbox"></i>
          <span>Message Box</span></a>
      </li>

      
      <li class="nav-item active">
        <a class="nav-link" href="HNoticeBox">
          <i class="fas fa-fw fa-comment"></i>
          <span>Notice Box</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="HComplainBox">
          <i class="fas fa-fw fa-exclamation-triangle"></i>
          <span>Complain Box</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="RequestBox">
          <i class="fas fa-fw fa-comments"></i>
          <span>Request Box</span></a>
      </li>

      <!-- Divider -->
      <hr class="sidebar-divider">

      <div class="sidebar-heading">
        Seats
      </div>

      <li class="nav-item">
        <a class="nav-link" href="Merit">
          <i class="fas fa-fw fa-list-alt"></i>
          <span>Merit</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="StudentsList">
          <i class="fas fa-fw fa-bed"></i>
          <span>Seats</span></a>
      </li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
<form id=form runat="server">
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Add Notice</h1>
            <p class="mt-2"><a href="HNoticeBox" class="mr-4 text-secondary text-decoration-none">Notice Box</a><a href="AddNotice" class="text-primary text-decoration-none" style="border-bottom:1px solid">Add Notice</a></p>
          </div>

          <!-- Content Row -->
          <div class="row mb-4 justify-content-center">
            <!-- Fade In Utility -->
            <div class="col-xl-8">

              <div class="card position-relative">
               
                <div class="card-body">
                <div class="small mb-1">Send To:</div>    
                <div class="dropdown mb-4">
                    <asp:DropDownList ID="SendType" runat="server" class="btn btn-info dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" AutoPostBack="true" OnTextChanged="SendType_TextChanged" required>
                        <asp:ListItem >All</asp:ListItem>
                        <asp:ListItem >Personal</asp:ListItem>
                    </asp:DropDownList>
               </div>
                  <div runat="server" id="Enroll_div">
                      <div class="small mb-1">Enrollment No:</div>
                      <div class="input-group mb-4">
                          <asp:TextBox ID="Enrollno" runat="server" class="form-control bg-light border small" placeholder="Student Enrollment No" aria-label="Search" aria-describedby="basic-addon2" AutoPostBack="true" OnTextChanged="Enrollno_TextChanged" required></asp:TextBox>
                      </div>
                  </div>

                <div runat="server" id="StudName_div">
                  <div class="small mb-1">Student Name:</div>
                  <div class="input-group mb-4">
                      <asp:TextBox ID="StudName" runat="server" class="form-control bg-light border small" placeholder="Student Name" aria-label="Search" aria-describedby="basic-addon2" ReadOnly="true" required></asp:TextBox>
                  </div>
                 </div>

                  <div class="small mb-1">Subject:</div>
                  <div class="input-group mb-4">
                     <asp:TextBox ID="Subject" runat="server" class="form-control bg-light border small" placeholder="Notice Subject" aria-label="Search" aria-describedby="basic-addon2"  required></asp:TextBox>
                  </div>

                  <div class="small mb-1">Description:</div>
                  <div class="input-group mb-0">
                    <asp:TextBox ID="Description" runat="server" class="form-control bg-light border small" placeholder="Notice Description" aria-label="Search" aria-describedby="basic-addon2" TextMode="MultiLine" Rows="8" required></asp:TextBox>
                  </div>
                  </div>
                  <div class="row justify-content-center">
                  <div class="p-3 col-xl-10 mb-4">
                      <p class="text-dark text-center mb-3 border-bottom">Attech Files <span class="small">(You can Attech Maximum 3 Files with one Notice.)</span></p>
                      <div class="small mb-1">Attech File 1:</div>
                      <div class="input-group mb-2">
                          <asp:FileUpload ID="AttechFile1" runat="server" type="button" class="btn btn-secondary col-xl-12" BorderStyle="Dotted"/>
                      </div>
                      <div class="small mb-1">Attech File 2:</div>
                      <div class="input-group mb-2">
                          <asp:FileUpload ID="AttechFile2" runat="server" type="button" class="btn btn-secondary col-xl-12" BorderStyle="Dotted"/>
                      </div>
                      <div class="small mb-1">Attech File 3:</div>
                      <div class="input-group mb-4">
                          <asp:FileUpload ID="AttechFile3" runat="server" type="button" class="btn btn-secondary col-xl-12" BorderStyle="Dotted"/>
                      </div>
                  </div>
                  </div>
                  <div class="text-center mb-4">
                      <asp:Button ID="Button1" runat="server" Text="Send Notice" class="btn btn-primary" onclick="Send_Click"/>                    
                  </div>
                </div>
              </div>
            </div>

          </div>
        </div>
        </form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="AddComplain.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Add Complain</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="slidebar" Runat="Server">

      
      <li class="nav-item">
        <a class="nav-link" href="Inbox">
          <i class="fas fa-fw fa-inbox"></i>
          <span>Inbox</span></a>
      </li>

      
      <li class="nav-item">
        <a class="nav-link" href="NoticeBox">
          <i class="fas fa-fw fa-comment"></i>
          <span>Notice Box</span></a>
      </li>

      <li class="nav-item active">
        <a class="nav-link" href="ComplainBox">
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
        Profiles
      </div>

      <li class="nav-item">
        <a class="nav-link" href="StudentProfile">
          <i class="fas fa-fw fa-user"></i>
          <span>My Profile</span></a>
      </li>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
        <form id="form1" runat="server">
        <!-- Begin Page Content -->
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Add Complain</h1>
            <p class="mt-2"><a href="ComplainBox" class="mr-4 text-secondary text-decoration-none">Complain Box</a><a href="AddComplain" class="text-danger text-decoration-none" style="border-bottom:1px solid">Add Complain</a></p>
          </div>

          <!-- Content Row -->
          <div class="row justify-content-center">

            <!-- Fade In Utility -->
            <div class="col-xl-8">

              <div class="card position-relative">
               
                <div class="card-body">

                  <div class="small mb-1">Subject:</div>
                  <div class="input-group mb-4">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control bg-light border small" placeholder="Complain Subject" aria-label="Search" aria-describedby="basic-addon2"></asp:TextBox>
                  </div>

                  <div class="small mb-1">Description:</div>
                  <div class="input-group mb-4">
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control bg-light border small" placeholder="Complain Description" aria-label="Search" aria-describedby="basic-addon2" TextMode="MultiLine" Rows=5></asp:TextBox>
                  </div>
                   <div class="text-center">
                       <asp:Button ID="Button1" runat="server" Text="Send Complain" class="btn btn-danger mt-4" OnClick="send_comp"/>
                  </div>                                  
                </div>
              </div>

            </div>

          </div>

        </div>
        <!-- /.container-fluid -->
         </form> 
</asp:Content>


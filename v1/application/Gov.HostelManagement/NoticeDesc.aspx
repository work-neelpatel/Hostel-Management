<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="NoticeDesc.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Notice Box</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slidebar" Runat="Server">

      
      <li class="nav-item">
        <a class="nav-link" href="Inbox">
          <i class="fas fa-fw fa-inbox"></i>
          <span>Inbox</span></a>
      </li>

      
      <li class="nav-item active">
        <a class="nav-link" href="NoticeBox">
          <i class="fas fa-fw fa-comment"></i>
          <span>Notice Box</span></a>
      </li>

      <li class="nav-item">
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
    <form id="form" runat=server>
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Notice Description</h1>
          </div>
          <!-- Content Row -->
          <div class="row justify-content-center">

            <div class="col-xl-8 mb-4">
              <div class="card shadow mb-4 border-left-primary">
                <div class="card-header py-3 font-weight-bold text-primary">
                    <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                    <div class="form-inline mt-2"><p ID="date" runat="server" class="text-secondary pr-2"></p><p ID="tdiff" runat="server"></p></div>
                  </div>
                <div class="card-body text-center">
                <div class="mb-3 text-secondary text-left">
                  <asp:Label ID="msg_body" runat="server"></asp:Label>  
                  </div>
                  
                  <div class="mb-2 text-dark text-center border-bottom">                            
                   <asp:Label ID="ftitle" runat="server"></asp:Label>                              
                  </div>
                  <div class="mb-4 col-lg-12">
                      <asp:Panel ID="attech_files" runat="server" class="p-t-20 p-l-20 p-r-20 list-group text-center">
                       
                       </asp:Panel>
                  
                  </div>
                  <div class="pt-3 text-left">
                            <a href="NoticeBox" class="text-decoration-none text-primary">&larr; Go Back </a>
                    </div>
                  </div>
              </div>
            </div>
          </div>
        </div>
        </form>
</asp:Content>


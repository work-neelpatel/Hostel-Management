<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="Inbox.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Inbox</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slidebar" Runat="Server">

      
      <li class="nav-item active">
        <a class="nav-link" href="Inbox">
          <i class="fas fa-fw fa-inbox"></i>
          <span>Inbox</span></a>
      </li>

      
      <li class="nav-item">
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
    <form id="form" Runat="Server">
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Notice Box</h1>
          </div>
          <p class="pt-4 text-dark text-center" runat="server" id="empty_box">No Personal Notice from Hostel.</p>

          <!-- Content Row -->
          <div class="row justify-content-center">

            <div class="col-xl-6 mb-4">

                <asp:Panel ID="NoticeBox" runat="server">
                </asp:Panel>
             
            </div>
          </div>
        </div>
  </form>
</asp:Content>
  

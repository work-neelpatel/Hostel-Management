<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="ComplainBox.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Complain Box</title>
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
<form id="form" Runat="Server">
        <div class="container-fluid">

          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Complain Box</h1>
            <p class="mt-2"><a href="ComplainBox" class="mr-4 text-danger text-decoration-none" style="border-bottom:1px solid">Complain Box</a><a href="AddComplain" class="text-secondary text-decoration-none" >Add Complain</a></p>
          </div>
          <p class="pt-4 text-dark text-center" runat="server" id="empty_box">No Complain from You, if you want to send any Complain to Hostel you can send it from <a href="AddComplain">Add Complain</a> .</p>

          <div class="row justify-content-center">

            <div class="col-xl-6 mb-4">

              <asp:Panel ID="ComplainBox" runat="server">
              </asp:Panel>

            </div>
          </div>
        </div>
        </form>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="HNoticeBox.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Notice Box</title>
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
        <a class="nav-link" href="HRequestBox">
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
<form id="form" Runat="Server">

        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Notice Box</h1>
            <p class="mt-2"><a href="HNoticeBox" class="mr-4 text-primary text-decoration-none" style="border-bottom:1px solid">Notice Box</a><a href="AddNotice" class="text-secondary text-decoration-none">Add Notice</a></p>
          </div>
          <p class="pt-4 text-dark text-center" runat="server" id="empty_box">No Notice from you, if you want to send any Notice to students then you can send from <a href="AddNotice">Add Notice</a> .</p>

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


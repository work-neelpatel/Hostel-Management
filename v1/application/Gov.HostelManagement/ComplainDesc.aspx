<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="ComplainDesc.aspx.cs" Inherits="_Default" %>

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
        <form id=form runat="server">
        <div class="container-fluid">

          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Complain Description</h1>
          </div>

          <div class="row justify-content-center">
            <div class="col-xl-8 mb-4">
              <div class="card shadow mb-4 border-left-danger">
                <div class="card-header py-3 font-weight-bold text-danger">
                    <asp:Label ID="title" runat="server" Text="Label"></asp:Label>
                    <div class="form-inline mt-2"><p ID="date" runat="server" class="text-secondary pr-2"></p><p ID="tdiff" runat="server"></p></div>
                  </div>
                <div class="card-body">
                  <asp:Label ID="content" runat="server" Text="Label" class="mb-3  text-secondary"></asp:Label>
                    <div class="mb-2 font-weight-bold text-secondary text-center border-bottom pt-3">
                        <asp:Label ID="result" runat="server" Text="Result" ></asp:Label>
                    </div>
                  
                 <div class="pt-2 text-center">
                  <asp:Label ID="accept" runat="server" Text="Complain Accepted" class="mb-2 text-success text-center"></asp:Label>
                  <asp:Label ID="denied" runat="server" Text="Complain Denied" class="mb-4 text-danger text-center"></asp:Label>
                  <asp:Label ID="pending" runat="server" Text="Result Pending.." class="mb-4 text-secondary text-center"></asp:Label>           
                 </div>

                  <div class="pt-4">
                      <a href="ComplainBox" class="text-decoration-none text-danger">&larr; Go Back </a>
                  </div>
              </div>

            </div>
          </div>
        </div>
        </div>
        </form>
</asp:Content>


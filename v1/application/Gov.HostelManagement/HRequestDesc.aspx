<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="HRequestDesc.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Request Box</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="slidebar" Runat="Server">
      
      <li class="nav-item">
        <a class="nav-link" href="MessageBox">
          <i class="fas fa-fw fa-inbox"></i>
          <span>Message Box</span></a>
      </li>

      
      <li class="nav-item">
        <a class="nav-link" href="HNoticeBox">
          <i class="fas fa-fw fa-comment"></i>
          <span>Notice Box</span></a>
      </li>

      <li class="nav-item">
        <a class="nav-link" href="HComplainBox">
          <i class="fas fa-fw fa-exclamation-triangle"></i>
          <span>Complain Box</span></a>
      </li>

      <li class="nav-item active">
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
<form id=form runat="server">
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Request Description</h1>
          </div>
          <!-- Content Row -->

          <div class="row justify-content-center">

            <div class="col-xl-8 mb-4">
              <div class="card shadow mb-4 border-left-warning">
                <div class="card-header py-3 font-weight-bold text-warning">
                    <asp:Label ID="title" runat="server" Text="Label"></asp:Label><br />
                    <asp:Label ID="sname" runat="server"></asp:Label>
                    <div class="form-inline mt-2"><p ID="date" runat="server" class="text-secondary pr-2"></p><p ID="tdiff" runat="server"></p></div>
                  </div>
                <div class="card-body">
                        <div runat="server" id="UpdateDetails_div" class="mb-2">
                            <p class="text-center border-bottom text-dark">Update Details</p>
                            <div class="form-inline" runat="server" id="ChangeMobile_div">
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label9" runat="server" Text="Old Mobile :" class="text-dark"></asp:Label>
                                  <asp:Label ID="Old_Mobile" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label6" runat="server" Text="New Mobile :" class="text-dark"></asp:Label>
                                  <asp:Label ID="New_Mobile" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                            </div>
                            <div class="form-inline" runat="server" id="ChangeEmail_div">
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label1" runat="server" Text="Old Email :" class="text-dark"></asp:Label>
                                  <asp:Label ID="Old_Email" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label3" runat="server" Text="New Email :" class="text-dark"></asp:Label>
                                  <asp:Label ID="New_Email" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                            </div>
                            <div class="form-inline" runat="server" id="ChangeREmail_div">
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label5" runat="server" Text="Old Recovery Email :" class="text-dark"></asp:Label>
                                  <asp:Label ID="Old_REmail" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                                <div class="form-inline col-6 p-0">
                                  <asp:Label ID="Label11" runat="server" Text="New Recovery Email :" class="text-dark"></asp:Label>
                                  <asp:Label ID="New_REmail" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                                </div>
                            </div>
                        </div>
                        <div runat="server" id="ChangeRoom_div" class="mb-2">
                            <p class="text-center border-bottom text-dark">Change Room Details</p>
                            <div class="form-inline">
                              <asp:Label ID="Label4" runat="server" Text="Room Holder :" class="text-dark"></asp:Label>
                              <asp:Label ID="Rholder" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                            </div>
                            <div class="form-inline">
                              <asp:Label ID="Label10" runat="server" Text="Current Room No :" class="text-dark"></asp:Label>
                              <asp:Label ID="Curr_Room_no" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                            </div>
                            <div class="form-inline">
                              <asp:Label ID="Label12" runat="server" Text="Requested Room No :" class="text-dark"></asp:Label>
                              <asp:Label ID="Req_Room_no" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                            </div>
                            <div class="form-inline">
                              <asp:Label ID="Label2" runat="server" Text="Requested Room Holder :" class="text-dark"></asp:Label>
                              <asp:Label ID="RRholder" runat="server" Text="" class="col-9 p-0 pl-1"></asp:Label>                
                            </div>
                            <div class="form-inline">
                              <asp:Label ID="Label8" runat="server" Text="Reason :" class="text-dark"></asp:Label>
                              <asp:Label ID="Change_Reason" runat="server" Text="" class="col-9 p-0 pl-1 text-capitalize"></asp:Label>                
                            </div>
                        </div>
                    <div class="mb-2 font-weight-bold text-secondary text-center border-bottom pt-3">
                        <asp:Label ID="result" runat="server" Text="Result" ></asp:Label>
                    </div>
                  
                  <div class="form-inline">
                      <div class="col-6 text-right"><asp:Button ID="Allow" runat="server" Text="Accept" class="btn btn-success" onclick="Allow_Click"/></div>
                       <div class="col-6 text-left"><asp:Button ID="Deny" runat="server" Text="Decline" class="btn btn-danger" onclick="Deny_Click"/></div>
                  </div>

                 <div class="pt-2 text-center">
                  <asp:Label ID="accept" runat="server" Text="Request Accepted" class="mb-2 text-success text-center"></asp:Label>
                  <asp:Label ID="denied" runat="server" Text="Request Declined" class="mb-4 text-danger text-center"></asp:Label>
                 </div>
                  <div class="pt-4">
                      <a href="HRequestBox" class="text-decoration-none text-warning">&larr; Go Back </a>
                  </div>
               
              </div>
            </div>
          </div>
        </div>

        </div>
        </form>
</asp:Content>


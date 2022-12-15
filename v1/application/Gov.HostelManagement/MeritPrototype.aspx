<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="MeritPrototype.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Merit Prototype</title>
    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
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

      <li class="nav-item active">
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
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Merit Prototype</h1>
            <p class="mt-2"><a href="Merit" class="mr-4 text-secondary text-decoration-none" >Merit</a><a href="MeritPrototype" class="text-info text-decoration-none" style="border-bottom:1px solid">Merit Prototype</a></p>
          </div>

            <div class="card shadow mb-4">
              <div class="card-body">
                <div class="table-responsive">
                  <table class="table table-bordered" width="100%" cellspacing="0">
                      <thead>
                      <tr align="center">
                        <th rowspan=3>Department</th>
                        <th rowspan=3>Year</th>
                        <th colspan=5>No of seats For Boys</th>
                        <th colspan=5>No of seats For Girls</th>
                      </tr>
                      <tr align=center>
                        <th colspan=4>Category Wise Allocation</th>
                        <th rowspan=2>Total</th>
                        <th colspan=4>Category Wise Allocation</th>
                        <th rowspan=2>Total</th>
                      </tr>
                      <tr align=center>
                        <th>Open</th>
                        <th>SEBC</th>
                        <th>SC</th>
                        <th>ST</th>
                        <th>Open</th>
                        <th>SEBC</th>
                        <th>SC</th>
                        <th>ST</th>
                      </tr>
                      </thead>
                    <tbody>
                                            <tr>
                                                <td align="center">
                                                    <asp:PlaceHolder ID="show_merit" runat="server"></asp:PlaceHolder>
                                                </td>
                                            </tr>
                                        </tbody>
                  </table>
                </div>
              </div>
            </div>

          </div>

</asp:Content>


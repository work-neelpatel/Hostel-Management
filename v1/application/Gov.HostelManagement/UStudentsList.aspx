<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="UStudentsList.aspx.cs" Inherits="_Default" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Requested Seats</title>

    <!-- Custom styles for this page -->
    <link href="vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    <link href="css/sb-admin-2.css" rel="stylesheet">

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

      <li class="nav-item">
        <a class="nav-link" href="Merit">
          <i class="fas fa-fw fa-list-alt"></i>
          <span>Merit</span></a>
      </li>

      <li class="nav-item active">
        <a class="nav-link" href="StudentsList">
          <i class="fas fa-fw fa-bed"></i>
          <span>Seats</span></a>
      </li>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" Runat="Server">
<form id=form runat="server">
        <div class="container-fluid">
            <div class="h5 text-center border-bottom p-0 m-0 pb-4"><a href="StudentsList" class="mr-4 text-primary text-decoration-none" style="border-bottom:1px solid">Students Seats</a><a href="#" class="text-secondary text-decoration-none">Guest Seats</a></div>
          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Requested Seats</h1>
            <p class="mt-2"><a href="StudentsList" class="mr-4 text-secondary text-decoration-none" >Allocated Seats</a><a href="UStudentsList" class="text-info text-decoration-none" style="border-bottom:1px solid">Requested Seats</a></p>
          </div>
              <div class="text-right col-xl-12 mb-4 pr-4">
                    <asp:Button ID="GenrateReport" runat="server" Text="Genrate Report" class="btn btn-primary btn-rectangle" onclick="GenrateReport_Click" />
              </div>
          <div class="card shadow mb-4">
            <div class="card-header py-3">
                <div class="form-inline font-weight-bold text-info">
                    <p class="col-xl-2">Gender</p>
                    <p class="col-xl-2">Category</p>
                    <p class="col-xl-2">Department</p>
                    <p class="col-xl-1">Year</p>
                    <p class="col-xl-5 text-right p-0">
                        <a href="StudentsList" class="btn btn-danger btn-rectangle">Clear Search History</a>
                    </p>
                </div>

                <div class="form-inline mb-3 row text-left">
                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Gender_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem> 
                            <asp:ListItem></asp:ListItem> 
                         </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Cat_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>GEN</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>OBC</asp:ListItem>
                            <asp:ListItem>ST</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Dept_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>ENG.</asp:ListItem>
                            <asp:ListItem>MEDICAL</asp:ListItem>
                            <asp:ListItem>ARTS</asp:ListItem>
                            <asp:ListItem>MENEGMENT</asp:ListItem>
                            <asp:ListItem>COMMERCE</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-1">
                        <asp:DropDownList ID="DeptYear_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem></asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-xl-5 text-right">
                        <asp:Button ID="FindSeats" runat="server" Text="Find Seats" class="btn btn-info btn-rectangle" onclick="FindSeats_Click" />
                    </div>

                </div>
            </div>
            <div class="card-body">
              <div class="table-responsive">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr>
                      <th>Student</th>
                      <th>Enrollment No</th>
                      <th>Percentage</th>
                      <th>Gender</th>
                      <th>Department</th>
                      <th>Year</th>
                      <th>Category</th>
                    </tr>
                  </thead>
                  <tfoot>
                    <tr>
                      <th>Student</th>
                      <th>Enrollment No</th>
                      <th>Percentage</th>
                      <th>Gender</th>
                      <th>Department</th>
                      <th>Year</th>
                      <th>Category</th>
                    </tr>
                  </tfoot>
                  <tbody>
                    <asp:PlaceHolder ID="Student_tbl" runat="server"></asp:PlaceHolder>
                  </tbody>
                </table>
              </div>

              <asp:Label ID="data" runat="server" Text="data" style="display:none"></asp:Label>
              <asp:Label ID="tblname" runat="server" Text="tblname" style="display:none"></asp:Label>
              <div id="Grid" style="display:none">
                      <table class="table">
                        <thead class="thead-dark">
                          <tr>
                              <th>Student</th>
                              <th>Enrollment No</th>
                              <th>Percentage</th>
                              <th>Gender</th>
                              <th>Department</th>
                              <th>Year</th>
                              <th>Category</th>
                          </tr>
                        </thead>
                        <tbody>
                           <asp:PlaceHolder ID="Student_tbl2" runat="server"></asp:PlaceHolder>
                        </tbody>                                          
                      </table>
                  </div>
                  <br />
                  <asp:HiddenField ID="hfGridHtml" runat="server" />

                  <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
                  <script type="text/javascript">
                      $(function () {
                          $("[id*=GenrateReport]").click(function () {
                              $("[id*=hfGridHtml]").val($("#Grid").html());
                          });
                      });
                  </script>

            </div>
          </div>

        </div>
        </form>
</asp:Content>



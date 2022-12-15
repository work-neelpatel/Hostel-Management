<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="Merit.aspx.cs" Inherits="_Default" ValidateRequest="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Merit</title>
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
<form id=form runat="server">
        <div class="container-fluid">

          <!-- Page Heading -->
          <div class="d-sm-flex align-items-center justify-content-between mb-4">
            <h1 class="h3 mb-0 text-gray-800">Merit</h1>
            <p class="mt-2"><a href="Merit" class="mr-4 text-info text-decoration-none" style="border-bottom:1px solid">Merit</a><a href="MeritPrototype" class="text-secondary text-decoration-none">Merit Prototype</a></p>
          </div>
          <div class="form-inline">
              <div class="text-center border p-2 mb-2 col-xl-10">
                   <p class="text-dark font-weight-bold">On the click of this Button system allocate the Hostel seats on Crieteria.</p>
                  <p class="mt-1 col-12">
                            <asp:Button ID="AllocateSeats" runat="server" Text="Allocate Seats" 
                                class="btn btn-ljcca btn-rectangle col-xl-2" onclick="AllocateSeats_Click"/>
                   </p>
              </div>
              <div class="text-right pr-4 mt-3 col-xl-2">
                            <asp:Button ID="GenrateReport" runat="server" Text="Genrate Report" class="btn btn-primary btn-rectangle" onclick="GenrateReport_Click" />
              </div>
          </div>

          <div class="card shadow mb-4">
              <div class="card-header py-3">
                <div class="form-inline font-weight-bold text-info">
                    <p class="col-xl-2">Gender</p>
                    <p class="col-xl-2">Category</p>
                    <p class="col-xl-2">Department</p>
                    <p class="col-xl-1">Year</p>
                    <p class="col-xl-2 text-danger">Unassigned Seats : <span runat="server" id="ua_seats" >0</span></p>
                    <p class="col-xl-3 pl-3">
                        <a href="Merit" class="btn btn-danger btn-rectangle col-8">Clear Search History</a>
                    </p>
                </div>

                <div class="form-inline mb-3 row text-left">
                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Gender_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem Value="male">Male</asp:ListItem>
                            <asp:ListItem Value="female">Female</asp:ListItem> 
                         </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2 ">
                        <asp:DropDownList ID="Cat_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>GEN</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>OBC</asp:ListItem>
                            <asp:ListItem>ST</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2 ">
                        <asp:DropDownList ID="Dept_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>ENG.</asp:ListItem>
                            <asp:ListItem>MEDICAL</asp:ListItem>
                            <asp:ListItem>ARTS</asp:ListItem>
                            <asp:ListItem>MENEGMENT</asp:ListItem>
                            <asp:ListItem>COMMERCE</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-1">
                        <asp:DropDownList ID="DeptYear_drpdwn" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-xl-2">
                        <asp:Button ID="FindSeats" runat="server" Text="Find Seats" 
                            class="btn btn-info btn-rectangle" onclick="FindSeats_Click"/>
                    </div>

                    <div class="input-group col-xl-2">
                        <asp:TextBox ID="AddSeats_txt" runat="server" type="number" class="form-control bg-light border-1 small" placeholder="No of Seats" aria-label="Search" aria-describedby="basic-addon2" max=120 min=1></asp:TextBox>
                    </div>

                    <div class="col-xl-1">
                        <asp:Button ID="AddSeats" runat="server" Text="Add" 
                            class="btn btn-success btn-rectangle col-12 px-0" onclick="AddSeats_Click"/>
                    </div>

                </div>
                <div class="form-inline mb-3 row text-left">
                    <div class="dropdown col-xl-2">
                         <asp:DropDownList ID="Gender_drpdwn2" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem Value="male">Male</asp:ListItem>
                                <asp:ListItem Value="female">Female</asp:ListItem>
                            </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Cat_drpdwn2" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>GEN</asp:ListItem>
                            <asp:ListItem>SC</asp:ListItem>
                            <asp:ListItem>OBC</asp:ListItem>
                            <asp:ListItem>ST</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-2">
                        <asp:DropDownList ID="Dept_drpdwn2" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                             <asp:ListItem>ENG.</asp:ListItem>
                             <asp:ListItem>MEDICAL</asp:ListItem>
                             <asp:ListItem>ARTS</asp:ListItem>
                             <asp:ListItem>MENEGMENT</asp:ListItem>
                             <asp:ListItem>COMMERCE</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="dropdown col-xl-1">
                         <asp:DropDownList ID="DeptYear_drpdwn2" runat="server" class="btn btn-secondary dropdown-toggle" type="role"  data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                        </asp:DropDownList>
                    </div>

                    <div class="col-xl-2 ">
                        <asp:Button ID="FindSeats2" runat="server" Text="Find Seats" 
                            class="btn btn-info btn-rectangle" onclick="FindSeats2_Click" />
                    </div>

                    <div class="input-group col-xl-2">
                        <asp:TextBox ID="RemoveSeats_txt" runat="server" type="number" class="form-control bg-light border-1 small" placeholder="No of Seats" aria-label="Search" aria-describedby="basic-addon2" max=120 min=1></asp:TextBox>
                    </div>

                    <div class="col-xl-1">
                        <asp:Button ID="RemoveSeats" runat="server" Text="Remove" 
                            class="btn btn-danger btn-ractengle col-12 px-0" onclick="RemoveSeats_Click" />
                    </div>
                </div>
              </div>
            <div class="card-body">
              <div class="table-responsive" id="Grid">
                <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                  <thead>
                    <tr>
                      <th>Gender</th>
                      <th>Department</th>
                      <th>Year</th>
                      <th>Category</th>
                      <th>Provided Seats</th>
                      <th>Allocated Seats</th>
                    </tr>
                  </thead>
                  <tfoot>
                    <tr>
                      <th>Gender</th>
                      <th>Department</th>
                      <th>Year</th>
                      <th>Category</th>
                      <th>Provided Seats</th>
                      <th>Allocated Seats</th>
                    </tr>
                  </tfoot>
                  <tbody>
                    <asp:PlaceHolder ID="Merit_tbl" runat="server"></asp:PlaceHolder>
                  </tbody>
                </table>
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

        </div>
        </form>
</asp:Content>


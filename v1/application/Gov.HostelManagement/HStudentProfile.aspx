<%@ Page Title="" Language="C#" MasterPageFile="HostelMaster.master" AutoEventWireup="true" CodeFile="HStudentProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Student Profile</title>
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
            <h1 class="h3 mb-0 text-gray-800">Student Profile</h1>
          </div>

          <!-- Content Row -->
          <div class="row">

            <!-- Content Column -->
            <div class="col-lg-6 mb-4">
              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Personal Details</h6>
                </div>
                <div class="card-body">
                  <div class="text-center">
                      <asp:Image ID="StudImg" runat="server" class="img-fluid px-3 px-sm-4 mt-3 mb-4" style="width: 15rem;"  alt="Student Image"/>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Name:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Name" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Enrollment No:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Enrolll_no" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Gender:</div>
                    <div class="bg-light border-0 text-dark"><asp:Label ID="Gender" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">DOB:</div>
                    <div class="bg-light border-0 text-dark"><asp:Label ID="dob" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Mobile:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Mobile" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Email:</div>
                    <div class="bg-light border-0 text-dark"><asp:Label ID="Email" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Recovery Email:</div>
                    <div class="bg-light border-0 text-dark"><asp:Label ID="REmail" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Address:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Address" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Area:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Area" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">City:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="City" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Category:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Category" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Father name:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="FName" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Father mobile:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="FMobile" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Mother name:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="MName" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Mother mobile:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="MMobile" runat="server"></asp:Label></div>
                  </div>
                  </div>
              </div>
            </div>

            <div class="col-lg-6 mb-4">

              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Education Details</h6>
                </div>
                <div class="card-body">
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">College:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="ClgName" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">College Year:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="ClgCurr_Year" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Department:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Dept" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Department Years:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Depr_Year" runat="server"></asp:Label></div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Percentage:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Percentage" runat="server"></asp:Label></div>
                  </div>
                </div>
              </div>

              <div class="card shadow mb-4">
                <div class="card-header py-3">
                  <h6 class="m-0 font-weight-bold text-primary">Hostel Details</h6>
                </div>
                <div class="card-body">

                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Room No:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="RoomNo" runat="server"></asp:Label></div>
                  </div>

                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Joined Date:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="JoinDate" runat="server"></asp:Label></div>
                  </div>

                  <div class="mb-3 form-inline" runat="server" id="Com_Req">
                    <div class="col-xl-6 mt-3 m-0">
                      <div class="card border-left-danger shadow h-100 py-2">
                        <div class="card-body">
                          <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                              <div class="text-xs font-weight-bold text-danger text-uppercase mb-1">Complains</div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-success" runat="server" id="CA"></div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-danger" runat="server" id="CD"></div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-secondary" runat="server" id="CP"></div>
                            </div>
                            <div class="col-auto">
                              <i class="fas fa-exclamation-triangle fa-2x text-gray-300"></i>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>

                    <div class="col-xl-6 mt-3">
                      <div class="card border-left-warning shadow h-100 py-2">
                        <div class="card-body">
                          <div class="row no-gutters align-items-center">
                            <div class="col mr-2">
                              <div class="text-xs font-weight-bold text-warning text-uppercase mb-1">Requests</div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-success" runat="server" id="RA"></div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-danger" runat="server" id="RD"></div>
                              <div class="h5 mb-0 font-weight-bold text-800 text-secondary" runat="server" id="RP"></div>
                            </div>
                            <div class="col-auto">
                              <i class="fas fa-comments fa-2x text-gray-300"></i>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>

                </div>
              </div>

            </div>
          </div>
        </div>
        </form>
</asp:Content>

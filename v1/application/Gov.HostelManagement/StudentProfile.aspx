<%@ Page Title="" Language="C#" MasterPageFile="StudentMaster.master" AutoEventWireup="true" CodeFile="StudentProfile.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Student Profile</title>
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

      <li class="nav-item active">
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
                      <div class="text-center">
                           <asp:Button ID="Change_details_btn" runat="server" Text="Change Details" 
                               class="btn btn-success" onclick="Change_details_btn_Click" />
                      </div>
                      <div class="text-center">
                           <asp:Button ID="SendRequest_btn2" runat="server" Text="Send Request" 
                               class="btn btn-warning" Visible="false" onclick="SendRequest_btn2_Click"/>
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
                        <asp:Label ID="Mobile" runat="server"></asp:Label>
                    </div>
                    <div class="bg-light text-dark mt-2">
                        <asp:TextBox ID="Mobile_txtbox" runat="server" type="number" class="form-control bg-light small" placeholder="New Mobile" aria-label="Search" aria-describedby="basic-addon2" Visible="false" onkeydown="limit(this,10);" onkeyup="limit(this,10);" min=10></asp:TextBox>
                    </div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Email:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="Email" runat="server"></asp:Label>
                    </div>
                    <div class="bg-light text-dark mt-2">
                        <asp:TextBox ID="Email_txtbox" runat="server" type="email" class="form-control bg-light small" placeholder="New Email" aria-label="Search" aria-describedby="basic-addon2" Visible="false" ></asp:TextBox>
                    </div>
                  </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Recovery Email:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="REmail" runat="server"></asp:Label>
                    </div>
                    <div class="bg-light text-dark mt-2">
                        <asp:TextBox ID="REmail_txtbox" runat="server" type="email" class="form-control bg-light small" placeholder="New Recovery Email" aria-label="Search" aria-describedby="basic-addon2" Visible="false"></asp:TextBox>
                    </div>
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
                  <div id="ChangeR"></div>
                  <div class="border p-3" runat="server" id="ChangeRoom" visible="false">
                      <div class="mb-3">
                        <div class="mb-1 font-weight-bold">Requested Room No:</div>
                            <div class="bg-light border-0 text-dark">
                                <asp:TextBox ID="RRno" runat="server" type="number" min=1 max=120 class="form-control bg-light border small" placeholder="Requested Room No" aria-describedby="basic-addon2" AutoPostBack="true" OnTextChanged="RRno_TextChanged" required></asp:TextBox>
                          </div>
                      </div>
                      <div class="mb-3">
                        <asp:Label class="font-weight-bold" runat="server" id="Enroll_no_lbl" visible="false"></asp:Label>
                        <div class="mb-1 font-weight-bold" runat="server" visible="false" id="RHname">Room Holder Name:</div>
                            <div class="bg-light border-0 text-dark">
                                <asp:Label ID="RHname_lbl" runat="server"></asp:Label>
                            </div>
                      </div>
                      <div class="mb-3">
                        <div class="mb-1 font-weight-bold">Reason for Room Change :</div>
                        <div class="bg-light border-0 text-dark">
                            <asp:TextBox ID="Reason" runat="server" class="form-control bg-light border small" placeholder="Reason for Room Change" aria-label="Search" aria-describedby="basic-addon2" TextMode="MultiLine" Rows=3 required></asp:TextBox>
                        </div>
                      </div>
                      <div class="text-center">
                           <asp:Button ID="SendRequest_btn" runat="server" Text="Send Request" 
                               class="btn btn-warning" onclick="SendRequest_btn_Click"/>
                      </div>
                  </div>
                      <div class="text-center mb-3">
                           <asp:Button ID="ChangeRoom_btn" runat="server" Text="Change Room" 
                               class="btn btn-success" onclick="ChangeRoom_btn_Click" />
                      </div>
                  <div class="mb-3">
                    <div class="mb-1 font-weight-bold">Joined Date:</div>
                    <div class="bg-light border-0 text-dark">
                        <asp:Label ID="JoinDate" runat="server"></asp:Label></div>
                  </div>

                  <div class="mb-3 form-inline">
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
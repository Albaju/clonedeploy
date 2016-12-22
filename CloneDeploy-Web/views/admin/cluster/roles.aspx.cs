﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloneDeploy_Web.views.admin.cluster
{
    public partial class roles : BasePages.Admin
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayRoles();
        }

        protected void btnUpdateSettings_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void ddlOperationMode_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayRoles();
        }

        private void DisplayRoles()
        {
            divRoles.Visible = ddlOperationMode.Text != "Single";
        }
    }
}
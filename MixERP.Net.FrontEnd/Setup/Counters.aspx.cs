﻿/********************************************************************************
Copyright (C) Binod Nepal, Mix Open Foundation (http://mixof.org).

This Source Code Form is subject to the terms of the Mozilla Public License, v. 2.0. 
If a copy of the MPL was not distributed  with this file, You can obtain one at 
http://mozilla.org/MPL/2.0/.
***********************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MixERP.Net.BusinessLayer.Helpers;
using MixERP.Net.Common.Helpers;
using MixERP.Net.WebControls.ScrudFactory;

namespace MixERP.Net.FrontEnd.Setup
{
    public partial class Counters : MixERP.Net.BusinessLayer.BasePageClass
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScrudForm scrud = new ScrudForm();

            scrud.KeyColumn = "counter_id";

            scrud.TableSchema = "office";
            scrud.Table = "counters";
            scrud.ViewSchema = "office";
            scrud.View = "counters";

            scrud.DisplayFields = this.GetDisplayFields();
            scrud.DisplayViews = this.GetDisplayViews();

            scrud.Text = Resources.Titles.Counters;

            ToolkitScriptManager1.NamingContainer.Controls.Add(scrud);
        }

        private string GetDisplayFields()
        {
            List<string> displayFields = new List<string>();
            ScrudHelper.AddDisplayField(displayFields, "office.cash_repositories.cash_repository_id", ConfigurationHelper.GetDbParameter("CashRepositoryDisplayField"));
            ScrudHelper.AddDisplayField(displayFields, "office.stores.store_id", ConfigurationHelper.GetDbParameter("StoreDisplayField"));
            return string.Join(",", displayFields);
        }

        private string GetDisplayViews()
        {
            List<string> displayViews = new List<string>();
            ScrudHelper.AddDisplayView(displayViews, "office.cash_repositories.cash_repository_id", "office.cash_repository_view");
            ScrudHelper.AddDisplayView(displayViews, "office.stores.store_id", "office.store_view");
            return string.Join(",", displayViews);
        }



    }
}
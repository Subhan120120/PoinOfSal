﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointOfSale
{
    public partial class FormChange : XtraForm
    {
        public decimal Cash { get; set; }
        public decimal Change { get; set; }
        public FormChange(decimal Cash, decimal Change)
        {
            InitializeComponent();
            this.Cash = Cash;
            this.Change = Change;
            AcceptButton = btn_Ok;
        }

        private void FormChange_Load(object sender, EventArgs e)
        {
            txtEdit_Cash.EditValue = Cash;
            txtEdit_Change.EditValue = Change;
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
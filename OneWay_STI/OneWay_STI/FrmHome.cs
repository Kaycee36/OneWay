﻿using OneWay;
using OneWay_STI;
using OneWayUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baby_Thesis_Test
{
    public partial class FrmHome : Form
    {
        private Form activeForm;
        private Button activeButton;
        private List<Button> buttonList = new List<Button>();

        public FrmHome()
        {
            InitializeComponent();
            inactiveButts();
        }

        public void openChildForm(Form childForm, object buttonSender)
        {
            if (activeForm != null)
            {
                activeForm.Hide();
            }

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(childForm);
            pnlContent.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

            activeButton = (Button)buttonSender;
            foreach (Button btn in buttonList)
            {
                if (btn == buttonSender)
                {
                    activeButton.BackColor = Color.FromArgb(103, 142, 184);
                }
                else
                {
                    btn.BackColor = Color.FromArgb(16, 52, 84);
                }
            }
        }

        private void inactiveButts()
        {
            buttonList.AddRange(new Button[]
            {
                btnP_FullScale, btnP_Front, btnP_Side, btnP_GazeMoto, btnP_Back
            });
        }

        private void btnP_FullScale_Click_1(object sender, EventArgs e)
        {
            openChildForm(FrmFullScale.Instance, sender);
        }

        private void btnP_Front_Click_1(object sender, EventArgs e)
        {
            openChildForm(FrmFront.Instance, sender);
        }

        private void btnP_Side_Click_1(object sender, EventArgs e)
        {
            openChildForm(FrmSide.Instance, sender);
        }

        private void btnP_Back_Click_1(object sender, EventArgs e)
        {
            openChildForm(FrmBack.Instance, sender);
        }

        private void btnP_GazeMoto_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmGazeMoto(), sender);
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            openChildForm(new FrmFullScale(), btnP_FullScale);
        }

        private void btnLogBook_Click(object sender, EventArgs e)
        {
            openChildForm(new FrmParkingInfo(), btnLogBook);
        }

        private void pbClose_MouseHover(object sender, EventArgs e)
        {
            Cursor= Cursors.Hand;
        }
        private void pbMinimize_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pbClose_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pbMinimize_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pbLogout_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }
        private void pbLogout_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pbClose_MouseClick(object sender, MouseEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to EXIT?", "Exit Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
        private void pbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbLogout_Click(object sender, EventArgs e)
        {
            //insert form sa login
        }

    }
}

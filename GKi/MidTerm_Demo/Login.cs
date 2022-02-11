using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MidTerm_Demo
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void llbSignUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUp = new SignUp();
            signUp.ShowDialog();
        }

        private void llbChangePassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.ShowDialog();
        }

        Modify modify = new Modify();
        private void btLogin_Click(object sender, EventArgs e)
        {
            string accountname = tbAccountName.Text;
            string password = tbPassword.Text;
           
            if (accountname.Trim() == "") 
            {
                errorProvider1.SetError(tbAccountName, "Thiếu tài khoản");
                errorProvider2.Clear();
                MessageBox.Show("Vui lòng nhập tài khoản");
                
            }    
            else if (password.Trim() == "") 
            {
                errorProvider2.SetError(tbPassword, "Thiếu mật khẩu");
                errorProvider1.Clear();
                MessageBox.Show("Vui lòng nhập mật khẩu");
                
            }
            else
            {
                string query = "Select * from Account where Account = '"+accountname+ "'and Password='"+password+"'";
                // string query = "Select * from TenTable where Cot1 = '"+accountname+ "'and Cot2='"+password+"'";
                if (modify.accounts(query).Count != 0)
                {
                    MessageBox.Show("Đăng nhập thành công!", " Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Form1 form1 = new Form1();
                    form1.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng, vui lòng kiểm tra lại!", " Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        /*
        private void Login_Move(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng nhập thành công!", " Thông báo ", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK) ;
            {
                notifyIcon1.ShowBalloonTip(1000, "THÔNG BÁO", "Bạn vừa đăng nhập vào hệ thông giám sát xử ký nước thải ", ToolTipIcon.Info);
            }
        }
           

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
        */
    }
}

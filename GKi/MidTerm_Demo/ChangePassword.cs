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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void tbAccountName_TextChanged(object sender, EventArgs e)
        {

        }
      

        Modify modify = new Modify();

        private void btChange_Click(object sender, EventArgs e)
        {
            string accountname = tbAccountName.Text;
            string oldpassword = tbOldPassword.Text;
            string newpassword = tbNewPassword.Text;
            if (accountname.Trim() == "") 
            {
                errorProvider1.SetError(tbAccountName, "Thiếu tài khoản");
                errorProvider2.Clear();
                errorProvider3.Clear();
                MessageBox.Show("Vui lòng nhập tài khoản cần đổi mật khẩu");
            }
            else if (oldpassword.Trim() == "") 
            {
                errorProvider2.SetError(tbOldPassword , "Thiếu mật khẩu cũ");
                errorProvider1.Clear();
                errorProvider3.Clear();
                MessageBox.Show("Vui lòng điền mật khẩu cũ");
            }
            else if (newpassword.Trim() == "") 
            {
                errorProvider3.SetError(tbNewPassword , "Thiếu mật khẩu mới");
                errorProvider2.Clear();
                errorProvider1.Clear();
                MessageBox.Show("Vui lòng điền mật khẩu mới");
            }
          
            else
            {
                string query = "Select * from Account where Account = '" + accountname + "'and Password='" + oldpassword + "'";
                if (modify.accounts(query).Count != 0)
                {
                    //try
                    //{
                        string query1 = "Update Account set Password = '" + newpassword + "' where Account ='" + accountname + "'";
                        modify.Command1(query1);
                        if (MessageBox.Show("Thay đổi thành thành công! ", "Thông báo", MessageBoxButtons.OK , MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            this.Close();
                        }
                   // }
                    //catch
                    //{
                       // MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo");
                   // }
                }
                else
                {
                    MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Thông báo");
                }
                
            }

        }

        private void btBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

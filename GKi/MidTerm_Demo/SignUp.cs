using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace MidTerm_Demo
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        public bool checkAccount(string Account) //Check account and password
        {
            return Regex.IsMatch(Account, "^[a-zA-Z0-9]");
        }

        Modify modify = new Modify();
        private void btSignUp_Click(object sender, EventArgs e)
        {
            string accountname = tbAccountName.Text;
            string password = tbPassword.Text;
            string repassword = tbRePassword.Text;

            if (!checkAccount(accountname)) 
            {
                errorProvider1.SetError(tbAccountName, "Tài khoản không hợp lệ");
                errorProvider2.Clear();
                errorProvider3.Clear();
                MessageBox.Show("Tài khoản chỉ sử dụng chữ và số, không sử dụng ký tự đặc biệt!"); 
                return; 
            }//check tk
            if (!checkAccount(password)) 
            {
                errorProvider2.SetError(tbPassword , "Mật khẩu không hợp lệ");
                errorProvider1.Clear();
                errorProvider3.Clear();
                MessageBox.Show("Mật khẩu chỉ sử dụng chữ và số, không sử dụng ký tự đặc biệt!"); 
                return; 
            }//check mk
            if (repassword != password) 
            {
                errorProvider3.SetError(tbRePassword, "Mật khẩu không trùng khớp");
                errorProvider2.Clear();
                errorProvider1.Clear();
                MessageBox.Show ("Hai mật khẩu không trùng khớp, vui lòng kiểm tra lại!");
                return; 
            }//check repass va pass

            try
            {
                string query = "Insert into Account values ('" + accountname + "','" + password + "')";
                modify.Command(query);
                if (MessageBox.Show("Đăng ký thành công!","Thông báo",MessageBoxButtons.OK ,MessageBoxIcon.Information)==DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Tài khoản đã được đăng ký, Vui lòng thử lại tài khoản khác");
            }
        }

        private void btBack_Click(object sender, EventArgs e)
        
            {
                this.Close();
            }
        
    }
}

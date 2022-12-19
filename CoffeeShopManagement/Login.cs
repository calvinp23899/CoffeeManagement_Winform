using CoffeeShopManagement;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text;
            string passWord = txbPassWord.Text;
            if (IsCheckLogin(userName, passWord))
            {
                Account loginAccount = AccountDAO.Instance.GetAccountByUserName(userName);
                TableManagement f = new TableManagement(loginAccount);
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private bool IsCheckLogin(string userName, string passWord)
        {
            return AccountDAO.Instance.Login(userName, passWord);
        }
    }
}

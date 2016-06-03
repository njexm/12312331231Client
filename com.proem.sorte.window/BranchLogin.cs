using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Branch;
using Branch.com.proem.exm.util;
using SorteClint.com.proem.sorte.window;
using log4net;

namespace Branch
{
    public partial class BranchLogin : Form
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILog log = LogManager.GetLogger(typeof(BranchLogin));

        public BranchLogin()
        {
            InitializeComponent();
        }

        private bool textbox_focus = true;

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = this.userNameTextBox.Text;
            string pass = this.userPasswordTextBox.Text;
            if (username.Equals("") || pass.Equals(""))
            {
                promptPanel.Show();
                //MessageBox.Show("用户名或者密码不能为空!");
            }
            else
            {
                //调用Md5 获取加密后的密码
                string password = MD5Util.GetMd5(pass);
                //获取数据库连接
                OracleConnection connection = OracleUtil.OpenConn();
                string queryString = "select a.password,a.id,a.name, b.id as userName from ctp_user a left join zc_user_info b on a.id=b.user_id where a.name ='" + username + "'";

                OracleCommand command = new OracleCommand(queryString);
                command.Connection = connection;

                try
                {
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        string confirmPassword = string.Format("{0}", reader["password"]);
                        if (password.Equals(confirmPassword))
                        {
                            LoginUserInfo.id = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                            LoginUserInfo.name = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                            LoginUserInfo.branchName = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                            //loadLoginUserInfo();
                            //用户名，密码验证成功
                            this.DialogResult = DialogResult.OK;

                        }
                        else
                        {
                            promptPanel.Show();
                            //MessageBox.Show("用户名或者密码输入错误,请重新输入!");
                        }
                    }
                    else
                    {
                        promptPanel.Show();
                        //MessageBox.Show("用户名或者密码输入错误,请重新输入!");
                    }
                }
                catch (Exception ex)
                {
                    log.Error("获取登录信息失败", ex);
                }
                finally
                {
                    OracleUtil.CloseConn(connection);
                }
            }
        }


        private void leaveButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void userNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void userPasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            promptPanel.Hide();
        }

        private void userNameTextBox_Click(object sender, EventArgs e)
        {
            textbox_focus = true;
        }

        private void userPasswordTextBox_Click(object sender, EventArgs e)
        {
            textbox_focus = false;
        }

        private void BranchLogin_Load(object sender, EventArgs e)
        {
            Times times = new Times();
            times.TopLevel = false;
            this.timePanel.Controls.Add(times);
            times.Show();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "1";
            }
            else
            {
                userPasswordTextBox.Text += "1";
            }
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "2";
            }
            else
            {
                userPasswordTextBox.Text += "2";
            }
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "3";
            }
            else
            {
                userPasswordTextBox.Text += "3";
            }
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "4";
            }
            else
            {
                userPasswordTextBox.Text += "4";
            }
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "5";
            }
            else
            {
                userPasswordTextBox.Text += "5";
            }
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "6";
            }
            else
            {
                userPasswordTextBox.Text += "6";
            }
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "7";
            }
            else
            {
                userPasswordTextBox.Text += "7";
            }
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "8";
            }
            else
            {
                userPasswordTextBox.Text += "8";
            }
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "9";
            }
            else
            {
                userPasswordTextBox.Text += "9";
            }
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                userNameTextBox.Text += "0";
            }
            else
            {
                userPasswordTextBox.Text += "0";
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (textbox_focus == true)
            {
                if (userNameTextBox.Text.Length > 0)
                {
                    userNameTextBox.Text = userNameTextBox.Text.Remove(userNameTextBox.Text.Length - 1, 1);
                }
            }
            else
            {
                if (userPasswordTextBox.Text.Length > 0)
                {
                    userPasswordTextBox.Text = userPasswordTextBox.Text.Remove(userPasswordTextBox.Text.Length - 1, 1);
                }
            }
        }
        
        private void clearBotton_Click(object sender, EventArgs e)
        {
            this.userNameTextBox.Clear();
            this.userPasswordTextBox.Clear();
            this.userNameTextBox.Focus();
        }

        private void BranchLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loginButton_Click(this, EventArgs.Empty);
            }
            if (e.KeyCode == Keys.Escape)
            {
                leaveButton_Click(this, EventArgs.Empty);
            }
        }

        private void userNameTextBox_TextChanged_1(object sender, EventArgs e)
        {
            promptPanel.Hide();
        }

    }
}

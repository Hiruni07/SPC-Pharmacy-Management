using System;
using System.Drawing;
using System.Windows.Forms;

namespace SPCPharmacyManagement
{
    public partial class LoginForm : Form
    {
        // Hardcoded admin credentials
        private const string ADMIN_USERNAME = "admin";
        private const string ADMIN_PASSWORD = "admin123";

        private int loginAttempts = 0;
        private const int MAX_LOGIN_ATTEMPTS = 3;

        public LoginForm()
        {
            InitializeComponent();
            InitializeFormAppearance();
        }

        private void InitializeFormAppearance()
        {
            this.BackColor = Color.FromArgb(41, 128, 185);
            txtUsername.Focus();
            SetPlaceholderText();
        }

        private void SetPlaceholderText()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Text = "Enter username";
                txtUsername.ForeColor = Color.Gray;
            }

            txtUsername.Enter += (sender, e) =>
            {
                if (txtUsername.Text == "Enter username")
                {
                    txtUsername.Text = "";
                    txtUsername.ForeColor = Color.Black;
                }
            };

            txtUsername.Leave += (sender, e) =>
            {
                if (string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtUsername.Text = "Enter username";
                    txtUsername.ForeColor = Color.Gray;
                }
            };
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            using (Pen pen = new Pen(Color.FromArgb(189, 195, 199), 2))
            {
                e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            PerformLogin();
        }

        private void PerformLogin()
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (username == "Enter username") username = "";

            if (string.IsNullOrEmpty(username))
            {
                ShowError("Please enter username.");
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                ShowError("Please enter password.");
                txtPassword.Focus();
                return;
            }

            if (username.Equals(ADMIN_USERNAME, StringComparison.OrdinalIgnoreCase) &&
                password == ADMIN_PASSWORD)
            {
                ShowSuccess("Login successful! Welcome Admin.");
                this.Hide();
                MainForm mainForm = new MainForm();
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
            }
            else
            {
                loginAttempts++;

                if (loginAttempts >= MAX_LOGIN_ATTEMPTS)
                {
                    ShowError($"Maximum login attempts exceeded. Application will close.");
                    Application.Exit();
                }
                else
                {
                    int remainingAttempts = MAX_LOGIN_ATTEMPTS - loginAttempts;
                    ShowError($"Invalid username or password. {remainingAttempts} attempt(s) remaining.");
                    txtPassword.Clear();
                    txtUsername.Focus();
                }
            }
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }

        private void txtUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PerformLogin();
                e.Handled = true;
            }
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            // ESC disabled
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.FromArgb(46, 204, 113);
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public bool IsAuthenticated { get; private set; } = false;

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }

        private void pnlMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

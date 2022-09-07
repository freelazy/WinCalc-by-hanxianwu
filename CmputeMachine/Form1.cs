namespace CmputeMachine
{
    public partial class Form1 : Form
    {
        int biaoji = 0;

        public Form1()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 点击数字事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            //判断上一步是否为 + - * /
            if (biaoji == 1)
            {
                txtResult.Text = "0";
                biaoji = 0;
            }
            //判断上一步是否为 =
            if (biaoji == 2)
            {
                txtResult.Text = "0";
                txtAlgorithm.Text = "";
                biaoji = 0;
            }
            Button btn = (Button)sender;
            //判断是否为0
            if (txtResult.Text == "0")
            {
                txtResult.Text = btn.Text;
            }
            else
            {
                txtResult.Text += btn.Text;
            }
        }
        private decimal JiSuan()
        {
            string fuhao = txtAlgorithm.Text.Substring(txtAlgorithm.Text.Length - 1);
            decimal jisuan = Convert.ToDecimal(txtAlgorithm.Text.Substring(0, txtAlgorithm.Text.Length - 1));
            decimal sr = Convert.ToDecimal(txtResult.Text);

            decimal jieguo = 0;
            switch (fuhao)
            {
                case "+": jieguo = jisuan + sr; break;
                case "-": jieguo = jisuan - sr; break;
                case "×": jieguo = jisuan * sr; break;
                case "÷": jieguo = jisuan / sr; break;
                default:
                    break;
            }
            return jieguo;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtResult.Text.Substring(txtResult.Text.Length - 1) == btnDian.Text)
            {
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
            Button btn = (Button)sender;
            //判断计算框是否不为空
            if (txtAlgorithm.Text != "")
            {
                decimal dc = JiSuan();
                txtResult.Text = dc.ToString();

            }
            txtAlgorithm.Text = txtResult.Text + btn.Text;

            //加减乘除标记为1
            biaoji = 1;
        }

        /// <summary>
        /// 点击等于事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            decimal dc = JiSuan();
            txtAlgorithm.Text = txtAlgorithm.Text + txtResult.Text + btnResult.Text;
            txtResult.Text = dc.ToString();
            biaoji = 2;
        }

        /// <summary>
        /// 退格事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYu_Click(object sender, EventArgs e)
        {
            //判断输入框长度是否为1
            if (txtResult.Text.Length == 1)
            {
                txtResult.Text = "0";
            }
            else
            {
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtResult.Text = "0";
            txtAlgorithm.Text = "";
        }

        private void btnResetResult_Click(object sender, EventArgs e)
        {
            txtResult.Text = "";
        }

        /// <summary>
        /// 点击“.”事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDian_Click(object sender, EventArgs e)
        {
            //判断输入项是否不包含“.”
            if (!txtResult.Text.Contains(btnDian.Text))
            {
                txtResult.Text += btnDian.Text;
            }
        }
    }
}
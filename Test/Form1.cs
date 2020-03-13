using System;
using System.Windows.Forms;
using VehendiMathematica;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void log(string message, int indent = 0, bool overwrite = false)
        {
            string space = "";
            for (int i = 0; i < indent; i++)
            {
                space += "   ";
            }
            if (overwrite)
                logBox.Text = space + message + Environment.NewLine;
            else
                logBox.Text += space + message + Environment.NewLine;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            try
            {
                log("Vector2コンストラクタ", 0, true);
                Vector2 vec2 = new Vector2(2, 2);
                log(vec2.ToString(), 1);
                log("Vector3コンストラクタ");
                Vector3 vec3A = new Vector3(1, 1, 0);
                log(vec3A.ToString(), 1);
                log("Vector3コンストラクタ");
                Vector3 vec3B = new Vector3(1, 1, 1);
                log(vec3B.ToString(), 1);

                log("正規化");
                vec3A.Normalize();
                log(vec3A.ToString());
                vec3B.Normalize();
                log(vec3B.ToString());
            }
            catch (Exception ex)
            {
                log(Environment.NewLine + "エラー：" + ex.GetType());
                log(ex.Message, 1);
                log("スタックトレース：");
                log(ex.StackTrace);
            }
        }
    }
}

namespace SimpleGameSaveBackuper
{
    public partial class Form1 : Form
    {

        string source = "Source Path", destination = "Destination Path";
        string[] folder;
        int interval = 20;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Settings1.Default["source_cfg"].ToString();
            source = Settings1.Default["source_cfg"].ToString();

            textBox2.Text = Settings1.Default["destination_cfg"].ToString();
            destination = Settings1.Default["destination_cfg"].ToString();

            textBox3.Text = Settings1.Default["interval_cfg"].ToString();
            //don't look at line below XD garbage code inbound
            interval = Convert.ToInt32(Settings1.Default["interval_cfg"].ToString());

            timer1.Enabled = true;
            timer1.Interval = interval * 60000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            source = textBox1.Text;
            destination = textBox2.Text;
            interval = Convert.ToInt32(textBox3.Text);
            Settings1.Default["interval_cfg"] = interval;
            Settings1.Default.Save();
            timer1.Interval = interval * 60000;
            label4.Text = "Settings Set! Interval: " + interval + " minutes -> " + interval * 60000 + " ms";
        }

        public static string OpenFolderDialog()
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    return dlg.SelectedPath;
                else
                    return string.Empty;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            source = OpenFolderDialog();
            textBox1.Text = source;
            Settings1.Default["source_cfg"] = source;
            Settings1.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            destination = OpenFolderDialog();
            textBox2.Text = destination;
            Settings1.Default["destination_cfg"] = destination;
            Settings1.Default.Save();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            CopyFilesRecursively(source, destination + @"\" + folder_slice(source) + " - " + DateTime.Now.ToString().Replace(':', '_'));
            label4.Text = "Last backup: " + DateTime.Now.ToString();
        }

        //I'm pretty sure that function below and folder_slice(source) can be avoided or done better - but guess it's good enough - hey it just works!
        public static string folder_slice(string path)
        {
            string[] folder = path.Split('\\');
            return folder[folder.Length - 1];
        }
        //Stack Overflow function below
        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CopyFilesRecursively(source, destination + @"\" + folder_slice(source) + " - " + DateTime.Now.ToString().Replace(':', '_'));
            label4.Text = "Last backup (MANUAL): " + DateTime.Now.ToString();
        }
    }
}
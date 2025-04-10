namespace DragDropFileSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtFiles_DragEnter(object sender, DragEventArgs e)
        {
            // 检查拖动的数据是否是文件
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy; // 允许复制
            }
            else
            {
                e.Effect = DragDropEffects.None; // 不允许其他操作
            }
        }

        private void txtFiles_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖放的文件路径
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // 清空 TextBox
            txtFiles.Clear();

            // 将文件路径添加到 TextBox 中
            foreach (string file in files)
            {
                txtFiles.AppendText(file + Environment.NewLine);
            }
        }
    }
}

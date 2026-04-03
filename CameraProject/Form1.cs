using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV;

namespace CameraProject
{
    public partial class Form1 : Form
    {
        //摄像机
        private VideoCapture capture;
        //图像数据结构
        private Mat frame;
        //定时器
        private Timer frameTimer;
        //相机是否连接
        private bool isCameraConnected;
        //是否正在预览
        private bool isPreviewRunning;

        public Form1()
        {
            InitializeComponent();
            InitializeCameraUi();
        }

        private void InitializeCameraUi()
        {
            // 图片自适应
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // 初始状态：未连接相机，预览按钮不可用
            isCameraConnected = false;
            isPreviewRunning = false;
            buttonOpen.Enabled = false;
            buttonColse.Enabled = false;

            // 定时更新帧
            frameTimer = new Timer();
            frameTimer.Interval = 30;
            frameTimer.Tick += FrameTimer_Tick;

            // 复用 Mat，减少频繁分配
            frame = new Mat();

            // 窗体关闭时释放资源
            this.FormClosing += Form1_FormClosing;
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (isCameraConnected)
            {
                MessageBox.Show("相机已连接。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //获取摄像头
                capture = new VideoCapture(0, VideoCapture.API.DShow);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameWidth, 640);
                capture.Set(Emgu.CV.CvEnum.CapProp.FrameHeight, 480);

                // 尝试一帧验证是否连接成成果
                using (Mat testFrame = capture.QueryFrame())
                {
                    if (testFrame == null || testFrame.IsEmpty)
                    {
                        throw new Exception("无法从相机读取画面。");
                    }
                }

                //相机接成功，开启画面和关闭画面按钮变为可用状态
                isCameraConnected = true;
                buttonOpen.Enabled = true;
                buttonColse.Enabled = true;

                MessageBox.Show("相机连接成功。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StopPreview();
                ReleaseCapture();

                isCameraConnected = false;
                buttonOpen.Enabled = false;
                buttonColse.Enabled = false;
                //相机连接失败，弹出错误提示
                MessageBox.Show("连接相机失败：" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDiscConnect_Click(object sender, EventArgs e)
        {
            if (!isCameraConnected)
            {
                return;
            }

            StopPreview();
            ReleaseCapture();
            ClearPictureBoxImage();

            isCameraConnected = false;
            buttonOpen.Enabled = false;
            buttonColse.Enabled = false;
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (!isCameraConnected || capture == null)
            {
                MessageBox.Show("请先连接相机。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (isPreviewRunning)
            {
                return;
            }

            frameTimer.Start();
            isPreviewRunning = true;
        }

        private void buttonColse_Click(object sender, EventArgs e)
        {
            StopPreview();
            //根据情况，选择是否清除画面
            //ClearPictureBoxImage();
        }

        private void FrameTimer_Tick(object sender, EventArgs e)
        {
            if (!isCameraConnected || capture == null)
            {
                return;
            }

            try
            {
                capture.Read(frame);
                if (frame == null || frame.IsEmpty)
                {
                    return;
                }

                // 每帧会创建新对象，必须释放旧图，避免内存泄露
                Bitmap newBitmap = frame.ToBitmap();
                Image oldImage = pictureBox1.Image;
                pictureBox1.Image = newBitmap;
                if (oldImage != null)
                {
                    oldImage.Dispose();
                }
            }
            catch
            {
                // 读取异常时停止预览
                StopPreview();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopPreview();
            ReleaseCapture();
            ClearPictureBoxImage();

            if (frame != null)
            {
                frame.Dispose();
                frame = null;
            }

            if (frameTimer != null)
            {
                frameTimer.Dispose();
                frameTimer = null;
            }
        }

        //关闭预览
        private void StopPreview()
        {
            if (frameTimer != null)
            {
                frameTimer.Stop();
            }
            isPreviewRunning = false;
        }

        //释放相机
        private void ReleaseCapture()
        {
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
        }

        // 清理 PictureBox 中的图像资源
        private void ClearPictureBoxImage()
        {
            if (pictureBox1.Image != null)
            {
                var old = pictureBox1.Image;
                pictureBox1.Image = null;
                old.Dispose();
            }
        }

    }
}

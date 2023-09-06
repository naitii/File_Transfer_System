using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Threading;

namespace FTS_receiver_
{
    public partial class MainWindow : Window
    {
        private TcpListener listener;
        private string savePath = "";

        public MainWindow()
        {
            InitializeComponent();
            select_folder.Visibility = (Visibility)0x64;
            ProgressBar.Visibility = (Visibility)0x64;
            path.Visibility = (Visibility)0x64;
            ip.Visibility = (Visibility)0x64;
            ProgressTextBlock.Visibility = (Visibility)0x64;
            listener = new TcpListener(IPAddress.Any, 12345);
            listener.Start();

            string IpAddress = GetLocalIPAddress();
            ip.Text += IpAddress;
        }

        private void select_folder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog browser = new FolderBrowserDialog();
            browser.ShowNewFolderButton = true;

            DialogResult res = browser.ShowDialog();

            if (res == System.Windows.Forms.DialogResult.OK)
            {
                savePath = browser.SelectedPath;
                path.Text = savePath;
            }
        }

        private async void StartListening()
        {
            while (true)
            {
                try
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Dispatcher.Invoke(() => ProgressTextBlock.Text = "Connected to sender...");

                    using (NetworkStream stream = client.GetStream())
                    {
                        byte[] fileNameBytes = new byte[1024];
                        int fileNameBytesRead = await stream.ReadAsync(fileNameBytes, 0, fileNameBytes.Length);
                        string fileName = Encoding.UTF8.GetString(fileNameBytes, 0, fileNameBytesRead);


                        fileName = string.Join("_", fileName.Split(Path.GetInvalidFileNameChars()));
                        int fl = 0;
                        for(int i= fileName.Length-1; i>=0; i--)
                        {
                            if (fileName[i] == '_' && fl == 0)
                            {
                                fileName = fileName.Remove(i, 1); 
                                fl = 1;
                            }

                            else
                            {
                                break;
                            }
                        }

                        string filePath = System.IO.Path.Combine(savePath, fileName);
                        using (FileStream fileStream = File.Create(filePath))
                        {
                            byte[] buffer = new byte[1024];
                            int bytesRead;
                            long totalBytesReceived = 0;

                            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                            {
                                await fileStream.WriteAsync(buffer, 0, bytesRead);
                                totalBytesReceived += bytesRead;

                                double progress = (double)totalBytesReceived / fileStream.Length * 100;
                                Dispatcher.Invoke(() => ProgressBar.Value = progress);
                            }
                        }

                        Dispatcher.Invoke(() => ProgressTextBlock.Text = $"Received file: {fileName}");
                    }

                    client.Close();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            }
        }


        private string GetLocalIPAddress()
        {
            string hostName = Dns.GetHostName();
            IPAddress[] addresses = Dns.GetHostAddresses(hostName);

            foreach (IPAddress address in addresses)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    return address.ToString();
                }
            }

            return "IP address not found";
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string emailAddress = emailBox.Text.Trim();

            try
            {
                MailAddress mailAddress = new MailAddress(emailAddress);
                string domain = mailAddress.Host;
                if (!domain.Contains("iitr.ac.in"))
                {
                    System.Windows.Forms.MessageBox.Show("Sorry, this Software is available for IIT Roorkee students only");
                }
                else
                {
                    select_folder.Visibility = 0;
                    ProgressBar.Visibility = 0;
                    path.Visibility = 0;
                    ip.Visibility = 0;
                    ProgressTextBlock.Visibility = 0;

                    label1.Visibility = (Visibility)0x64;
                    login.Visibility = (Visibility)0x64;
                    emailBox.Visibility = (Visibility)0x64;

                    StartListening();
                    ProgressTextBlock.Text = "Waiting For Sender.....";
                }
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Invalid email address format.");
            }
        }
    }
}

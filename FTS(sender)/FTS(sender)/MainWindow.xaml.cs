using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Net.NetworkInformation;
using System.IO;
using System.Drawing;
using System.Net.Sockets;
using System.Net;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace FTS_sender_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {

        private string serverIp = "";
        private int serverPort = 12345;
        private string filePath = "";


        public MainWindow()
        {
            InitializeComponent();
            browse.Visibility = (Visibility)0x64;
            Transfer.Visibility = (Visibility)0x64;
            path.Visibility = (Visibility)0x64;
            ProgressBar.Visibility = (Visibility)0x64;
            ProgressTextBlock.Visibility = (Visibility)0x64;

            ipAddress.Visibility = (Visibility)0x64;
        }

        private async void search_Click(object sender, RoutedEventArgs e)
        {
            serverIp = ipAddress.Text;

            using (TcpClient client = new TcpClient())
            {
                try
                {
                    await client.ConnectAsync(serverIp, serverPort);
                    ProgressTextBlock.Text = "Connected to reciever...";

                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Couldn't Connect to the Server ");

                    return;
                }
                try
                {

                    using (NetworkStream stream = client.GetStream())
                    {
                        filePath += path.Text;
                        try
                        {
                            string fileName = System.IO.Path.GetFileName(filePath);
                            StreamWriter streamWriter = new StreamWriter(stream);
                            await streamWriter.WriteLineAsync(fileName);
                            await streamWriter.FlushAsync();

                            using (FileStream fileStream = File.OpenRead(filePath))
                            {
                                byte[] buffer = new byte[1024];
                                int bytesRead;
                                long totalBytesSent = 0;

                                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    await stream.WriteAsync(buffer, 0, bytesRead);
                                    totalBytesSent += bytesRead;

                                    double progress = (double)totalBytesSent / fileStream.Length * 100;
                                    Dispatcher.Invoke(() =>
                                    {
                                        ProgressBar.Value = progress;
                                    });
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            System.Windows.Forms.MessageBox.Show(ex.ToString());
                        }
                    }

                    Dispatcher.Invoke(() =>
                    {
                        if (ProgressBar.Value == 100)
                        {
                            ProgressTextBlock.Text = "File sent successfully.";

                        }
                        else
                        {
                            ProgressTextBlock.Text = "Some error occured";
                        }
                    });
                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }



            }
        }

        private void browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "All Files|*.*",
                Title = "Select Files"
            };

            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                string[] fileNames = op.FileNames;


                path.Text = string.Join(Environment.NewLine, fileNames);
            }

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
                    System.Windows.Forms.MessageBox.Show("Sorry this Software is available for IIT Roorkee students only");
                }
                else
                {
                    browse.Visibility = 0;
                    Transfer.Visibility = 0;
                    path.Visibility = 0;
                    ProgressBar.Visibility = 0;
                    ProgressTextBlock.Visibility = 0;
                    ipAddress.Visibility = 0;

                    ProgressTextBlock.Visibility = 0;
                    label1.Visibility = (Visibility)0x64;
                    login.Visibility = (Visibility)0x64;
                    emailBox.Visibility = (Visibility)0x64;
                }

            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show("Invalid email address format.");
            }
        }


        int flag = 0;

        private void ipAddress_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (flag == 0)
            {
                ipAddress.Text = "";
                flag = 1;
            }
        }
    }
}
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelloWorldInstaller
{
    public partial class InstallerForm : Form
    {
        private bool _isBusy = false;

        private bool isBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                if (_isBusy)
                {
                    btnInstall.Enabled = false;
                    btnInitialize.Enabled = false;
                }
                else
                {
                    btnInstall.Enabled = true;
                    btnInitialize.Enabled = true;
                }
            }
        }

        public InstallerForm()
        {
            InitializeComponent();
        }

        private void Log(string text, params object[] args)
        {
            consoleTextBox.Invoke(new MethodInvoker(() =>
            {
                consoleTextBox.AppendText(String.Format(text, args));
                consoleTextBox.AppendText(Environment.NewLine);
                consoleTextBox.SelectionStart = consoleTextBox.Text.Length;
                consoleTextBox.ScrollToCaret();
            }));
        }

        private async void btnInstall_Click(object sender, EventArgs args)
        {
            try
            {
                isBusy = true;

                Log("---- {0} ----", "Installing");
                await Task.Run(() => InstallApp());
            }
            catch (Exception e)
            {
                Log("Error: Failed to install app");
                Log(e.Message);
            }
            finally
            {
                isBusy = false;
            }
        }


        private void InstallApp()
        {
            Log("Starting the installer...");

            var appxPath = Path.GetFullPath("HelloWorld.appxbundle");

            //Use the following sample if there is any dependency
            //var dependPath = Path.GetFullPath("Microsoft.VCLibs.x86.12.00.appx");
            //var arguments = String.Format("/c powershell add-appxpackage -Path {0} –DependencyPath {1}", appxPath, dependPath);

            var arguments = String.Format("/c powershell add-appxpackage -Path {0}", appxPath);
            var startInfo = new ProcessStartInfo("cmd.exe", arguments)
            {
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            var process = Process.Start(startInfo);
            process.WaitForExit(15000);

            Log("Install complete");
        }

        private void ProcessDataReceived(object sender, DataReceivedEventArgs dataReceivedEventArgs)
        {
            if (!String.IsNullOrEmpty(dataReceivedEventArgs.Data))
            {
                Log(dataReceivedEventArgs.Data);
            }
        }

        private void SetGroupPolicy()
        {
            Log("Updating group policy to allow trusted apps installation...");
            //(HKEY_LOCAL_MACHINE\Software\Policies\Microsoft\Windows\Appx\AllowAllTrustedApps = 1 )
            Process regeditProcess = Process.Start("regedit.exe", "/s " + Path.GetFullPath("GroupPolicy.reg"));
            regeditProcess.WaitForExit();
            Log("Group policy updated");
        }

        private void InstallCertificate()
        {

            Log("Installing certificate");

            var certMgr = Path.GetFullPath("certMgr.exe");
            var certFile = Path.GetFullPath("HelloWorld.cer");
            var arguments = String.Format(" /add {0} /s /r localMachine root", certFile);

            var startInfo = new ProcessStartInfo(certMgr, arguments)
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas",
                UseShellExecute = true,
                CreateNoWindow = true,
            };

            var process = Process.Start(startInfo);
            process.WaitForExit(15000);

            Log("Certificate added to trusted root");

        }

        private void AddSideLoadingKey()
        {
            //Add sideloading key if its not already added
            //Slmgr /ipk <product key>  and < slmgr /ato ec67814b-30e6-4a50-bf7b-d55daf729d1e> 
            Log("Adding sideloading key...");

            var startInfo = new ProcessStartInfo(Path.GetFullPath("sideloadingkey.bat"))
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                Verb = "runas",
                UseShellExecute = true,
                CreateNoWindow = true,
            };

            var process = Process.Start(startInfo);

            process.WaitForExit(15000);

            Log("Sideloading key added.");
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            try
            {
                isBusy = true;
                //Updating group policy to allow trusted apps installation
                SetGroupPolicy();
                //Certificate adding to trusted root
                InstallCertificate();
                //Adding sideloading key
                AddSideLoadingKey();
            }
            catch (Exception ex)
            {
                Log("Error: Failed to install app");
                Log(ex.Message);
            }
            finally
            {
                isBusy = false;
            }
        }
    }
}

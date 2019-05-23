using System;
using System.ComponentModel;
using System.IO;
using System.Net;

namespace MUnique.OpenMU.Launcher.Models
{
public class DownloadTask : IDisposable
    {
        #region Fields

        private readonly WebClient WClient = new WebClient
        {
            //Prevent proxies like Fiddler to sniff the url and contents
            Proxy = new WebProxy()
        };

        #endregion

        public bool StartedDownload { get; private set; }

        public void Dispose()
        {
            WClient?.Dispose();
            URI = null;
        }

        public void StartDownload()
        {
            if (StartedDownload)
            {
                return;
            }

            StartedDownload = true;

            if (!Directory.Exists(SaveDir))
            {
                Directory.CreateDirectory(SaveDir);
            }

            if (OnlyIfDoesntExists && File.Exists(SavePath))
            {
                Progress = 100;
                Finished = true;
                return;
            }
            else
            {
                File.Delete(SavePath);
            }

            //Console.WriteLine(URI.ToString());
            WClient.DownloadFileAsync(URI, SavePath);
        }

        #region Constructors and Destructors

        public bool OnlyIfDoesntExists { get; set; }

        public DownloadTask(Uri uri, string savePath)
        {
            URI      = uri;
            SavePath = savePath;
            SaveDir  = Path.GetDirectoryName(savePath);
            FileName = Path.GetFileName(savePath);

            if (RequireRestart)
            {
                SavePath = SavePath + ".new";
                FileName = FileName + ".new";
            }

            WClient.DownloadProgressChanged += WClient_DownloadProgressChanged;
            WClient.DownloadFileCompleted   += WClient_DownloadFileCompleted;
        }

        #endregion

        #region Public Events

        public delegate void OnDownloadCompleteDelegate(DownloadTask task);
        public delegate void OnProgressChangedDelegate(int progress);

        public event OnDownloadCompleteDelegate OnDownloadComplete;

        public event OnProgressChangedDelegate OnProgressChanged;

        #endregion

        #region Public Properties

        public string FileName { get; set; }

        public bool Finished { get; set; }

        public int Progress { get; set; }

        public string SaveDir { get; set; }

        public string SavePath { get; set; }

        public Uri URI { get; set; }

        public bool RequireRestart { get; set; } = false;

        #endregion

        #region Methods

        private void WClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Progress = 100;
            Finished = true;
            OnDownloadComplete?.Invoke(this);
        }

        private void WClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
            OnProgressChanged?.Invoke(Progress);
        }

        #endregion
    }
}
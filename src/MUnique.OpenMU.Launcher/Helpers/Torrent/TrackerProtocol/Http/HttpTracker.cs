using System;
using System.Diagnostics;
using MUnique.OpenMU.Launcher.Helpers.Torrent.Extensions;
using MUnique.OpenMU.Launcher.Helpers.Torrent.TrackerProtocol.EventArgs;
using MUnique.OpenMU.Launcher.Helpers.Torrent.TrackerProtocol.Udp.Messages;
using AnnounceMessage = MUnique.OpenMU.Launcher.Helpers.Torrent.TrackerProtocol.Http.Messages.AnnounceMessage;
using AnnounceResponseMessage = MUnique.OpenMU.Launcher.Helpers.Torrent.TrackerProtocol.Http.Messages.AnnounceResponseMessage;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.TrackerProtocol.Http
{
    /// <summary>
    ///     The HTTP tracker.
    /// </summary>
    public sealed class HttpTracker : Tracker
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="HttpTracker" /> class.
        /// </summary>
        /// <param name="trackerUri">The tracker URI.</param>
        /// <param name="peerId">The peer identifier.</param>
        /// <param name="torrentInfoHash">The torrent information hash.</param>
        /// <param name="listeningPort">The listening port.</param>
        public HttpTracker(Uri trackerUri, string peerId, string torrentInfoHash, int listeningPort)
            : base(trackerUri, peerId, torrentInfoHash, listeningPort)
        {
        }

        #endregion Public Constructors

        #region Private Methods

        /// <summary>
        ///     Gets the tracker URI.
        /// </summary>
        /// <returns>The tracker URI.</returns>
        private Uri GetUri()
        {
            string uri;

            uri = TrackerUri.ToString();
            uri += "?";
            uri += new AnnounceMessage(TorrentInfoHash, PeerId, ListeningPort, BytesUploaded, BytesDownloaded, BytesLeftToDownload, WantedPeerCount, TrackingEvent).Encode();

            return new Uri(uri);
        }

        #endregion Private Methods

        #region Protected Methods

        /// <summary>
        ///     Called when announce is requested.
        /// </summary>
        protected override void OnAnnounce()
        {
            AnnounceResponseMessage message;
            Uri uri;

            OnAnnouncing(this, System.EventArgs.Empty);

            try
            {
                uri = GetUri();

                Debug.WriteLine($"{TrackerUri} -> {uri}");

                if (AnnounceResponseMessage.TryDecode(uri.ExecuteBinaryRequest(), out message))
                {
                    Debug.WriteLine($"{TrackerUri} <- {message}");

                    UpdateInterval = message.UpdateInterval;

                    OnAnnounced(this, new AnnouncedEventArgs(message.UpdateInterval, message.LeecherCount, message.SeederCount, message.Peers));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"could not send message to HTTP tracker {TrackerUri} for torrent {TorrentInfoHash}: {ex.Message}");
            }
        }

        /// <summary>
        ///     Called when starting tracking.
        /// </summary>
        protected override void OnStart()
        {
        }

        /// <summary>
        ///     Called when stopping tracking.
        /// </summary>
        protected override void OnStop()
        {
            TrackingEvent = TrackingEvent.Stopped;

            OnAnnounce();
        }

        #endregion Protected Methods
    }
}
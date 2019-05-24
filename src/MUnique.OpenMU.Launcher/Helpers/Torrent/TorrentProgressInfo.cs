﻿using System;
using System.Collections.Generic;
using DefensiveProgrammingFramework;
using MUnique.OpenMU.Launcher.Helpers.Torrent.PeerWireProtocol;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent
{
    /// <summary>
    ///     The torrent progress info.
    /// </summary>
    public class TorrentProgressInfo
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TorrentProgressInfo" /> class.
        /// </summary>
        /// <param name="torrentInfoHash">The torrent information hash.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="completedPercentage">The completed percentage.</param>
        /// <param name="downloaded">The downloaded.</param>
        /// <param name="downloadSpeed">The download speed.</param>
        /// <param name="uploaded">The uploaded.</param>
        /// <param name="uploadSpeed">The upload speed.</param>
        /// <param name="leecherCount">The leecher count.</param>
        /// <param name="seederCount">The seeder count.</param>
        public TorrentProgressInfo(string torrentInfoHash, TimeSpan duration, decimal completedPercentage, long downloaded, decimal downloadSpeed, long uploaded,
            decimal uploadSpeed, int leecherCount, int seederCount)
        {
            torrentInfoHash.CannotBeNullOrEmpty();
            duration.MustBeGreaterThanOrEqualTo(TimeSpan.Zero);
            completedPercentage.MustBeGreaterThanOrEqualTo(0);
            downloaded.MustBeGreaterThanOrEqualTo(0);
            downloadSpeed.MustBeGreaterThanOrEqualTo(0);
            uploaded.MustBeGreaterThanOrEqualTo(0);
            uploadSpeed.MustBeGreaterThanOrEqualTo(0);
            leecherCount.MustBeGreaterThanOrEqualTo(0);
            seederCount.MustBeGreaterThanOrEqualTo(0);

            TorrentInfoHash = torrentInfoHash;
            Duration = duration;
            CompletedPercentage = completedPercentage;
            Downloaded = downloaded;
            DownloadSpeed = downloadSpeed;
            Uploaded = uploaded;
            UploadSpeed = uploadSpeed;
            LeecherCount = leecherCount;
            SeederCount = seederCount;

            Trackers = new List<TorrentTrackerInfo>();
            Peers = new List<TorrentPeerInfo>();
            Pieces = new List<PieceStatus>();
            Files = new List<TorrentFileInfo>();
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="TorrentProgressInfo" /> class from being created.
        /// </summary>
        private TorrentProgressInfo()
        {
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the completed percentage.
        /// </summary>
        /// <value>
        ///     The completed percentage.
        /// </value>
        public decimal CompletedPercentage { get; }

        /// <summary>
        ///     Gets the downloaded byte count.
        /// </summary>
        /// <value>
        ///     The downloaded byte count.
        /// </value>
        public long Downloaded { get; }

        /// <summary>
        ///     Gets the download speed in bytes per second.
        /// </summary>
        /// <value>
        ///     The download speed in bytes per second.
        /// </value>
        public decimal DownloadSpeed { get; }

        /// <summary>
        ///     Gets the duration.
        /// </summary>
        /// <value>
        ///     The duration.
        /// </value>
        public TimeSpan Duration { get; }

        /// <summary>
        ///     Gets the files.
        /// </summary>
        /// <value>
        ///     The files.
        /// </value>
        public IEnumerable<TorrentFileInfo> Files { get; }

        /// <summary>
        ///     Gets the leecher count.
        /// </summary>
        /// <value>
        ///     The leecher count.
        /// </value>
        public int LeecherCount { get; }

        /// <summary>
        ///     Gets the peers.
        /// </summary>
        /// <value>
        ///     The peers.
        /// </value>
        public IEnumerable<TorrentPeerInfo> Peers { get; }

        /// <summary>
        ///     Gets the pieces.
        /// </summary>
        /// <value>
        ///     The pieces.
        /// </value>
        public List<PieceStatus> Pieces { get; }

        /// <summary>
        ///     Gets the seeder count.
        /// </summary>
        /// <value>
        ///     The seeder count.
        /// </value>
        public int SeederCount { get; }

        /// <summary>
        ///     Gets the torrent information hash.
        /// </summary>
        /// <value>
        ///     The torrent information hash.
        /// </value>
        public string TorrentInfoHash { get; }

        /// <summary>
        ///     Gets the trackers.
        /// </summary>
        /// <value>
        ///     The trackers.
        /// </value>
        public IEnumerable<TorrentTrackerInfo> Trackers { get; }

        /// <summary>
        ///     Gets the uploaded byte count.
        /// </summary>
        /// <value>
        ///     The uploaded byte count.
        /// </value>
        public long Uploaded { get; }

        /// <summary>
        ///     Gets the upload speed in bytes per second.
        /// </summary>
        /// <value>
        ///     The upload speed in bytes per second.
        /// </value>
        public decimal UploadSpeed { get; }

        #endregion Public Properties
    }
}
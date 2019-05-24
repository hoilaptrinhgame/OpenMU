﻿using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.EventArgs
{
    /// <summary>
    ///     The torrent leeching event arguments.
    /// </summary>
    public sealed class TorrentLeechingEventArgs : System.EventArgs
    {
        #region Public Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="TorrentLeechingEventArgs" /> class.
        /// </summary>
        /// <param name="torrentInfo">The torrent information.</param>
        public TorrentLeechingEventArgs(TorrentInfo torrentInfo)
        {
            torrentInfo.CannotBeNull();

            TorrentInfo = torrentInfo;
        }

        #endregion Public Constructors

        #region Private Constructors

        /// <summary>
        ///     Prevents a default instance of the <see cref="TorrentLeechingEventArgs" /> class from being created.
        /// </summary>
        private TorrentLeechingEventArgs()
        {
        }

        #endregion Private Constructors

        #region Public Properties

        /// <summary>
        ///     Gets the torrent information.
        /// </summary>
        /// <value>
        ///     The torrent information.
        /// </value>
        public TorrentInfo TorrentInfo { get; }

        #endregion Public Properties
    }
}
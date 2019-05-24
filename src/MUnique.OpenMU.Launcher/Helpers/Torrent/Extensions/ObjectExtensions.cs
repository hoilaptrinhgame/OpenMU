﻿using System;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.Extensions
{
    /// <summary>
    ///     The object extenstions.
    /// </summary>
    public static class ObjectExtensions
    {
        #region Public Methods

        /// <summary>
        ///     Asynchronouses the specified value.
        /// </summary>
        /// <typeparam name="T">The value type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The casted value.</returns>
        /// <exception cref="System.ArgumentException">Value is of incorrect type</exception>
        public static T As<T>(this object value)
        {
            if (value is T)
            {
                return (T) value;
            }

            throw new ArgumentException("Value is of incorrect type");
        }

        #endregion Public Methods
    }
}
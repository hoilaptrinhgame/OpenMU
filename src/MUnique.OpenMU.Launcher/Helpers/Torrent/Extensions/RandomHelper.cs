﻿using System;
using System.Text;
using DefensiveProgrammingFramework;

namespace MUnique.OpenMU.Launcher.Helpers.Torrent.Extensions
{
    /// <summary>
    ///     Random helper.
    /// </summary>
    public static class RandomHelper
    {
        #region Private Fields

        /// <summary>
        ///     The random generator.
        /// </summary>
        private static readonly Random random = new Random(DateTime.UtcNow.Millisecond);

        #endregion Private Fields

        #region Public Properties

        /// <summary>
        ///     Gets the random.
        /// </summary>
        /// <value>
        ///     The random.
        /// </value>
        public static Random Random => random;

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        ///     Generates a random string with the given length.
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="stringCasing">The string casing.</param>
        /// <param name="characters">The allowed characters.</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, StringCasing stringCasing, params char[] characters)
        {
            if (characters == null ||
                characters.Length == 0)
            {
                return string.Empty;
            }

            size.MustBeGreaterThan(0);
            characters.CannotBeNullOrEmpty();

            var builder = new StringBuilder();

            for (var i = 0; i < size; i++) builder.Append(characters[random.Next(0, characters.Length - 1)]);

            return builder.ToString().ToString(stringCasing);
        }

        /// <summary>
        ///     Generates a random string with the given length.
        /// </summary>
        /// <param name="size">Size of the string</param>
        /// <param name="characters">The characters.</param>
        /// <returns>Random string</returns>
        public static string RandomString(int size, string characters)
        {
            if (string.IsNullOrEmpty(characters))
            {
                return string.Empty;
            }

            return RandomString(size, StringCasing.None, characters.ToCharArray());
        }

        #endregion Public Methods
    }
}
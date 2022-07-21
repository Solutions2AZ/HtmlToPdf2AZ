﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlToPdf2AZ.Models
{
    public class PaperFormat : PuppeteerSharp.Media.PaperFormat
    {
        public PaperFormat(decimal width, decimal height) : base(width, height)
        {
        }
        public static PaperFormat Letter => new PaperFormat(8.5m, 11);

        /// <summary>
        /// Legal: 8.5 inches by 14 inches.
        /// </summary>
        public static PaperFormat Legal => new PaperFormat(8.5m, 14);

        /// <summary>
        /// Tabloid: 11 inches by 17 inches.
        /// </summary>
        public static PaperFormat Tabloid => new PaperFormat(11, 17);

        /// <summary>
        /// Ledger: 17 inches by 11 inches.
        /// </summary>
        public static PaperFormat Ledger => new PaperFormat(17, 11);

        /// <summary>
        /// A0: 33.1 inches by 46.8 inches.
        /// </summary>
        public static PaperFormat A0 => new PaperFormat(33.1m, 46.8m);

        /// <summary>
        /// A1: 23.4 inches by 33.1 inches
        /// </summary>
        public static PaperFormat A1 => new PaperFormat(23.4m, 33.1m);

        /// <summary>
        /// A2: 16.5 inches by 23.4 inches
        /// </summary>
        public static PaperFormat A2 => new PaperFormat(16.54m, 23.4m);

        /// <summary>
        /// A3: 11.7 inches by 16.5 inches
        /// </summary>
        public static PaperFormat A3 => new PaperFormat(11.7m, 16.54m);

        /// <summary>
        /// A4: 8.27 inches by 11.7 inches
        /// </summary>
        public static PaperFormat A4 => new PaperFormat(8.27m, 11.7m);

        /// <summary>
        /// A5: 5.83 inches by 8.27 inches
        /// </summary>
        public static PaperFormat A5 => new PaperFormat(5.83m, 8.27m);

        /// <summary>
        /// A6: 4.13 inches by 5.83 inches
        /// </summary>
        public static PaperFormat A6 => new PaperFormat(4.13m, 5.83m);

    }
}

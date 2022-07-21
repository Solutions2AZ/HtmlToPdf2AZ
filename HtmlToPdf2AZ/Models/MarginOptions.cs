using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlToPdf2AZ.Models
{
    /// <summary>
    /// MarginOptions
    /// </summary>
    public class MarginOptions : PuppeteerSharp.Media.MarginOptions
    {
        /// <summary>
        /// 
        /// </summary>
        public MarginOptions()
        {
        }
        /// <summary>
        /// MarginOptions
        /// </summary>
        /// <param name="margin"></param>
        public MarginOptions(string margin)
        {
            Top = margin;
            Left = margin;
            Bottom = margin;
            Right = margin;
        }
        /// <summary>
        /// MarginOptions
        /// </summary>
        /// <param name="top"></param>
        /// <param name="left"></param>
        /// <param name="bottom"></param>
        /// <param name="right"></param>
        public MarginOptions(string top, string left, string bottom, string right)
        {
            Top = top;
            Left = left;
            Bottom = bottom;
            Right = right;
        }
    }
}

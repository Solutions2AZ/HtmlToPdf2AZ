using System;
using System.IO;
using System.Threading.Tasks;
using PuppeteerSharp;

namespace HtmlToPdf2AZ
{
    public class PdfTools
    {
        public PdfTools()
        {

        }
        /// <summary>
        /// Get PDF From HTML
        /// </summary>
        /// <param name="htmlContent">HTML Content</param>
        /// <param name="headerTemplate">
        ///  HTML template for the print footer. Should be valid HTML markup with following classes used to inject printing values into them:
        ///   <c>date</c> - formatted print date
        ///   <c>title</c> - document title
        ///   <c>url</c> - document location
        ///   <c>pageNumber</c> - current page number
        ///   <c>totalPages</c> - total pages in the document</param>
        /// <param name="footerTemplate">
        ///  HTML template for the print footer. Should be valid HTML markup with following classes used to inject printing values into them:
        ///   <c>date</c> - formatted print date
        ///   <c>title</c> - document title
        ///   <c>url</c> - document location
        ///   <c>pageNumber</c> - current page number
        ///   <c>totalPages</c> - total pages in the document</param>
        /// <param name="marginOptions">Paper margins, defaults to none</param>
        /// <param name="paperFormat">Paper format. If set, takes priority over <see cref="Width"/> and <see cref="Height"/></param>
        /// <param name="landscape">Paper orientation.. Defaults to <c>false</c></param>
        /// <param name="scale">Scale of the webpage rendering. Defaults to <c>1</c>. Scale amount must be between 0.1 and 2.</param>
        /// <returns>Stream File</returns>
        public async Task<Stream> GetPDFFromHTML(string htmlContent, string headerTemplate = "", string footerTemplate = "", Models.MarginOptions marginOptions = null, Models.PaperFormat paperFormat = null, bool landscape = false, decimal scale = 1)
        {

            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    //Headless = true,
                    //ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
                }
            );
            await using var page = await browser.NewPageAsync();
            await page.SetContentAsync(htmlContent);
            var pdfOptions = new PdfOptions()
            {
                PrintBackground = true,
                OmitBackground = true,
                Landscape = landscape,
                Scale = scale
            };
            string headerFooterPadding = "<style>#header, #footer { padding: 0 !important; }</style>";
            if (!string.IsNullOrEmpty(headerTemplate) || !string.IsNullOrEmpty(footerTemplate))
                pdfOptions.DisplayHeaderFooter = true;
            if (!string.IsNullOrEmpty(headerTemplate))
                pdfOptions.HeaderTemplate = headerFooterPadding + headerTemplate;

            if (!string.IsNullOrEmpty(footerTemplate))
                pdfOptions.FooterTemplate = headerFooterPadding + footerTemplate;

            if (marginOptions != null)
                pdfOptions.MarginOptions = marginOptions;
            if (paperFormat != null)
                pdfOptions.Format = paperFormat;
            return await page.PdfStreamAsync(pdfOptions);
        }
        /// <summary>
        /// Get PDF From URL
        /// </summary>
        /// <param name="url">Url to Download</param>
        /// <param name="headerTemplate">
        ///  HTML template for the print footer. Should be valid HTML markup with following classes used to inject printing values into them:
        ///   <c>date</c> - formatted print date
        ///   <c>title</c> - document title
        ///   <c>url</c> - document location
        ///   <c>pageNumber</c> - current page number
        ///   <c>totalPages</c> - total pages in the document</param>
        /// <param name="footerTemplate">
        ///  HTML template for the print footer. Should be valid HTML markup with following classes used to inject printing values into them:
        ///   <c>date</c> - formatted print date
        ///   <c>title</c> - document title
        ///   <c>url</c> - document location
        ///   <c>pageNumber</c> - current page number
        ///   <c>totalPages</c> - total pages in the document</param>
        /// <param name="marginOptions">Paper margins, defaults to none</param>
        /// <param name="paperFormat">Paper format. If set, takes priority over <see cref="Width"/> and <see cref="Height"/></param>
        /// <param name="landscape">Paper orientation.. Defaults to <c>false</c></param>
        /// <param name="scale">Scale of the webpage rendering. Defaults to <c>1</c>. Scale amount must be between 0.1 and 2.</param>
        /// <returns>Stream File</returns>
        public async Task<Stream> GetPDFFromURL(string url, string headerTemplate = "", string footerTemplate = "", Models.MarginOptions marginOptions = null, Models.PaperFormat paperFormat = null, bool landscape = false, decimal scale = 1)
        {

            using var browserFetcher = new BrowserFetcher();
            await browserFetcher.DownloadAsync();
            await using var browser = await Puppeteer.LaunchAsync(
                new LaunchOptions
                {
                    //Headless = true,
                    //ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
                }
            );
            await using var page = await browser.NewPageAsync();
            await page.GoToAsync(url);
            var pdfOptions = new PdfOptions()
            {
                PrintBackground = true,
                OmitBackground = true,
                Landscape = landscape,
                Scale = scale
            };
            string headerFooterPadding = "<style>#header, #footer { padding: 0 !important; }</style>";
            if (!string.IsNullOrEmpty(headerTemplate) || !string.IsNullOrEmpty(footerTemplate))
                pdfOptions.DisplayHeaderFooter = true;
            if (!string.IsNullOrEmpty(headerTemplate))
                pdfOptions.HeaderTemplate = headerFooterPadding + headerTemplate;

            if (!string.IsNullOrEmpty(footerTemplate))
                pdfOptions.FooterTemplate = headerFooterPadding + footerTemplate;

            if (marginOptions != null)
                pdfOptions.MarginOptions = marginOptions;
            if (paperFormat != null)
                pdfOptions.Format = paperFormat;
            return await page.PdfStreamAsync(pdfOptions);
        }

    }
}

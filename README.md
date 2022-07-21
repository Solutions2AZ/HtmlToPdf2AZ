# HtmlToPdf2AZ
HtmlToPdf2AZ is a simple library for generating PDFs from html or from url.

## Main methods
- **GetPDFFromHTML**: use that method to convert an HTML to Stream PDF
- **GetPDFFromURL**: use that method to convert an url content to Stream PDF

## Example of use
```csharp
		static void Main(string[] args)
        {
            var pdf = new HtmlToPdf2AZ.PdfTools();
            string outputFile = @"C:\myfile.pdf";
            string outputFile2 = @"C:\mifile2.pdf";
            var res = pdf.GetPDFFromHTML("<p style='font-size:20px;'>Hello world</p>",
                headerTemplate: "<div class=\"header\" style=\"padding: 10px; -webkit-print-color-adjust: exact; background-color: red; colour: white; width: 100%; text-align: left; font-size: 12px;\">Header goes here<br /><br /><br /> Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\" ></span></div>",
                footerTemplate: "<div class=\"footer\" style=\"padding: 10px; -webkit-print-color-adjust: exact; background-color: blue; colour: white; width: 100%; text-align: right; font-size: 12px;\">Here goes the footer<br /><br /><br /> Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\ "></span></div>",
                marginOptions: new Tools.Models.MarginOptions("50"),
                paperFormat: Tools.Models.PaperFormat.A4).Result;
            var res2 = pdf.GetPDFFromURL("https://www.google.es",
                headerTemplate: "<div class=\"header\" style=\"padding: 0 !important; edge: 0; -webkit-print-color-adjust: exact; background-color: red; colour: white; width: 100%; text-align: left; font-size: 12px;\">header of John<br /> Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\"></span></div> ",
                footerTemplate: "<div class=\"footer\" style=\"padding: 0 !important; edge: 0; -webkit-print-color-adjust: exact; background-color: blue; colour: white; width: 100%; text-align: right; font-size: 12px;\">footer of John<br /> Page <span class=\"pageNumber\"></span> of <span class=\"totalPages\"></span></div> ",
                marginOptions: new Tools.Models.MarginOptions("50"),
                paperFormat: Tools.Models.PaperFormat.A4).Result;
            SaveFileStream(outputFile, res);
            SaveFileStream(outputFile2, res2);
        }
        private static void SaveFileStream(string path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }
```
## License
MIT
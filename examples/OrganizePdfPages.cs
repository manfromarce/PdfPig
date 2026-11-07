namespace UglyToad.Examples
{
    using System;
    using System.IO;
    using PdfPig;
    using PdfPig.Content;
    using PdfPig.Writer;

    internal static class OrganizePdfPages
    {
        public static void Run(string sourcePdfPath)
        {
            using var source = PdfDocument.Open(sourcePdfPath);
            using var builder = new PdfDocumentBuilder();

            builder.AddPage(PageSize.A4);
            builder.AddPage(source, 1);
            builder.AddPage(source, 2, 1);
            builder.AddPage(PageSize.A4, 2);

            builder.MovePage(4, 2);
            builder.RemovePage(3);
            builder.DuplicatePage(1, 3);

            var result = builder.Build();
            var output = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "organizedPages.pdf");
            File.WriteAllBytes(output, result);

            Console.WriteLine($"File output to: {output}");
            Console.WriteLine("The result contains source pages and a new blank page, inserted, reordered, and duplicated.");
        }
    }
}

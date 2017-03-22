using System;
using System.IO;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace Pdf2Text
{
	class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			DateTime start = DateTime.Now;
            /*
            if (args.Length < 2)
			{
				Console.WriteLine("Usage: PDF2TEXT <input filename (PDF)> <output filename (text)>");
				return;
			}
            */


            // using (StreamWriter sw = new StreamWriter(args[1]))
            using (StreamWriter sw = new StreamWriter("output.txt"))
            {
                // sw.WriteLine(parseUsingPDFBox(args[0]));
                KamilPdfTest("Spiewnik KFC.pdf");
                // sw.WriteLine(parseUsingPDFBox("Spiewnik KFC.pdf"));
            }

			Console.WriteLine("Done. Took " + (DateTime.Now - start));

            //			Console.ReadLine();

		}

        private static void KamilPdfTest(string input)
        {
            PDDocument doc = null;

            try
            {
                doc = PDDocument.load(input);
                PDFTextStripper stripper = new PDFTextStripper();
                // stripper.getText(doc);


                Matrix line = stripper.getTextLineMatrix();
                // int page_nr = stripper.getCurrentPageNo();
                PDPage page = stripper.getCurrentPage();
                Matrix line2 = stripper.getTextMatrix();
                int char_cnt = stripper.getTotalCharCnt();

				string article_start = stripper.getArticleStart();
				string article_end = stripper.getArticleEnd();




				string pdf = stripper.getText(doc);                     // wrzuca caly tekst do sringa - dziala
                char_cnt = pdf.Length;

            }
            finally
            {
                if (doc != null)
                {
                    doc.close();
                }
            }

        }

	}
}

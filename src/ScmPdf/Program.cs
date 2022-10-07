using System.Reflection;
using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using iText.Layout;
using iText.Layout.Element;

class Program
{
  static void Main1() 
  {
    PdfDocument pdfDocument = new PdfDocument(new PdfWriter(new FileStream("c:/temp/hello1.pdf", FileMode.Create, FileAccess.Write)));
    Document document = new Document(pdfDocument);

    String line = "Hello! Welcome to iTextPdf 1";
    document.Add(new Paragraph(line));
    
    document.Close();
    Console.WriteLine("Awesome PDF just got created.");
  }
  static void Main(string[] args) 
  {
    if(args.Length < 3)
    {
        var versionString = Assembly.GetEntryAssembly()?
                                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                                .InformationalVersion
                                .ToString();

        Console.WriteLine($"mergepdf v{versionString}");
        Console.WriteLine("-------------");
        Console.WriteLine("\nUsage:");
        Console.WriteLine("  mergepdf <Novo.Pdf> <Merge1.Pdf> <Merge2.Pdf> <MergeN.Pdf>");
        
        return;
    }
    var pdfList = new List<byte[]>();

    foreach (var item in args.Skip(1))
    {
        pdfList.Add(File.ReadAllBytes(item));
    }

    File.WriteAllBytes(args[0], Combine(pdfList));

    Console.WriteLine($"PDF {args[0]} gerado com sucesso.");
  }


public static byte[] Combine(IEnumerable<byte[]> pdfs)
{
    using (var writerMemoryStream = new MemoryStream())
    {
        using (var writer = new PdfWriter(writerMemoryStream))
        {
            using (var mergedDocument = new PdfDocument(writer))
            {
                var merger = new PdfMerger(mergedDocument);

                foreach (var pdfBytes in pdfs)
                {
                    using (var copyFromMemoryStream = new MemoryStream(pdfBytes))
                    {
                        using (var reader = new PdfReader(copyFromMemoryStream))
                        {
                            using (var copyFromDocument = new PdfDocument(reader))
                            {
                                merger.Merge(copyFromDocument, 1, copyFromDocument.GetNumberOfPages());
                            }
                        }
                    }
                }
            }
        }

        return writerMemoryStream.ToArray();
    }
}


}
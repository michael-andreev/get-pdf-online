using System;
using System.IO;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using PrecizeSoft.IO.Converters;

namespace PrecizeSoft.GetPdfOnline.Cmd.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //(new PrecizeSoft.IO.Tests.Converters.LOToPdfConverterTests()).ParallelTest(@"..\..\..\precizesoft-io\tests\samples\mini.docx", 100, 2, false);

            //ConvertBytesTest(@"d:\LO-PDF\resume.docx", @"d:\LO-PDF\resume.pdf");

            //var factory = new ConverterFactory();
            //var converter = factory.CreateWcfConverterV1(new EndpointAddress("http://localhost:9436/Converter/V1/Service.svc"));
            //var converter = factory.CreateLOToPdfConverter();
            //converter.Convert(@"d:\LO-PDF\resume.docx", @"d:\LO-PDF\resume.pdf");
            /*(new Task(() => { converter.Convert(@"d:\LO-PDF\resume.docx", @"d:\LO-PDF\resume.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume2.docx", @"d:\LO-PDF\resume2.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume3.docx", @"d:\LO-PDF\resume3.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume4.docx", @"d:\LO-PDF\resume4.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume5.docx", @"d:\LO-PDF\resume5.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume6.docx", @"d:\LO-PDF\resume6.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume7.docx", @"d:\LO-PDF\resume7.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume8.docx", @"d:\LO-PDF\resume8.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume9.docx", @"d:\LO-PDF\resume9.pdf"); })).Start();
            (new Task(() => { converter.Convert(@"d:\LO-PDF\resume10.docx", @"d:\LO-PDF\resume10.pdf"); })).Start();*/
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }

        static public void ConvertBytesTest(string sourceFileName, string destinationFileName)
        {
            byte[] sourceFileBytes = File.ReadAllBytes(sourceFileName);
            string sourceFileExtension = Path.GetExtension(sourceFileName);

            LOWriterToPdfConverter converter = new LOWriterToPdfConverter();

            File.WriteAllBytes(destinationFileName, converter.Convert(sourceFileBytes, sourceFileExtension));

            FileInfo fi = new FileInfo(destinationFileName);
        }

    }
}
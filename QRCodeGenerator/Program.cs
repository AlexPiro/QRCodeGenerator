using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QRCoder;
using System.IO;

namespace QRCodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(args[0], QRCodeGenerator.ECCLevel.L);
            //QRCode qrCode = new QRCode(qrCodeData);

            PdfByteQRCode qrCode = new PdfByteQRCode(qrCodeData);
            byte[] qrCodeAsPdfByteArr = qrCode.GetGraphic(20);

            string filename = $"qr_code_{args[0]}.pdf";
            string path = @"C:\Users\Alexandre\Desktop\" + filename;
            File.WriteAllBytes(path, qrCodeAsPdfByteArr);

            Console.WriteLine("QRCode generated");
            Console.ReadKey();

        }
    }
}

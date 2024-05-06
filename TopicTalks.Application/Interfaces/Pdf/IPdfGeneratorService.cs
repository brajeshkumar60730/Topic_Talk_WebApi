using DinkToPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopicTalks.Application.Interfaces.Pdf
{
    public interface  IPdfGeneratorService
    {
        HtmlToPdfDocument CreatePdfObject(string htmlContent);
        byte[] GeneratePdf(string htmlContent);
        byte[] GeneratePdf(HtmlToPdfDocument pdf);
    }
}

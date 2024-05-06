using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopicTalks.Application.Dtos;

namespace TopicTalks.Application.Interfaces.Pdf
{
    public interface IPdfService
    {
        byte[] GenerateQuestionPdf(QuestionWithAnswersDto dto);
    }
}

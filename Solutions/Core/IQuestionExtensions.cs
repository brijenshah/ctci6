using System.ComponentModel;
using System.Linq;

namespace Core
{
    public static class IQuestionExtensions
    {
        public static QuestionAttribute Metadata(this IQuestion @question)
        {
            return (QuestionAttribute)@question.GetType().GetCustomAttributes(typeof(QuestionAttribute), true)[0];
        }
    }
}

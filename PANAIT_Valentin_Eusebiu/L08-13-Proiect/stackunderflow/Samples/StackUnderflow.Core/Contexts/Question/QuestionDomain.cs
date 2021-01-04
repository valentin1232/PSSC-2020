using Access.Primitives.IO;

using StackUnderflow.Domain.Core.Contexts.Question.ValidateQuestionOp;

using System;
using System.Collections.Generic;
using System.Text;
using static PortExt;
using LanguageExt;

using static StackUnderflow.Domain.Core.Contexts.Question.ValidateQuestionOp.ValidateQuestionResult;

namespace StackUnderflow.Domain.Core
{
    public static class QuestionDomain
    {
        public static Port<IValidateQuestionResult> ValidateQuestion(ValidateQuestionCmd command)
        {
            return NewPort<ValidateQuestionCmd, IValidateQuestionResult>(command);
        }

    }
}

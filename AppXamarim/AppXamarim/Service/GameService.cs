using AppXamarim.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.Service
{
    public class GameService
    {
        private int QuestionIndex { get; set; }
        public bool?[] Responses { get; private set; }
        public List<QuizQuestion> Questions { get; private set; }

        public QuizQuestion CurrentQuestion { get { return Questions[QuestionIndex]; } }

        public bool? CurrentResponse { get { return Responses[QuestionIndex]; } }

        public int NumberOfQuestions
        {
            get { return (Questions == null) ? 0 : Questions.Count; }
        }

        public GameService(List<QuizQuestion> questions)
        {
            Questions = questions;
            Responses = new bool?[Questions.Count];
        }

        public bool NextQuestion()
        {
            if (QuestionIndex < NumberOfQuestions - 1)
            {
                QuestionIndex++;
                return true;
            }
            return false;
        }

        public void ReStart()
        {
            QuestionIndex = 0;

            Responses = new bool?[Questions.Count];
        }

        public void OnTrue()
        {
            Responses[QuestionIndex] = true;
        }

        public void OnFalse()
        {
            Responses[QuestionIndex] = false;
        }

        public int GetNumbersOfCorrectResponse()
        {
            int count = 0;

            for (int i = 0; i <= Responses.Length; i++)
            {
                if (IsQuestionCorrect(i) == true)
                    count++;
            }
            return count;
        }

        private bool IsQuestionCorrect(int Index)
        {
            if (Index < 0 || Index >= NumberOfQuestions)
                return false;

            if (Responses[Index] == null)
                return false;

            if (Responses[Index].Value == Questions[Index].Answer)
                return true;

            return false;
        }
    }
}

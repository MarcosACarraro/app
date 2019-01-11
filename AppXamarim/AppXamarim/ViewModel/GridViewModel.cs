using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using AppXamarim.Service;
using AppXamarim.Model;

namespace AppXamarim.ViewModel
{
    public class GridViewModel : BaseViewModel
    {
        public GameService _Game { get; set; }
        IServiceNavigation _navigation;
        IServiceMessage _message;

        public GridViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
            Iniciar();
        }

        private void Iniciar()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>();
            questions.Add(new QuizQuestion { Question = "Vermelho ou Amarelo", Answer = true, Explanation = "Sem Explicação" });
            questions.Add(new QuizQuestion { Question = "Verde ou Azul", Answer = false, Explanation = "Sem Explicação" });
            questions.Add(new QuizQuestion { Question = "Preto ou Branco", Answer = true, Explanation = "Sem Explicação" });
            questions.Add(new QuizQuestion { Question = "Amarelo ou Cinza", Answer = false, Explanation = "Sem Explicação" });
            questions.Add(new QuizQuestion { Question = "Rosa ou Verd", Answer = true, Explanation = "Sem Explicação" });
            _Game = new GameService(questions);

            ReSetUI();
        }

        public ICommand btnTrueCommand
        {
            get
            {
                return new Command((value) =>
                {
                    OnAnswer(true);
                });
            }
        }

        public ICommand btnFalseCommand
        {
            get
            {
                return new Command((value) =>
                {
                    OnAnswer(false);
                });
            }
        }


        public ICommand btnNextCommand
        {
            get
            {
                return new Command((value) =>
                {
                    if (_Game.NextQuestion() == true)
                    {
                        ReSetUI();
                    }
                    else
                    {
                        //lblResultado.Text = string.Format("Voce acertou {0} de {1}", Game.GetNumbersOfCorrectResponse(), Game.NumberOfQuestions);
                    }
                });
            }
        }


        private void ReSetUI()
        {
            LblQuestion = _Game.CurrentQuestion.Question;
            LblResponse = string.Empty;
            //lblResultado.Text = string.Empty;

            //btnTrue.Enabled = true;
            //btnFalse.Enabled = true;
            //btnNext.Enabled = false;
        }

        private void OnAnswer(bool answer)
        {
            if (answer == true)
            {
                _Game.OnTrue();
            }
            else
            {
                _Game.OnFalse();
            }

            LblResponse = _Game.CurrentResponse == _Game.CurrentQuestion.Answer ? "Correct" : "Incorrect";

            //btnTrue.Enabled = false;
            //btnFalse.Enabled = false;
            //btnNext.Enabled = true;

        }



        #region Properties
        private string lblQuestion = "";
        public string LblQuestion { get { return lblQuestion; } set { this.Set("LblQuestion", ref lblQuestion, value); } }

        private string lblResponse = "";
        public string LblResponse { get { return lblResponse; } set { this.Set("LblResponse", ref lblResponse, value); } }
        #endregion
    }
}

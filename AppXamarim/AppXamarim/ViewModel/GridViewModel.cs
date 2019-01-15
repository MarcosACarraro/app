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
        readonly IServiceNavigation _navigation;
        readonly IServiceMessage _message;

        public GridViewModel(IServiceNavigation navigation, IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
            Iniciar();
        }

        private void Iniciar()
        {
            List<QuizQuestion> questions = new List<QuizQuestion>
            {
                new QuizQuestion { Question = "The Enlightenment was an intellectual movement that celebrated religious faith over reason.", Answer = true, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "Vincent van Gogh sold only one painting during his lifetime.", Answer = false, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "Fingernails and hair continue to grow after death.", Answer = true, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "Russia has the largest area of any country in the world.", Answer = false, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "The name Wall Street stems from the row(wall) of banks that greeted visitors to New York City's financial district in the 1800s", Answer = true, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "The funny bone is really a bone.", Answer = true, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "The mosquito has caused more human deaths than any other creature in history.", Answer = false, Explanation = "Sem Explicação" },
                new QuizQuestion { Question = "Carl Lewis holds the record for most individual gold medals at the Olympics.", Answer = true, Explanation = "Sem Explicação" }
            };

            _Game = new GameService(questions);

            ReSetUI();
        }

        public ICommand BtnTrueCommand
        {
            get
            {
                return new Command((value) =>
                {
                    OnAnswer(true);
                });
            }
        }

        public ICommand BtnFalseCommand
        {
            get
            {
                return new Command((value) =>
                {
                    OnAnswer(false);
                });
            }
        }


        public ICommand BtnNextCommand
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
                        string resultado = string.Format("Voce acertou {0} de {1}", _Game.GetNumbersOfCorrectResponse(), _Game.NumberOfQuestions);
                        Resultado(resultado);
                    }
                });
            }
        }

        public async void Resultado(object value)
        {
            await _navigation.NavigateToAsync<ReviewPageViewModel>(value);
        }


        private void ReSetUI()
        {
            LblQuestion = _Game.CurrentQuestion.Question;
            LblResponse = string.Empty;
            //lblResultado.Text = string.Empty;

            BtnTrueIsEnabled = true;
            BtnFalseIsEnabled = true;
            BtnNextIsEnabled = false;
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

            BtnTrueIsEnabled = false;
            BtnFalseIsEnabled = false;
            BtnNextIsEnabled = true;
        }

        #region Properties
        private string lblQuestion = "";
        public string LblQuestion { get { return lblQuestion; } set { this.Set("LblQuestion", ref lblQuestion, value); } }

        private string lblResponse = "";
        public string LblResponse { get { return lblResponse; } set { this.Set("LblResponse", ref lblResponse, value); } }

        private bool btnTrueIsEnabled = false;
        public bool BtnTrueIsEnabled { get { return btnTrueIsEnabled; } set { this.Set("BtnTrueIsEnabled", ref btnTrueIsEnabled, value); } }

        private bool btnFalseIsEnabled = false;
        public bool BtnFalseIsEnabled { get { return btnFalseIsEnabled; } set { this.Set("BtnFalseIsEnabled", ref btnFalseIsEnabled, value); } }

        private bool btnNextIsEnabled = false;
        public bool BtnNextIsEnabled { get { return btnNextIsEnabled; } set { this.Set("BtnNextIsEnabled", ref btnNextIsEnabled, value); } }
        #endregion
    }
}

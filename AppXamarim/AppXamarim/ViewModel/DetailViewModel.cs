using AppXamarim.Model;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppXamarim.ViewModel
{
    public class DetailViewModel:BaseViewModel
    {
        IServiceMessage _message;
        IServiceNavigation _navigation;

        public DetailViewModel(IServiceMessage message , IServiceNavigation navigation)
        {
            _message = message;
            _navigation = navigation;
        }

        public override Task InitializeAsync(object navigationData)
        {
            if (!string.IsNullOrEmpty(navigationData.ToString()))
            {
                DataModel model = (DataModel)navigationData;
              
                Id = model.id;
                Image = model.avatar;
                Nome = model.first_name;
                SobreNome = model.last_name;

            }
            return base.InitializeAsync(navigationData);
        }


        #region Properties

        private int id = 0;
        public int Id { get { return id; } set { this.Set("Id", ref id, value); } }

        private string image = string.Empty;
        public string Image { get { return image; } set { this.Set("Image", ref image, value); } }

        private string nome = string.Empty;
        public string Nome { get { return nome; } set { this.Set("Nome", ref nome, value); } }

        private string sobrenome = string.Empty;
        public string SobreNome { get { return sobrenome; } set { this.Set("SobreNome", ref sobrenome, value); } }

        #endregion
    }
}

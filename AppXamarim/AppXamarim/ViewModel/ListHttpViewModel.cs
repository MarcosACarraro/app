using AppXamarim.Model;
using AppXamarim.Service;
using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.ViewModel
{
    public class ListHttpViewModel:BaseViewModel
    {
        public ObservableCollection<DataModel> collection { get; set; }
        private IGetService _service;

        IServiceNavigation _navigation;
        IServiceMessage _message;

        public ListHttpViewModel(IServiceNavigation navigation, IServiceMessage message, IGetService service)
        {
            _service = service;
            _navigation = navigation;
            _message = message;
            collection = new ObservableCollection<DataModel>();
            LoadItens();
        }

        DataModel selectedItemCommand;
        public DataModel SelectedItemCommand
        {
            get
            {
                return selectedItemCommand;
            }
            set
            {
                if (selectedItemCommand != value)
                {
                    selectedItemCommand = value;
                    Detalhes(selectedItemCommand);
                }
            }
        }

        public async void LoadItens()
        {
            var itens = await _service.GetAsync();
            foreach (var item in itens.data)
            {
                collection.Add(item);
            }
        }

        public async void Detalhes(object value)
        {
            await _navigation.NavigateToAsync<DetailViewModel>(value);
        }
    }
}

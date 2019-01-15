using AppXamarim.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.Service
{
    public class MenuService
    {
        public List<MenuModel> GetItensMenu()
        {
            return new List<MenuModel>
            {
                new MenuModel { Id=1, Descricao = "Login"},
                new MenuModel { Id=2, Descricao = "Tabbed"},
                new MenuModel { Id=3, Descricao = "Animacoes"},
                new MenuModel { Id=4, Descricao = "Timer"},
                new MenuModel { Id=5, Descricao = "Camera"},
                new MenuModel { Id=6, Descricao = "Info device"},
                new MenuModel { Id=7, Descricao = "Lotties"},
                new MenuModel { Id=8, Descricao = "Httpclient ListView"},
                new MenuModel { Id=9, Descricao = "Carousel"},
                new MenuModel { Id=10, Descricao = "QUIZ"},
                new MenuModel { Id=11, Descricao = "LayOut"},
            };
        }
    }
}

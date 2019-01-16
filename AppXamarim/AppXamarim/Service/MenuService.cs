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
                new MenuModel { Id=1, Item ="Login", Descricao = "Exemplo Login"},
                new MenuModel { Id=2, Item ="Tabbed", Descricao = "Exemplo pagins  com Tabbed"},
                new MenuModel { Id=3, Item ="Animacoes", Descricao = "Exemplo de Animações"},
                new MenuModel { Id=4, Item ="Timer", Descricao = "Exemplo de Timer"},
                new MenuModel { Id=5, Item ="Camera", Descricao = "Exemplo uso dispositivo Camera"},
                new MenuModel { Id=6, Item ="Info device", Descricao = "informações do aparelho"},
                new MenuModel { Id=7, Item ="Lotties", Descricao = "Exemplo de animações Lotties"},
                new MenuModel { Id=8, Item ="Httpclient ListView", Descricao = "Exemplo consumo API"},
                new MenuModel { Id=9, Item ="Carousel", Descricao = "Exemplo de animações Imagens Carousel"},
                new MenuModel { Id=10, Item ="QUIZ", Descricao = "Questionário com respostas verdadeira ou falsa"},
                new MenuModel { Id=11, Item ="LayOut", Descricao = "Exemplo de LayOut"},
            };
        }
    }
}

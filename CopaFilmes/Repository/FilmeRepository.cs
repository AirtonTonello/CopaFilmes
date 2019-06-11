﻿using CopaFilmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CopaFilmes.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        /// <summary>
        /// Construtor da classe
        /// </summary>
        #region Construtor
        public FilmeRepository()
        {
        }
        #endregion

        /// <summary>
        /// Consome a API e retorna o IEnumerable da classe FIlme
        /// </summary>
        /// <returns></returns>
        #region GetAll()
        public IEnumerable<Filme> GetAll()
        {
            List<Filme> filmes = new List<Filme>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://copadosfilmes.azurewebsites.net");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("/api/filmes").Result;
                if (response.IsSuccessStatusCode)
                {
                    var todos = response.Content.ReadAsAsync<IEnumerable<Filme>>().Result.OrderBy(x => x.Titulo);
                    filmes = todos.ToList();
                }
            }

            return filmes;
        }
        #endregion

        /// <summary>
        /// Recebe como parametro a Classe Filme e chama a função que retorna o Vencedor
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        #region GetCampeao()
        public Filme GetCampeao(Filme model)
        {
            return GetVencedores(GetFinalistas(GetSemiFinais(model.FilmesSelecionados)));
        }
        #endregion

        /// <summary>
        /// Recebe como parametro a List de Filmes e retorna os vencedores das SemiFinais
        /// </summary>
        /// <param name="todos"></param>
        /// <returns></returns>
        #region GetSemiFinais()
        private List<string> GetSemiFinais(IList<string> todos)
        {
            List<string> SemiFinais = new List<string>();

            for (int i = 0, j = 7; i < 4; i++, j--)
            {
                if (float.Parse(todos[i].Split('-')[1]) < float.Parse(todos[j].Split('-')[1]))
                {
                    SemiFinais.Add(todos[j]);
                }
                else
                {
                    SemiFinais.Add(todos[i]);
                }
            }

            return SemiFinais;
        }
        #endregion

        /// <summary>
        /// Recebe como parametro a List de Filmes que venceu as SemiFinais e retorna os vencedores para a Final
        /// </summary>
        /// <param name="SemiFinais"></param>
        /// <returns></returns>
        #region GetFinalistas()
        private List<string> GetFinalistas(List<string> SemiFinais)
        {
            List<string> Final = new List<string>();

            for (int i = 0, j = 3; i < 2; i++, j--)
            {
                if (float.Parse(SemiFinais[i].Split('-')[1]) < float.Parse(SemiFinais[j].Split('-')[1]))
                {
                    Final.Add(SemiFinais[j]);
                }
                else
                {
                    Final.Add(SemiFinais[i]);
                }
            }

            return Final;
        }
        #endregion

        /// <summary>
        /// Recebe os dois Finalistas e retorna a Classe Filme com o Campeão e o Vice
        /// </summary>
        /// <param name="Final"></param>
        /// <returns></returns>
        #region GetVencedores()
        private Filme GetVencedores(List<string> Final)
        {
            Filme f = new Filme();

            if (float.Parse(Final[0].Split('-')[1]) < float.Parse(Final[1].Split('-')[1]))
            {
                f.Campeao = Final[1].Split('-')[0];
                f.CampeaoNota = Final[1].Split('-')[1];
                f.Vice = Final[0].Split('-')[0];
                f.ViceNota = Final[0].Split('-')[1];
            }
            else
            {
                f.Campeao = Final[0].Split('-')[0];
                f.CampeaoNota = Final[0].Split('-')[1];
                f.Vice = Final[1].Split('-')[0];
                f.ViceNota = Final[1].Split('-')[1];
            }

            return f;
        }
        #endregion
    }
}
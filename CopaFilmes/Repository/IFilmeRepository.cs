using CopaFilmes.Models;
using System.Collections.Generic;

namespace CopaFilmes.Repository
{
    public interface IFilmeRepository
    {
        IEnumerable<Filme> GetAll();
        Filme GetCampeao(Filme model);
    }
}
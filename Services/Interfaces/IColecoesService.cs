using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Project_md2.Models.Enum;
using Project_md2.Models.ViewModels;

namespace Project_md2.Services.Interfaces
{
  public interface IColecoesService
  {
    Task<bool?> CreateAsync(PostColecao colecao);
    Task<bool?> UpdateAsync(PutColecao colecao);
    Task<bool?> UpdateEstadoSistemaAsync(int id, EstadoSistema estadoSistema);
    Task<List<Colecao?>> GetAllAsync(EstadoSistema? estadoSistema);
    Task<Colecao?> GetByIdAsync(int id);
  }
}
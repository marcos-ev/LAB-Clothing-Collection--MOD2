using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Project_md2.Models.Enum;

namespace Project_md2.Database.Repositories.Interfaces
{
  public interface IModelosRepository
  {
    Task<bool?> CreateAsync(Modelo modelo);
    Task<bool?> UpdateAsync(Modelo modelo);
    Task<bool?> UpdateLayoutAsync(int id, Layout layout);
    Task<List<Modelo>> GetAllAsync(Layout? layout);
    Task<bool> CheckNomeModeloAsync(string nomeModelo);
    Task<Modelo?> GetByIdAsync(int id);
    Task<bool?> DeleteAsync(int id);
  }
}
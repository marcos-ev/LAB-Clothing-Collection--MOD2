using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Project_md2.Models.Enum;
using Project_md2.Models.ViewModels;

namespace Project_md2.Services.Interfaces
{
  public interface IModelosService
  {
    Task<bool?> CreateAsync(PostModelo modelo);
    Task<bool?> UpdateAsync(PutModelo modelo);
    Task<bool?> UpdateLayoutAsync(int id, Layout layout);
    Task<List<Modelo?>> GetAllAsync(Layout? layout);
    Task<Modelo?> GetByIdAsync(int id);
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Project_md2.Models.Enum;
using Project_md2.Models.ViewModels;

namespace Project_md2.Services.Interfaces
{
  public interface IUsuariosService
  {
    Task<bool?> CreateAsync(PostUsuario usuario);
    Task<bool?> UpdateAsync(PutUsuario usuario);
    Task<bool?> UpdateStatusAsync(int id, Status status);
    Task<List<Usuario?>> GetAllAsync(Status? status);
    Task<Usuario?> GetByIdAsync(int id);

  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models;
using Project_md2.Models.Enum;

namespace Project_md2.Database.Repositories.Interfaces
{
  public interface IUsuariosRepository
  {
    Task<bool?> CreateAsync(Usuario usuario);
    Task<bool?> UpdateAsync(Usuario usuario);
    Task<bool?> UpdateStatusAsync(int id, Status status);
    Task<List<Usuario>> GetAllAsync(Status? status);
    Task<bool> CheckCpfCnpjAsync(string cpfCnpj);
    Task<Usuario?> GetByIdAsync(int id);
    Task<bool?> DeleteAsync(int id);
  }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Database.Repositories.Interfaces;
using Project_md2.Models;
using Project_md2.Models.Enum;
using Project_md2.Models.ViewModels;
using Project_md2.Services.Interfaces;

namespace Project_md2.Services
{
  public class ModelosService : IModelosService
  {
    private readonly IModelosRepository _modelosRepository;

    public ModelosService(IModelosRepository modelosRepository)
    {
      _modelosRepository = modelosRepository;
    }

    public async Task<bool?> CreateAsync(PostModelo postModelo)
    {
      try
      {
        if (await _modelosRepository.CheckNomeModeloAsync(postModelo.NomeModelo))
          return null;

        var modelo = new Modelo
        {
          NomeModelo = postModelo.NomeModelo,
          IdColecaoRelacionada = postModelo.IdColecaoRelacionada,
          Tipo = postModelo.Tipo,
          Layout = postModelo.Layout
        };

        return await _modelosRepository.CreateAsync(modelo);
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<bool?> UpdateAsync(PutModelo putModelo)
    {
      try
      {
        var modelo = await _modelosRepository.GetByIdAsync(putModelo.Id);

        if (modelo == null)
          return null;

        if (!string.IsNullOrEmpty(putModelo.NomeModelo))
          modelo.NomeModelo = putModelo.NomeModelo;

        if (putModelo.IdColecaoRelacionada != 0)
          modelo.IdColecaoRelacionada = putModelo.IdColecaoRelacionada;

        if (Enum.IsDefined(typeof(Tipo), putModelo.Tipo))
          modelo.Tipo = putModelo.Tipo;

        if (Enum.IsDefined(typeof(Layout), putModelo.Layout))
          modelo.Layout = putModelo.Layout;

        return await _modelosRepository.UpdateAsync(modelo);
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<bool?> UpdateLayoutAsync(int id, Layout layout)
    {
      try
      {
        var modelo = await _modelosRepository.GetByIdAsync(id);

        if (modelo == null)
          return null;

        if (!Enum.IsDefined(typeof(Layout), layout))
          return null;

        return await _modelosRepository.UpdateLayoutAsync(id, layout);

      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<List<Modelo>> GetAllAsync(Layout? layout)
    {
      return await _modelosRepository.GetAllAsync(layout);
    }

    public async Task<Modelo?> GetByIdAsync(int id)
    {
      return await _modelosRepository.GetByIdAsync(id);
    }

    public Task<bool?> UpdateStatusAsync(int id, Layout layout)
    {
      throw new NotImplementedException();
    }
  }
}

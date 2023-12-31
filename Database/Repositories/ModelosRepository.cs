using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_md2.Database.Repositories.Interfaces;
using Project_md2.Models;
using Project_md2.Models.Enum;

namespace Project_md2.Database.Repositories
{
  public class ModelosRepository : IModelosRepository
  {
    private readonly FashionContext _context;

    public ModelosRepository(FashionContext modeloRepository)
    {
      _context = modeloRepository;
    }

    public async Task<bool?> CreateAsync(Modelo modelo)
    {
      try
      {
        await _context.Modelos.AddAsync(modelo);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<bool?> UpdateAsync(Modelo modelo)
    {
      try
      {
        _context.Modelos.Update(modelo);
        await _context.SaveChangesAsync();
        return true;
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
        var modelo = await GetByIdAsync(id);

        if (modelo == null)
          return null;

        modelo.Layout = layout;
        _context.Modelos.Update(modelo);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<List<Modelo>> GetAllAsync(Layout? layout)
    {
      try
      {
        if (layout == null)
          return await _context.Modelos.ToListAsync();

        return await _context.Modelos.Where(u => u.Layout == layout).ToListAsync();
      }
      catch (Exception e)
      {
        return new List<Modelo>();
      }
    }

    public async Task<bool> CheckNomeModeloAsync(string nomeModelo)
    {
      try
      {
        return await _context.Modelos.AnyAsync(u => u.NomeModelo == nomeModelo);
      }
      catch (Exception e)
      {
        return false;
      }
    }

    public async Task<Modelo?> GetByIdAsync(int id)
    {
      try
      {
        return await _context.Modelos.FindAsync(id);
      }
      catch (Exception e)
      {
        return null;
      }
    }

    public async Task<bool?> DeleteAsync(int id)
    {
      try
      {
        var modelo = await _context.Modelos.FindAsync(id);

        if (modelo == null)
          return null;

        _context.Modelos.Remove(modelo);
        await _context.SaveChangesAsync();
        return true;
      }
      catch (Exception e)
      {
        return false;
      }
    }
  }
}

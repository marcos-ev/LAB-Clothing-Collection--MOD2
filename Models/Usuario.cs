using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_md2.Models.Enum;

namespace Project_md2.Models
{
  public class Usuario : Pessoa
  {
    public const int EmailMaxLength = 100;
    public string Email { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public Status Status { get; set; }
  }
}
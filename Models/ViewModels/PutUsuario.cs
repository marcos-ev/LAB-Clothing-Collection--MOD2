using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Project_md2.Models.Enum;

namespace Project_md2.Models.ViewModels
{
  public class PutUsuario
  {
    [IgnoreDataMember]
    public int Id { get; set; }

    [Required(ErrorMessage = "O campo Nome Completo é obrigatório.")]
    public string NomeCommpleto { get; set; }

    [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo Tipo de Usuário é obrigatório.")]
    [EnumDataType(typeof(TipoUsuario), ErrorMessage = "O campo Tipo de Usuário é inválido.")]
    public TipoUsuario TipoUsuario { get; set; }
  }
}
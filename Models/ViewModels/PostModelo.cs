using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Project_md2.Models.Enum;

namespace Project_md2.Models.ViewModels
{
  public class PostModelo
  {
    [Required(ErrorMessage = "O campo Nome do Modelo é obrigatório.")]
    public string NomeModelo { get; set; }

    [Required(ErrorMessage = "O campo Id da Coleção Relacionada é obrigatório.")]
    public int IdColecaoRelacionada { get; set; }

    [Required(ErrorMessage = "O campo Tipo é obrigatório.")]
    public Tipo Tipo { get; set; }

    [Required(ErrorMessage = "O campo Layout é obrigatório.")]
    public Layout Layout { get; set; }
  }
}
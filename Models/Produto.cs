using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFex1.Models
{
public class Produto
{

[Key]
public int Id { get; set; }

[Required]
[MaxLength(120)]
public string? Nome { get; set; }

[Required]
[MaxLength(300)]
public string? Descricao { get; set; }

[Required]
[Column(TypeName = "decimal(10,2)")]
public decimal Preco { get; set; }
public int QtnEstoque { get; set; }
public int CategoriaId { get; set; } // FK
public Categoria? Categoria { get; set; }


}

}
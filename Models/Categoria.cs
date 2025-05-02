using System.ComponentModel.DataAnnotations;

namespace EFex1.Models
{
public class Categoria
{

public int Id { get; set; }

[Required]
[MaxLength(120)]
public string? Nome { get; set; }

[Required]
[MaxLength(120)]
public string? Slug { get; set; }

public List<Produto>? Produtos { get; set; }


}

}
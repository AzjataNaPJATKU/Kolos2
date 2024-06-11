using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Models;

[Table("Backpacks")]
[PrimaryKey(nameof(CharacterId), nameof(Itemid))]
public class Backpacks
{
    public int CharacterId { get; set; }
    public int Itemid { get; set; }
    public int Amount { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public Characters Characters { get; set; } = null!;
    [ForeignKey(nameof(Itemid))]
    public Items Items { get; set; } = null!;
}
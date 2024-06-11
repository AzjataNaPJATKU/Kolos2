namespace CodeFirst.DTO;

public class GetCharacterDTO
{
    public string fisrtName;
    public string lastName;
    public int CurrentWeight;
    public int MaxWeight;
    public ICollection<BackPackItemsDto> BackPackItems { get; set; } = new List<BackPackItemsDto>();
    
}
public class BackPackItemsDto
{
    public string itemName;
    public int Itemweight;
    public int amount;

}
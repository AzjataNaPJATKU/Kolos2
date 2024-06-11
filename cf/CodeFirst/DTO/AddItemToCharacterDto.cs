namespace CodeFirst.DTO;

public class AddItemToCharacterDto
{
    public int CharacteridInt;
    public ICollection<itemstoaddDto> ItemstoaddDtos = new List<itemstoaddDto>();
}

public class itemstoaddDto
{
    public int amount;
    public int itemId;
}
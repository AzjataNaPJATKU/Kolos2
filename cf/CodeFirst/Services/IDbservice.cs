using CodeFirst.Models;

namespace CodeFirst.Services;

public interface IDbservice
{
    Task<bool> DoesCharacterExists(int CharacterId);
    Task<ICollection<Characters>> GetCharacterItems(int CharacterId);
    Task<ICollection<Titles>> GetCharacterTitles(int CharacterId);
    Task<bool> DoesItemExist(int ItemId);
    Task addToBackpack(int IdCharacter, int IdItem, int Amount);

}
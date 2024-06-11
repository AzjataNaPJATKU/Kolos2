using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CodeFirst.Services;

public class Dbservice : IDbservice
{
    private readonly ApplicationContext _context;
    public Dbservice(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesCharacterExists(int CharacterId)
    {
        return await _context.Characters.Where(characters => characters.Id == CharacterId).AnyAsync();
    }

    public async Task<ICollection<Characters>> GetCharacterItems(int CharacterId)
    {
        return await _context.Characters
            .Include(e => e.Backpacks)
            .ThenInclude(e => e.Items)
            .Where(e => e.Id == CharacterId)
            .ToListAsync();
    }

    public Task<ICollection<Titles>> GetCharacterTitles(int CharacterId)
    {
        //TODO
        throw new NotImplementedException();
    }

    public async Task<bool> DoesItemExist(int ItemId)
    {
        return await _context.Items.Where(items => items.Id == ItemId).AnyAsync();
    }

    public async Task addToBackpack(int IdCharacter, int IdItem, int Amount)
    {
        var backitems = new Backpacks();
        backitems.CharacterId = IdCharacter;
        backitems.Itemid = IdItem;
        backitems.Amount = Amount;
        
        await _context.AddRangeAsync(backitems);
        await _context.SaveChangesAsync();
    }
}
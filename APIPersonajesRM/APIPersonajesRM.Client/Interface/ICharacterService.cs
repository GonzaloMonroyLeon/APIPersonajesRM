using APIPersonajesRM.Shared.Models;

namespace APIPersonajesRM.Client.Services
{
    public interface ICharacterService
    {
        Task<Characters> GetCharactersAsync();
    }
}


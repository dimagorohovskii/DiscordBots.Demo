using RolePlay.Common.Game.Contracts;
using System.Collections.Generic;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="ICharItem"/> objects
    /// </summary>
    public interface ICharItemRepository : ICommonRepositoryExt<ulong, ICharItem>
    {
        /// <summary>
        /// Get all character items
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <param name="storageId">Storage ID or <see langword="null"/>, if you need items from the character's inventory</param>
        /// <returns>Items owned by the character</returns>
        public IReadOnlyCollection<ICharItem> GetCharacterItems(ulong characterId, long? storageId);
    }
}

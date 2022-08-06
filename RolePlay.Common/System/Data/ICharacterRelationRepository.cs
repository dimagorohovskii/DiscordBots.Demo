using RolePlay.Common.Game.Contracts;
using System.Collections.Generic;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="ICharacterRelation"/> objects
    /// </summary>
    public interface ICharacterRelationRepository : ICommonRepositoryExt<ulong, ICharacterRelation>
    {
        /// <summary>
        /// Get all relationships of a character with other characters
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <returns>Received relationship indicators</returns>
        public IReadOnlyCollection<ICharacterRelation> GetCharacterRelations(ulong characterId);
    }
}

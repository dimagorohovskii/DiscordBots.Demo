using RolePlay.Common.Game.Contracts;
using System.Collections.Generic;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="IFractionRelation"/> objects
    /// </summary>
    public interface IFractionRelationRepository : ICommonRepositoryExt<ulong, IFractionRelation>
    {
        /// <summary>
        /// Get all relationships of a character with fractions
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <returns>Received relationship indicators</returns>
        public IReadOnlyCollection<IFractionRelation> GetCharacterFractionRelations(ulong characterId);
    }
}

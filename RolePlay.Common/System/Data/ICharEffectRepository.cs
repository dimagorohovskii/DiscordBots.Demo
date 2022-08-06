using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;
using System.Collections.Generic;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="ICharEffect"/> objects
    /// </summary>
    public interface ICharEffectRepository : ICommonRepositoryExt<ulong, ICharEffect>
    {
        /// <summary>
        /// Check temporary effects and remove if expired
        /// </summary>
        public void CheckTempEffects();
        /// <summary>
        /// Get all character effects
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <returns>All character effects</returns>
        public IReadOnlyCollection<ICharEffect> GetCharacterSkills(ulong characterId);
    }
}

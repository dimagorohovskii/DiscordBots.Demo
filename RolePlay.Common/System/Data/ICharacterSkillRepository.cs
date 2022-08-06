using RolePlay.Common.Game.Contracts;
using System.Collections.Generic;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="ICharacterSkill"/> objects
    /// </summary>
    public interface ICharacterSkillRepository : ICommonRepositoryExt<ulong, ICharacterSkill>
    {
        /// <summary>
        /// Get all character skills
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <returns>All dynamic character skills</returns>
        public IReadOnlyCollection<ICharacterSkill> GetCharacterSkills(ulong characterId);
    }
}

using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;
using System;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Character skill
    /// </summary>
    public class CharacterSkill : ChangeableObject, ICharacterSkill
    {
        #region Properties
        public ulong Id { get; set; }

        public long SkillId { get; set; }

        public ulong CharacterId { get; set; }

        public long Exp { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Build character skill
        /// </summary>
        /// <param name="id">Character skill ID</param>
        /// <param name="skillId">Skill ID</param>
        /// <param name="characterId">Character ID</param>
        /// <param name="exp">Skill experience</param>
        /// <exception cref="ArgumentNullException"></exception>
        public CharacterSkill(ulong id, long skillId, ulong characterId, long exp)
        {
            Id = id;
            SkillId = skillId;
            CharacterId = characterId;
            Exp = exp;
        }
        #endregion
    }
}

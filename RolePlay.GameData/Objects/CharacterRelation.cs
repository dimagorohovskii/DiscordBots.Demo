using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Relationship with the character
    /// </summary>
    public class CharacterRelation : ChangeableObject, ICharacterRelation
    {
        #region Properties
        public ulong Id { get; set; }

        public ulong CharacterId { get; }

        public ulong NPCUid { get; }

        public int Value { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Generate a new indicator of relationship with the character
        /// </summary>
        /// <param name="id">Relationship ID</param>
        /// <param name="characterId">Player ID</param>
        /// <param name="nPCUid">NPC ID</param>
        /// <param name="value">Relationship value</param>
        public CharacterRelation(ulong id, ulong characterId, ulong nPCUid, int value)
        {
            Id = id;
            CharacterId = characterId;
            NPCUid = nPCUid;
            Value = value;
        }
        #endregion
    }
}

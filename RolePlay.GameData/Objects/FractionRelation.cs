using RolePlay.Common.Game.Contracts;
using RolePlay.GameData.System;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Faction relationship indicator
    /// </summary>
    public class FractionRelation : ChangeableObject, IFractionRelation
    {
        #region Properties
        public ulong Id { get; set; }

        public ulong CharacterId { get; }

        public long FractionId { get; }

        public int Value { get; set; }

        public int Reputation { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Form a new indicator of relations with the faction
        /// </summary>
        /// <param name="id">Relationship ID</param>
        /// <param name="characterId">Player ID</param>
        /// <param name="fractionId">Faction ID</param>
        /// <param name="value">Relationship value</param>
        /// <param name="reputation">Reputation value</param>
        public FractionRelation(ulong id, ulong characterId, long fractionId, int value, int reputation)
        {
            Id = id;
            CharacterId = characterId;
            FractionId = fractionId;
            Value = value;
            Reputation = reputation;
        }
        #endregion
    }
}

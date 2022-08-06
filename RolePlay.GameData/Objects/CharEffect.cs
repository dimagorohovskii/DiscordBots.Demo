using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.GameData.System;
using System;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Effect on the character
    /// </summary>
    public class CharEffect : ChangeableObject, ICharEffect
    {
        #region Properties
        public ulong Id { get; set; }

        public int EffectId { get; }

        public ulong CharacterId { get; }

        public DateTime? EndTime { get; set; }

        public double? Value { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Generate character effect
        /// </summary>
        /// <param name="id">Character effect ID</param>
        /// <param name="effectId">Effect ID</param>
        /// <param name="characterId">Owner character ID</param>
        /// <param name="endTime">End time, if any</param>
        /// <param name="value">Effect value, if any</param>
        public CharEffect(ulong id, int effectId, ulong characterId, DateTime? endTime, double? value)
        {
            Id = id;
            EffectId = effectId;
            CharacterId = characterId;
            EndTime = endTime;
            Value = value;
        }
        #endregion
    }
}

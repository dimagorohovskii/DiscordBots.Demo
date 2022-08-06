using System.Collections.Generic;

namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// General rules of battles
    /// </summary>
    public interface IFightMechanicsRules
    {
        /// <summary>
        /// Base min damage
        /// </summary>
        public int MinDamage { get; }
        /// <summary>
        /// Base max damage
        /// </summary>
        public int MaxDamage { get; }
        /// <summary>
        /// Get protection level for modifiers
        /// </summary>
        /// <param name="modifiers">Enumerable of modifiers</param>
        /// <returns>Calculated protection level</returns>
        public int GetDefenceForModifiers(IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get max step distance for modifiers
        /// </summary>
        /// <param name="modifiers">Enumerable of modifiers</param>
        /// <returns>Maximum step distance</returns>
        public int GetMaxStepDistance(IEnumerable<ICharModifier> modifiers);
    }
}

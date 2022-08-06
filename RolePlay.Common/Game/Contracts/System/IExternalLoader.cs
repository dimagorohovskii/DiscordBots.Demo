using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Contracts.Mechanics;
using System.Collections.Generic;

namespace RolePlay.Common.Game.Contracts.System
{
    /// <summary>
    /// Service that receives game objects from external libraries
    /// </summary>
    public interface IExternalLoader
    {
        /// <summary>
        /// Get all game effects
        /// </summary>
        /// <returns>Generated effects dictionary</returns>
        public IReadOnlyDictionary<int, IEffect> GetGameEffects();
        /// <summary>
        /// Get all game factions
        /// </summary>
        /// <returns>Generated factions dictionary</returns>
        public IReadOnlyDictionary<long, IFraction> GetGameFractions();
        /// <summary>
        /// Get all game items
        /// </summary>
        /// <returns>Generated items dictionary</returns>
        public IReadOnlyDictionary<int, IItem> GetGameItems();
        /// <summary>
        /// Get all NPCs
        /// </summary>
        /// <returns>Generated NPCs dictionary</returns>
        public IReadOnlyDictionary<ulong, INPC> GetGameNPCs();
        /// <summary>
        /// Get all game dynamic skills
        /// </summary>
        /// <returns>Generated dynamic skills dictionary</returns>
        public IReadOnlyDictionary<long, ISkill> GetGameSkills();
        /// <summary>
        /// Get all game bf cells types
        /// </summary>
        /// <returns>Generated bf cells types dictionary</returns>
        public IReadOnlyDictionary<long, IBattleFieldCellInfo> GetBattleFieldCells();
    }
}

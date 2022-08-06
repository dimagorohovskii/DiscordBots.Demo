using RolePlay.Common.System.Structs;
using System.Collections.Generic;

namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// A template that allows you to generate a random battlefield according to certain rules
    /// </summary>
    public interface IBattleFieldTemplate
    {
        /// <summary>
        /// List of card sizes for which the template can be used
        /// </summary>
        public IReadOnlyCollection<BFSize> AvailableSizes { get; }
        /// <summary>
        /// Generate a map
        /// </summary>
        /// <returns>Formed map</returns>
        public IBattleField Generate();
    }
}

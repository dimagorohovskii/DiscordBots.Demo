namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// (WIP) Item value calculator
    /// </summary>
    public interface ICostCounter
    {
        /// <summary>
        /// Get the cost of an abstract item
        /// </summary>
        /// <param name="item">Calculated Item</param>
        /// <returns>Item cost</returns>
        public long GetCostOf(IItem item);
        /// <summary>
        /// Get the cost of a specific item
        /// </summary>
        /// <param name="item">Calculated Item</param>
        /// <returns>Item cost</returns>
        public long GetCostOf(ICharItem item);
    }
}

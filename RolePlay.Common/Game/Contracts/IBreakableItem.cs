namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Item that can be broken
    /// </summary>
    public interface IBreakableItem : ICharItem
    {
        /// <summary>
        /// Item health
        /// </summary>
        public int Health { get; set; }
        /// <summary>
        /// Item max health
        /// </summary>
        public int MaxHealth { get; }
        /// <summary>
        /// String representation of the item's health
        /// </summary>
        public string HealthName { get; }
    }
}

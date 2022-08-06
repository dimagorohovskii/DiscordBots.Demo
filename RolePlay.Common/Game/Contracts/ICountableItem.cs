namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// An item that can be stacked in a character's inventory
    /// </summary>
    public interface ICountableItem : ICharItem
    {
        /// <summary>
        /// Count of items
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Total items weight
        /// </summary>
        public double SumWeight { get; }
    }
}

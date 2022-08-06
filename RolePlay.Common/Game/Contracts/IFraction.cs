namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// (WIP) Game faction
    /// </summary>
    public interface IFraction
    {
        /// <summary>
        /// Faction ID
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// User-friendly faction name
        /// </summary>
        public string Name { get; }
    }
}

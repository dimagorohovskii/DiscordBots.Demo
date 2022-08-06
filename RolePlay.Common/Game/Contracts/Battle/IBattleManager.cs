namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// (WIP) The battle manager that manages the entire course of the battles
    /// </summary>
    public interface IBattleManager
    {
        /// <summary>
        /// The length of one cell of the battlefield
        /// </summary>
        public int CellWidth { get; }
        /// <summary>
        /// The height of one cell of the battlefield
        /// </summary>
        public int CellHeight { get; }
    }
}

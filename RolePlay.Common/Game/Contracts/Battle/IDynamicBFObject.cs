namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// An object that can appear/remove/move during a battle
    /// </summary>
    public interface IDynamicBFObject : IBattleFieldCell
    {
        /// <summary>
        /// Render priority
        /// </summary>
        public int Priority { get; }
        /// <summary>
        /// Move object to new coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void Move(int x, int y);
        /// <summary>
        /// Delete object from the map
        /// </summary>
        public void Delete();
    }
}

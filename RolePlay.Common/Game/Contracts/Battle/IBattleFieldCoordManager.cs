namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// Manager that converts user coordinate representation to machine representation and vice versa
    /// </summary>
    public interface IBattleFieldCoordManager
    {
        /// <summary>
        /// Get string coordinate by number
        /// </summary>
        /// <param name="coord">Original number</param>
        /// <returns>String coordinate</returns>
        public string GetStringCoord(int coord);
        /// <summary>
        /// Try to form a coordinate from a string
        /// </summary>
        /// <param name="stringCoord">String representation of the coordinate</param>
        /// <param name="coord">Numeric representation of a coordinate</param>
        /// <returns><see langword="true"/>, if the conversion is successful. Otherwise <see langword="false"/></returns>
        public bool TryGetCoordFromString(string stringCoord, out int coord);
        /// <summary>
        /// Try to get coordinates from string
        /// </summary>
        /// <param name="coords">String with coordinates</param>
        /// <param name="x">Received X coordinate</param>
        /// <param name="y">Received Y coordinate</param>
        /// <returns><see langword="true"/>, if the conversion is successful. Otherwise <see langword="false"/></returns>
        public bool TryGetCoordsFromString(string coords, out int x, out int y);
    }
}

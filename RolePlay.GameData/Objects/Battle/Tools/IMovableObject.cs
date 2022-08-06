namespace RolePlay.GameData.Objects.Battle.Tools
{
    /// <summary>
    /// An object that can be moved by specifying coordinates 
    /// </summary>
    internal interface IMovableObject
    {
        /// <summary>
        /// X coordinate
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y coordinate
        /// </summary>
        public int Y { get; set; }
    }
}

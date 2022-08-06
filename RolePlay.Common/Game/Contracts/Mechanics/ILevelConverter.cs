namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// Converter describing different level representations
    /// </summary>
    public interface ILevelConverter
    {
        /// <summary>
        /// Maximum level value
        /// </summary>
        public int MaxLevel { get; }
        /// <summary>
        /// Maximum experience value
        /// </summary>
        public long MaxExp { get; }
        /// <summary>
        /// Minimum level value
        /// </summary>
        public int MinLevel { get; }
        /// <summary>
        /// Minimum experience value
        /// </summary>
        public long MinExp { get; }
        /// <summary>
        /// Get level for experience value
        /// </summary>
        /// <param name="exp">Experience value for calculation</param>
        /// <returns>Level value corresponding to the specified experience</returns>
        public int GetLevelForExp(long exp);
        /// <summary>
        /// Get the total amount of experience required to reach the specified level
        /// </summary>
        /// <param name="level">The level for which experience goal will be determined</param>
        /// <returns>The amount of experience required to reach the specified level</returns>
        public long GetAbsExpGoalForLevel(int level);
        /// <summary>
        /// Get a string representation of the level value
        /// </summary>
        /// <param name="level">The level for which the definition will be</param>
        /// <param name="propertyName">Parameter whose value will be received</param>
        /// <returns>String representation of the level value</returns>
        public string GetLevelStringView(int level, string propertyName);
    }
}

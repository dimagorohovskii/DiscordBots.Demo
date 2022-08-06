namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// Character dynamic skill
    /// </summary>
    public interface ISkill
    {
        /// <summary>
        /// Skill ID
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// User-friendly skill name
        /// </summary>
        public string Name { get; }
    }
}

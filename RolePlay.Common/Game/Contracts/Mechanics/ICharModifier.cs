using RolePlay.Common.Game.Enums;

namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// Instructions for changing a specific character characteristic
    /// </summary>
    public interface ICharModifier
    {
        /// <summary>
        /// Dynamic skill ID, if any
        /// </summary>
        public long? SkillId { get; }
        /// <summary>
        /// String representation of the skill, if any
        /// </summary>
        public string? SkillName { get; }
        /// <summary>
        /// Absolute skill change, if any
        /// </summary>
        public int? AbsModification { get; }
        /// <summary>
        /// Relative skill change, if any
        /// </summary>
        public double? RelModification { get; }
        /// <summary>
        /// Type of impact, if any
        /// </summary>
        public ImpactType? ImpactType { get; }
    }
}

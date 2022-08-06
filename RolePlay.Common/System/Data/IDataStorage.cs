namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Project global data storage
    /// </summary>
    public interface IDataStorage
    {
        /// <summary>
        /// Player characters storage
        /// </summary>
        IUserCharactersRepository Characters { get; }
        /// <summary>
        /// Character skills storage
        /// </summary>
        ICharacterSkillRepository Skills { get; }
        /// <summary>
        /// Character effects storage
        /// </summary>
        ICharEffectRepository Effects { get; }
        /// <summary>
        /// Character items storage
        /// </summary>
        ICharItemRepository Items { get; }
        /// <summary>
        /// Character fraction relations storage
        /// </summary>
        IFractionRelationRepository FractionRelations { get; }
        /// <summary>
        /// Character NPC relations storage
        /// </summary>
        ICharacterRelationRepository CharacterRelations { get; }
    }
}

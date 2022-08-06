using RolePlay.Common.Game.Contracts;

namespace RolePlay.Common.System.Data
{
    /// <summary>
    /// Repository for storing <see cref="IPlayerCharacter"/> objects
    /// </summary>
    public interface IUserCharactersRepository : ICommonRepositoryExt<ulong, IPlayerCharacter>
    {
        /// <summary>
        /// Does a character exist?
        /// </summary>
        /// <param name="characterId">Character ID. Link to <see cref="ICharacter.CharacterId"/></param>
        /// <returns><see langword="true"/>, if exist. Otherwise <see langword="false"/></returns>
        public bool IsExists(ulong characterId);
        /// <summary>
        /// Update only specific property values
        /// </summary>
        /// <param name="character">Character for update</param>
        /// <param name="properties">Properties that will be updated</param>
        public void LightUpdate(IPlayerCharacter character, params string[] properties);
    }
}

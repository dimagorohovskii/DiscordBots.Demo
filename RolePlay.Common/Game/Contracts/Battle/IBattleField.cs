using System.Collections.Generic;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.Battle
{
    /// <summary>
    /// Representation of the battlefield
    /// </summary>
    public interface IBattleField
    {
        /// <summary>
        /// Unique battlefield ID
        /// </summary>
        public long Id { get; }
        /// <summary>
        /// Battlefield width
        /// </summary>
        public int Width { get; }
        /// <summary>
        /// Battlefield height
        /// </summary>
        public int Height { get; }
        /// <summary>
        /// Dynamic objects on the battlefield
        /// </summary>
        public IReadOnlyCollection<IDynamicBFObject> DynamicBFObjects { get; }
        /// <summary>
        /// Get battlefield cell by coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>The cell located at the specified coordinates</returns>
        IBattleFieldCell this[int x, int y] { get; }
        /// <summary>
        /// Generate an image for the battlefield
        /// </summary>
        /// <returns>General view of the battlefield</returns>
        public Image GetBattlefieldImage();
        /// <summary>
        /// Generate an image for the battlefield from the point of view of the character
        /// </summary>
        /// <param name="characterId">Character on whose behalf the view will be</param>
        /// <returns>View of the battlefield through the eyes of a character</returns>
        public Image GetBattlefieldImage(ulong characterId);
        /// <summary>
        /// Get the character participating in the battle by ID
        /// </summary>
        /// <param name="characterId">Character ID</param>
        /// <returns>The character that was found by ID</returns>
        public IBFCharacter GetBattlefieldCharacter(ulong characterId);
        /// <summary>
        /// Add a new character from a random side of the battlefield
        /// </summary>
        /// <param name="character">The character to add</param>
        public void AddNewCharacter(ICharacter character);
        /// <summary>
        /// Add a new character to a specific position
        /// </summary>
        /// <param name="character">The character to add</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public void AddNewCharacter(ICharacter character, int x, int y);
        /// <summary>
        /// Add new dynamic object
        /// </summary>
        /// <param name="id">Object type identifier</param>
        /// <param name="x">X coordinate of the object</param>
        /// <param name="y">Object Y coordinate</param>
        public void AddNewDynamicObject(long id, int x, int y);
        /// <summary>
        /// Request dynamic objects by coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>All dynamic objects located by coordinates</returns>
        public IList<IDynamicBFObject> GetDynamicBFObject(int x, int y);
    }
}

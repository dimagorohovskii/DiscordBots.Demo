using RolePlay.Common.Game.Contracts.Mechanics;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// General representation of the player character
    /// </summary>
    public interface IPlayerCharacter : ICharacter
    {
        /// <summary>
        /// Add character experience to a skill
        /// </summary>
        /// <param name="skillId">Skill ID</param>
        /// <param name="exp">Accrued or subtracted experience</param>
        public void AddExp(long skillId, long exp);
        /// <summary>
        /// Add a relationship with a character
        /// </summary>
        /// <param name="npcId">Character ID</param>
        /// <param name="value">Value of relationship with the character</param>
        public void AddRelation(ulong npcId, int value);
        /// <summary>
        /// Add relationship with a faction
        /// </summary>
        /// <param name="fractionId">Faction ID</param>
        /// <param name="relationVal">Value of relationship with the fraction</param>
        /// <param name="reputationVal">Value of reputation in the fraction</param>
        public void AddRelation(int fractionId, int relationVal, int reputationVal);
        /// <summary>
        /// Add a new item to the character's inventory
        /// </summary>
        /// <param name="item">Added item</param>
        public void AddNewItem(IItem item);
        /// <summary>
        /// Add a stackable item to the character's inventory in a certain amount
        /// </summary>
        /// <param name="item">Added item</param>
        /// <param name="coumt">Number of added items</param>
        public void AddNewItem(IItem item, int coumt);
        /// <summary>
        /// Add a new item to the character's inventory
        /// </summary>
        /// <param name="item">Added item</param>
        public void AddNewItem(ICharItem item);
        /// <summary>
        /// Remove item from character's inventory 
        /// </summary>
        /// <param name="itemId">The ID of the item to be removed from the inventory</param>
        public void RemoveItem(ulong itemId);
        /// <summary>
        /// Remove item count from stackable items
        /// </summary>
        /// <param name="itemId">Item ID</param>
        /// <param name="count">Item count</param>
        public void RemoveItem(ulong itemId, int count);
        /// <summary>
        /// Add a new effect to the character
        /// </summary>
        /// <param name="effect">Added effect</param>
        public void AddNewEffect(IEffect effect);
        /// <summary>
        /// Add a new effect to the character
        /// </summary>
        /// <param name="effect">Added effect</param>
        public void AddNewEffect(ICharEffect effect);
        /// <summary>
        /// Remove effect from character
        /// </summary>
        /// <param name="effectId">Identifier of the effect what must be removed</param>
        public void RemoveEffect(ulong effectId);
    }
}

using System.Collections.Generic;

namespace RolePlay.Common.Game.Contracts.Mechanics
{
    /// <summary>
    /// A set of rules that describe how a character's skills and characteristics affect the game's rules
    /// </summary>
    public interface ISkillsMechanics
    {
        /// <summary>
        /// The level below which maximum health cannot fall
        /// </summary>
        public int MinMaxHPLevel { get; }
        /// <summary>
        /// Fatal hunger level
        /// </summary>
        public int MaxHunger { get; }
        /// <summary>
        /// Fatal thirst level
        /// </summary>
        public int MaxThirst { get; }
        /// <summary>
        /// Get the max carry weight for the strength value
        /// </summary>
        /// <param name="strength">Strength level</param>
        /// <returns>Max carry weight</returns>
        public double GetWeightForStrength(int strength);
        /// <summary>
        /// Get parameter value with modifiers
        /// </summary>
        /// <param name="paramName">Parameter name</param>
        /// <param name="level">Parameter level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Actual parameter value</returns>
        public double GetSkillValueWithModifiers(string paramName, int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get parameter value with modifiers
        /// </summary>
        /// <param name="paramId">Parameter ID</param>
        /// <param name="level">Parameter level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Actual parameter value</returns>
        public double GetSkillValueWithModifiers(long paramId, int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get max health for endurance level
        /// </summary>
        /// <param name="level">Endurance level</param>
        /// <returns>Max health level</returns>
        public int GetMAXHpForLevel(int level);
        /// <summary>
        /// Get the character's maximum health level, given modifiers
        /// </summary>
        /// <param name="level">Endurance level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Max health level</returns>
        public int GetRealMAXHpLevel(int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get a character's attractiveness level
        /// </summary>
        /// <param name="level">Charisma of the character</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Current level of attractiveness</returns>
        public int GetAttractivenessForChar(int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get a character's intimidation level
        /// </summary>
        /// <param name="level">Charisma of the character</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Current level of intimidation</returns>
        public int GetIntimidationForChar(int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get a character's persuasion level
        /// </summary>
        /// <param name="level">Charisma of the character</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Current level of persuasion</returns>
        public int GetConvictionForChar(int level, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get the minimum damage level for strength and modifiers
        /// </summary>
        /// <param name="strength">Strength level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Minimum damage level</returns>
        public int GetMinDamageForStrength(int strength, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get the maximum damage level for strength and modifiers
        /// </summary>
        /// <param name="strength">Strength level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Maximum damage level</returns>
        public int GetMaxDamageForStrength(int strength, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get the minimum damage level for perception and modifiers
        /// </summary>
        /// <param name="perception">Perception level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Minimum damage level</returns>
        public int GetMinDamageForPerception(int perception, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get the maximum damage level for perception and modifiers
        /// </summary>
        /// <param name="perception">Perception level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Maximum damage level</returns>
        public int GetMaxDamageForPerception(int perception, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Gain critical strike chance for intelligence and modifiers
        /// </summary>
        /// <param name="intel">Intelligence level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Chance of critical damage as a percentage, rounded up to a whole number</returns>
        public int GetCritChanseForIntelligence(int intel, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Gain a chance to block a melee attack
        /// </summary>
        /// <param name="strength">Strength level</param>
        /// <param name="agility">Agility level</param>
        /// <param name="endurance">Endurance level</param>
        /// <param name="luck">Luck level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Chance to block a melee attack as a percentage, rounded up to a whole number</returns>
        public int GetBlockChance(int strength, int agility, int endurance, int luck, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Gain a chance to avoid a melee attack
        /// </summary>
        /// <param name="agility">Agility level</param>
        /// <param name="luck">Luck level</param>
        /// <param name="modifiers">A set of modifiers</param>
        /// <returns>Chance to avoid a melee attack as a percentage, rounded up to a whole number</returns>
        public int GetDodgeChance(int agility, int luck, IEnumerable<ICharModifier> modifiers);
        /// <summary>
        /// Get character's initiative level
        /// </summary>
        /// <param name="character">Character data for calculations</param>
        /// <returns>Initiative level</returns>
        public int GetInitiativeForCharacter(ICharacter character);
    }
}

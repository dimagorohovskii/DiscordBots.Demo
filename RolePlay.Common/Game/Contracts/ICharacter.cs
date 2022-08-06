using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.Game.Enums;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts
{
    /// <summary>
    /// General representation of the in-game character
    /// </summary>
    public interface ICharacter : IChangeable
    {
        /// <summary>
        /// Character ID
        /// </summary>
        public ulong CharacterId { get; }
        /// <summary>
        /// Character`s name
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Character species
        /// </summary>
        public string Species { get; }
        /// <summary>
        /// Character gender
        /// </summary>
        public string Sex { get; }
        /// <summary>
        /// Character faction
        /// </summary>
        public IFraction? Fraction { get; set; }
        /// <summary>
        /// Character reputation
        /// </summary>
        public int Reputation { get; set; }
        /// <summary>
        /// Character description
        /// </summary>
        public string Description { get; set; }

        #region Skills
        #region SPECIAL
        /// <summary>
        /// Character strength
        /// </summary>
        public int Strength { get; }
        /// <summary>
        /// String value of the character strength
        /// </summary>
        public string StrengthVal { get; }
        /// <summary>
        /// Experience for the next strength level
        /// </summary>
        public long StrengthGoal { get; }
        /// <summary>
        /// Get the real value of the character's strength, taking into modifiers
        /// </summary>
        public int RealStrengthValue { get; }

        /// <summary>
        /// Character agility
        /// </summary>
        public int Agility { get; }
        /// <summary>
        /// String value of the character agility
        /// </summary>
        public string AgilityVal { get; }
        /// <summary>
        /// Experience for the next agility level
        /// </summary>
        public long AgilityGoal { get; }
        /// <summary>
        /// Get the real value of the character's agility, taking into modifiers
        /// </summary>
        public int RealAgilityValue { get; }

        /// <summary>
        /// Character perception
        /// </summary>
        public int Perception { get; }
        /// <summary>
        /// String value of the character perception
        /// </summary>
        public string PerceptionVal { get; }
        /// <summary>
        /// Experience for the next perception level
        /// </summary>
        public long PerceptionGoal { get; }
        /// <summary>
        /// Get the real value of the character's perception, taking into modifiers
        /// </summary>
        public int RealPerceptionValue { get; }

        /// <summary>
        /// Character luck
        /// </summary>
        public int Luck { get; }
        /// <summary>
        /// String value of the character luck
        /// </summary>
        public string LuckVal { get; }
        /// <summary>
        /// Experience for the next luck level
        /// </summary>
        public long LuckGoal { get; }
        /// <summary>
        /// Get the real value of the character's luck, taking into modifiers
        /// </summary>
        public int RealLuckValue { get; }

        /// <summary>
        /// Character endurance
        /// </summary>
        public int Endurance { get; }
        /// <summary>
        /// String value of the character endurance
        /// </summary>
        public string EnduranceVal { get; }
        /// <summary>
        /// Experience for the next endurance level
        /// </summary>
        public long EnduranceGoal { get; }
        /// <summary>
        /// Get the real value of the character's perception, taking into modifiers
        /// </summary>
        public int RealEnduranceValue { get; }

        /// <summary>
        /// Character charisma
        /// </summary>
        public int Charisma { get; }
        /// <summary>
        /// String value of the character charisma
        /// </summary>
        public string CharismaVal { get; }
        /// <summary>
        /// Experience for the next charisma level
        /// </summary>
        public long CharismaGoal { get; }
        /// <summary>
        /// Get the real value of the character's charisma, taking into modifiers
        /// </summary>
        public int RealCharismaValue { get; }

        /// <summary>
        /// Character intelligence
        /// </summary>
        public int Intelligence { get; }
        /// <summary>
        /// String value of the character intelligence
        /// </summary>
        public string IntelligenceVal { get; }
        /// <summary>
        /// Experience for the next intelligence level
        /// </summary>
        public long IntelligenceGoal { get; }
        /// <summary>
        /// Get the real value of the character's intelligence, taking into modifiers
        /// </summary>
        public int RealIntelligenceValue { get; }

        /// <summary>
        /// Actual strength exp points value
        /// </summary>
        public long ExpStrength { get; set; }
        /// <summary>
        /// Actual agility exp points value
        /// </summary>
        public long ExpAgility { get; set; }
        /// <summary>
        /// Actual perception exp points value
        /// </summary>
        public long ExpPerception { get; set; }
        /// <summary>
        /// Actual luck exp points value
        /// </summary>
        public long ExpLuck { get; set; }
        /// <summary>
        /// Actual endurance exp points value
        /// </summary>
        public long ExpEndurance { get; set; }
        /// <summary>
        /// Actual charisma exp points value
        /// </summary>
        public long ExpCharisma { get; set; }
        /// <summary>
        /// Actual intelligence exp points value
        /// </summary>
        public long ExpIntelligence { get; set; }
        #endregion

        #region Other
        /// <summary>
        /// Get skill level
        /// </summary>
        /// <param name="skillId">Skill ID</param>
        /// <returns>Current skill level or <see langword="null"/>, if the character does not have the skill with the specified id</returns>
        public int? GetLefelForSkill(long skillId);
        /// <summary>
        /// Getting the string value of a skill
        /// </summary>
        /// <param name="skillId">Skill ID</param>
        /// <returns>Current skill string value or <see langword="null"/>, if the character does not have the skill with the specified id</returns>
        public string? GetStringValForSkill(long skillId);
        /// <summary>
        /// Get the actual skill level with modifiers
        /// </summary>
        /// <param name="skillId">Skill ID</param>
        /// <returns>Current skill level or <see langword="null"/>, if the character does not have the skill with the specified id</returns>
        public int? GetRealLevelForSkill(long skillId);
        /// <summary>
        /// Get the experience required for the skill level
        /// </summary>
        /// <param name="level">Skill level</param>
        /// <returns>Experience required for level</returns>
        public long GetSkillExpGoal(int level);
        /// <summary>
        /// All character skills
        /// </summary>
        public IReadOnlyDictionary<long, ICharacterSkill> Skills { get; }

        #endregion
        #endregion

        #region Inventory
        /// <summary>
        /// Equipped weapon
        /// </summary>
        public IWeapon? Weapon { get; set; }
        /// <summary>
        /// Equipped helmet
        /// </summary>
        public IEquipment? Helmet { get; set; }
        /// <summary>
        /// Equipped face protection
        /// </summary>
        public IEquipment? Face { get; set; }
        /// <summary>
        /// Equipped mask
        /// </summary>
        public IEquipment? Mask { get; set; }
        /// <summary>
        /// Equipped outerwear
        /// </summary>
        public IEquipment? Outerwear { get; set; }
        /// <summary>
        /// Equipped armor
        /// </summary>
        public IEquipment? Armor { get; set; }
        /// <summary>
        /// Equipped pants
        /// </summary>
        public IEquipment? Pants { get; set; }
        /// <summary>
        /// Equipped gloves
        /// </summary>
        public IEquipment? Gloves { get; set; }
        /// <summary>
        /// Equipped boots
        /// </summary>
        public IEquipment? Boots { get; set; }
        /// <summary>
        /// Equipped backpack
        /// </summary>
        public IEquipment? Backpack { get; set; }
        /// <summary>
        /// Equipped belt
        /// </summary>
        public IEquipment? Belt { get; set; }
        /// <summary>
        /// Items in the character's inventory
        /// </summary>
        public IReadOnlyCollection<ICharItem> Items { get; }
        /// <summary>
        /// Character inventory weight
        /// </summary>
        public double Weight { get; }
        /// <summary>
        /// Maximum carry weight by character
        /// </summary>
        public double MaxWeight { get; }

        /// <summary>
        /// Equip character item from inventory
        /// </summary>
        /// <param name="itemId">Item ID</param>
        public void Equip(ulong itemId);
        #endregion

        #region State
        /// <summary>
        /// Effects currently affecting the character
        /// </summary>
        public IReadOnlyCollection<ICharEffect> Effects { get; }
        /// <summary>
        /// Character health level
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Maximum character health
        /// </summary>
        public int MaxHP { get; }
        /// <summary>
        /// The actual level of character maximum health
        /// </summary>
        public int RealMaxHPLevel { get; }
        /// <summary>
        /// Character's hunger level
        /// </summary>
        public int Hunger { get; set; }
        /// <summary>
        /// Character's thirst level
        /// </summary>
        public int Thrist { get; set; }
        /// <summary>
        /// Is the character dead
        /// </summary>
        public bool IsDead { get; }
        #endregion

        #region Social
        /// <summary>
        /// Character attractiveness level
        /// </summary>
        public int Attractiveness { get; }
        /// <summary>
        /// Character intimidation level
        /// </summary>
        public int Intimidation { get; }
        /// <summary>
        /// Character persuasiveness level
        /// </summary>
        public int Persuasiveness { get; }
        #endregion

        #region Relations
        /// <summary>
        /// Relationships with other characters
        /// </summary>
        public IReadOnlyCollection<ICharacterRelation> CharacterRelations { get; }
        /// <summary>
        /// Relations with other factions
        /// </summary>
        public IReadOnlyCollection<IFractionRelation> FractionRelations { get; }
        #endregion

        #region Fight
        /// <summary>
        /// Type of impact by character attacks
        /// </summary>
        public ImpactType ImpactType { get; }
        /// <summary>
        /// Type of character attacks
        /// </summary>
        public AttackType AttackType { get; }
        /// <summary>
        /// The minimum damage level of the character's weapon
        /// </summary>
        public int MinAttack { get; }
        /// <summary>
        /// The maximum damage level of the character's weapon
        /// </summary>
        public int MaxAttack { get; }
        /// <summary>
        /// Critical damage chance
        /// </summary>
        public int CritChance { get; }
        /// <summary>
        /// Chance to block a melee attack
        /// </summary>
        public int BlockChance { get; }
        /// <summary>
        /// Chance to dodge melee attacks
        /// </summary>
        public int DodgeChance { get; }
        /// <summary>
        /// Character initiative
        /// </summary>
        public int Initiative { get; }
        /// <summary>
        /// Defense from character equipment
        /// </summary>
        public int Defense { get; }
        /// <summary>
        /// Maximum range of movement
        /// </summary>
        public int MaxMovementDistance { get; }
        #endregion

        /// <summary>
        /// Character image
        /// </summary>
        public Image? Image { get; set; }
    }
}

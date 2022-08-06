namespace RolePlay.GameData.Data
{
    /// <summary>
    /// Data that allows you to completely recreate the character
    /// </summary>
    public class CharacterData
    {
        /// <summary>
        /// Character ID
        /// </summary>
        public ulong CharacterId { get; set; }
        /// <summary>
        /// Character `s name
        /// </summary>
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Character species
        /// </summary>
        public string Species { get; set; } = string.Empty;
        /// <summary>
        /// Character sex
        /// </summary>
        public string Sex { get; set; } = string.Empty;
        /// <summary>
        /// Character description
        /// </summary>
        public string Description { get; set; } = string.Empty;
        /// <summary>
        /// Character faction
        /// </summary>
        public long? Fraction { get; set; }
        /// <summary>
        /// Character reputation
        /// </summary>
        public int Reputation { get; set; }
        /// <summary>
        /// Character strength experience value 
        /// </summary>
        public long ExpStrength { get; set; }
        /// <summary>
        /// Character agility experience value
        /// </summary>
        public long ExpAgility { get; set; }
        /// <summary>
        /// Character perception experience value
        /// </summary>
        public long ExpPerception { get; set; }
        /// <summary>
        /// Character luck experience value
        /// </summary>
        public long ExpLuck { get; set; }
        /// <summary>
        /// Character endurance experience value
        /// </summary>
        public long ExpEndurance { get; set; }
        /// <summary>
        /// Character charisma experience value
        /// </summary>
        public long ExpCharisma { get; set; }
        /// <summary>
        /// Character intelligence experience value
        /// </summary>
        public long ExpIntelligence { get; set; }

        /// <summary>
        /// Equipped weapon
        /// </summary>
        public ulong? Weapon { get; set; }
        /// <summary>
        /// Equipped helmet
        /// </summary>
        public ulong? Helmet { get; set; }
        /// <summary>
        /// Equipped face protection
        /// </summary>
        public ulong? Face { get; set; }
        /// <summary>
        /// Equipped mask
        /// </summary>
        public ulong? Mask { get; set; }
        /// <summary>
        /// Equipped outerwear
        /// </summary>
        public ulong? Outerwear { get; set; }
        /// <summary>
        /// Equipped armor
        /// </summary>
        public ulong? Armor { get; set; }
        /// <summary>
        /// Equipped pants
        /// </summary>
        public ulong? Pants { get; set; }
        /// <summary>
        /// Equipped gloves
        /// </summary>
        public ulong? Gloves { get; set; }
        /// <summary>
        /// Equipped boots
        /// </summary>
        public ulong? Boots { get; set; }
        /// <summary>
        /// Equipped backpack
        /// </summary>
        public ulong? Backpack { get; set; }
        /// <summary>
        /// Equipped belt
        /// </summary>
        public ulong? Belt { get; set; }
        /// <summary>
        /// Character health level
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Character hunger level
        /// </summary>
        public int Hunger { get; set; }
        /// <summary>
        /// Character thrist level
        /// </summary>
        public int Thrist { get; set; }
        /// <summary>
        /// Character image in Base64
        /// </summary>
        public string Image { get; set; } = string.Empty;
    }
}

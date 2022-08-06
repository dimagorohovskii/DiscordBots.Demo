using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Enums;
using RolePlay.GameData.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using Universal;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Game character 
    /// </summary>
    public abstract class Character : ChangeableObject, ICharacter
    {
        #region Fields
        protected readonly ILevelConverter _specialConverter, _skillsConverter;
        protected readonly ISkillsMechanics _skillsMechanics;
        protected readonly IFightMechanicsRules _fightMechanicsRules;
        protected readonly Dictionary<long, ICharacterSkill> _skills;
        protected readonly IList<ICharItem> _items;
        protected readonly IList<ICharEffect> _effects;
        protected readonly IList<IFractionRelation> _fractionRelations;
        protected readonly IList<ICharacterRelation> _characterRelations;
        private string _name = string.Empty;
        private string _species = string.Empty;
        private string _sex = string.Empty;
        private int _hp, _hunger, _thrist;
        #endregion

        #region Properties
        public ulong CharacterId { get; }

        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Name));
                }

                if (_name == value)
                {
                    return;
                }

                _name = value;
            }
        }

        public string Species
        {
            get => _species;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Species));
                }

                if (_species == value)
                {
                    return;
                }

                _species = value;
            }
        }

        public string Sex
        {
            get => _sex;
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(Sex));
                }

                if (_sex == value)
                {
                    return;
                }

                _sex = value;
            }
        }

        public IFraction? Fraction { get; set; }

        public int Reputation { get; set; }

        #region SPECIAL
        public int Strength => _specialConverter.GetLevelForExp(ExpStrength);

        public string StrengthVal => _specialConverter.GetLevelStringView(Strength, nameof(Strength));

        public long StrengthGoal => _specialConverter.GetAbsExpGoalForLevel(Strength + 1);

        public int RealStrengthValue => GetSkillRealValue(nameof(Strength), Strength);


        public int Agility => _specialConverter.GetLevelForExp(ExpAgility);

        public string AgilityVal => _specialConverter.GetLevelStringView(Agility, nameof(Agility));

        public long AgilityGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Agility + 1));

        public int RealAgilityValue => GetSkillRealValue(nameof(Agility), Agility);


        public int Perception => _specialConverter.GetLevelForExp(ExpPerception);

        public string PerceptionVal => _specialConverter.GetLevelStringView(Perception, nameof(Perception));

        public long PerceptionGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Perception + 1));

        public int RealPerceptionValue => GetSkillRealValue(nameof(Perception), Perception);


        public int Luck => _specialConverter.GetLevelForExp(ExpLuck);

        public string LuckVal => _specialConverter.GetLevelStringView(Luck, nameof(Luck));

        public long LuckGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Luck + 1));

        public int RealLuckValue => GetSkillRealValue(nameof(Luck), Luck);


        public int Endurance => _specialConverter.GetLevelForExp(ExpEndurance);

        public string EnduranceVal => _specialConverter.GetLevelStringView(Endurance, nameof(Endurance));

        public long EnduranceGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Endurance + 1));

        public int RealEnduranceValue => GetSkillRealValue(nameof(Endurance), Endurance);


        public int Charisma => _specialConverter.GetLevelForExp(ExpCharisma);

        public string CharismaVal => _specialConverter.GetLevelStringView(Charisma, nameof(Charisma));

        public long CharismaGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Charisma + 1));

        public int RealCharismaValue => GetSkillRealValue(nameof(Charisma), Charisma);


        public int Intelligence => _specialConverter.GetLevelForExp(ExpIntelligence);

        public string IntelligenceVal => _specialConverter.GetLevelStringView(Intelligence, nameof(Intelligence));

        public long IntelligenceGoal => _specialConverter.GetAbsExpGoalForLevel(Math.Min(_specialConverter.MaxLevel, Intelligence + 1));

        public int RealIntelligenceValue => GetSkillRealValue(nameof(Intelligence), Intelligence);


        public long ExpStrength { get; set; }

        public long ExpAgility { get; set; }

        public long ExpPerception { get; set; }

        public long ExpLuck { get; set; }

        public long ExpEndurance { get; set; }

        public long ExpCharisma { get; set; }

        public long ExpIntelligence { get; set; }

        #endregion

        public IReadOnlyDictionary<long, ICharacterSkill> Skills => _skills;

        #region Inventory
        public IWeapon? Weapon { get; set; }

        public IEquipment? Helmet { get; set; }

        public IEquipment? Face { get; set; }

        public IEquipment? Mask { get; set; }

        public IEquipment? Outerwear { get; set; }

        public IEquipment? Armor { get; set; }

        public IEquipment? Pants { get; set; }

        public IEquipment? Gloves { get; set; }

        public IEquipment? Boots { get; set; }

        public IEquipment? Backpack { get; set; }

        public IEquipment? Belt { get; set; }

        public IReadOnlyCollection<ICharItem> Items => _items.ToReadOnlyCollection();

        public double Weight
        {
            get
            {
                double weight = 0;
                foreach (ICharItem item in Items)
                {
                    if (item is ICountableItem countableItem)
                    {
                        weight += countableItem.SumWeight;
                    }
                    else
                    {
                        weight += item.Weight;
                    }
                }

                return weight;
            }
        }
        public double MaxWeight => _skillsMechanics.GetWeightForStrength(Strength);
        #endregion

        #region State
        public IReadOnlyCollection<ICharEffect> Effects => new ReadOnlyCollection<ICharEffect>(_effects);

        public int HP
        {
            get => _hp;
            set
            {
                if (_hp == value)
                {
                    return;
                }

                _hp = Math.Min(MaxHP, Math.Max(value, 0));
            }
        }

        public int MaxHP => Math.Max(_skillsMechanics.MinMaxHPLevel, _skillsMechanics.GetMAXHpForLevel(Endurance));

        public int RealMaxHPLevel => Math.Max(_skillsMechanics.MinMaxHPLevel, _skillsMechanics.GetRealMAXHpLevel(RealEnduranceValue, GetAllModifiers()));

        public int Hunger
        {
            get => _hunger;
            set
            {
                if (_hunger == value)
                {
                    return;
                }

                _hunger = Math.Max(0, Math.Min(_skillsMechanics.MaxHunger, value));
            }
        }

        public int Thrist
        {
            get => _thrist;
            set
            {
                if (_thrist == value)
                {
                    return;
                }

                _thrist = Math.Max(0, Math.Min(_skillsMechanics.MaxThirst, value));
            }
        }

        public bool IsDead => HP == 0 || Hunger == _skillsMechanics.MaxHunger || Thrist == _skillsMechanics.MaxThirst || Effects.Any(e => e.Value.HasValue && e.Value == 100);
        #endregion

        #region Social
        public int Attractiveness => _skillsMechanics.GetAttractivenessForChar(RealCharismaValue, GetAllModifiers());

        public int Intimidation => _skillsMechanics.GetIntimidationForChar(RealCharismaValue, GetAllModifiers());

        public int Persuasiveness => _skillsMechanics.GetConvictionForChar(RealCharismaValue, GetAllModifiers());
        #endregion

        #region Relations
        public IReadOnlyCollection<ICharacterRelation> CharacterRelations => new ReadOnlyCollection<ICharacterRelation>(_characterRelations);

        public IReadOnlyCollection<IFractionRelation> FractionRelations => new ReadOnlyCollection<IFractionRelation>(_fractionRelations);
        #endregion

        #region Fight
        public ImpactType ImpactType => Weapon == null ? ImpactType.Physical : Item.Items[Weapon.ItemId].ImpactType.GetValueOrDefault(ImpactType.Physical);

        public AttackType AttackType => Weapon == null ? AttackType.MeleeAttack : Item.Items[Weapon.ItemId].AttackType.GetValueOrDefault(AttackType.MeleeAttack);

        public int MinAttack => AttackType switch
        {
            AttackType.MeleeAttack => _skillsMechanics.GetMinDamageForStrength(RealStrengthValue, GetAllModifiers()),
            AttackType.RangedAttack => _skillsMechanics.GetMinDamageForPerception(RealPerceptionValue, GetAllModifiers()),
            _ => throw new ArgumentOutOfRangeException(nameof(AttackType)),
        };

        public int MaxAttack => AttackType switch
        {
            AttackType.MeleeAttack => _skillsMechanics.GetMaxDamageForStrength(RealStrengthValue, GetAllModifiers()),
            AttackType.RangedAttack => _skillsMechanics.GetMaxDamageForPerception(RealPerceptionValue, GetAllModifiers()),
            _ => throw new ArgumentOutOfRangeException(nameof(AttackType)),
        };

        public int CritChance => _skillsMechanics.GetCritChanseForIntelligence(RealIntelligenceValue, GetAllModifiers());

        public int BlockChance => _skillsMechanics.GetBlockChance(RealStrengthValue, RealAgilityValue, RealEnduranceValue, RealLuckValue, GetAllModifiers());

        public int DodgeChance => _skillsMechanics.GetDodgeChance(Agility, Luck, GetAllModifiers());

        public int Initiative => _skillsMechanics.GetInitiativeForCharacter(this);

        public int Defense => _fightMechanicsRules.GetDefenceForModifiers(GetAllModifiers());

        public int MaxMovementDistance => _fightMechanicsRules.GetMaxStepDistance(GetAllModifiers());
        #endregion

        public Image? Image { get; set; }

        public string Description { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Form a new character
        /// </summary>
        /// <param name="specialConverter">Rules for calculating his main characteristics</param>
        /// <param name="skillsConverter">Rules for calculating his additional characteristics</param>
        /// <param name="skillsMechanics">Rules for calculating his mechanic</param>
        /// <param name="fightMechanicsRules">Fighting rules</param>
        /// <param name="characterId">Character ID</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Character(ILevelConverter specialConverter, ILevelConverter skillsConverter, ISkillsMechanics skillsMechanics, IFightMechanicsRules fightMechanicsRules, ulong characterId)
        {
            _specialConverter = specialConverter ?? throw new ArgumentNullException(nameof(specialConverter));
            _skillsConverter = skillsConverter ?? throw new ArgumentNullException(nameof(skillsConverter));
            _skillsMechanics = skillsMechanics ?? throw new ArgumentNullException(nameof(skillsMechanics));
            _fightMechanicsRules = fightMechanicsRules ?? throw new ArgumentNullException(nameof(fightMechanicsRules));
            _skills = new Dictionary<long, ICharacterSkill>();
            _items = new List<ICharItem>();
            _effects = new List<ICharEffect>();
            _fractionRelations = new List<IFractionRelation>();
            _characterRelations = new List<ICharacterRelation>();
            CharacterId = characterId;
            Description = string.Empty;
        }
        #endregion

        #region Public/Internal methods
        public int? GetLefelForSkill(long skillId)
        {
            if (_skills.TryGetValue(skillId, out ICharacterSkill skill))
            {
                return _skillsConverter.GetLevelForExp(skill.Exp);
            }

            return null;
        }

        public string? GetStringValForSkill(long skillId)
        {
            if (_skills.TryGetValue(skillId, out ICharacterSkill skill))
            {
                return _skillsConverter.GetLevelStringView(_skillsConverter.GetLevelForExp(skill.Exp), Skill.Skills[skill.SkillId].Name);
            }

            return null;
        }

        public int? GetRealLevelForSkill(long skillId)
        {
            if (_skills.TryGetValue(skillId, out ICharacterSkill skill))
            {
                return GetSkillRealValue(Skill.Skills[skill.SkillId].Name, _skillsConverter.GetLevelForExp(skill.Exp));
            }

            return null;
        }

        public long GetSkillExpGoal(int level)
        {
            return _skillsConverter.GetAbsExpGoalForLevel(level);
        }

        public void Equip(ulong itemId)
        {
            ICharItem? item = Items.FirstOrDefault(x => x.Id == itemId);
            if (item == null)
            {
                throw new ArgumentOutOfRangeException(nameof(itemId));
            }

            switch (Item.Items[item.ItemId].ItemType)
            {
                case ItemType.Face:
                    _items.Remove(item);
                    if (Face != null)
                    {
                        _items.Add(Face);
                    }

                    Face = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Other:
                    throw new InvalidOperationException($"Этот предмет {Item.Items[item.ItemId].ItemType} нельзя экипировать");
                case ItemType.Weapon:
                    _items.Remove(item);
                    if (Weapon != null)
                    {
                        _items.Add(Weapon);
                    }

                    Weapon = item as IWeapon;
                    SetChanged();
                    break;
                case ItemType.Helmet:
                    _items.Remove(item);
                    if (Helmet != null)
                    {
                        _items.Add(Helmet);
                    }

                    Helmet = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Mask:
                    _items.Remove(item);
                    if (Mask != null)
                    {
                        _items.Add(Mask);
                    }
                    Mask = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Outerwear:
                    _items.Remove(item);
                    if (Outerwear != null)
                    {
                        _items.Add(Outerwear);
                    }
                    Outerwear = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Armor:
                    _items.Remove(item);
                    if (Armor != null)
                    {
                        _items.Add(Armor);
                    }
                    Armor = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Pants:
                    _items.Remove(item);
                    if (Pants != null)
                    {
                        _items.Add(Pants);
                    }
                    Pants = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Gloves:
                    _items.Remove(item);
                    if (Gloves != null)
                    {
                        _items.Add(Gloves);
                    }
                    Gloves = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Boots:
                    _items.Remove(item);
                    if (Boots != null)
                    {
                        _items.Add(Boots);
                    }

                    Boots = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Backpack:
                    _items.Remove(item);
                    if (Backpack != null)
                    {
                        _items.Add(Backpack);
                    }

                    Backpack = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Belt:
                    _items.Remove(item);
                    if (Belt != null)
                    {
                        _items.Add(Belt);
                    }
                    Belt = item as IEquipment;
                    SetChanged();
                    break;
                case ItemType.Countable:
                    throw new InvalidOperationException($"Этот предмет {Item.Items[item.ItemId].ItemType} нельзя экипировать");
                default:
                    throw new InvalidOperationException($"Этот предмет {Item.Items[item.ItemId].ItemType} нельзя экипировать");
            }
        }
        #endregion

        #region Protected/Private methods
        /// <summary>
        /// Get the actual value of the skill 
        /// </summary>
        /// <param name="skillName">Skill name</param>
        /// <param name="level">Skill level</param>
        /// <returns>The real value of the skill</returns>
        private int GetSkillRealValue(string skillName, int level)
        {
            return (int)Math.Floor(_skillsMechanics.GetSkillValueWithModifiers(skillName, level, GetAllModifiers()));
        }
        /// <summary>
        /// Get all modifiers that affect the character
        /// </summary>
        /// <returns>Collection of active modifiers</returns>ik
        private List<ICharModifier> GetAllModifiers()
        {
            List<ICharModifier> modifiers = new List<ICharModifier>();
            foreach (ICharItem? equipment in new ICharItem?[]
            {
                Helmet, Face, Mask, Outerwear, Armor, Pants, Gloves, Boots, Backpack, Belt, Weapon
            })
            {
                if (equipment == null)
                {
                    continue;
                }

                modifiers.AddRange(Item.Items[equipment.ItemId].Modifiers);
            }

            foreach (ICharEffect effect in Effects)
            {
                modifiers.AddRange(Effect.Effects[effect.EffectId].Modifiers);
            }

            return modifiers;
        }

        #endregion 
    }
}

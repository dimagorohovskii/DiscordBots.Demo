using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Enums;
using RolePlay.GameData.Data;
using RolePlay.GameData.Extentions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Игровой персонаж
    /// </summary>
    public class PlayerCharacter : Character, IPlayerCharacter
    {
        #region Properties
        protected Dictionary<long, ICharacterSkill> _skillsSafe
        {
            get
            {
                lock (_skills)
                {
                    return _skills;
                }
            }
        }

        protected IList<ICharItem> _itemsSafe
        {
            get
            {
                lock (_items)
                {
                    return _items;
                }
            }
        }

        protected IList<ICharEffect> _effectsSafe
        {
            get
            {
                lock (_effects)
                {
                    return _effects;
                }
            }
        }

        protected IList<IFractionRelation> _fractionRelationsSafe
        {
            get
            {
                lock (_fractionRelations)
                {
                    return _fractionRelations;
                }
            }
        }

        protected IList<ICharacterRelation> _characterRelationsSafe
        {
            get
            {
                lock (_characterRelations)
                {
                    return _characterRelations;
                }
            }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Form a new playable character
        /// </summary>
        /// <param name="data">Character data</param>
        /// <param name="items">Character inventory</param>
        /// <param name="skills">Dynamic character skills</param>
        /// <param name="fractionRelations">Character's relationship with other factions</param>
        /// <param name="characterRelations">Character's relationship with other characters</param>
        /// <exception cref="ArgumentNullException"></exception>
        public PlayerCharacter(CharacterData data, IEnumerable<ICharItem> items, IEnumerable<ICharacterSkill> skills, IEnumerable<IFractionRelation> fractionRelations, IEnumerable<ICharacterRelation> characterRelations)
            : base(GameRules.SpecialConverter, GameRules.SkillsConverter, GameRules.SkillsMechanics, GameRules.FightMechanicsRules, data == null ? throw new ArgumentNullException(nameof(data)) : data.CharacterId)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (skills == null)
            {
                throw new ArgumentNullException(nameof(skills));
            }

            if (fractionRelations == null)
            {
                throw new ArgumentNullException(nameof(fractionRelations));
            }

            if (characterRelations == null)
            {
                throw new ArgumentNullException(nameof(characterRelations));
            }

            Description = data.Description;
            foreach (ICharItem item in items)
            {
                if (data.Weapon.HasValue && item.Id == data.Weapon.Value)
                {
                    Weapon = (IWeapon)item;
                }
                else if (data.Helmet.HasValue && item.Id == data.Helmet.Value)
                {
                    Helmet = (IEquipment)item;
                }
                else if (data.Face.HasValue && item.Id == data.Face.Value)
                {
                    Face = (IEquipment)item;
                }
                else if (data.Mask.HasValue && item.Id == data.Mask.Value)
                {
                    Mask = (IEquipment)item;
                }
                else if (data.Outerwear.HasValue && item.Id == data.Outerwear.Value)
                {
                    Outerwear = (IEquipment)item;
                }
                else if (data.Armor.HasValue && item.Id == data.Armor.Value)
                {
                    Armor = (IEquipment)item;
                }
                else if (data.Pants.HasValue && item.Id == data.Pants.Value)
                {
                    Pants = (IEquipment)item;
                }
                else if (data.Gloves.HasValue && item.Id == data.Gloves.Value)
                {
                    Gloves = (IEquipment)item;
                }
                else if (data.Boots.HasValue && item.Id == data.Boots.Value)
                {
                    Boots = (IEquipment)item;
                }
                else if (data.Backpack.HasValue && item.Id == data.Backpack.Value)
                {
                    Backpack = (IEquipment)item;
                }
                else if (data.Belt.HasValue && item.Id == data.Belt.Value)
                {
                    Belt = (IEquipment)item;
                }
                else
                {
                    _items.Add(item);
                }
            }
            foreach (ICharacterSkill skill in skills)
            {
                _skills.Add(skill.SkillId, skill);
            }
            foreach (IFractionRelation relation in fractionRelations)
            {
                _fractionRelations.Add(relation);
            }
            foreach (ICharacterRelation relation in characterRelations)
            {
                _characterRelations.Add(relation);
            }

            if (!string.IsNullOrWhiteSpace(data.Image))
            {
                using MemoryStream ms = new MemoryStream(Convert.FromBase64String(data.Image));
                Image = Image.FromStream(ms);
            }

            Name = data.Name;
            Species = data.Species;
            Sex = data.Sex;
            if (data.Fraction.HasValue && Objects.Fraction.Fractions.TryGetValue(data.Fraction.Value, out IFraction fraction))
            {
                Fraction = fraction;
            }

            Reputation = data.Reputation;
            ExpStrength = data.ExpStrength;
            ExpAgility = data.ExpAgility;
            ExpPerception = data.ExpPerception;
            ExpLuck = data.ExpLuck;
            ExpEndurance = data.ExpEndurance;
            ExpCharisma = data.ExpCharisma;
            ExpIntelligence = data.ExpIntelligence;

            HP = data.HP;
            Hunger = data.Hunger;
            Thrist = data.Thrist;
        }
        #endregion

        #region Public/Internal methods
        public void AddExp(long skillId, long exp)
        {
            if (_skills.TryGetValue(skillId, out ICharacterSkill skill))
            {
                skill.Exp = Math.Min(_skillsConverter.MaxExp, Math.Max(_skillsConverter.MinExp, skill.Exp + exp));
                skill.SetChanged();
                skill.Commit();
            }
            else
            {
                if (exp > 0)
                {
                    CharacterSkill newSkill = new CharacterSkill(0, skillId, CharacterId, _skillsConverter.MinExp + exp);
                    newSkill.SetInserted();
                    newSkill.Commit();
                    _skillsSafe[skillId] = newSkill;
                }
            }
        }

        public void AddRelation(ulong npcId, int value)
        {
            ICharacterRelation relation = CharacterRelations.FirstOrDefault(r => r.NPCUid == npcId);
            if (relation == null)
            {
                relation = new CharacterRelation(0, CharacterId, npcId, value);
                relation.SetInserted();
                relation.Commit();
                _characterRelations.Add(relation);
            }
            else
            {
                relation.Value += value;
                relation.SetChanged();
                relation.Commit();
            }
        }

        public void AddRelation(int fractionId, int relationVal, int reputationVal)
        {
            IFractionRelation relation = FractionRelations.FirstOrDefault(r => r.FractionId == fractionId);
            if (relation == null)
            {
                relation = new FractionRelation(0, CharacterId, fractionId, relationVal, reputationVal);
                relation.SetInserted();
                relation.Commit();
                _fractionRelations.Add(relation);
            }
            else
            {
                relation.Value += relationVal;
                relation.Reputation += reputationVal;
                relation.SetChanged();
                relation.Commit();
            }
        }

        public void AddNewItem(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (item.ItemType == ItemType.Countable)
            {
                if (_itemsSafe.FirstOrDefault(i => i.ItemId == item.Id) is ICountableItem existing)
                {
                    existing.Count++;
                    existing.SetChanged();
                    existing.Commit();
                    return;
                }
            }

            ICharItem newItem = CharItemFactory(item);
            newItem.SetInserted();
            newItem.Commit();
            _itemsSafe.Add(newItem);
        }

        public void AddNewItem(IItem item, int count)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (item.ItemType == ItemType.Countable)
            {
                if (_itemsSafe.FirstOrDefault(i => i.ItemId == item.Id) is ICountableItem existing)
                {
                    existing.Count += count;
                    existing.SetChanged();
                    existing.Commit();
                    return;
                }
            }

            ICharItem newItem = CharItemFactory(item);
            if (newItem is ICountableItem countable)
            {
                countable.Count = count;
            }

            newItem.SetInserted();
            newItem.Commit();
            _itemsSafe.Add(newItem);
        }

        public void AddNewItem(ICharItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (Item.Items[item.ItemId].ItemType == ItemType.Countable)
            {
                if (_itemsSafe.FirstOrDefault(i => i.Id == item.Id) is ICountableItem existing)
                {
                    existing.Count++;
                    existing.SetChanged();
                    item.SetDeleted();
                    return;
                }
            }

            item.OwnerId = CharacterId;
            item.SetChanged();
            item.Commit();
            _itemsSafe.Add(item);
        }

        public void RemoveItem(ulong itemId)
        {
            ICharItem? item = _itemsSafe.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                if (Weapon != null && Weapon.Id == itemId)
                {
                    Weapon.SetDeleted();
                    Weapon.Commit();
                    Weapon = null;
                }
                else if (Helmet != null && Helmet.Id == itemId)
                {
                    Helmet.SetDeleted();
                    Helmet.Commit();
                    Helmet = null;
                }
                else if (Face != null && Face.Id == itemId)
                {
                    Face.SetDeleted();
                    Face.Commit();
                    Face = null;
                }
                else if (Mask != null && Mask.Id == itemId)
                {
                    Mask.SetDeleted();
                    Mask.Commit();
                    Mask = null;
                }
                else if (Outerwear != null && Outerwear.Id == itemId)
                {
                    Outerwear.SetDeleted();
                    Outerwear.Commit();
                    Outerwear = null;
                }
                else if (Armor != null && Armor.Id == itemId)
                {
                    Armor.SetDeleted();
                    Armor.Commit();
                    Armor = null;
                }
                else if (Pants != null && Pants.Id == itemId)
                {
                    Pants.SetDeleted();
                    Pants.Commit();
                    Pants = null;
                }
                else if (Gloves != null && Gloves.Id == itemId)
                {
                    Gloves.SetDeleted();
                    Gloves.Commit();
                    Gloves = null;
                }
                else if (Boots != null && Boots.Id == itemId)
                {
                    Boots.SetDeleted();
                    Boots.Commit();
                    Boots = null;
                }
                else if (Backpack != null && Backpack.Id == itemId)
                {
                    Backpack.SetDeleted();
                    Backpack.Commit();
                    Backpack = null;
                }
                else if (Belt != null && Belt.Id == itemId)
                {
                    Belt.SetDeleted();
                    Belt.Commit();
                    Belt = null;
                }
                else
                {
                    throw new ArgumentException($"Персонаж #{CharacterId} не обладает предметом #{itemId}");
                }
            }
            else
            {
                if (item is ICountableItem countable && countable.Count > 1)
                {
                    countable.Count--;
                    countable.SetChanged();
                    countable.Commit();
                }
                else
                {
                    item.SetDeleted();
                    item.Commit();
                    _itemsSafe.Remove(item);
                }
            }
        }

        public void RemoveItem(ulong itemId, int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            ICharItem? item = _itemsSafe.FirstOrDefault(i => i.Id == itemId);
            if (item == null)
            {
                throw new ArgumentException($"Персонаж #{CharacterId} не обладает предметом #{itemId}");
            }
            else if (item is ICountableItem countable)
            {
                if (countable.Count > count)
                {
                    countable.Count -= count;
                    countable.SetChanged();
                    countable.Commit();
                }
                else
                {
                    item.SetDeleted();
                    item.Commit();
                    _itemsSafe.Remove(item);
                }
            }
            else
            {
                throw new ArgumentException($"Предмет #{itemId} не является стакаемым");
            }
        }

        public void AddNewEffect(IEffect effect)
        {
            if (effect == null)
            {
                throw new ArgumentNullException(nameof(effect));
            }

            ICharEffect charEffect = new CharEffect(0, effect.EffectId, CharacterId, null, null);
            charEffect.SetInserted();
            charEffect.Commit();
            _effectsSafe.Add(charEffect);
        }

        public void AddNewEffect(ICharEffect effect)
        {
            if (effect == null)
            {
                throw new ArgumentNullException(nameof(effect));
            }

            _effectsSafe.Add(effect);
        }

        public void RemoveEffect(ulong effectId)
        {
            ICharEffect effect = _effectsSafe.FirstOrDefault(e => e.Id == effectId);
            if (effect == null)
            {
                throw new ArgumentException($"Персонаж #{CharacterId} не обладает эффектом #{effectId}");
            }

            effect.SetDeleted();
            effect.Commit();
            _effectsSafe.Remove(effect);
        }
        #endregion

        #region Protected/Private methods
        /// <summary>
        /// Generate a character item based on item data
        /// </summary>
        /// <param name="item">Item data</param>
        /// <returns>Formed character item</returns>
        private ICharItem CharItemFactory(IItem item)
        {
            switch (item.ItemType)
            {
                case ItemType.Other:
                    return new CharItem(0, item.Id, CharacterId, null, item.Weight);
                case ItemType.Weapon:
                    return new Weapon(0, item.Id, CharacterId, item.MaxHealth.GetValueOrDefault(100), null, item.Weight);
                case ItemType.Helmet:
                case ItemType.Face:
                case ItemType.Mask:
                case ItemType.Outerwear:
                case ItemType.Armor:
                case ItemType.Pants:
                case ItemType.Gloves:
                case ItemType.Boots:
                case ItemType.Backpack:
                case ItemType.Belt:
                    return new Equipment(0, item.Id, CharacterId, item.MaxHealth.GetValueOrDefault(100), null, item.Weight);
                case ItemType.Countable:
                    return new CountableItem(0, item.Id, 1, CharacterId, null, item.Weight);
                default:
                    throw new ArgumentException($"Не удалось сформировать объект типа {item.ItemType}");
            }
        }
        #endregion
    }
}

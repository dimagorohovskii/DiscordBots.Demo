using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.System.Data;
using RolePlay.Common.System.Exceptions;
using System;

namespace RolePlay.GameData.Extentions
{
    /// <summary>
    /// Data storage extentions
    /// </summary>
    public static class DataExtentions
    {
        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this ICharacterRelation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.CharacterRelations.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this ICharacterSkill obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Skills.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this ICharEffect obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Effects.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this ICharItem obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Items.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this IFractionRelation obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.FractionRelations.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save changes for the object
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void Commit(this IPlayerCharacter obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Characters.UniversalUpdate(obj);
        }

        /// <summary>
        /// Save character's state
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void SaveState(this IPlayerCharacter obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Characters.LightUpdate(obj, nameof(IPlayerCharacter.HP), nameof(IPlayerCharacter.Thrist), nameof(IPlayerCharacter.Hunger));
            foreach (ICharEffect effect in obj.Effects)
            {
                GameRules.DataStorage.Effects.UniversalUpdate(effect);
            }
        }

        /// <summary>
        /// Save the character's inventory
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void SaveInventory(this IPlayerCharacter obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Characters.LightUpdate(obj,
                nameof(IPlayerCharacter.Weapon), nameof(IPlayerCharacter.Helmet), nameof(IPlayerCharacter.Face),
                nameof(IPlayerCharacter.Mask), nameof(IPlayerCharacter.Outerwear), nameof(IPlayerCharacter.Armor),
                nameof(IPlayerCharacter.Pants), nameof(IPlayerCharacter.Gloves), nameof(IPlayerCharacter.Boots),
                nameof(IPlayerCharacter.Backpack), nameof(IPlayerCharacter.Belt));
            foreach (ICharItem item in obj.Items)
            {
                GameRules.DataStorage.Items.UniversalUpdate(item);
            }
        }

        /// <summary>
        /// Save character's experience
        /// </summary>
        /// <param name="obj">Object for save</param>
        public static void SaveExp(this IPlayerCharacter obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            GameRules.DataStorage.Characters.LightUpdate(obj,
                nameof(IPlayerCharacter.ExpStrength), nameof(IPlayerCharacter.ExpAgility), nameof(IPlayerCharacter.ExpPerception),
                nameof(IPlayerCharacter.ExpLuck), nameof(IPlayerCharacter.ExpEndurance), nameof(IPlayerCharacter.ExpCharisma),
                nameof(IPlayerCharacter.ExpIntelligence));
            foreach (ICharacterSkill skill in obj.Skills.Values)
            {
                GameRules.DataStorage.Skills.UniversalUpdate(skill);
            }
        }

        /// <summary>
        /// Try to get value from repository
        /// </summary>
        /// <typeparam name="TKey">Key type</typeparam>
        /// <typeparam name="TObject">Object type</typeparam>
        /// <param name="repository">Source repository</param>
        /// <param name="key">Search key</param>
        /// <param name="obj">The object that was found</param>
        /// <returns><see langword="true"/>, if the object is found. Otherwise <see langword="false"/></returns>
        public static bool TryGetValue<TKey, TObject>(this ICommonRepository<TKey, TObject> repository, TKey key, out TObject obj) where TObject : IChangeable
        {
            try
            {
                obj = repository.GetById(key);
                return true;
            }
            catch (DataNotFoundException)
            {
                obj = default;
                return false;
            }
        }
    }
}

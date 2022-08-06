using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Game effect
    /// </summary>
    public class Effect : IEffect
    {
        static Effect()
        {
            Effects = ServicesCollection.GetService<IExternalLoader>().GetGameEffects();
        }

        /// <summary>
        /// All existing effects in the game
        /// </summary>
        public static IReadOnlyDictionary<int, IEffect> Effects { get; }

        #region Class

        #region Properties
        public int EffectId { get; }

        public string Name { get; }

        public string Description { get; }

        public Bitmap Icon { get; }

        public bool CanBeMultyplied { get; }

        public IReadOnlyCollection<ICharModifier> Modifiers { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Generate a new game effect
        /// </summary>
        /// <param name="effectId">Unique object identifier</param>
        /// <param name="name">Effect name</param>
        /// <param name="description">Effect description</param>
        /// <param name="icon">Effect icon</param>
        /// <param name="canBeMultyplied">Can an effect be applied to a character multiple times?</param>
        /// <param name="modifiers">List of effect modifiers</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Effect(int effectId, string name, string description, Bitmap icon, bool canBeMultyplied, params ICharModifier[] modifiers)
        {
            EffectId = effectId;
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Icon = icon ?? throw new ArgumentNullException(nameof(icon));
            CanBeMultyplied = canBeMultyplied;
            Modifiers = new ReadOnlyCollection<ICharModifier>(modifiers);
        }
        #endregion

        #endregion
    }
}

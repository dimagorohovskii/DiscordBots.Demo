using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.System;
using System;
using System.Collections.Generic;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// (WIP) Game fraction
    /// </summary>
    public class Fraction : IFraction
    {
        static Fraction()
        {
            Fractions = ServicesCollection.GetService<IExternalLoader>().GetGameFractions();
        }


        /// <summary>
        /// All factions in the game
        /// </summary>                     
        public static IReadOnlyDictionary<long, IFraction> Fractions { get; }

        #region Class

        #region Properties
        public long Id { get; }

        public string Name { get; } = string.Empty;
        #endregion

        #region Constructors
        public Fraction(long id, string name)
        {
            Id = id;
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        #endregion

        #endregion;
    }
}

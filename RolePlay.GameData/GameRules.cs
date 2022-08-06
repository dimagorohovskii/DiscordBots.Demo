using RolePlay.Common.Game.Contracts.Mechanics;
using RolePlay.Common.System;
using RolePlay.Common.System.Data;

namespace RolePlay.GameData
{
    /// <summary>
    /// Established set of rules
    /// </summary>
    internal static class GameRules
    {
        static GameRules()
        {
            SpecialConverter = ServicesCollection.GetService<ILevelConverter>();
            SkillsConverter = ServicesCollection.GetService<ILevelConverter>();
            ItemsConverter = ServicesCollection.GetService<ILevelConverter>();
            SkillsMechanics = ServicesCollection.GetService<ISkillsMechanics>();
            CostCounter = ServicesCollection.GetService<ICostCounter>();
            FightMechanicsRules = ServicesCollection.GetService<IFightMechanicsRules>();
            DataStorage = ServicesCollection.GetService<IDataStorage>();
        }

        #region Properties
        /// <summary>
        /// Default basic skills converter
        /// </summary>
        public static ILevelConverter SpecialConverter { get; }
        /// <summary>
        /// Default dynamic skill converter
        /// </summary>
        public static ILevelConverter SkillsConverter { get; }
        /// <summary>
        /// Default items converter
        /// </summary>
        public static ILevelConverter ItemsConverter { get; }
        /// <summary>
        /// Default skill mechanics
        /// </summary>
        public static ISkillsMechanics SkillsMechanics { get; }
        /// <summary>
        /// Rules for the fights
        /// </summary>
        public static IFightMechanicsRules FightMechanicsRules { get; }
        /// <summary>
        /// Default rules for calculating the cost of items
        /// </summary>
        public static ICostCounter CostCounter { get; }
        /// <summary>
        /// Storage of all data 
        /// </summary>
        public static IDataStorage DataStorage { get; }
        #endregion
    }
}

using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.System;
using System;
using System.Collections.Generic;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// Skill instance
    /// </summary>
    public class Skill : ISkill
    {
        static Skill()
        {
            Skills = ServicesCollection.GetService<IExternalLoader>().GetGameSkills();
        }

        /// <summary>
        /// All existing skills
        /// </summary>
        public static IReadOnlyDictionary<long, ISkill> Skills { get; }


        #region Class

        #region Properties
        public long Id { get; }

        public string Name { get; } = string.Empty;
        #endregion

        #region Constructors
        /// <summary>
        /// Build a new skill
        /// </summary>
        /// <param name="id">Skill ID</param>
        /// <param name="name">Skill name</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Skill(long id, string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Id = id;
        }
        #endregion

        #endregion
    }
}

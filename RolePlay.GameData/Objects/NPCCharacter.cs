using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Mechanics;

namespace RolePlay.GameData.Objects
{
    /// <summary>
    /// (WIP) NPC
    /// </summary>
    public class NPCCharacter : Character, INPC
    {
        public NPCCharacter(ILevelConverter specialConverter, ILevelConverter skillsConverter, ISkillsMechanics skillsMechanics, IFightMechanicsRules fightMechanicsRules, ulong characterId)
            : base(specialConverter, skillsConverter, skillsMechanics, fightMechanicsRules, characterId)
        {
        }
    }
}

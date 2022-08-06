using RolePlay.Common.Game.Contracts.System;

namespace RolePlay.GameData.System
{
    /// <summary>
    /// Object that can be changed
    /// </summary>
    public abstract class ChangeableObject : IChangeable
    {
        #region Properties
        public bool IsNew { get; set; }

        public bool IsChanged { get; set; }

        public bool IsDeleted { get; set; }
        #endregion

        #region Public/Internal methods
        public void SetInserted()
        {
            IsNew = true;
        }

        public void SetDeleted()
        {
            IsDeleted = true;
        }

        public void SetChanged()
        {
            IsChanged = true;
        }

        public void SetUnchanged()
        {
            IsChanged = IsDeleted = IsNew = false;
        }
        #endregion
    }
}

namespace RolePlay.Common.Game.Contracts.System
{
    /// <summary>
    /// An object whose state can be changed
    /// </summary>
    public interface IChangeable
    {
        /// <summary>
        /// Flag that the object is new
        /// </summary>
        public bool IsNew { get; set; }
        /// <summary>
        /// Flag that the object has been modified
        /// </summary>
        public bool IsChanged { get; set; }
        /// <summary>
        /// Flag that the object has been deleted
        /// </summary>
        public bool IsDeleted { get; set; }
        /// <summary>
        /// Mark an object as created
        /// </summary>
        public void SetInserted();
        /// <summary>
        /// Mark an object as deleted
        /// </summary>
        public void SetDeleted();
        /// <summary>
        /// Mark an object as modified
        /// </summary>
        public void SetChanged();
        /// <summary>
        /// Mark an object unchanged
        /// </summary>
        public void SetUnchanged();
    }
}

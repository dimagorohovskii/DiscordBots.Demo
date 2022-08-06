using RolePlay.Common.Game.Enums;
using System;
using System.Drawing;

namespace RolePlay.Common.Game.Contracts.System
{
    /// <summary>
    /// (WIP) Manager providing visual processing tools
    /// </summary>
    public interface IVisualManager : IDisposable
    {
        /// <summary>
        /// Primary font used by default
        /// </summary>
        public FontFamily MainFont { get; }
        /// <summary>
        /// Get font by parameters
        /// </summary>
        /// <param name="name">Font name</param>
        /// <param name="size">Font size</param>
        /// <returns>Generated font</returns>
        public Font GetFont(string name, int size);
        /// <summary>
        /// Get a static image of the specified type
        /// </summary>
        /// <param name="imgType">Image type</param>
        /// <returns>Received image</returns>
        public Image GetImage(ImgType imgType);
    }
}

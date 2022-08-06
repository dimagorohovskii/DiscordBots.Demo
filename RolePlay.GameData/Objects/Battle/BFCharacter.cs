using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.Game.Enums;
using RolePlay.Common.System;
using RolePlay.GameData.Objects.Battle.Tools;
using System;
using System.Drawing;

namespace RolePlay.GameData.Objects.Battle
{
    /// <summary>
    /// Character participating in the battlefield
    /// </summary>
    internal class BFCharacter : IBFCharacter, IMovableObject, IDisposable
    {
        #region Fields
        private readonly IBattleManager _battleManager;
        private readonly BattleField _battlefield;
        private readonly Font _nameFont;
        private readonly int _fontX, _fontY, _fontHeight;
        private bool _disposedValue;
        #endregion

        #region Properties
        public ICharacter Character { get; }

        public int X { get; set; }

        public int Y { get; set; }

        public CoverType CoverType => CoverType.LightCover;

        public PassingType PassingType => PassingType.Impassable;

        public Image Image { get; }

        public int Priority => 10000000;
        #endregion

        #region Constructors
        /// <summary>
        /// Form a character for the battlefield
        /// </summary>
        /// <param name="battlefield">Battlefield - owner</param>
        /// <param name="character">Added character</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <exception cref="ArgumentNullException"></exception>
        public BFCharacter(BattleField battlefield, ICharacter character, int x, int y)
        {
            _battlefield = battlefield ?? throw new ArgumentNullException(nameof(battlefield));
            Character = character ?? throw new ArgumentNullException(nameof(character));
            _battleManager = ServicesCollection.GetService<IBattleManager>();
            Image = GetImageForCell(Character.Image);
            X = x;
            Y = y;

            IVisualManager visualManager = ServicesCollection.GetService<IVisualManager>();
            _nameFont = new Font(visualManager.MainFont, 14);
            using Bitmap b = new Bitmap(_battleManager.CellWidth, _battleManager.CellHeight);
            using Graphics g = Graphics.FromImage(b);
            SizeF size = g.MeasureString(character.Name, _nameFont);
            _fontHeight = (int)Math.Round(size.Height);
            _fontY = -(int)Math.Round(size.Height);
            _fontX = (int)Math.Round(_battleManager.CellWidth / 2d - size.Width / 2d);
        }

        ~BFCharacter()
        {
            Dispose(disposing: false);
        }
        #endregion

        #region Public/Internal methods
        public CoverType IsInCover()
        {
            CoverType ct = GetCoverType(X + 1, Y);
            if (ct == CoverType.FullCover)
            {
                return ct;
            }

            ct = (CoverType)Math.Max((int)ct, (int)GetCoverType(X - 1, Y));
            if (ct == CoverType.FullCover)
            {
                return ct;
            }

            ct = (CoverType)Math.Max((int)ct, (int)GetCoverType(X, Y + 1));
            if (ct == CoverType.FullCover)
            {
                return ct;
            }

            ct = (CoverType)Math.Max((int)ct, (int)GetCoverType(X, Y - 1));
            return ct;
        }
        public CoverType IsInCover(int x, int y)
        {
            if (x == X)
            {
                if (y > Y)
                {
                    return GetCoverType(X, Y + 1);
                }
                else
                {
                    return GetCoverType(X, Y - 1);
                }
            }

            if (y == Y)
            {
                if (x > X)
                {
                    return GetCoverType(X + 1, Y);
                }
                else
                {
                    return GetCoverType(X - 1, Y);
                }
            }

            int resultCover;
            if (X > x)
            {
                if (Y > y)
                {
                    resultCover = Math.Max((int)GetCoverType(X + 1, Y), (int)GetCoverType(X, Y + 1));
                }
                else
                {
                    resultCover = Math.Max((int)GetCoverType(X + 1, Y), (int)GetCoverType(X, Y - 1));
                }
            }
            else
            {
                if (Y > y)
                {
                    resultCover = Math.Max((int)GetCoverType(X - 1, Y), (int)GetCoverType(X, Y + 1));
                }
                else
                {
                    resultCover = Math.Max((int)GetCoverType(X - 1, Y), (int)GetCoverType(X, Y - 1));
                }
            }

            return (CoverType)resultCover;
        }

        public void Delete()
        {
            _battlefield.DynamicObjectsContainer.Delete(this);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Move(int x, int y)
        {
            _battlefield.DynamicObjectsContainer.Move(this, x, y);
        }

        public void DrawOn(Graphics g, int x, int y)
        {
            if (g == null)
            {
                throw new ArgumentNullException(nameof(g));
            }

            g.DrawImage(Image, x, y);

            CoverType cover = IsInCover();
            IVisualManager visualManager = ServicesCollection.GetService<IVisualManager>();
            Image? coverImage;
            switch (cover)
            {
                case CoverType.FullCover:
                    coverImage = visualManager.GetImage(ImgType.FullDefence);
                    break;
                case CoverType.LightCover:
                    coverImage = visualManager.GetImage(ImgType.LightDefence);
                    break;
                default:
                    coverImage = null;
                    break;
            }

            if (coverImage != null)
            {
                int imgWidth = (int)Math.Round(_battleManager.CellWidth / 2d);
                int imgHeight = (int)Math.Round(_battleManager.CellHeight / 2d);
                g.DrawImage(coverImage, x + _fontX - imgWidth, y + _fontY + _fontHeight - imgHeight, imgWidth, imgHeight);
            }

            g.DrawString(Character.Name, _nameFont, GetNameColor(), x + _fontX, y + _fontY);
        }
        #endregion

        #region Protected/Private methods
        /// <summary>
        /// Get the maximum cover level located at the coordinate
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Type of cover located by coordinates</returns>
        private CoverType GetCoverType(int x, int y)
        {
            if (x < 0 || _battlefield.Width <= x)
            {
                return CoverType.None;
            }

            if (y < 0 || _battlefield.Height <= y)
            {
                return CoverType.None;
            }

            CoverType ct = _battlefield[x, y].CoverType;
            if (ct == CoverType.FullCover)
            {
                return ct;
            }

            foreach (IDynamicBFObject dynamicObject in _battlefield.GetDynamicBFObject(x, y))
            {
                ct = (CoverType)Math.Max((int)ct, (int)dynamicObject.CoverType);
                if (ct == CoverType.FullCover)
                {
                    return ct;
                }
            }

            return ct;
        }
        /// <summary>
        /// Generate image for cell
        /// </summary>
        /// <param name="baseImage">Base image</param>
        /// <returns>Generated image for cell size</returns>
        private Image GetImageForCell(Image? baseImage)
        {
            Bitmap bitmap = new Bitmap(_battleManager.CellWidth, _battleManager.CellWidth);
            using Graphics g = Graphics.FromImage(bitmap);
            if (baseImage == null)
            {
                g.FillRectangle(Brushes.AliceBlue, 0, 0, _battleManager.CellWidth, _battleManager.CellWidth);
            }
            else
            {
                int scalledWidth, scalledHeight;
                if (baseImage.Width > baseImage.Height)
                {
                    double scale = _battleManager.CellWidth / (double)baseImage.Width;
                    scalledWidth = (int)Math.Round(baseImage.Width * scale);
                    scalledHeight = (int)Math.Round(baseImage.Height * scale);
                }
                else
                {
                    double scale = _battleManager.CellHeight / (double)baseImage.Height;
                    scalledWidth = (int)Math.Round(baseImage.Width * scale);
                    scalledHeight = (int)Math.Round(baseImage.Height * scale);
                }

                int startX = (int)Math.Round(_battleManager.CellWidth / 2d - scalledWidth / 2d);
                int startY = (int)Math.Round(_battleManager.CellHeight / 2d - scalledHeight / 2d);

                g.DrawImage(baseImage, startX, startY, scalledWidth, scalledHeight);
            }

            return bitmap;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Image?.Dispose();
                    _nameFont?.Dispose();
                }

                _disposedValue = true;
            }
        }
        /// <summary>
        /// Get actual name text color
        /// </summary>
        /// <returns>Actual name text color</returns>
        private Brush GetNameColor()
        {
            double percent = Character.HP / (double)Character.MaxHP;
            if (percent < 0.1)
            {
                return Brushes.DarkRed;
            }
            else if (percent < 0.25)
            {
                return Brushes.Red;
            }
            else if (percent < 0.5)
            {
                return Brushes.Orange;
            }
            else if (percent < 0.75)
            {
                return Brushes.Yellow;
            }
            else
            {
                return Brushes.DarkGreen;
            }
        }
        #endregion
    }
}

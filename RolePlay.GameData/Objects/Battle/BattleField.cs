using RolePlay.Common.Game.Contracts;
using RolePlay.Common.Game.Contracts.Battle;
using RolePlay.Common.Game.Contracts.System;
using RolePlay.Common.Game.Enums;
using RolePlay.Common.System;
using RolePlay.Common.System.Structs;
using RolePlay.GameData.Objects.Battle.Tools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;

namespace RolePlay.GameData.Objects.Battle
{
    /// <summary>
    /// (WIP) Representation of the battlefield
    /// </summary>
    public class BattleField : IBattleField, IDisposable
    {
        #region Fields
        private readonly Random _rand;
        private readonly IBattleFieldCell[,] _cells;
        private readonly IBattleFieldCoordManager _coordManager;
        private readonly IBattleManager _battleManager;
        private readonly Font _font;
        private readonly SizeF _fontSize;
        private bool _disposedValue;
        #endregion

        #region Properties
        public IBattleFieldCell this[int x, int y] => _cells[x, y];

        public long Id { get; }

        public int Width { get; }

        public int Height { get; }
        /// <summary>
        /// Collection of dynamic objects
        /// </summary>
        internal DynamicObjectsContainer DynamicObjectsContainer { get; }

        public IReadOnlyCollection<IDynamicBFObject> DynamicBFObjects => new ReadOnlyCollection<IDynamicBFObject>(DynamicObjectsContainer.GetAllDynamicObjects());
        #endregion

        #region Constructors
        public BattleField(long id, IBattleFieldCell[,] cells)
        {
            Id = id;
            if (cells == null)
            {
                throw new ArgumentOutOfRangeException(nameof(cells));
            }

            for (int x = 0; x < cells.GetLength(0); x++)
            {
                for (int y = 0; y < cells.GetLongLength(1); y++)
                {
                    if (cells[x, y] == null)
                    {
                        throw new ArgumentNullException($"Cell {x} {y} was Null");
                    }
                }
            }

            Width = cells.GetLength(0);
            Height = cells.GetLength(1);
            _cells = cells;
            DynamicObjectsContainer = new DynamicObjectsContainer();
            _coordManager = ServicesCollection.GetService<IBattleFieldCoordManager>();
            IVisualManager visualManager = ServicesCollection.GetService<IVisualManager>();
            _font = new Font(visualManager.MainFont, 12);
            _battleManager = ServicesCollection.GetService<IBattleManager>();

            string maxX = _coordManager.GetStringCoord(Width);
            string maxY = Height.ToString();

            using Bitmap b = new Bitmap(10, 10);
            using Graphics g = Graphics.FromImage(b);
            _fontSize = new SizeF(g.MeasureString(maxY, _font).Width, g.MeasureString(maxX, _font).Height);
            _rand = new Random();
        }

        ~BattleField()
        {
            Dispose(disposing: false);
        }
        #endregion

        #region Public/Internal methods
        public void AddNewCharacter(ICharacter character)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            GetRandomCoords(3, out int x, out int y);
            AddNewCharacter(character, x, y);
        }

        public void AddNewCharacter(ICharacter character, int x, int y)
        {
            if (character == null)
            {
                throw new ArgumentNullException(nameof(character));
            }

            if (DynamicObjectsContainer.GetCharacter(character.CharacterId) != null)
            {
                throw new ArgumentException($"Персонаж с #{character.CharacterId} уже присутствует на поле");
            }

            if (x < 0 || x >= Width)
            {
                throw new ArgumentOutOfRangeException(nameof(x));
            }

            if (y < 0 || y >= Height)
            {
                throw new ArgumentOutOfRangeException(nameof(y));
            }

            BFCharacter newChar = new BFCharacter(this, character, x, y);
            DynamicObjectsContainer.AddNewObject(newChar);
        }

        public void AddNewDynamicObject(long id, int x, int y)
        {
            DynamicObjectsContainer.AddNewObject(new DynamicBFObject(this, id, x, y));
        }

        public IBFCharacter GetBattlefieldCharacter(ulong characterId)
        {
            IBFCharacter? character = DynamicObjectsContainer.GetCharacter(characterId);
            if (character == null)
            {
                throw new ArgumentOutOfRangeException(nameof(characterId));
            }

            return character;
        }

        public IList<IDynamicBFObject> GetDynamicBFObject(int x, int y)
        {
            return DynamicObjectsContainer[x, y];
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public Image GetBattlefieldImage()
        {
            Image image = GenerateCanvas(out int startX, out int startY, out int endX, out int endY);
            using Graphics g = Graphics.FromImage(image);
            using Pen mainPen = new Pen(Brushes.Black, 3);
            using Pen shortPen = new Pen(Brushes.Black, 1);
            using Brush walkPointBrush = new SolidBrush(Color.FromArgb(30, 0, 255, 255));
            g.FillRectangle(Brushes.White, 0, 0, image.Width, image.Height);
            for (int x = 0; x < Width; x++)
            {
                int coordX = _battleManager.CellWidth * x + startX;
                for (int y = 0; y < Height; y++)
                {
                    int coordY = _battleManager.CellHeight * y + startY;
                    g.DrawImage(this[x, y].Image, coordX, coordY, _battleManager.CellWidth, _battleManager.CellHeight);

                    if (x == 0)
                    {
                        g.DrawString(y.ToString(), _font, Brushes.Black, 0, coordY);
                        g.DrawString(y.ToString(), _font, Brushes.Black, endX, coordY);
                    }
                }

                g.DrawString(_coordManager.GetStringCoord(x), _font, Brushes.Black, coordX, 0);
                g.DrawString(_coordManager.GetStringCoord(x), _font, Brushes.Black, coordX, endY);
            }

            for (int x = 0; x < Width; x++)
            {
                int coordX = _battleManager.CellWidth * x + startX;
                for (int y = 0; y < Height; y++)
                {
                    int coordY = _battleManager.CellHeight * y + startY;
                    foreach (IDynamicBFObject obj in DynamicObjectsContainer[x, y].OrderBy(x => x.Priority))
                    {
                        if (obj is IBFCharacter character)
                        {
                            character.DrawOn(g, coordX, coordY);
                        }
                        else
                        {
                            g.DrawImage(obj.Image, coordX, coordY, _battleManager.CellWidth, _battleManager.CellHeight);
                        }
                    }
                }
            }


            List<RectangleF> rects = new List<RectangleF>();
            bool gray = false;
            for (int x = 0; x < Width; x++)
            {
                if (gray)
                {
                    gray = !gray;
                    int coordX = _battleManager.CellWidth * x + startX;
                    rects.Add(new RectangleF(coordX, startY, _battleManager.CellWidth, endY - startY));
                }
                else
                {
                    gray = !gray;
                    continue;
                }
            }

            gray = false;
            for (int y = 0; y < Height; y++)
            {
                if (gray)
                {
                    gray = !gray;
                    int coordY = _battleManager.CellHeight * y + startY;
                    rects.Add(new RectangleF(startX, coordY, endX - startX, _battleManager.CellHeight));
                }
                else
                {
                    gray = !gray;
                    continue;
                }
            }

            using Brush brush = new SolidBrush(Color.FromArgb(10, 255, 255, 255));
            g.FillRectangles(brush, rects.ToArray());
            g.DrawRectangle(mainPen, startX, startY, endX - startX, endY - startY);
            return image;
        }

        public Image GetBattlefieldImage(ulong characterId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Protected/Private methods
        /// <summary>
        /// Сформировать рандомные координаты на карте
        /// </summary>
        /// <param name="rangeFromStart">Максимальное расстрояние от края</param>
        /// <param name="x">Сформированная координата X</param>
        /// <param name="y">Сформированная координата Y</param>
        private void GetRandomCoords(int rangeFromStart, out int x, out int y)
        {
            x = _rand.Next(Math.Min(Width, rangeFromStart));
            y = _rand.Next(Math.Min(Height, rangeFromStart));

            if (_rand.Next(100) > 50)
            {
                x = Width - 1 - x;
            }

            if (_rand.Next(100) > 50)
            {
                y = Height - 1 - y;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    DynamicObjectsContainer?.Dispose();
                    _font?.Dispose();
                }

                _disposedValue = true;
            }
        }
        /// <summary>
        /// Get all possible path points for a character
        /// </summary>
        /// <param name="character">Character to scan</param>
        /// <returns>Received waypoints</returns>
        private IList<BFPoint> GetAllWalkPoints(IBFCharacter character)
        {
            IDictionary<BFPoint, int> visitedPoints = new Dictionary<BFPoint, int>();
            List<BFPoint> availablePoints = new List<BFPoint>();
            ScanVisitedPoints(availablePoints, visitedPoints, character.X, character.Y, character.Character.MaxMovementDistance, true);
            return availablePoints;
        }
        /// <summary>
        /// Scan all possible paths from a point
        /// </summary>
        /// <param name="availablePoints">Points where the character can go</param>
        /// <param name="visitedPoints">Points that have already been scanned</param>
        /// <param name="x">X coordinate of the scanned point</param>
        /// <param name="y">Y coordinate of the scanned point</param>
        /// <param name="steps">Remaining number of steps</param>
        /// <param name="isFirst">Is it the first pass? If yes, then some conditions are ignored</param>
        private void ScanVisitedPoints(IList<BFPoint> availablePoints, IDictionary<BFPoint, int> visitedPoints, int x, int y, int steps, bool isFirst = false)
        {
            BFPoint point = new BFPoint(x, y);
            bool wasScanned = false;
            if (visitedPoints.TryGetValue(point, out int lastSteps))
            {
                wasScanned = true;
                if (lastSteps >= steps)
                {
                    return;
                }
            }

            visitedPoints[point] = steps;
            if (steps == 0 || x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return;
            }

            if (!isFirst)
            {
                if (_cells[x, y].PassingType == PassingType.Impassable)
                {
                    return;
                }

                if (DynamicObjectsContainer[x, y].Any(c => c.PassingType == PassingType.Impassable))
                {
                    return;
                }

                if (!wasScanned)
                {
                    availablePoints.Add(point);
                }
            }

            if (steps - 1 == 0)
            {
                return;
            }

            ScanVisitedPoints(availablePoints, visitedPoints, x - 1, y, steps - 1);
            ScanVisitedPoints(availablePoints, visitedPoints, x + 1, y, steps - 1);
            ScanVisitedPoints(availablePoints, visitedPoints, x, y - 1, steps - 1);
            ScanVisitedPoints(availablePoints, visitedPoints, x, y + 1, steps - 1);
        }
        /// <summary>
        /// Form a canvas and get dimensions to start painting
        /// </summary>
        /// <param name="startX">Start X coordinate of rendering</param>
        /// <param name="startY">Start Y coordinate of rendering</param>
        /// <param name="endX">End X coordinate of rendering</param>
        /// <param name="endY">End Y coordinate of rendering</param>
        /// <returns>Formed canvas</returns>
        private Image GenerateCanvas(out int startX, out int startY, out int endX, out int endY)
        {
            int width = (int)Math.Round(_fontSize.Width * 2 + Width * _battleManager.CellWidth);
            int height = (int)Math.Round(_fontSize.Height * 2 + Height * _battleManager.CellHeight);
            startX = (int)_fontSize.Width;
            startY = (int)_fontSize.Height;
            endX = width - (int)_fontSize.Width;
            endY = height - (int)_fontSize.Height;
            return new Bitmap(width, height);
        }
        #endregion 
    }
}

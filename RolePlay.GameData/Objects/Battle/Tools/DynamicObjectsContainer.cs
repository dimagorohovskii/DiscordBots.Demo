using RolePlay.Common.Game.Contracts.Battle;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RolePlay.GameData.Objects.Battle.Tools
{
    /// <summary>
    /// Container of dynamic battlefield objects
    /// </summary>
    internal class DynamicObjectsContainer : IDisposable
    {
        #region Fields
        private readonly IDictionary<int, IDictionary<int, IList<IDynamicBFObject>>> _dynamicObjects;
        private readonly IDictionary<ulong, IBFCharacter> _characters;
        private bool _disposedValue;
        #endregion

        #region Constructors
        /// <summary>
        /// Generate a new container of dynamic battlefield objects
        /// </summary>
        public DynamicObjectsContainer()
        {
            _dynamicObjects = new Dictionary<int, IDictionary<int, IList<IDynamicBFObject>>>();
            _characters = new Dictionary<ulong, IBFCharacter>();
        }

        ~DynamicObjectsContainer()
        {
            Dispose(disposing: false);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Get dynamic objects located by coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>List of dynamic objects located at the specified coordinates</returns>
        public IList<IDynamicBFObject> this[int x, int y]
        {
            get
            {
                if (!_dynamicObjects.TryGetValue(x, out IDictionary<int, IList<IDynamicBFObject>>? oy))
                {
                    return new IDynamicBFObject[0];
                }

                if (!oy.TryGetValue(y, out IList<IDynamicBFObject>? objects))
                {
                    return new IDynamicBFObject[0];
                }

                return objects;
            }
        }
        #endregion

        #region Public/Internal methods
        /// <summary>
        /// Add a new object to the collection
        /// </summary>
        /// <param name="obj">Object for add</param>
        public void AddNewObject(IDynamicBFObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            if (!_dynamicObjects.TryGetValue(obj.X, out IDictionary<int, IList<IDynamicBFObject>>? oy))
            {
                oy = new Dictionary<int, IList<IDynamicBFObject>>();
                _dynamicObjects[obj.X] = oy;
            }

            if (!oy.TryGetValue(obj.Y, out IList<IDynamicBFObject> objects))
            {
                objects = new List<IDynamicBFObject>();
                oy[obj.Y] = objects;
            }

            objects.Add(obj);
            if (obj is IBFCharacter character)
            {
                _characters.Add(character.Character.CharacterId, character);
            }
        }

        /// <summary>
        /// Get all added dynamic objects
        /// </summary>
        /// <returns>Collection of all added dynamic objects</returns>
        public IList<IDynamicBFObject> GetAllDynamicObjects()
        {
            List<IDynamicBFObject> objects = new List<IDynamicBFObject>();
            foreach (IDictionary<int, IList<IDynamicBFObject>>? oy in _dynamicObjects.Values)
            {
                objects.AddRange(oy.Values.SelectMany(x => x));
            }

            return objects;
        }

        /// <summary>
        /// Get character by id
        /// </summary>
        /// <param name="characterId">Character ID</param>
        /// <returns>The character with the specified id, or <see langword="null"/> if the character is not found</returns>
        public IBFCharacter? GetCharacter(ulong characterId)
        {
            if (_characters.TryGetValue(characterId, out IBFCharacter bFCharacter))
            {
                return bFCharacter;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get character by coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Character with at specified coordinates or <see langword="null"/> if character not found</returns>
        public IBFCharacter? GetCharacter(int x, int y)
        {
            return this[x, y].OfType<IBFCharacter>().FirstOrDefault();
        }

        /// <summary>
        /// Move object by specified coordinates
        /// </summary>
        /// <param name="obj">Moveable object</param>
        /// <param name="x">New coordinate X</param>
        /// <param name="y">New coordinate Y</param>
        public void Move(IDynamicBFObject obj, int x, int y)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            DeleteInternal(obj);
            if (obj is IMovableObject movable)
            {
                movable.X = x;
                movable.Y = y;
            }
            else
            {
                obj.Move(x, y);
            }

            AddNewObject(obj);
        }

        /// <summary>
        /// Remove object from collection
        /// </summary>
        /// <param name="obj">Object for removing</param>
        public void Delete(IDynamicBFObject obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }

            DeleteInternal(obj);
            if (obj is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Protected/Private methods
        /// <summary>
        /// Remove object from dictionaries
        /// </summary>
        /// <param name="obj">Object for removing</param>
        private void DeleteInternal(IDynamicBFObject obj)
        {
            IDictionary<int, IList<IDynamicBFObject>> oy = _dynamicObjects[obj.X];
            IList<IDynamicBFObject> objects = oy[obj.Y];
            objects.Remove(obj);
            if (objects.Count == 0)
            {
                oy.Remove(obj.Y);
            }

            if (oy.Count == 0)
            {
                _dynamicObjects.Remove(obj.X);
            }

            if (obj is IBFCharacter character)
            {
                _characters.Remove(character.Character.CharacterId);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    List<IDisposable> disposableObjects = new List<IDisposable>();
                    foreach (IDictionary<int, IList<IDynamicBFObject>> pairs in _dynamicObjects.Values)
                    {
                        disposableObjects.AddRange(pairs.Values.SelectMany(x => x).OfType<IDisposable>());
                    }

                    disposableObjects.ForEach(d => d.Dispose());
                }

                _disposedValue = true;
            }
        }
        #endregion
    }
}

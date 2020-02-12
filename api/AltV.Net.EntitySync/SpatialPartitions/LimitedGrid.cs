using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class LimitedGrid : Grid2
    {
        /// <summary>
        /// Comparer for comparing two keys, handling equality as beeing greater
        /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        class DuplicateKeyComparer<TKey>
            :
                IComparer<TKey> where TKey : IComparable
        {
            public int Compare(TKey x, TKey y)
            {
                var result = x.CompareTo(y);

                return result == 0 ? 1 : result;
            }
        }
        
        private static readonly DuplicateKeyComparer<float> _duplicateKeyComparer = new DuplicateKeyComparer<float>();

        private readonly int limit;
        
        private readonly SortedList<float, IEntity> sortedList = new SortedList<float, IEntity>(_duplicateKeyComparer);
        
        /// <summary>
        /// The constructor of the grid spatial partition algorithm
        /// </summary>
        /// <param name="maxX">The max x value</param>
        /// <param name="maxY">The max y value</param>
        /// <param name="areaSize">The Size of a grid area</param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="limit"></param>
        /// <param name="distance"></param>
        public LimitedGrid(int maxX, int maxY, int areaSize, int xOffset, int yOffset, int limit, int distance = 0) : base(maxX,
            maxY, areaSize, xOffset, yOffset, distance)
        {
            this.limit = limit;
        }

        public override IEnumerable<IEntity> Find(Vector3 position, int dimension)
        {
            var posX = position.X + xOffset;
            var posY = position.Y + yOffset;

            var xIndex = (int) Math.Floor(posX / areaSize);

            var yIndex = (int) Math.Floor(posY / areaSize);

            // x2 and y2 only required for complete exact range check

            /*var x2Index = (int) Math.Ceiling(posX / areaSize);

            var y2Index = (int) Math.Ceiling(posY / areaSize);*/
            
            if (xIndex < 0 || yIndex < 0 || xIndex >= maxXAreaIndex || yIndex >= maxYAreaIndex) yield break;

            var gridEntity = entityAreas[xIndex][yIndex];

            sortedList.Clear();

            while (gridEntity != null)
            {
                var entityClientDistance = Vector3.Distance(gridEntity.Entity.Position, position);
                if (entityClientDistance <= gridEntity.Entity.Range &&
                    CanSeeOtherDimension(gridEntity.Entity.Dimension, dimension))
                {
                    sortedList.Add(entityClientDistance, gridEntity.Entity);
                }

                gridEntity = gridEntity.Next;
            }

            var i = limit;
            
            using (var enumerator = sortedList.GetEnumerator())
            {
                while (i-- != 0 && enumerator.MoveNext())
                {
                    yield return enumerator.Current.Value;
                }
            }
        }
    }
}
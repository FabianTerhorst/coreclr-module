using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class LimitedPriorityGrid3 : Grid3
    {
        /// <summary>
        /// Comparer for comparing two keys, handling equality as beeing greater
        /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        private class DuplicateKeyComparer
            : IComparer<float>
        {
            public int Compare(float x, float y)
            {
                var result = x.CompareTo(y);

                return result == 0 ? 1 : result;
            }
        }

        private static readonly DuplicateKeyComparer _duplicateKeyComparer = new DuplicateKeyComparer();

        private readonly SortedLimitedList<float, IEntity> sortedList;

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
        public LimitedPriorityGrid3(int maxX, int maxY, int areaSize, int xOffset, int yOffset, int limit) : base(maxX,
            maxY, areaSize, xOffset, yOffset)
        {
            sortedList = new SortedLimitedList<float, IEntity>(limit, limit, _duplicateKeyComparer);
        }

        public override IList<IEntity> Find(Vector3 position, int dimension)
        {
            var posX = position.X + xOffset;
            var posY = position.Y + yOffset;

            var xIndex = (int) Math.Floor(posX / areaSize);

            var yIndex = (int) Math.Floor(posY / areaSize);

            // x2 and y2 only required for complete exact range check

            /*var x2Index = (int) Math.Ceiling(posX / areaSize);

            var y2Index = (int) Math.Ceiling(posY / areaSize);*/

            if (xIndex < 0 || yIndex < 0 || xIndex >= maxXAreaIndex || yIndex >= maxYAreaIndex) return null;

            var areaEntities = entityAreas[xIndex][yIndex];

            sortedList.ClearSize();

            for (int j = 0, innerLength = areaEntities.Count; j < innerLength; j++)
            {
                var areaEntity = areaEntities[j];
                var entityClientDistance = Vector3.DistanceSquared(areaEntity.Position, position);
                var entity = areaEntities[j];
                if (entityClientDistance <= entity.RangeSquared &&
                    CanSeeOtherDimension(dimension, entity.Dimension))
                {
                    areaEntity.LastStreamInRange = entityClientDistance;
                    if (((IPriorityEntity) entity).IsHighPriority)
                    {
                        sortedList.Add(0, areaEntity);
                    }
                    else
                    {
                        sortedList.Add(entityClientDistance, areaEntity);
                    }
                }
            }

            /*var i = limit;
            
            using (var enumerator = sortedList.GetEnumerator())
            {
                while (i-- != 0 && enumerator.MoveNext())
                {
                    yield return enumerator.Current.Value;
                }
            }*/

            return sortedList.Values;
        }
    }
}
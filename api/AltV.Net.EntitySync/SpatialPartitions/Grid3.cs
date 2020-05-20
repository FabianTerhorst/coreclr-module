using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class Grid3 : SpatialPartition
    {
        private static readonly float Tolerance = 0.013F; //0.01318359375F;

        // x-index, y-index, col shapes
        protected readonly List<IEntity>[][] entityAreas;

        protected readonly int maxX;

        protected readonly int maxY;

        protected readonly int areaSize;

        protected readonly int xOffset;

        protected readonly int yOffset;

        protected readonly int maxXAreaIndex;

        protected readonly int maxYAreaIndex;
        
        private readonly IList<IEntity> entities = new List<IEntity>();

        /// <summary>
        /// The constructor of the grid spatial partition algorithm
        /// </summary>
        /// <param name="maxX">The max x value</param>
        /// <param name="maxY">The max y value</param>
        /// <param name="areaSize">The Size of a grid area</param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        public Grid3(int maxX, int maxY, int areaSize, int xOffset, int yOffset)
        {
            this.maxX = maxX + xOffset;
            this.maxY = maxY + yOffset;
            this.areaSize = areaSize;
            this.xOffset = xOffset;
            this.yOffset = yOffset;

            maxXAreaIndex = this.maxX / areaSize;
            maxYAreaIndex = this.maxY / areaSize;

            entityAreas = new List<IEntity>[maxXAreaIndex][];

            for (var i = 0; i < maxXAreaIndex; i++)
            {
                entityAreas[i] = new List<IEntity>[maxYAreaIndex];
                for (var j = 0; j < maxYAreaIndex; j++)
                {
                    entityAreas[i][j] = new List<IEntity>();
                }
            }
        }

        //TODO: insert entities sorted by id
        public override void Add(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;

            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);

            if (range == 0 || startingYIndex < 0 || startingXIndex < 0 ||
                stoppingYIndex >= maxYAreaIndex ||
                stoppingXIndex >= maxXAreaIndex) return;

            // Now fill all areas from min {x, y} to max {x, y}
            for (var j = startingXIndex; j <= stoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    xArr[i].Add(entity);
                }
            }
        }

        //TODO: remove entities thar are sorted by id with binary search
        public override void Remove(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;
            var id = entity.Id;
            var type = entity.Type;

            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);

            if (range == 0 || startingYIndex < 0 || startingXIndex < 0 ||
                stoppingYIndex > maxYAreaIndex ||
                stoppingXIndex > maxXAreaIndex) return;

            // Now remove entity from all areas from min {x, y} to max {x, y}
            for (var j = startingXIndex; j <= stoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    var arr = xArr[i];
                    var length = arr.Count;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;

                    xArr[i].RemoveAt(k);
                }
            }
        }

        public override void UpdateEntityPosition(IEntity entity, in Vector3 newPosition)
        {
            var oldEntityPositionX = entity.Position.X + xOffset;
            var oldEntityPositionY = entity.Position.Y + yOffset;
            var newEntityPositionX = newPosition.X + xOffset;
            var newEntityPositionY = newPosition.Y + yOffset;
            var range = entity.Range;
            var id = entity.Id;
            var type = entity.Type;

            var oldSquareMaxX = oldEntityPositionX + range;
            var oldSquareMaxY = oldEntityPositionY + range;
            var oldSquareMinX = oldEntityPositionX - range;
            var oldSquareMinY = oldEntityPositionY - range;

            var newSquareMaxX = newEntityPositionX + range;
            var newSquareMaxY = newEntityPositionY + range;
            var newSquareMinX = newEntityPositionX - range;
            var newSquareMinY = newEntityPositionY - range;

            if (range == 0 || oldSquareMinX < 0 || oldSquareMinY < 0 ||
                oldSquareMaxX > maxX ||
                oldSquareMaxY > maxY || newSquareMinX < 0 || newSquareMinY < 0 ||
                newSquareMaxX > maxX ||
                newSquareMaxY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);

            //TODO: do later checking for overlaps between the grid areas in the two dimensional array
            //  --    --    --    --   
            // |xy|  |xy|  |yy|  |  |    
            // |yx|  |yx|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |xy|  |xy|  |yy|  |  |    
            // |yx|  |yx|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |yy|  |yy|  |yy|  |  |    
            // |yy|  |yy|  |yy|  |  |
            //  --    --    --    --  
            //
            //  --    --    --    --   
            // |  |  |  |  |  |  |  |    
            // |  |  |  |  |  |  |  |
            //  --    --    --    --  
            // Now we have to check if some of the (oldStartingYIndex, oldStoppingYIndex) areas are inside (newStartingYIndex, newStoppingYIndex)
            // Now we have to check if some of the (oldStartingXIndex, oldStoppingXIndex) areas are inside (newStartingXIndex, newStoppingXIndex)


            for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
                {
                    //TODO: Now we check if (i,j) is inside the new position range, so we don't have to delete it
                    var arr = xArr[i];
                    var length = arr.Count;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;
                    xArr[i].RemoveAt(k);
                }
            }

            for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
                {
                    xArr[i].Add(entity);
                }
            }
        }

        public override void UpdateEntityRange(IEntity entity, uint range)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var oldRange = entity.Range;
            var id = entity.Id;
            var type = entity.Type;

            var oldSquareMaxX = entityPositionX + oldRange;
            var oldSquareMaxY = entityPositionY + oldRange;
            var oldSquareMinX = entityPositionX - oldRange;
            var oldSquareMinY = entityPositionY - oldRange;

            var newSquareMaxX = entityPositionX + range;
            var newSquareMaxY = entityPositionY + range;
            var newSquareMinX = entityPositionX - range;
            var newSquareMinY = entityPositionY - range;

            if (range == 0 || oldSquareMinX < 0 || oldSquareMinY < 0 ||
                oldSquareMaxX > maxX ||
                oldSquareMaxY > maxY ||
                newSquareMinX < 0 || newSquareMinY < 0 ||
                newSquareMaxX > maxX ||
                newSquareMaxY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);

            for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
                {
                    //TODO: Now we check if (i,j) is inside the new position range, so we don't have to delete it
                    var arr = xArr[i];
                    var length = arr.Count;
                    int k;
                    var found = false;
                    for (k = 0; k < length; k++)
                    {
                        var currEntity = arr[k];
                        if (currEntity.Id != id || currEntity.Type != type) continue;
                        found = true;
                        break;
                    }

                    if (!found) continue;
                    xArr[i].RemoveAt(k);
                }
            }

            for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
                {
                    xArr[i].Add(entity);
                }
            }
        }

        public override void UpdateEntityDimension(IEntity entity, int dimension)
        {
            // This algorithm doesn't has different memory layout depending on dimension
        }

        /*
        X can see only X
        -X can see 0 and -X
        0 can't see -X and X
        */
        protected static bool CanSeeOtherDimension(int dimension, int otherDimension)
        {
            if (dimension > 0) return dimension == otherDimension || otherDimension == int.MinValue;
            if (dimension < 0) return otherDimension == 0 || dimension == otherDimension || otherDimension == int.MinValue;
            return otherDimension == 0 || otherDimension == int.MinValue;
        }

        //TODO: check if we can find a better way to pass a position and e.g. improve performance of this method by return type ect.
        public override IList<IEntity> Find(Vector3 position, int dimension)
        {
            var posX = position.X + xOffset;
            var posY = position.Y + yOffset;

            var xIndex = (int) Math.Floor(posX / areaSize);

            var yIndex = (int) Math.Floor(posY / areaSize);

            if (xIndex < 0 || yIndex < 0 || xIndex >= maxXAreaIndex || yIndex >= maxYAreaIndex) return null;

            // x2 and y2 only required for complete exact range check

            /*var x2Index = (int) Math.Ceiling(posX / areaSize);

            var y2Index = (int) Math.Ceiling(posY / areaSize);*/

            var areaEntities = entityAreas[xIndex][yIndex];
            
            entities.Clear();

            for (int j = 0, innerLength = areaEntities.Count; j < innerLength; j++)
            {
                var entity = areaEntities[j];
                if (Vector3.DistanceSquared(entity.Position, position) > entity.RangeSquared ||
                    !CanSeeOtherDimension(dimension, entity.Dimension)) continue;
                entities.Add(entity);
            }

            return entities;

            /*if (xIndex != x2Index && yIndex == y2Index)
            {
                var innerAreaEntities = entityAreas[x2Index][yIndex];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            } else if (xIndex == x2Index && yIndex != y2Index)
            {
                var innerAreaEntities = entityAreas[xIndex][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            } else if (xIndex != x2Index && yIndex != y2Index)
            {
                var innerAreaEntities = entityAreas[x2Index][yIndex];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
                
                innerAreaEntities = entityAreas[x2Index][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
                
                innerAreaEntities = entityAreas[xIndex][y2Index];

                for (int j = 0, innerLength = innerAreaEntities.Length; j < innerLength; j++)
                {
                    var entity = innerAreaEntities[j];
                    if (Vector3.Distance(entity.Position, position) > entity.Range) continue;
                    callback(entity);
                }
            }*/
        }
    }
}
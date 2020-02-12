using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class Grid2 : SpatialPartition
    {
        protected readonly GridEntity[][] entityAreas;

        protected readonly int maxX;

        protected readonly int maxY;

        protected readonly int areaSize;

        protected readonly int xOffset;

        protected readonly int yOffset;

        protected readonly int distance;

        protected readonly int maxXAreaIndex;
        
        protected readonly int maxYAreaIndex;
        

        /// <summary>
        /// The constructor of the grid spatial partition algorithm
        /// </summary>
        /// <param name="maxX">The max x value</param>
        /// <param name="maxY">The max y value</param>
        /// <param name="areaSize">The Size of a grid area</param>
        /// <param name="xOffset"></param>
        /// <param name="yOffset"></param>
        /// <param name="distance"></param>
        public Grid2(int maxX, int maxY, int areaSize, int xOffset, int yOffset, int distance = 0)
        {
            if (distance > areaSize)
            {
                throw new ArgumentException("Distance shouldn't be larger then area size:");
            }

            this.maxX = maxX;
            this.maxY = maxY;
            this.areaSize = areaSize;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
            this.distance = distance;

            maxXAreaIndex = maxX / areaSize;
            maxYAreaIndex = maxX / areaSize;

            entityAreas = new GridEntity[maxXAreaIndex][];

            for (var i = 0; i < maxXAreaIndex; i++)
            {
                entityAreas[i] = new GridEntity[maxYAreaIndex];
                for (var j = 0; j < maxYAreaIndex; j++)
                {
                    entityAreas[i][j] = null;
                }
            }
        }

        public override void Add(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);
            
            if (startingXIndex < 0) return;
            if (startingYIndex < 0) return;
            if (stoppingXIndex >= maxXAreaIndex) return;
            if (stoppingYIndex >= maxYAreaIndex) return;

            // Now fill all areas from min {x, y} to max {x, y}
            for (var j = startingXIndex; j <= stoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    var gridEntity = new GridEntity(entity, null, xArr[i]);
                    xArr[i] = gridEntity;
                    if (gridEntity.Next != null)
                    {
                        gridEntity.Next.Prev = gridEntity;
                    }
                }
            }
        }

        public override void Remove(IEntity entity)
        {
            var entityPositionX = entity.Position.X + xOffset;
            var entityPositionY = entity.Position.Y + yOffset;
            var range = entity.Range;
            var id = entity.Id;
            var type = entity.Type;
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var squareMaxX = entityPositionX + range;
            var squareMaxY = entityPositionY + range;
            var squareMinX = entityPositionX - range;
            var squareMinY = entityPositionY - range;

            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(squareMinY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(squareMinX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex =
                (int) Math.Ceiling(squareMaxY / areaSize);
            var stoppingXIndex =
                (int) Math.Ceiling(squareMaxX / areaSize);

            if (startingXIndex < 0) return;
            if (startingYIndex < 0) return;
            if (stoppingXIndex >= maxYAreaIndex) return;
            if (stoppingYIndex >= maxYAreaIndex) return;
            
            // Now remove entity from all areas from min {x, y} to max {x, y}
            for (var j = startingXIndex; j <= stoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    var gridEntity = xArr[i];
                    while (gridEntity != null)
                    {
                        if (gridEntity.Entity.Id == id && gridEntity.Entity.Type == type)
                        {
                            var prev = gridEntity.Prev;
                            var next = gridEntity.Next;
                            if (prev == null) // head of list
                            {
                                if (next != null) // maybe only element in list
                                {
                                    next.Prev = null;
                                }

                                xArr[i] = next;
                            }
                            else // not head of list
                            {
                                if (next != null)
                                {
                                    next.Prev = prev;
                                }

                                prev.Next = next;
                            }

                            break;
                        }

                        gridEntity = gridEntity.Next;
                    }
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
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var oldSquareMaxX = oldEntityPositionX + range;
            var oldSquareMaxY = oldEntityPositionY + range;
            var oldSquareMinX = oldEntityPositionX - range;
            var oldSquareMinY = oldEntityPositionY - range;
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var newSquareMaxX = newEntityPositionX + range;
            var newSquareMaxY = newEntityPositionY + range;
            var newSquareMinX = newEntityPositionX - range;
            var newSquareMinY = newEntityPositionY - range;

            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);
            
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);
            
            if (oldStartingXIndex < 0) return;
            if (oldStartingYIndex < 0) return;
            if (oldStoppingXIndex >= maxYAreaIndex) return;
            if (oldStoppingYIndex >= maxYAreaIndex) return;
            
            if (newStartingXIndex < 0) return;
            if (newStartingYIndex < 0) return;
            if (newStoppingXIndex >= maxYAreaIndex) return;
            if (newStoppingYIndex >= maxYAreaIndex) return;

            for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
                {
                    var gridEntity = xArr[i];
                    while (gridEntity != null)
                    {
                        if (gridEntity.Entity.Id == id && gridEntity.Entity.Type == type)
                        {
                            var prev = gridEntity.Prev;
                            var next = gridEntity.Next;
                            if (prev == null) // head of list
                            {
                                if (next != null) // maybe only element in list
                                {
                                    next.Prev = null;
                                }

                                xArr[i] = next;
                            }
                            else // not head of list
                            {
                                if (next != null)
                                {
                                    next.Prev = prev;
                                }

                                prev.Next = next;
                            }

                            break;
                        }

                        gridEntity = gridEntity.Next;
                    }
                }
            }

            for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
                {
                    var gridEntity = new GridEntity(entity, null, xArr[i]);
                    xArr[i] = gridEntity;
                    if (gridEntity.Next != null)
                    {
                        gridEntity.Next.Prev = gridEntity;
                    }
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
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var oldSquareMaxX = entityPositionX + oldRange;
            var oldSquareMaxY = entityPositionY + oldRange;
            var oldSquareMinX = entityPositionX - oldRange;
            var oldSquareMinY = entityPositionY - oldRange;
            
            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var newSquareMaxX = entityPositionX + range;
            var newSquareMaxY = entityPositionY + range;
            var newSquareMinX = entityPositionX - range;
            var newSquareMinY = entityPositionY - range;

            // We first use starting y index to start filling
            var oldStartingYIndex = (int) Math.Floor(oldSquareMinY / areaSize);
            // We now define starting x index to start filling
            var oldStartingXIndex = (int) Math.Floor(oldSquareMinX / areaSize);
            // Also define stopping indexes
            var oldStoppingYIndex =
                (int) Math.Ceiling(oldSquareMaxY / areaSize);
            var oldStoppingXIndex =
                (int) Math.Ceiling(oldSquareMaxX / areaSize);
            
            // We first use starting y index to start filling
            var newStartingYIndex = (int) Math.Floor(newSquareMinY / areaSize);
            // We now define starting x index to start filling
            var newStartingXIndex = (int) Math.Floor(newSquareMinX / areaSize);
            // Also define stopping indexes
            var newStoppingYIndex =
                (int) Math.Ceiling(newSquareMaxY / areaSize);
            var newStoppingXIndex =
                (int) Math.Ceiling(newSquareMaxX / areaSize);
            
            if (oldStartingXIndex < 0) return;
            if (oldStartingYIndex < 0) return;
            if (oldStoppingXIndex >= maxYAreaIndex) return;
            if (oldStoppingYIndex >= maxYAreaIndex) return;
            
            if (newStartingXIndex < 0) return;
            if (newStartingYIndex < 0) return;
            if (newStoppingXIndex >= maxYAreaIndex) return;
            if (newStoppingYIndex >= maxYAreaIndex) return;

            for (var j = oldStartingXIndex; j <= oldStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = oldStartingYIndex; i <= oldStoppingYIndex; i++)
                {
                    var gridEntity = xArr[i];
                    while (gridEntity != null)
                    {
                        if (gridEntity.Entity.Id == id && gridEntity.Entity.Type == type)
                        {
                            var prev = gridEntity.Prev;
                            var next = gridEntity.Next;
                            if (prev == null) // head of list
                            {
                                if (next != null) // maybe only element in list
                                {
                                    next.Prev = null;
                                }

                                xArr[i] = next;
                            }
                            else // not head of list
                            {
                                if (next != null)
                                {
                                    next.Prev = prev;
                                }

                                prev.Next = next;
                            }

                            break;
                        }

                        gridEntity = gridEntity.Next;
                    }
                }
            }

            for (var j = newStartingXIndex; j <= newStoppingXIndex; j++)
            {
                var xArr = entityAreas[j];
                for (var i = newStartingYIndex; i <= newStoppingYIndex; i++)
                {
                    var gridEntity = new GridEntity(entity, null, xArr[i]);
                    xArr[i] = gridEntity;
                    if (gridEntity.Next != null)
                    {
                        gridEntity.Next.Prev = gridEntity;
                    }
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
            if (dimension > 0) return dimension == otherDimension;
            if (dimension < 0) return otherDimension == 0 || dimension == otherDimension;
            if (dimension == 0) return otherDimension == 0;
            return false;
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

            while (gridEntity != null)
            {
                if (Vector3.Distance(gridEntity.Entity.Position, position) <= gridEntity.Entity.Range &&
                    CanSeeOtherDimension(gridEntity.Entity.Dimension, dimension))
                {
                    yield return gridEntity.Entity;
                }

                gridEntity = gridEntity.Next;
            }
        }
    }
}
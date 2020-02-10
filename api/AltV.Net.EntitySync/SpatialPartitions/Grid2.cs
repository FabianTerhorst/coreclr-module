using System;
using System.Collections.Generic;
using System.Numerics;

namespace AltV.Net.EntitySync.SpatialPartitions
{
    public class Grid2 : SpatialPartition
    {
        private readonly GridEntity[][] entityAreas;

        private readonly int maxX;

        private readonly int maxY;

        private readonly int areaSize;

        private readonly int xOffset;

        private readonly int yOffset;

        private readonly int distance;

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

            var maxXAreaIndex = maxX / areaSize;
            var maxYAreaIndex = maxX / areaSize;

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
            if (range == 0 || entityPositionX < 0 || entityPositionY < 0 ||
                entityPositionX > maxX ||
                entityPositionY > maxY) return;

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
            if (range == 0 || entityPositionX < 0 || entityPositionY < 0 ||
                entityPositionX > maxX ||
                entityPositionY > maxY) return;

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
            if (range == 0 || oldEntityPositionX < 0 || oldEntityPositionY < 0 ||
                oldEntityPositionX > maxX ||
                oldEntityPositionY > maxY || newEntityPositionX < 0 || newEntityPositionY < 0 ||
                newEntityPositionX > maxX ||
                newEntityPositionY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var oldSquareMaxX = oldEntityPositionX + range;
            var oldSquareMaxY = oldEntityPositionY + range;
            var oldSquareMinX = oldEntityPositionX - range;
            var oldSquareMinY = oldEntityPositionY - range;
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
            var newSquareMaxX = newEntityPositionX + range;
            var newSquareMaxY = newEntityPositionY + range;
            var newSquareMinX = newEntityPositionX - range;
            var newSquareMinY = newEntityPositionY - range;
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
            if (range == 0 || entityPositionX < 0 || entityPositionY < 0 ||
                entityPositionX > maxX ||
                entityPositionY > maxY) return;

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var oldSquareMaxX = entityPositionX + oldRange;
            var oldSquareMaxY = entityPositionY + oldRange;
            var oldSquareMinX = entityPositionX - oldRange;
            var oldSquareMinY = entityPositionY - oldRange;
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
            var newSquareMaxX = entityPositionX + range;
            var newSquareMaxY = entityPositionY + range;
            var newSquareMinX = entityPositionX - range;
            var newSquareMinY = entityPositionY - range;
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
        private static bool CanSeeOtherDimension(int dimension, int otherDimension)
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

            if (posX < 0 || posY < 0 || posX > maxX || posY > maxY) yield break;

            var xIndex = (int) Math.Floor(posX / areaSize);

            var yIndex = (int) Math.Floor(posY / areaSize);

            // x2 and y2 only required for complete exact range check

            /*var x2Index = (int) Math.Ceiling(posX / areaSize);

            var y2Index = (int) Math.Ceiling(posY / areaSize);*/

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
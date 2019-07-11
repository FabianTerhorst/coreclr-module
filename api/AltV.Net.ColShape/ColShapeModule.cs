using System;
using System.Collections.Generic;
using System.Threading;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    /// <summary>
    /// Requires a lock in entity pool and concurrent dictionary for looping, only use with AltV.Net.Async together
    /// </summary>
    public class ColShapeModule
    {
        //TODO: we maybe need two colShapeAreas then when using dimensions, because negative dimensions are supported as well
        //TODO: add support for multi dimensions by making another dimension as first index of array for dimension value,
        //TODO: but first check how global and private dimensions work

        //TODO: for removing col shapes we need to calculate x, y index again and remove it from the system array
        //TODO: just round up always when inserting col shapes then it can't happen

        // To reduce gc work
        private Position pos;
        private IColShape shape;
        private readonly HashSet<IWorldObject> worldObjectsToRemove = new HashSet<IWorldObject>();
        private readonly HashSet<IWorldObject> worldObjectsToReset = new HashSet<IWorldObject>();

        private static readonly float tolerance = 0.013F; //0.01318359375F;

        // x-index, y-index, col shapes
        private readonly IColShape[][][] colShapeAreas;

        // all col shapes
        private IColShape[] colShapes = new IColShape[0];

        internal Action<IWorldObject, IColShape> OnEntityEnterColShape;

        internal Action<IWorldObject, IColShape> OnEntityExitColShape;

        private bool running = true;

        private readonly int areaSize;

        private readonly int maxAreaIndex;

        private const int MaxCoordinate = 50_000;
        
        /// <summary>
        /// Init col shape module
        /// areaSize of 1 requires 10gb ram
        /// areaSize of 10 requires 100mb ram
        /// areaSize of 100 requires 1mb ram
        /// </summary>
        /// <param name="areaSize">Larger area size => more ram, less cpu usage</param>
        public ColShapeModule(int areaSize = 100)
        {
            this.areaSize = areaSize;
            maxAreaIndex = MaxCoordinate / areaSize;
            colShapeAreas = new IColShape[maxAreaIndex][][];
            for (var i = 0; i < maxAreaIndex; i++)
            {
                colShapeAreas[i] = new IColShape[maxAreaIndex][];
                for (var j = 0; j < maxAreaIndex; j++)
                {
                    colShapeAreas[i][j] = new IColShape[0];
                }
            }

            var thread = new Thread(Loop)
            {
                IsBackground = true
            };
            thread.Start();
        }

        public virtual ICollection<IPlayer> GetAllPlayers()
        {
            return Alt.GetAllPlayers();
        }

        public virtual ICollection<IVehicle> GetAllVehicles()
        {
            return Alt.GetAllVehicles();
        }

        // we need to save in players somehow current state to check if its not inside anymore for this player to call exit
        private void Loop()
        {
            while (running)
            {
                using (var players = GetAllPlayers().GetEnumerator())
                {
                    while (players.MoveNext())
                    {
                        ComputeWorldObject(players.Current);
                    }
                }

                using (var vehicles = GetAllVehicles().GetEnumerator())
                {
                    while (vehicles.MoveNext())
                    {
                        ComputeWorldObject(vehicles.Current);
                    }
                }

                if (worldObjectsToRemove.Count != 0)
                {
                    worldObjectsToRemove.Clear();
                }

                if (worldObjectsToReset.Count != 0)
                {
                    worldObjectsToReset.Clear();
                }

                // col shape exit is calculated via bool that gets set to false before each iteration and will set back to true when the entity is inside
                // when its still false after iteration entity isn't inside anymore
                lock (colShapes)
                {
                    for (int i = 0, length = colShapes.Length; i < length; i++)
                    {
                        var colShape = colShapes[i];
                        if (colShape.LastChecked.Count == 0) continue;
                        using (var colShapeWorldObjects = colShape.LastChecked.GetEnumerator())
                        {
                            while (colShapeWorldObjects.MoveNext())
                            {
                                if (!colShapeWorldObjects.Current.Value)
                                {
                                    shape.RemoveWorldObject(colShapeWorldObjects.Current.Key);
                                    OnEntityExitColShape?.Invoke(colShapeWorldObjects.Current.Key, shape);
                                    worldObjectsToRemove.Add(colShapeWorldObjects.Current.Key);
                                }
                                else
                                {
                                    worldObjectsToReset.Add(colShapeWorldObjects.Current.Key);
                                }
                            }
                        }

                        if (worldObjectsToReset.Count != 0)
                        {
                            using (var worldObjectsToResetEnumerator = worldObjectsToReset.GetEnumerator())
                            {
                                while (worldObjectsToResetEnumerator.MoveNext())
                                {
                                    colShape.ResetCheck(worldObjectsToResetEnumerator.Current);
                                }
                            }

                            worldObjectsToReset.Clear();
                        }

                        if (worldObjectsToRemove.Count != 0)
                        {
                            using (var worldObjectsToRemoveEnumerator = worldObjectsToRemove.GetEnumerator())
                            {
                                while (worldObjectsToRemoveEnumerator.MoveNext())
                                {
                                    colShape.RemoveCheck(worldObjectsToRemoveEnumerator.Current);
                                }
                            }

                            worldObjectsToRemove.Clear();
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }

        public void Shutdown()
        {
            running = false;
        }

        private void ComputeWorldObject(IWorldObject worldObject)
        {
            lock (worldObject)
            {
                if (!worldObject.Exists) return;
                pos = worldObject.Position;
            }

            var posX = OffsetPosition(pos.X);
            var posY = OffsetPosition(pos.Y);

            if (posX < 0 || posY < 0 || posX > MaxCoordinate || posY > MaxCoordinate) return;

            //TODO: when ceiling and floor is not the same divided by AreaSize we need to check two areas, that can happen on border

            var xIndex = (int) Math.Floor(posX / areaSize);

            var yIndex = (int) Math.Floor(posY / areaSize);

            Console.WriteLine("player: (" + xIndex + "," + yIndex + ")");

            lock (colShapeAreas)
            {
                var areaColShapes = colShapeAreas[xIndex][yIndex];

                for (int j = 0, innerLength = areaColShapes.Length; j < innerLength; j++)
                {
                    shape = areaColShapes[j];
                    if (!shape.IsPositionInside(in pos)) continue;
                    shape.SetCheck(worldObject);
                    shape.AddWorldObject(worldObject);
                    OnEntityEnterColShape?.Invoke(worldObject, shape);
                }
            }
        }

        public void Add(IColShape colShape)
        {
            //TODO: create list here instead of lock with volatile
            //var newColShapeAreas = new ColShape[500][][];
            //TODO: we need to copy array one by one, since copy doesnt support multi dimensions
            //Array.Copy(colShapeAreas, newColShapeAreas, colShapeAreas.Length);
            /*for (int i = 0, length = newColShapeAreas.Length; i < length; i++)
            {
                newColShapeAreas[i] = new ColShape[500][];
                for (int j = 0, innerLength = newColShapeAreas[i].Length; j < innerLength; j++)
                {
                    var newColShapes = new ColShape[colShapeAreas[i][j].Length];
                    Array.Copy(colShapeAreas[i][j], newColShapes, newColShapes.Length);
                    newColShapeAreas[i][j] = newColShapes;
                }
            }*/

            var colShapePositionX = OffsetPosition(colShape.Position.X);
            var colShapePositionY = OffsetPosition(colShape.Position.Y);
            if (colShape.Radius == 0 || colShapePositionX < 0 || colShapePositionY < 0 || colShapePositionX > MaxCoordinate ||
                colShapePositionY > MaxCoordinate) return;

            lock (colShapes)
            {
                var colShapesLength = colShapes.Length;
                Array.Resize(ref colShapes, colShapesLength + 1);
                colShapes[colShapesLength] = colShape;
            }

            // we actually have a circle but we use this as a square for performance reasons
            // we now find all areas that are inside this square
            var maxX = colShapePositionX + colShape.Radius;
            var maxY = colShapePositionY + colShape.Radius;
            var minX = colShapePositionX - colShape.Radius;
            var minY = colShapePositionY - colShape.Radius;
            // We first use starting y index to start filling
            var startingYIndex = (int) Math.Floor(minY / areaSize);
            // We now define starting x index to start filling
            var startingXIndex = (int) Math.Floor(minX / areaSize);
            // Also define stopping indexes
            var stoppingYIndex = (int) Math.Floor(maxY / areaSize); //TODO: Math.Ceiling when inconsistency happens
            var stoppingXIndex = (int) Math.Floor(maxX / areaSize); //TODO: Math.Ceiling when inconsistency happens
            // Now fill all areas from min {x, y} to max {x, y}
            Console.WriteLine("ColShape X Areas (" + startingXIndex + "," + stoppingXIndex + ")");
            Console.WriteLine("ColShape Y Areas (" + startingYIndex + "," + stoppingYIndex + ")");
            lock (colShapeAreas)
            {
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    for (var j = startingXIndex; j <= stoppingXIndex; j++)
                    {
                        var length = colShapeAreas[i][j].Length;
                        Array.Resize(ref colShapeAreas[i][j], length + 1);
                        colShapeAreas[j][i][length] = colShape;
                    }
                }
            }

            //TODO: trivial area should be between
            /*var xIndex = (int) Math.Floor(colShape.Position.X / AreaSize);
            var yIndex = (int) Math.Floor(colShape.Position.Y / AreaSize);
            var length = colShapeAreas[xIndex][yIndex].Length;
            Array.Resize(ref colShapeAreas[xIndex][yIndex], length + 1);
            colShapeAreas[xIndex][yIndex][length] = colShape;*/

            //colShapeAreas = newColShapeAreas TODO: when done, lock can be removed from loop and here
        }

        /// <summary>
        /// We offset the position so the maps negative positions doesn't break
        /// </summary>
        /// <param name="value">x, y, z value to offset</param>
        /// <returns></returns>
        private static float OffsetPosition(float value)
        {
            return value + 10000;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading;
using AltV.Net.Data;
using AltV.Net.Elements.Entities;

namespace AltV.Net.ColShape
{
    /// <summary>
    /// Requires a lock in entity pool, so probably always requires async
    /// </summary>
    public class ColShapeModule
    {
        //TODO: for removing col shapes we need to calculate x, y index again and remove it from the system array

        //TODO: just round up always when inserting col shapes then it can't happen,
        //TODO: btw for large colshapes we need to put same colshape in multiple areas because it can be bigger then the area

        //TODO: col shape with size <= 100 size will always be in at least all border areas

        //TODO: colshape with n = size / 100 will be in all n border areas around the calculated area

        //TODO: when x = size / 100 and n > 1 then 1 is x instead of e.g. +1 x times in a increasing 4-edge circle with the radius of size / 100

        //TODO: border areas are when index is (m, n) {(m, n), (m+1, n), (m-1, n), (m, n+1), (m, n-1), (m+1, n+1), (m+1, n-1), (m-1, n+1), (m-1, n-1)}

        //TODO: this is still not perfect, because colshapes are then expected to be placed on multiple places at ones

        //TODO: calculate the range radius with the colshape coordinates and
        //TODO: range and check which areas contains these coordinates and add it to the areas that contains the coordinates

        // To reduce gc work
        private List<IPlayer> players;
        private List<IVehicle> vehicles;
        private IPlayer curr;
        private Position pos;
        private ColShape shape;

        private static readonly float tolerance = 0.013F; //0.01318359375F;

        private const int Max = 100 * 500;

        // x-index, y-index, col shapes
        private readonly ColShape[][][] colShapeAreas = new ColShape[500][][];

        private Action<IWorldObject, ColShape> OnEntityEnterColShape;

        public ColShapeModule()
        {
            for (int i = 0, length = colShapeAreas.Length; i < length; i++)
            {
                colShapeAreas[i] = new ColShape[500][];
                for (int j = 0, innerLength = colShapeAreas[i].Length; j < innerLength; j++)
                {
                    colShapeAreas[i][j] = new ColShape[0];
                }
            }

            var thread = new Thread(Loop)
            {
                IsBackground = true
            };
            thread.Start();
        }

        // we need to save in players somehow current state to check if its not inside anymore for this player to call exit
        private void Loop()
        {
            //TODO: copy colShapeAreas array here or do lock, currently we do lock
            //TODO: add support for vehicles
            players = new List<IPlayer>(Alt.GetAllPlayers());
            vehicles = new List<IVehicle>(Alt.GetAllVehicles());

            //TODO: now hash pos in fragments of map areas and create matrix of col shape lists for map areas
            //100x100 is one area we create them when creating a col shape
            for (int i = 0, length = players.Count; i < length; i++)
            {
                ComputeWorldObject(players[i]);
            }

            for (int i = 0, length = vehicles.Count; i < length; i++)
            {
                ComputeWorldObject(vehicles[i]);
            }
        }

        private void ComputeWorldObject(IWorldObject worldObject)
        {
            lock (worldObject)
            {
                if (!worldObject.Exists) return;
                pos = worldObject.Position;
            }

            if (pos.X > Max || pos.Y > Max) return;

            //TODO: when ceiling and floor is not the same divided by 100 we need to check two areas, that can happen on border

            var xIndex = (int) Math.Floor(pos.X / 100);

            var yIndex = (int) Math.Floor(pos.Y / 100);
            lock (colShapeAreas)
            {
                var colShapes = colShapeAreas[xIndex][yIndex];

                for (int j = 0, innerLength = colShapes.Length; j < innerLength; j++)
                {
                    shape = colShapes[j];
                    if (pos.Distance(shape.Position) <= shape.Radius)
                    {
                        shape.WorldObjects.Add(worldObject);
                        OnEntityEnterColShape?.Invoke(worldObject, shape);
                        // inside
                    }
                    else
                    {
                        // outside
                    }
                }
            }
        }

        public void Add(ColShape colShape)
        {
            //TODO: create list here instead of lock wigh volatile
            lock (colShapeAreas)
            {
                if (colShape.Position.X > Max || colShape.Position.Y > Max) return;
                // we actually have a circle but we use this as a square for performance reasons
                // we now find all areas that are inside this square
                var maxX = colShape.Position.X + colShape.Radius;
                var maxY = colShape.Position.Y + colShape.Radius;
                var minX = colShape.Position.X - colShape.Radius;
                var minY = colShape.Position.Y - colShape.Radius;
                // We first use starting y index to start filling
                var startingYIndex = (int) Math.Floor(minY / 100);
                // We now define starting x index to start filling
                var startingXIndex = (int) Math.Floor(minX / 100);
                // Also define stopping indexes
                var stoppingYIndex = (int) Math.Floor(maxY / 100);
                var stoppingXIndex = (int) Math.Floor(maxX / 100);
                // Now fill all areas from min {x, y} to max {x, y}
                for (var i = startingYIndex; i <= stoppingYIndex; i++)
                {
                    for (var j = startingXIndex; j <= stoppingXIndex; j++)
                    {
                        var length = colShapeAreas[i][j].Length;
                        Array.Resize(ref colShapeAreas[i][j], length + 1);
                        colShapeAreas[i][j][length] = colShape;
                    }
                }

                //TODO: trivial area should be between
                /*var xIndex = (int) Math.Floor(colShape.Position.X / 100);
                var yIndex = (int) Math.Floor(colShape.Position.Y / 100);
                var length = colShapeAreas[xIndex][yIndex].Length;
                Array.Resize(ref colShapeAreas[xIndex][yIndex], length + 1);
                colShapeAreas[xIndex][yIndex][length] = colShape;*/
            }
        }
    }
}
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
        //TODO: just round up always when inserting col shapes then it can't happen,
        //TODO: btw for large colshapes we need to put same colshape in multiple areas because it can be bigger then the area
        
        //TODO: col shape with size <= 100 size will always be in at least all border areas
        
        //TODO: colshape with n = size / 100 will be in all n border areas around the calculated area
        
        //TODO: when x = size / 100 and n > 1 then 1 is x instead of e.g. +1 x times in a increasing 4-edge circle with the radius of size / 100
        
        //TODO: border areas are when index is (m, n) {(m, n), (m+1, n), (m-1, n), (m, n+1), (m, n-1), (m+1, n+1), (m+1, n-1), (m-1, n+1), (m-1, n-1)}
        
        // To reduce gc work
        private List<IPlayer> players;
        private IPlayer curr;
        private Position pos;

        // z doesn't matter, we put all z values in same
        
        // x-index, y-index, col shapes
        private ColShape[][][] colShapeAreas;

        public ColShapeModule()
        {
            var thread = new Thread(Loop)
            {
                IsBackground = true
            };
            thread.Start();
        }

        private void Loop()
        {
            players = new List<IPlayer>(Alt.GetAllPlayers());
            for (int i = 0, length = players.Count; i < length; i++)
            {
                curr = players[i];
                lock (curr)
                {
                    if (!curr.Exists) continue;
                    pos = curr.Position;
                }

                var xIndex = (int) Math.Ceiling(pos.X) / 100;

                var currXIndexArr = colShapeAreas[xIndex];
                
                if (currXIndexArr == null) continue;

                var yIndex = (int) Math.Ceiling(pos.Y) / 100;
                
                var curryYIndexArr = currXIndexArr[yIndex];
                
                if (curryYIndexArr == null) continue;

                for (int j = 0, innerLength = curryYIndexArr.Length; j < innerLength; j++)
                {
                    
                }

                //TODO: now hash pos in fragments of map areas and create matrix of col shape lists for map areas
                //100x100 is one area we create them when creating a col shape
            }
        }
    }
}
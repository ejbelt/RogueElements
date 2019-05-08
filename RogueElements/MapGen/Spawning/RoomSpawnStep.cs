﻿using System;
using System.Collections.Generic;

namespace RogueElements
{
    [Serializable]
    public abstract class RoomSpawnStep<T, E> : BaseSpawnStep<T, E>
        where T : class, IFloorPlanGenContext, IPlaceableGenContext<E>
        where E : ISpawnable
    {

        public RoomSpawnStep() { }
        public RoomSpawnStep(IStepSpawner<T, E> spawn) : base(spawn) { }

        public virtual void SpawnRandInCandRooms(T map, SpawnList<RoomHallIndex> spawningRooms, List<E> spawns, int successPercent)
        {
            while (spawningRooms.Count > 0 && spawns.Count > 0)
            {
                int randIndex = spawningRooms.PickIndex(map.Rand);
                RoomHallIndex roomIndex = spawningRooms.GetSpawn(randIndex);
                //try to spawn the item
                if (SpawnInRoom(map, roomIndex, spawns[spawns.Count - 1]))
                {
                    GenContextDebug.DebugProgress("Placed Object");
                    //remove the item spawn
                    spawns.RemoveAt(spawns.Count - 1);

                    if (successPercent <= 0)
                        spawningRooms.RemoveAt(randIndex);
                    else
                    {
                        int newRate = Math.Max(1, spawningRooms.GetSpawnRate(randIndex) * successPercent / 100);
                        spawningRooms.SetSpawnRate(randIndex, newRate);
                    }
                }
                else
                    spawningRooms.RemoveAt(randIndex);
            }
        }

        public virtual bool SpawnInRoom(T map, RoomHallIndex roomIndex, E spawn)
        {
            IRoomGen room = map.RoomPlan.GetRoomHall(roomIndex).Gen;
            List<Loc> freeTiles = map.GetFreeTiles(room.Draw);

            if (freeTiles.Count > 0)
            {
                int randIndex = map.Rand.Next(freeTiles.Count);
                map.PlaceItem(freeTiles[randIndex], spawn);
                return true;
            }

            return false;
        }
    }
}

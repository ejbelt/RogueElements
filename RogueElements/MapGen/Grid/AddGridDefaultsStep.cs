﻿// <copyright file="AddGridDefaultsStep.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;

namespace RogueElements
{
    [Serializable]
    public class AddGridDefaultsStep<T> : GridPlanStep<T>
        where T : class, IRoomGridGenContext
    {
        public AddGridDefaultsStep()
        {
        }

        public AddGridDefaultsStep(RandRange defaultRatio)
        {
            this.DefaultRatio = defaultRatio;
        }

        public RandRange DefaultRatio { get; set; }

        public override void ApplyToPath(IRandom rand, GridPlan floorPlan)
        {
            List<int> candidates = new List<int>();
            for (int ii = 0; ii < floorPlan.RoomCount; ii++)
            {
                if (!floorPlan.GetRoomPlan(ii).Immutable)
                {
                    List<int> adjacents = floorPlan.GetAdjacentRooms(ii);
                    if (adjacents.Count > 1)
                        candidates.Add(ii);
                }
            }

            // our candidates are all rooms except immutables and terminals
            int amountToDefault = this.DefaultRatio.Pick(rand) * candidates.Count / 100;
            for (int ii = 0; ii < amountToDefault; ii++)
            {
                int randIndex = rand.Next(candidates.Count);
                GridRoomPlan plan = floorPlan.GetRoomPlan(candidates[randIndex]);
                plan.RoomGen = new RoomGenDefault<T>();
                plan.PreferHall = true;
                candidates.RemoveAt(randIndex);
                GenContextDebug.DebugProgress("Defaulted Room");
            }
        }
    }
}

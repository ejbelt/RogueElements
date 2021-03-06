﻿// <copyright file="Map.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using RogueElements;

namespace RogueElements.Examples.Ex4_Stairs
{
    public class Map : BaseMap
    {
        public Map()
        {
            this.GenEntrances = new List<StairsUp>();
            this.GenExits = new List<StairsDown>();
        }

        public List<StairsUp> GenEntrances { get; set; }

        public List<StairsDown> GenExits { get; set; }
    }
}

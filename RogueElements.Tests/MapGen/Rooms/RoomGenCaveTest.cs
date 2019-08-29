﻿// <copyright file="RoomGenCaveTest.cs" company="Audino">
// Copyright (c) Audino
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace RogueElements.Tests
{
    [TestFixture]
    public class RoomGenCaveTest
    {
        [Test]
        [Ignore("TODO")]
        public void ProposeSize()
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("TODO")]
        public void DrawOnMap()
        {
            throw new NotImplementedException();
        }

        [Test]
        [Ignore("TODO")]
        public void PrepareFulfillableBorders()
        {
            throw new NotImplementedException();
        }

        public class TestRoomGenCave<T> : RoomGenCave<T>
            where T : ITiledGenContext
        {
            public Dictionary<Dir4, bool[]> PublicFulfillableBorder => this.FulfillableBorder;
        }
    }
}

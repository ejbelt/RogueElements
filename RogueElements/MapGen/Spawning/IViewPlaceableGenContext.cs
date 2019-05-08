﻿using System;
using System.Collections.Generic;

namespace RogueElements
{

    public interface IViewPlaceableGenContext<T> : IPlaceableGenContext<T>
        where T : ISpawnable
    {
        int Count { get; }
        T GetItem(int index);
        Loc GetLoc(int index);
    }

}

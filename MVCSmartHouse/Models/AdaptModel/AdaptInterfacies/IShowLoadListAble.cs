﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.Models.AdaptModel.AdaptInterfacies
{
    public interface IShowLoadListAble
    {
        void LoadChannel();
        string ShowChannelList();
    }
}
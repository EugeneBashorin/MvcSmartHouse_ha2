using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.Models.AdaptModel.AdaptInterfacies
{
    public interface IIncDecChannelAble
    {
        int Channel { get; set; }
        void IncreaseChannel();
        void DecreaseChannel();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCSmartHouse.Models.AdaptModel.AdaptInterfacies
{
   public interface IColdModeAble
    {
        void SetMaxMode();
        void SetMiddleMode();
        void SetMinMode();
        void SetAutoMode();
    }
}

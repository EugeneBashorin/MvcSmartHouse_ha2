using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSmartHouse1._0
{
    public interface IVolumeAble
    {
        int Volume { get; set; }
        void IncreaseVolume();
        void DecreaseVolume();
        void HandSetVolume(int inputData);
    }
}

using MVCSmartHouse.Models.AdaptModel.AdaptInterfacies;
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSmartHouse.Models.AdaptModel.AdaptModels
{
     class NewHeater: Heater, IHandSetTempWarmAble, IWarmModeAble, IIncDecTemperatureAble
    {
        private Mode mode;
        public NewHeater(string name, bool state, Mode mode, IParametrAble temperatureParam, IChangeSettingAble сhangeParams) : base(name, state, mode, temperatureParam, сhangeParams)
        {
            Name = name;
            State = state;
            this.mode = mode;
            TemperatureParam = temperatureParam;
            ChangeParams = сhangeParams;
        }   
    }
}
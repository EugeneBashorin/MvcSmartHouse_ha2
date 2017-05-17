
namespace SimpleSmartHouse1._0
{
    class AirCondition : Heater
    {      
        private Mode mode;      
        public AirCondition(string name, bool state, Mode mode, IParametrAble temperatureParam, IChangeSettingAble сhangeParams) : base(name, state, mode, temperatureParam, сhangeParams)
        {
            Name = name;
            State = state;
            this.mode = mode;
            TemperatureParam = temperatureParam;
            ChangeParams = сhangeParams;
        }
    }
}

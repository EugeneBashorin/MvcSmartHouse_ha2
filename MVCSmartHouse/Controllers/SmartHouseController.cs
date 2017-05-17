
using SimpleSmartHouse1._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSmartHouse.Controllers
{
    public class SmartHouseController : Controller
    {
        public ActionResult Index()
        {
            IDictionary<int, Device> deviceDictionary;
            if (Session["Device"] == null)
            {
                deviceDictionary = new SortedDictionary<int, Device>();
                deviceDictionary.Add(1, new TV("TV", false, new Parametr(0, 50, 3), new Parametr(1, 45, 12), new ChangeSetting(), BrightnessLevel.Default, new ListFunction()));
                deviceDictionary.Add(2, new Radio("Radio", false, new Parametr(0, 14, 3), new Parametr(1, 45, 10), new ChangeSetting(), new ListFunction()));
                deviceDictionary.Add(3, new Heater("Heater", false, Mode.Eco, new Parametr(15, 34, 18), new ChangeSetting()));
                deviceDictionary.Add(4, new AirCondition("AirCondition", false, Mode.Low, new Parametr(8, 26, 18), new ChangeSetting()));
                deviceDictionary.Add(5, new Illuminator("Illuminator", false, BrightnessLevel.Medium));
                Session["Device"] = deviceDictionary;
                Session["NextId"] = 6;
            }
            else
            {
                deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            }
            SelectListItem[] deviceList = new SelectListItem[5];
            deviceList[0] = new SelectListItem { Text = "TV", Value = "TV", Selected = true };
            deviceList[1] = new SelectListItem { Text = "Radio", Value = "Radio" };
            deviceList[2] = new SelectListItem { Text = "Heater", Value = "Heater" };
            deviceList[3] = new SelectListItem { Text = "AirCodition", Value = "AirCodition" };
            deviceList[4] = new SelectListItem { Text = "Illuminator", Value = "Illuminator" };
            ViewBag.DeviceList = deviceList;
            return View(deviceDictionary);
        }
        
        //ADD
        public ActionResult Add(string device)
        {
            Device newDevice;
            switch (device)
            {
                default:
                    newDevice = new TV("TV", false, new Parametr(1, 100, 3), new Parametr(1, 45, 15), new ChangeSetting(), BrightnessLevel.Default, new ListFunction());
                    break;
                case "Radio":
                    newDevice = new Radio("Radio", false, new Parametr(1, 100, 3), new Parametr(1, 45, 15), new ChangeSetting(), new ListFunction());
                    break;
                case "Heater":
                    newDevice = new Heater("Heater", false, Mode.Eco, new Parametr(8, 15, 12), new ChangeSetting());
                    break;
                case "AirCondition":
                    newDevice = new AirCondition("AirCondition", false, Mode.Low, new Parametr(8, 15, 12), new ChangeSetting());
                    break;
                case "Illuminator":
                    newDevice = new Illuminator("Illuminator", false, BrightnessLevel.Medium);
                    break;
            }
            int id = (int)Session["NextId"];
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            deviceDictionary.Add(id, newDevice);
            Session["Device"] = deviceDictionary;
            id++;
            Session["NextId"] = id;
            return RedirectToAction("Index");
        }
   
        //ON
        public ActionResult SwitchOn(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];

            if (deviceDictionary[id] is Device)
            {
                deviceDictionary[id].SwtchOn();

                if (deviceDictionary[id] is ISetChannelAble)
                {
                    ((ISetChannelAble)deviceDictionary[id]).LoadChannel();
                }
            }
            
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //OFF
        public ActionResult SwitchOff(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is Device)
            {
                deviceDictionary[id].SwtchOff();
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //DeleteDevice
        public ActionResult Delete(int id)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            deviceDictionary.Remove(id);
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        //Temperature//
        //HandSetTemperature
        public ActionResult SetTemperature(int id, int temperature = 15)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is ITemperatureAble)
            {
                ((ITemperatureAble)deviceDictionary[id]).HandSetTemperature(temperature);
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //IncreaseTemperature
        public ActionResult IncreaseTemperature(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is ITemperatureAble)
                if (deviceDictionary[id].State)
                {
                    ((ITemperatureAble)deviceDictionary[id]).IncreaseTemperature();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //DecreaseTemperature
        public ActionResult DecreaseTemperature(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is ITemperatureAble)
                if (deviceDictionary[id].State)
                {
                    ((ITemperatureAble)deviceDictionary[id]).DecreaseTemperature();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //HandSetVolume
        public ActionResult SetVolume(int id, int volume = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IVolumeAble)
            {
                ((IVolumeAble)deviceDictionary[id]).HandSetVolume(volume);
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //IncreaseVolume
        public ActionResult IncreaseVolume(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IVolumeAble)
                if (deviceDictionary[id].State)
                {
                    ((IVolumeAble)deviceDictionary[id]).IncreaseVolume();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //DecreaseVolume
        public ActionResult DecreaseVolume(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IVolumeAble)
                if (deviceDictionary[id].State)
                {
                    ((IVolumeAble)deviceDictionary[id]).DecreaseVolume();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //HandSetChannel
        public ActionResult SetChannel(int id, int channel = 8)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IChannelAble)
            {
               ((IChannelAble)deviceDictionary[id]).HandSetChannel(channel);
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //IncreaseChannel
        public ActionResult NextChannel(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IChannelAble)
                if (deviceDictionary[id].State)
                {
                    ((IChannelAble)deviceDictionary[id]).IncreaseChannel();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
        //DecreaseChannel
        public ActionResult PrevChannel(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IChannelAble)
                if (deviceDictionary[id].State)
                {
                    ((IChannelAble)deviceDictionary[id]).DecreaseChannel();
                }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        //ShowChannelList
        public ActionResult ShowChannelList(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IChannelAble & deviceDictionary[id].State)
            {
                if (deviceDictionary[id] is TV)
                {
                    Session["TVList"] = ((ISetChannelAble)deviceDictionary[id]).ShowChannelList();
                }
                if (deviceDictionary[id] is Radio)
                {
                    Session["RadioList"] = ((ISetChannelAble)deviceDictionary[id]).ShowChannelList();
                }
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        public ActionResult HideChannelList(int id, string command)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IChannelAble)
            {
                if (deviceDictionary[id] is TV)
                {
                    Session["TVList"] = null;
                }
                if (deviceDictionary[id] is Radio)
                {
                    Session["RadioList"] = null;
                }
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        //SetBrightMode
        public ActionResult SetBrightMode(int id, string brightMode)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IBrightAble<BrightnessLevel>)
            {
                IModeDefaultSettingsAble bMode = (IModeDefaultSettingsAble)deviceDictionary[id];
                Session["BrightMode"] = brightMode;
                switch (brightMode)
                {
                    case "Bright":
                        bMode.SetMaxMode();
                        break;
                    case "Medium":
                        bMode.SetMiddleMode();
                        break;
                    case "Low":
                        bMode.SetMinMode();
                        break;
                    default:
                        bMode.SetAutoMode();
                        break;
                }

            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }

        //SetMode
        public ActionResult SetMode(int id, string mode)
        {
            IDictionary<int, Device> deviceDictionary = (SortedDictionary<int, Device>)Session["Device"];
            if (deviceDictionary[id] is IModeAble<Mode>)
            {
                IModeDefaultSettingsAble mMode = (IModeDefaultSettingsAble)deviceDictionary[id];
                Session["Mode"] = mode;
                switch (mode)
                {
                    case "Turbo":
                        mMode.SetMaxMode();
                        break;
                    case "Eco":
                        mMode.SetMiddleMode();
                        break;
                    case "Low":
                        mMode.SetMinMode();
                        break;
                    default:
                        mMode.SetAutoMode();
                        break;
                }
            }
            Session["Device"] = deviceDictionary;
            return RedirectToAction("Index");
        }
    }
}
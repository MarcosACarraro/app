using AppXamarim.Service.Message;
using AppXamarim.Service.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarim.ViewModel
{
    public class DeviceInfoViewModel:BaseViewModel
    {
        IServiceNavigation _navigation;
        IServiceMessage _message;

        public DeviceInfoViewModel(IServiceNavigation navigation , IServiceMessage message)
        {
            _navigation = navigation;
            _message = message;
            GetInfoDevice();
        }

        public void GetInfoDevice()
        {
            var info = Plugin.DeviceInfo.CrossDeviceInfo.Current;

            Manufacturer = info.Manufacturer;
            DeviceName = info.DeviceName;
            DeviceID = info.Id;
            DeviceModel = info.Model;

        }


        #region Properties

        private string devicename = "";
        public string DeviceName { get { return devicename; } set { this.Set("DeviceName", ref devicename, value); } }

        private string deviceID = "";
        public string DeviceID { get { return deviceID; } set { this.Set("DeviceID", ref deviceID, value); } }

        private string deviceModel = "";
        public string DeviceModel { get { return deviceModel; } set { this.Set("DeviceModel", ref deviceModel, value); } }

        private string manufacturer = "";
        public string Manufacturer { get { return manufacturer; } set { this.Set("Manufacturer", ref manufacturer, value); } }

        #endregion
    }
}

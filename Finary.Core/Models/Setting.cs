using Newtonsoft.Json;
using Finary.Core.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Finary.Core.Models
{
    public class Setting
    {
        public string ApplicationName { set; get; }
        public string SecurityKey { set; get; }
        public string ProfileAddress { set; get; }

        public Setting()
        {
            init();
        }

        public void init()
        {
          
            using (SettingRepository sr = new SettingRepository())
            {
                ApplicationName = sr.GetByKey("ApplicationName");
                SecurityKey = sr.GetByKey("SecurityKey");
                ProfileAddress = sr.GetByKey("ProfileAddress");
            }

        }

    }


}


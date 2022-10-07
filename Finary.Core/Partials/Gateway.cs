using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finary.Core
{
    public partial class RialGateway
    {
        public string GetSerializedData()
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add("xConfig", this.xConfig);
            data.Add("xIsActive", this.xIsActive.ToString());
            data.Add("xIsPrimary", this.xIsPrimary.ToString());
            data.Add("xName", this.xName);
            data.Add("xTodayTotalTransactionAmounts", this.xTodayTotalTransactionAmounts.ToString());
            data.Add("xType", this.xType.ToString());
            
            return JsonConvert.SerializeObject(data);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    public class StakeHolder
    {
        public string address { get; set; }
        public string amount { get; set; }
    }

    public class StakeHoldersResponse
    {
        public int minConfirmations { get; set; }
        public string assetId { get; set; }
        public List<StakeHolder> holders { get; set; }
    }
}

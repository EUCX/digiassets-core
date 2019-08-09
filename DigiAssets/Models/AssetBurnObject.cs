using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    public class Burn
    {
        public int amount { get; set; }
        public string assetId { get; set; }
    }

    public class AssetBurnObject
    {
        public int fee { get; set; }
        public string pubKeyReturnMultisigDust { get; set; }
        public List<string> from { get; set; }
        public List<string> sendutxo { get; set; }
        public FinanceOutput financeOutput { get; set; }
        public string financeOutputTxid { get; set; }
        public List<Transfer> transfer { get; set; }
        public List<Burn> burn { get; set; }
        public Flags flags { get; set; }
        public Metadata metadata { get; set; }
    }
}

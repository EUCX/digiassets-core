using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    public class AssetSendObject
    {
        public int fee { get; set; }
        public string pubKeyReturnMultisigDust { get; set; }
        public List<string> from { get; set; }
        public List<string> sendutxo { get; set; }
        public FinanceOutput financeOutput { get; set; }
        public string financeOutputTxid { get; set; }
        public List<string> financeAddresses { get; set; }
        public List<string> to { get; set; }
        public Flags flags { get; set; }
        public Rules rules { get; set; }
        public Metadata metadata { get; set; }
    }
}

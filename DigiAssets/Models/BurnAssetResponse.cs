using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    public class BurnAssetResponse
    {
        public string txHex { get; set; }
        public List<double> coloredOutputIndexes { get; set; }
        public List<double> multisigOutputs { get; set; }
    }
}

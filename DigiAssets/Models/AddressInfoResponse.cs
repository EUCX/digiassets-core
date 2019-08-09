using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    public class Asset
    {
        public int amount { get; set; }
        public string assetId { get; set; }
        public string issueTxid { get; set; }
        public int divisibility { get; set; }
        public bool lockStatus { get; set; }
    }

    public class ScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
        public int reqSigs { get; set; }
        public List<string> addresses { get; set; }
    }

    public class Utxo
    {
        public int index { get; set; }
        public string txid { get; set; }
        public int value { get; set; }
        public int blockheight { get; set; }
        public bool used { get; set; }
        public List<Asset> assets { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
    }

    public class AddressInfoResponse
    {
        public string address { get; set; }
        public List<Utxo> utxos { get; set; }
    }
}

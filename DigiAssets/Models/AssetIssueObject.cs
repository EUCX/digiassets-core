using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{
    //public class ScriptPubKey
    //{
    //    public string asm { get; set; }
    //    public string hex { get; set; }
    //    public string type { get; set; }
    //    public int reqSigs { get; set; }
    //    public List<string> addresses { get; set; }
    //}

    public class FinanceOutput
    {
        public int value { get; set; }
        public int n { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
    }

    public class Flags
    {
        public bool injectPreviousOutput { get; set; }
    }

    public class Transfer
    {
        public string address { get; set; }
        public int amount { get; set; }
        public List<string> pubKeys { get; set; }
        public int m { get; set; }
    }

    //public class Item
    //{
    //    public string address { get; set; }
    //    public string assetId { get; set; }
    //    public double value { get; set; }
    //}

    //public class Fees
    //{
    //    public List<Item> items { get; set; }
    //    public bool locked { get; set; }
    //}

    //public class Expiration
    //{
    //    public int validUntil { get; set; }
    //    public bool locked { get; set; }
    //}

    //public class Minter
    //{
    //    public string address { get; set; }
    //    public bool locked { get; set; }
    //}

    public class Holder
    {
        public string address { get; set; }
        public bool locked { get; set; }
    }

    //public class Rules
    //{
    //    public int version { get; set; }
    //    public Fees fees { get; set; }
    //    public Expiration expiration { get; set; }
    //    public List<Minter> minters { get; set; }
    //    public List<Holder> holders { get; set; }
    //}

    //public class Url
    //{
    //    public string name { get; set; }
    //    public string url { get; set; }
    //    public string mimeType { get; set; }
    //    public string dataHash { get; set; }
    //}

    public class AssetIssueUserData
    {
    }

    public class Metadata
    {
        public string assetId { get; set; }
        public string assetName { get; set; }
        public string assetGenesis { get; set; }
        public string issuer { get; set; }
        public string description { get; set; }
        public List<Url> urls { get; set; }
        public List<Encryption> encryptions { get; set; }
        public AssetIssueUserData userData { get; set; }
    }

    public class AssetIssueObject
    {
        public string issueAddress { get; set; }
        public int amount { get; set; }
        public int fee { get; set; }
        public string pubKeyReturnMultisigDust { get; set; }
        public FinanceOutput financeOutput { get; set; }
        public string financeOutputTxid { get; set; }
        public bool reissueable { get; set; }
        public string aggregationPolicy { get; set; }
        public Flags flags { get; set; }
        public int divisibility { get; set; }
        public List<Transfer> transfer { get; set; }
        public Rules rules { get; set; }
        public Metadata metadata { get; set; }
    }
}

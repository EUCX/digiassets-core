using System;
using System.Collections.Generic;
using System.Text;

namespace DigiAssets.Core.Models
{

    public class Url
    {
        public string name { get; set; }
        public string url { get; set; }
        public string mimeType { get; set; }
        public string dataHash { get; set; }
    }

    public class Encryption
    {
        public string key { get; set; }
        public string pubKey { get; set; }
        public string format { get; set; }
        public string type { get; set; }
    }

    public class UserData
    {
    }

    public class Data
    {
        public string assetId { get; set; }
        public string assetName { get; set; }
        public string assetGenesis { get; set; }
        public string issuer { get; set; }
        public string description { get; set; }
        public List<Url> urls { get; set; }
        public List<Encryption> encryptions { get; set; }
        public UserData userData { get; set; }
    }

    public class Item
    {
        public string address { get; set; }
        public string assetId { get; set; }
        public double value { get; set; }
    }

    public class Fees
    {
        public List<Item> items { get; set; }
        public bool locked { get; set; }
    }

    public class Expiration
    {
        public int validUntil { get; set; }
        public bool locked { get; set; }
    }

    public class Minter
    {
        public string address { get; set; }
        public bool locked { get; set; }
    }

    public class RuleHolder
    {
        public string address { get; set; }
        public bool locked { get; set; }
    }

    public class Rules
    {
        public int version { get; set; }
        public Fees fees { get; set; }
        public Expiration expiration { get; set; }
        public List<Minter> minters { get; set; }
        public List<RuleHolder> holders { get; set; }
    }

    public class MetadataOfIssuence
    {
        public Data data { get; set; }
        public Rules rules { get; set; }
    }

    public class MetadataOfUtxo
    {
        public Data data { get; set; }
        public Rules rules { get; set; }
    }

    public class AssetMetaDataResponse
    {
        public int divisibility { get; set; }
        public string version { get; set; }
        public int totalSupply { get; set; }
        public int numOfHolders { get; set; }
        public int numOfTransactions { get; set; }
        public int numOfIssuance { get; set; }
        public int firstAppearsInBlock { get; set; }
        public MetadataOfIssuence metadataOfIssuence { get; set; }
        public MetadataOfUtxo metadataOfUtxo { get; set; }
        public string issueAddress { get; set; }
    }
}

# DigiAssets.Core
Simple .NET Core wrapper for DigiAssets RESTful API

## Installation
Install the NuGet package: `Install-Package DigiAssets.Core`

## Usage
```cs
try
{
    DigiAssets digiAssets = new DigiAssets("https://api.digiassets.net/v3");

    IssueAssetResponse myDigitalAsset = await digiAssets.Issue(new AssetIssueObject
    {
        amount = 500,
        metadata = new Metadata
        {
            assetName = "My Digital Asset Name",
            issuer = "Digital Asset, LLC",
            description = "Tokenized shares Digital Asset, LLC"
        },
        divisibility = 2,
        fee = 1000,
        reissueable = true,
        issueAddress = "{YOUR_ISSUE_ADDRESS}"
    });
}
catch (Exception ex)
{
    // handle exception
}
```

## More information
[DigiByte Protocol Specifications](https://github.com/DigiByte-Core/DigiAssets-Protocol-Specifications/wiki)
[DigiByte Protocol Specifications: getting started](https://github.com/DigiByte-Core/DigiAssets-Protocol-Specifications/wiki/Getting%20Started)

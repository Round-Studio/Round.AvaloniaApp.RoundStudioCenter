﻿using System.Threading.Tasks;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Entry.Assets.Center;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Enums;
using Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.NetworkServices;

namespace Round.NET.AvaloniaApp.RoundStudioCenter.Modules.Models.AssetsCenter;

public class GetAssetInfo
{
    public static async Task<AssetInfoEntry.InfoRoot> GetAssetItemInfo(AssetsIndexItemEntry item)
    {
        var type = item.Type;
        var url = "";

        switch (type)
        {
            case AssetsTypeEnum.Plugin:
                url = $"{RouterIndex.RootUrl}{RouterIndex.PluginInfoUrl}";
                break;
            case AssetsTypeEnum.Skin:
                url = $"{RouterIndex.RootUrl}{RouterIndex.SkinInfoUrl}";
                break;
            case AssetsTypeEnum.Code:
                url = $"{RouterIndex.RootUrl}{RouterIndex.CodeInfoUrl}";
                break;
        }

        url = url.Replace(RouterIndex.AssetNamePlaceholding, item.Name);
        return await HttpApiClient.GetAsync<AssetInfoEntry.InfoRoot>(url);
    }
}
const DEFAULT_RESOURCE_NAME = "_language_en_US";
const DEFAULT_LANG_CODE = "en-US";

const RESOURCES =  {
    "en-US": {
        All: 'All',
        SelectedItemCount: "# selected",
        SelectOptions: "Select options",
        SearchData: "Search data"
    },
    "zh-TW": {
        All: '全部',
        SelectedItemCount: "已選  # 個項目",
        SelectOptions: "選擇一個選項",
        SearchData: "搜寻数据"
    },
    "zh-CN": {
        All: '全部',
        SelectedItemCount: "已选  # 个项目",
        SelectOptions: "选择一个选项",
        SearchData: "搜寻数据"
    },
    "zh-Hans": {
        All: '全部',
        SelectedItemCount: "已选  # 个项目",
        SelectOptions: "选择一个选项",
        SearchData: "搜寻数据"
    },
}

function GetTextResources(language, key) {
    const langCode = language || "en-US";
    const resourceName = `_language_${langCode.replace("-", "_")}`;
    var langHandler = window[resourceName];

    return (langHandler && langHandler[key]) || (window[DEFAULT_RESOURCE_NAME] && window[DEFAULT_RESOURCE_NAME][key]) 
        || (RESOURCES[langCode] && RESOURCES[langCode][key]) || (RESOURCES[DEFAULT_LANG_CODE] && RESOURCES[DEFAULT_LANG_CODE][key])
        || key;
};

export { GetTextResources };
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Metadata;
using ReqFlow.UI.ViewModels;

namespace ReqFlow.UI.DataTemplates;

public class TabContentTemplateSelector : IDataTemplate
{
    [Content]
    public Dictionary<string, IDataTemplate> Templates { get; } = new();

    public Control? Build(object? param)
    {
        if (param == null)
        {
            return null;
        }

        // 使用 ViewModel 的实际类型名称作为键
        var key = param.GetType().Name;

        if (Templates.TryGetValue(key, out var template))
        {
            return template.Build(param);
        }

        // 如果没有找到特定类型的模板，可以返回一个默认的 TextBlock 或 null
        // 或者尝试查找基类 TabItemViewModel 的模板（如果已定义）
        if (param is TabItemViewModel && Templates.TryGetValue(nameof(TabItemViewModel), out var baseTemplate))
        {
            return baseTemplate.Build(param);
        }
        return new TextBlock { Text = $"Content template not found for type: {key}" };
    }

    public bool Match(object? data)
    {
        if (data == null)
        {
            return false;
        }
        var key = data.GetType().Name;
        if (Templates.ContainsKey(key))
        {
            return true;
        }
        // 检查是否可以匹配基类 TabItemViewModel
        if (data is TabItemViewModel && Templates.ContainsKey(nameof(TabItemViewModel)))
        {
            return true;
        }
        return false;
    }
}
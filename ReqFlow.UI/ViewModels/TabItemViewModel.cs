using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ReqFlow.UI.ViewModels;

public partial class TabItemViewModel : ObservableObject
{
    [ObservableProperty] private string _header;

    [ObservableProperty] private string _content; // 内容，可以是简单的字符串或更复杂的ViewModel

    // 用于唯一标识此标签页关联的内容节点，以便查找是否已打开
    // 我们将使用 ContentNodeViewModel 的实例本身作为ID
    public TreeNodeViewModel AssociatedNode { get; }

    // 用于从Tab项的UI请求关闭此Tab (例如，点击Tab上的关闭按钮)
    public Action<TabItemViewModel>? RequestCloseTab { get; set; }

    public TabItemViewModel(TreeNodeViewModel associatedNode, Action<TabItemViewModel>? requestCloseAction)
    {
        AssociatedNode = associatedNode;
        _header = associatedNode.Name; // 使用节点名称作为标签头
        _content = associatedNode.Name; // 使用节点的内容数据
        RequestCloseTab = requestCloseAction;
    }

    [RelayCommand]
    private void Close()
    {
        RequestCloseTab?.Invoke(this);
    }

    // 重写 Equals 和 GetHashCode 以确保基于 AssociatedNode 的比较
    // 这在使用 LINQ 的 FirstOrDefault 等方法时很有用
    public override bool Equals(object? obj)
    {
        return obj is TabItemViewModel other &&
               AssociatedNode.Equals(other.AssociatedNode);
    }

    public override int GetHashCode()
    {
        return AssociatedNode.GetHashCode();
    }
}
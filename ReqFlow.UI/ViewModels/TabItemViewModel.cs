using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReqFlow.Core.Enums;

namespace ReqFlow.UI.ViewModels;

public partial class TabItemViewModel : ObservableObject
{
    [ObservableProperty] private string _header;

    [ObservableProperty] private NodeType _nodeType;

    [ObservableProperty] private object? _content;

    public TreeNodeViewModel AssociatedNode { get; }

    public Action<TabItemViewModel>? RequestCloseTab { get; set; }

    public TabItemViewModel(TreeNodeViewModel associatedNode, Action<TabItemViewModel>? requestCloseAction)
    {
        AssociatedNode = associatedNode;
        _header = associatedNode.Name;
        _content = associatedNode.Name + associatedNode.NodeType;
        RequestCloseTab = requestCloseAction;
    }

    [RelayCommand]
    private void Close()
    {
        RequestCloseTab?.Invoke(this);
    }

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

public partial class ApiTabViewModel : TabItemViewModel
{
    public ApiTabViewModel(TreeNodeViewModel associatedNode, Action<TabItemViewModel>? requestCloseAction) : base(
        associatedNode, requestCloseAction)
    {
        NodeType = NodeType.Api;
    }
}

public partial class TestCaseTabViewModel : TabItemViewModel
{
    [ObservableProperty] private string _response = "response";

    public TestCaseTabViewModel(
        TreeNodeViewModel associatedNode,
        Action<TabItemViewModel>? requestCloseAction) : base(associatedNode, requestCloseAction)
    {
        NodeType = NodeType.TestCase;
    }
}
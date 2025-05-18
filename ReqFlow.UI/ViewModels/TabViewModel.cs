using CommunityToolkit.Mvvm.ComponentModel;

namespace ReqFlow.UI.ViewModels;

public partial class TabViewModel : ObservableObject
{
    [ObservableProperty] private string _header;

    [ObservableProperty] private bool _isSelected;

    [ObservableProperty] private string _nodeId;

    [ObservableProperty] private TreeNodeType _treeNodeType;
}
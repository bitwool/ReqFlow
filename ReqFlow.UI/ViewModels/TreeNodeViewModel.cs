using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using ReqFlow.Core.Enums;

namespace ReqFlow.UI.ViewModels;

public abstract partial class TreeNodeViewModel : ObservableObject
{
    [ObservableProperty] private string _id;

    [ObservableProperty] private string _name;

    [ObservableProperty] private NodeType _nodeType;

    [ObservableProperty] private bool _isVisible;

    [ObservableProperty] private bool _isSelected;


}

public partial class FolderNodeViewModel : TreeNodeViewModel
{
    [ObservableProperty] private bool _isExpanded;

    public ObservableCollection<TreeNodeViewModel> SubNodes { get; } = new();

}

public partial class ApiViewModel : TreeNodeViewModel
{
    [ObservableProperty] private string _httpMethod;

    [ObservableProperty] private bool _isExpanded;

    public ObservableCollection<TreeNodeViewModel> SubNodes { get; } = new();

}

public partial class TestCaseViewModel : TreeNodeViewModel
{
    [ObservableProperty] private bool _isSuccess;
}
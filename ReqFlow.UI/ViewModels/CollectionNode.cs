using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using CommunityToolkit.Mvvm.ComponentModel;
using ReqFlow.Core.Models;

namespace ReqFlow.UI.ViewModels;

public partial class CollectionNode : ObservableObject
{

    public string Id { set; get; } = string.Empty;

    public string Name { set; get; } = string.Empty;

    public NodeTypeEnum NodeType { set; get; } = NodeTypeEnum.Folder;

    public bool IsVisible { set; get; } = true;

    public bool IsExpanded { set; get; } = true;

    public bool IsTestCaseNode { set; get; } = false;

    public int Depth { get; set; } = 0;

    // public string NodeType { get; set; } = string.Empty;

    public ObservableCollection<CollectionNode> SubNodes { get; set; } = [];
}
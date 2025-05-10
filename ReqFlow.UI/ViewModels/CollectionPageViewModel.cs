using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Avalonia.Collections;
using ReqFlow.Core.Models;

namespace ReqFlow.UI.ViewModels;

public partial class CollectionPageViewModel : ViewModelBase
{
    public string Test { get; set; } = "Collection";

    public ObservableCollection<CollectionNode> Nodes { get; set; } = [];

    public CollectionPageViewModel()
    {
        CollectionNode node1 = new CollectionNode();
        node1.Name = "Node1";
        node1.NodeType = NodeTypeEnum.Folder;
        Nodes.Add(node1);
        CollectionNode node1_1 = new CollectionNode();
        node1_1.Name = "Node1_1";
        node1_1.NodeType = NodeTypeEnum.Folder;
        node1.SubNodes.Add(node1_1);
        CollectionNode node1_1_1 = new CollectionNode();
        node1_1_1.Name = "Node1_1_1";
        node1_1_1.NodeType = NodeTypeEnum.ApiDefinition;
        node1_1.SubNodes.Add(node1_1_1);

        CollectionNode node1_1_1_1 = new CollectionNode();
        node1_1_1_1.Name = "node1_1_1_1";
        node1_1_1_1.NodeType = NodeTypeEnum.TestCase;
        node1_1_1_1.IsTestCaseNode = true;
        node1_1_1.SubNodes.Add(node1_1_1_1);
        CollectionNode node1_1_1_2 = new CollectionNode();
        node1_1_1_2.Name = "node1_1_1_2";
        node1_1_1_2.NodeType = NodeTypeEnum.TestCase;
        node1_1_1_2.IsTestCaseNode = true;
        node1_1_1.SubNodes.Add(node1_1_1_2);

        CollectionNode node2 = new CollectionNode();
        node2.Name = "Node2";
        node2.NodeType = NodeTypeEnum.Folder;
        Nodes.Add(node2);
        CollectionNode node2_1 = new CollectionNode();
        node2_1.Name = "Node2_1";
        node2_1.NodeType = NodeTypeEnum.Folder;
        node2_1.IsExpanded = false;
        node2.SubNodes.Add(node2_1);

        CollectionNode node2_1_1 = new CollectionNode();
        node2_1_1.Name = "Node2_1_1";
        node2_1_1.NodeType = NodeTypeEnum.Folder;
        node2_1.SubNodes.Add(node2_1_1);

    }
}
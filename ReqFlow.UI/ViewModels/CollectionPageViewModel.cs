using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ReqFlow.UI.ViewModels;

public partial class CollectionPageViewModel : ViewModelBase
{
    public string Test { get; set; } = "Collection";

    [ObservableProperty]
    private WorkAreaViewModel _workAreaViewModel;

    [ObservableProperty] private ObservableCollection<TreeNodeViewModel> _nodes = new();

    [ObservableProperty] private TreeNodeViewModel? _selectedNode;

    public CollectionPageViewModel(WorkAreaViewModel workAreaViewModel)
    {
        _workAreaViewModel = workAreaViewModel;
        InitializeNodes();
    }

    private void InitializeNodes()
    {
        Nodes.Clear(); // 清除旧数据（如果需要）

        // 根节点 Folder1
        var folder1 = new FolderNodeViewModel
        {
            Id = "folder1",
            Name = "folder1",
            TreeNodeType = TreeNodeType.Folder,
            IsExpanded = true
        };
        Nodes.Add(folder1);

        // Folder1 的子节点 Folder1_1
        var folder1_1 = new FolderNodeViewModel
        {
            Id = "folder1_1",
            Name = "folder1_1",
            TreeNodeType = TreeNodeType.Folder,
            IsExpanded = true
        };
        folder1.SubNodes.Add(folder1_1);

        // Folder1_1 的子节点 Api1_1_1
        var api1_1_1 = new ApiViewModel
        {
            Id = "api1_1_1",
            Name = "api1_1_1",
            TreeNodeType = TreeNodeType.Api,
            HttpMethod = "GET",
            IsExpanded = true
        };
        folder1_1.SubNodes.Add(api1_1_1);

        // Api1_1_1 的子节点 TestCase1_1_1_1
        var testCase1_1_1_1 = new TestCaseViewModel
        {
            Id = "tc1_1_1_1",
            Name = "tc1_1_1_1",
            TreeNodeType = TreeNodeType.TestCase,
            IsSuccess = true
        };
        api1_1_1.SubNodes.Add(testCase1_1_1_1);

        // Api1_1_1 的子节点 TestCase1_1_1_2
        var testCase1_1_1_2 = new TestCaseViewModel
        {
            Id = "tc1_1_1_2",
            Name = "tc1_1_1_2",
            TreeNodeType = TreeNodeType.TestCase,
            IsSuccess = false
        };
        api1_1_1.SubNodes.Add(testCase1_1_1_2);

        // Folder1_1 的子节点 Api1_1_2 (平级Api)
        var api1_1_2 = new ApiViewModel
        {
            Id = "api1_1_2",
            Name = "Create User",
            TreeNodeType = TreeNodeType.Api,
            HttpMethod = "POST",
            IsExpanded = false // 默认不展开
        };
        folder1_1.SubNodes.Add(api1_1_2);


        // 根节点 Folder2
        var folder2 = new FolderNodeViewModel
        {
            Id = "folder2",
            Name = "folder2",
            TreeNodeType = TreeNodeType.Folder,
            IsExpanded = false // 默认不展开
        };
        Nodes.Add(folder2);

        // Folder2 的子节点 Folder2_1
        var folder2_1 = new FolderNodeViewModel
        {
            Id = "folder2_1",
            Name = "Categories",
            TreeNodeType = TreeNodeType.Folder,
            IsExpanded = true
        };
        folder2.SubNodes.Add(folder2_1);

        // Folder2_1 的子节点 Api2_1_1
        var api2_1_1 = new ApiViewModel
        {
            Id = "api2_1_1",
            Name = "List All Categories",
            TreeNodeType = TreeNodeType.Api,
            HttpMethod = "GET"
        };
        folder2_1.SubNodes.Add(api2_1_1);
    }


    public void OnNodeSelected(TreeNodeViewModel? treeNodeViewModel)
    {
        //如果treenodeviewmodel nodetype不是testcase 则 自动展开或者折叠

        if (treeNodeViewModel is FolderNodeViewModel folderNode)
        {
            folderNode.IsExpanded = !folderNode.IsExpanded;
        }
        else if (treeNodeViewModel is ApiViewModel apiNode)
        {
            apiNode.IsExpanded = !apiNode.IsExpanded;
        }
    }
}
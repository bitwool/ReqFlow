using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using ReqFlow.Core.Enums;

namespace ReqFlow.UI.ViewModels;

public partial class WorkAreaViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<TabItemViewModel> _openTabs = new();

    [ObservableProperty]
    private TabItemViewModel? _selectedTab;


    public void OpenOrSelectTab(TreeNodeViewModel treeNodeViewModel)
    {
        // 检查是否已存在基于 AssociatedNode 的标签页
        var existingTab = OpenTabs.FirstOrDefault(t => t.AssociatedNode.Equals(treeNodeViewModel));

        if (existingTab != null)
        {
            SelectedTab = existingTab; // 如果存在，则选中它
        }
        else
        {

            TabItemViewModel? newTab = treeNodeViewModel.NodeType switch
            {
                NodeType.Api => new ApiTabViewModel(treeNodeViewModel, CloseTab),
                NodeType.TestCase => new TestCaseTabViewModel(treeNodeViewModel, CloseTab),
                _ => null // 处理其他类型或未定义特定标签页类型的情况
            };

            if (newTab != null)
            {
                OpenTabs.Add(newTab);
                SelectedTab = newTab; // 选中新创建的标签页
            }
        }
    }

    // 关闭标签页的逻辑
    public void CloseTab(TabItemViewModel? tabToClose)
    {
        if (tabToClose != null && OpenTabs.Contains(tabToClose))
        {
            OpenTabs.Remove(tabToClose);
            // 如果关闭的是当前选中的标签页，则尝试选中列表中的第一个，或者设为null
            if (SelectedTab == tabToClose)
            {
                SelectedTab = OpenTabs.FirstOrDefault();
            }
        }
    }

    // 当选择文件夹或其他非内容项时，可以选择清空或不操作
    public void ClearOrHandleNonContentSelection()
    {
        Debug.WriteLine("Clearing or handling non-content selection");
    }

}

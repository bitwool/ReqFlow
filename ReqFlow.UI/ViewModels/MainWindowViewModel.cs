using System;
using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ReqFlow.UI.Views;

namespace ReqFlow.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private ViewModelBase _operationPage;
    [ObservableProperty] private SettingsPageViewModel _settingsPageViewModel;
    [ObservableProperty] private WorkAreaViewModel _workAreaViewModel;
    [ObservableProperty] private bool _isSettingsPage;

    // 定义各页面视图模型
    private readonly CollectionPageViewModel _collectionPageViewModel;
    private readonly VarsPageViewModel _varsPageViewModel;
    private readonly HistoryPageViewModel _historyPageViewModel;

    public MainWindowViewModel(
        CollectionPageViewModel collectionPageViewModel,
        VarsPageViewModel varsPageViewModel,
        HistoryPageViewModel historyPageViewModel,
        SettingsPageViewModel settingsPageViewModel,
        WorkAreaViewModel workAreaViewModel)
    {
        _collectionPageViewModel = collectionPageViewModel;
        _varsPageViewModel = varsPageViewModel;
        _historyPageViewModel = historyPageViewModel;
        _settingsPageViewModel = settingsPageViewModel;
        _workAreaViewModel = workAreaViewModel;

        OperationPage = _collectionPageViewModel;
        IsSettingsPage = false;

        _collectionPageViewModel.PropertyChanged += CollectionPageVM_PropertyChanged;
    }

    // 页面导航命令
    [RelayCommand]
    private void NavigateTo(string pageName)
    {
        IsSettingsPage = pageName == "Settings";

        if (!IsSettingsPage)
        {
            OperationPage = pageName switch
            {
                "Collection" => _collectionPageViewModel,
                "Vars" => _varsPageViewModel,
                "History" => _historyPageViewModel,
                _ => _collectionPageViewModel
            };
        }
    }


    private void CollectionPageVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(_collectionPageViewModel.SelectedNode))
        {
            HandleNodeSelection();
        }
    }

    private void HandleNodeSelection()
    {
        var selectedNode = _collectionPageViewModel.SelectedNode;
        if (selectedNode is TestCaseViewModel || selectedNode is ApiViewModel)
        {
            _workAreaViewModel.OpenOrSelectTab(selectedNode);
        }
        else
        {
            _workAreaViewModel.ClearOrHandleNonContentSelection();
        }
    }
}
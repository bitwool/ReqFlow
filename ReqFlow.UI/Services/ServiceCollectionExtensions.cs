using Microsoft.Extensions.DependencyInjection;
using ReqFlow.UI.ViewModels;

namespace ReqFlow.UI.Services;

public static class ServiceCollectionExtensions
{
    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<MainWindowViewModel>();
        collection.AddTransient<CollectionPageViewModel>();
        collection.AddTransient<VarsPageViewModel>();
        collection.AddTransient<HistoryPageViewModel>();
        collection.AddTransient<SettingsPageViewModel>();
        collection.AddTransient<WorkAreaViewModel>();
    }

}
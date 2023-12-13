using System.Windows.Controls;

namespace SmitApp.Contracts.Services;

public interface IPageService
{
    Type GetPageType(string key);

    Page GetPage(string key);
}

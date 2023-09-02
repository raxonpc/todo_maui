using System.Threading.Tasks;
using todo_maui.Model;

namespace todo_maui;
public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void ClearEntries()
    {
        taskTitleEntry.Text = String.Empty;
        taskDescriptionEntry.Text = String.Empty;
    }

    public void onTaskButtonClicked(object sender, EventArgs args)
    {
        ClearEntries();
        OnPropertyChanged();
    }

}


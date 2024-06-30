namespace GorselProgramlamaOdev2.Sayfalar;

public partial class Giris : ContentPage
{
	public Giris()
	{
		InitializeComponent();
	}

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (username == "suheda" && password == "suheda123")
        {
            Application.Current.MainPage = new AppShell();
        }
        else
        {
            await DisplayAlert("Hata", "Geçersiz kullanýcý adý veya þifre.", "Tamam");
        }
    }
}
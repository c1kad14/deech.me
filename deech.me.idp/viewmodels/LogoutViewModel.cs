using deech.me.idp.models;

namespace deech.me.idp.viewmodels
{
    public class LogoutViewModel : LogoutInputModel
    {
        public bool ShowLogoutPrompt { get; set; } = true;
    }
}
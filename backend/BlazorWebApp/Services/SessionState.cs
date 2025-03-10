namespace BlazorWebApp.Services
{
    public class SessionState
    {
        public bool IsAuthenticated { get; private set; } = false;
        public int UsuarioId { get; private set; } = 0;
        public string Token { get; private set; } = string.Empty;

        public event Action? OnChange;

        public void Login(int usuarioId, string token)
        {
            IsAuthenticated = true;
            UsuarioId = usuarioId;
            Token = token;
            NotifyStateChanged();
        }

        public void Logout()
        {
            IsAuthenticated = false;
            UsuarioId = 0;
            Token = string.Empty;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }


}

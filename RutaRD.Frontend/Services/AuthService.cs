using Microsoft.JSInterop;

namespace Frontend.Services
{
    public class Usuario
    {
        public string Nombre { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Contrasena { get; set; } = "";
        public string Rol { get; set; } = "Cliente";
    }

    public class AuthService
    {
        private readonly IJSRuntime _js;
        public Usuario? UsuarioActual { get; private set; }
        public event Action? OnCambio;

        private List<Usuario> _usuarios = new()
        {
            new Usuario
            {
                Nombre = "Administrador",
                Correo = "admin@rutard.com",
                Contrasena = "Admin123",
                Rol = "Administrador"
            }
        };

        public AuthService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InicializarAsync()
        {
            try
            {
                var correo = await _js.InvokeAsync<string>("localStorage.getItem", "rutard_correo");
                var rol = await _js.InvokeAsync<string>("localStorage.getItem", "rutard_rol");
                var nombre = await _js.InvokeAsync<string>("localStorage.getItem", "rutard_nombre");

                if (!string.IsNullOrEmpty(correo))
                {
                    UsuarioActual = new Usuario
                    {
                        Correo = correo,
                        Rol = rol ?? "Cliente",
                        Nombre = nombre ?? ""
                    };
                    OnCambio?.Invoke();
                }
            }
            catch { }
        }

        public string? Login(string correo, string contrasena)
        {
            var usuario = _usuarios.FirstOrDefault(u =>
                u.Correo.ToLower() == correo.ToLower() &&
                u.Contrasena == contrasena);

            if (usuario == null)
                return "Correo o contraseña incorrectos.";

            UsuarioActual = usuario;
            GuardarSesion();
            OnCambio?.Invoke();
            return null;
        }

        public string? Registrar(string nombre, string correo, string contrasena)
        {
            if (_usuarios.Any(u => u.Correo.ToLower() == correo.ToLower()))
                return "Este correo ya está registrado.";

            var nuevo = new Usuario
            {
                Nombre = nombre,
                Correo = correo,
                Contrasena = contrasena,
                Rol = "Cliente"
            };

            _usuarios.Add(nuevo);
            UsuarioActual = nuevo;
            GuardarSesion();
            OnCambio?.Invoke();
            return null;
        }

        public async Task CerrarSesion()
        {
            UsuarioActual = null;
            await _js.InvokeVoidAsync("localStorage.removeItem", "rutard_correo");
            await _js.InvokeVoidAsync("localStorage.removeItem", "rutard_rol");
            await _js.InvokeVoidAsync("localStorage.removeItem", "rutard_nombre");
            OnCambio?.Invoke();
        }

        public bool EstaAutenticado => UsuarioActual != null;
        public bool EsAdmin => UsuarioActual?.Rol == "Administrador";

        private async void GuardarSesion()
        {
            try
            {
                await _js.InvokeVoidAsync("localStorage.setItem", "rutard_correo", UsuarioActual!.Correo);
                await _js.InvokeVoidAsync("localStorage.setItem", "rutard_rol", UsuarioActual!.Rol);
                await _js.InvokeVoidAsync("localStorage.setItem", "rutard_nombre", UsuarioActual!.Nombre);
            }
            catch { }
        }
    }
}
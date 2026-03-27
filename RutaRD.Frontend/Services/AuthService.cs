using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

namespace Frontend.Services
{
    public class Usuario
    {
        public string Nombre { get; set; } = "";
        public string Correo { get; set; } = "";
        public string Rol { get; set; } = "Cliente";
    }

    public class AuthService
    {
        private readonly IJSRuntime _js;
        private readonly HttpClient _http;
        public Usuario? UsuarioActual { get; private set; }
        public event Action? OnCambio;

        public AuthService(IJSRuntime js, HttpClient http)
        {
            _js = js;
            _http = http;
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

        public async Task<string?> LoginAsync(string correo, string contrasena)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("http://localhost:5000/api/auth/login",
                    new { correo, contrasena });

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return "Correo o contraseña incorrectos.";
                }

                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();

                if (result?.usuario != null)
                {
                    UsuarioActual = new Usuario
                    {
                        Correo = result.usuario.correo,
                        Rol = result.usuario.rol,
                        Nombre = result.usuario.nombre
                    };
                    await GuardarSesionAsync();
                    OnCambio?.Invoke();
                    return null;
                }

                return "Error al procesar la respuesta.";
            }
            catch (Exception ex)
            {
                return $"Error de conexión: {ex.Message}";
            }
        }

        public async Task<string?> RegistrarAsync(string nombre, string correo, string contrasena)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("http://localhost:5000/api/auth/register",
                    new { nombre, correo, contrasena });

                if (!response.IsSuccessStatusCode)
                {
                    var error = await response.Content.ReadAsStringAsync();
                    return "El correo ya está registrado o hubo un error.";
                }

                var result = await response.Content.ReadFromJsonAsync<RegisterResponse>();

                if (result?.usuario != null)
                {
                    UsuarioActual = new Usuario
                    {
                        Correo = result.usuario.correo,
                        Rol = result.usuario.rol,
                        Nombre = result.usuario.nombre
                    };
                    await GuardarSesionAsync();
                    OnCambio?.Invoke();
                    return null;
                }

                return "Error al procesar la respuesta.";
            }
            catch (Exception ex)
            {
                return $"Error de conexión: {ex.Message}";
            }
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

        private async Task GuardarSesionAsync()
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

    public class LoginResponse
    {
        public string message { get; set; } = "";
        public UsuarioData? usuario { get; set; }
    }

    public class RegisterResponse
    {
        public string message { get; set; } = "";
        public UsuarioData? usuario { get; set; }
    }

    public class UsuarioData
    {
        public int id { get; set; }
        public string nombre { get; set; } = "";
        public string correo { get; set; } = "";
        public string rol { get; set; } = "";
    }
}
using Newtonsoft.Json;
using MVVMTiendaa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MVVMTiendaa.Services
{
    public class APIService
    {
        //inicializa httpClient
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://apiproyecto120231219155607.azurewebsites.net";

        public APIService()
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(_url)
            };
        }

        

        

        // Realiza una solicitud HTTP POST para crear una prenda

        public async Task<Prenda> CreatePrenda(PrendaUsuario prenda)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Prenda", prenda);
            return await response.Content.ReadFromJsonAsync<Prenda>();
        }

        public async Task<Prenda> UpdatePrenda(int IdPrenda, Prenda prenda)
        {
            

            var response = await _httpClient.PutAsJsonAsync("api/Prenda/" + IdPrenda, prenda);

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Prenda prod = JsonConvert.DeserializeObject<Prenda>(json_response);
                return prod;
            }
            return new Prenda();
        }

        // Realiza una solicitud HTTP para eliminar una prenda

        public async Task<bool> DeletePrenda(int IdPrenda)
        {
            var response = await _httpClient.DeleteAsync($"/api/Prenda/{IdPrenda}");
            
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

       

        ///////////////////////////ACCESORIO///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        

        

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Accesorio> CreateAccesorio(Accesorio accesorio)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Accesorio", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        public async Task<Accesorio> UpdateAccesorio(int IdAccesorio, Accesorio accesorio)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Accesorio/{IdAccesorio}", accesorio);
            return await response.Content.ReadFromJsonAsync<Accesorio>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

       
        public async Task<bool> DeleteAccesorio(int IdAccesorio)
        {
            var response = await _httpClient.DeleteAsync($"api/Accesorio/{IdAccesorio}");

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        ///////////////////////////PROMOCIONES///////////////////////////////////////
        // Realiza una solicitud HTTP para obtener la lista de accesorios
        

        

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Promocion> CreatePromocion(Promocion promocion)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Promocion", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        public async Task<Promocion> UpdatePromocion(int IdPromocion, Promocion promocion)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Promocion/ {IdPromocion}", promocion);
            return await response.Content.ReadFromJsonAsync<Promocion>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

        
        public async Task<bool> DeletePromocion(int IdPromocion)
        {
            var response = await _httpClient.DeleteAsync($"api/Promocion/{IdPromocion}");

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }

        ///////////////////////////Categorias///////////////////////////////////////

        public async Task<List<Categoria>> GetAllCategorias()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Categoria>>($"api/Categoria");
            return response;
        }

        public async Task<Categoria> GetCategoria(int IdCategoria)
        {
            // Obtiene 1 sola categoria por su Id
            var response = await _httpClient.GetFromJsonAsync<Categoria>($"api/Categoria/{IdCategoria}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Categoria> CreateCategoria(Categoria categoria)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Categoria", categoria);
            return await response.Content.ReadFromJsonAsync<Categoria>();
        }

        public async Task<Categoria> UpdateCategoria(int IdCategoria, Categoria categoria)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Categoria/ {IdCategoria}", categoria);
            return await response.Content.ReadFromJsonAsync<Categoria>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        public async void DeleteCategoria(int IdCategoria)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
            _httpClient.DeleteAsync($"api/Categoria/{IdCategoria}");
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada

        }

        ///////////////////////////Marca///////////////////////////////////////
        public async Task<List<Marca>> GetAllMarcas()

        {

            var response = await _httpClient.GetFromJsonAsync<List<Marca>>("api/Marca");
            return response;
        }

        public async Task<Marca> GetMarca(int IdMarca)
        {
            // Obtiene 1 solo accesorio por su Id
            var response = await _httpClient.GetFromJsonAsync<Marca>($"api/Marca/{IdMarca}");
            return response;
        }

        // Realiza una solicitud HTTP POST para crear un accesorio

        public async Task<Marca> CreateMarca(Marca marca)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Marca", marca);
            return await response.Content.ReadFromJsonAsync<Marca>();
        }

        public async Task<Marca> UpdateMarca(int IdMarca, Marca marca)
        {
            // Realiza una solicitud HTTP PUT para modificar un accesorio
            var response = await _httpClient.PutAsJsonAsync($"api/Marca/ {IdMarca}", marca);
            return await response.Content.ReadFromJsonAsync<Marca>();
        }

        // Realiza una solicitud HTTP para eliminar un accesorio

#pragma warning disable CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        public async void DeleteMarca(int IdMarca)
#pragma warning restore CS1998 // El método asincrónico carece de operadores "await" y se ejecutará de forma sincrónica
        {
#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
            _httpClient.DeleteAsync($"api/Marca/{IdMarca}");
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
        }

        // MÉTODOS QUE USAMOOOOOOSSSSS --------------------------------------------------------

        //USUARIOS
        public async Task<Usuario> GetUsuario(string usuario, string contrasena)
        {
            var response = await _httpClient.GetAsync($"/api/Usuario/porcliente/{usuario}/{contrasena}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuario1 = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuario1;
            }
            return null;
        }

        public async Task<Usuario> GetUsuarioPorCodigo(int IdUsuario)
        {
            var response = await _httpClient.GetAsync($"/api/Usuario/{IdUsuario}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuario1 = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuario1;
            }
            return null;
        }

        public async Task<Usuario> PostUsuario(Usuario usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"/api/Usuario/cliente", content);//viaja por el cuerpo
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuario1 = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuario1;
            }
            return null;
        }

        public async Task<Prenda> GetPrenda(int IdPrenda)
        {
            // Obtiene 1 solo prendas por su Id
            var response = await _httpClient.GetFromJsonAsync<Prenda>($"api/Prenda/{IdPrenda}");


            return response;
        }

        public async Task<List<Prenda>> GetAllPrendas()
        {
            var response = await _httpClient.GetAsync("/api/Prenda");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Prenda> prendas = JsonConvert.DeserializeObject<List<Prenda>>(json_response);
                return prendas;
            }
            return new List<Prenda>();

        }

        public async Task<List<Accesorio>> GetAllAccesorios()
        {
            var response = await _httpClient.GetAsync("/api/Accesorio");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Accesorio> accesorios = JsonConvert.DeserializeObject<List<Accesorio>>(json_response);
                return accesorios;
            }
            return new List<Accesorio>();

        }

        public async Task<Accesorio> GetAccesorio(int IdAccesorio)
        {
            // Obtiene 1 solo prendas por su Id
            var response = await _httpClient.GetFromJsonAsync<Accesorio>($"/api/Accesorio/{IdAccesorio}");


            return response;
        }

        //PROMOCIONES

        public async Task<List<Promocion>> GetAllPromociones()
        {
            var response = await _httpClient.GetAsync("/api/Promocion");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Promocion> promociones = JsonConvert.DeserializeObject<List<Promocion>>(json_response);
                return promociones;
            }
            return new List<Promocion>();

        }

        public async Task<Promocion> GetPromocion(int IdPromocion)
        {
            // Obtiene 1 solo prendas por su Id
            var response = await _httpClient.GetFromJsonAsync<Promocion>($"/api/Promocion/{IdPromocion}");


            return response;
        }

        public async Task<Carrito> PostCarrito(CarritoUsuario carritoUsuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(carritoUsuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Carrito", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Carrito carrito = JsonConvert.DeserializeObject<Carrito>(json_response);
                return carrito;
            }
            return new Carrito();
        }

        public async Task<List<DetalleCarrito>> GetAllDetalleCarritos()
        {
            var response = await _httpClient.GetAsync("/api/DetalleCarrito");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<DetalleCarrito> detalleCarrito = JsonConvert.DeserializeObject<List<DetalleCarrito>>(json_response);
                return detalleCarrito;
            }
            return new List<DetalleCarrito>();
        }
        //este metodo retorna todo la descripcion de un solo carrito

        public async Task<List<DetalleCarrito>> GetDetalleCarrito(int CarritoIdCarrito)
        {
            // Obtiene 1 solo prendas por su Id
            

            var response = await _httpClient.GetAsync($"/api/DetalleCarrito/porCarrito/{CarritoIdCarrito}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<DetalleCarrito> descripciones = JsonConvert.DeserializeObject<List<DetalleCarrito>>(json_response);
                return descripciones;
            }
            return new List<DetalleCarrito>();
        }

        public async Task<List<DetalleCompra>> GetDetalleCompra(int CompraIdCompra)
        {
            // Obtiene la lista de la descripcion por factura


            var response = await _httpClient.GetAsync($"/api/DetalleCompra/porCompra/{CompraIdCompra}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<DetalleCompra> descripciones = JsonConvert.DeserializeObject<List<DetalleCompra>>(json_response);
                return descripciones;
            }
            return new List<DetalleCompra>();
        }


        //uso para añadir al carrito

        public async Task<DetalleCarrito> PostDetalleCarrito(DetalleCarritoUsuario detalleCarritoUsuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(detalleCarritoUsuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/DetalleCarrito", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                DetalleCarrito dtcarrito = JsonConvert.DeserializeObject<DetalleCarrito>(json_response);
                return dtcarrito;
            }
            return new DetalleCarrito();
        }

        public async Task<Usuario> UpdateUsuario(int IdUsuario, Usuario usuario)
        {
            var content = new StringContent(JsonConvert.SerializeObject(usuario), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Usuario/{IdUsuario}", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Usuario usuario1 = JsonConvert.DeserializeObject<Usuario>(json_response);
                return usuario1;
            }
            return null;
        }
        // borrar productos
        public async Task<bool> DeleteDetalleCarrito(int IdDetalleCarrito)
        {
            var response = await _httpClient.DeleteAsync($"/api/DetalleCarrito/{IdDetalleCarrito}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<DetalleCarrito> descripciones = JsonConvert.DeserializeObject<List<DetalleCarrito>>(json_response);
                return true;
            }
            return false;

        }

        //GENERAR LA FACTURA DE COMPRA
        public async Task<Compra> PostNuevaCompra(int CarridoIdCarrito)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CarridoIdCarrito), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Carrito/GenerarCompra", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Compra compra = JsonConvert.DeserializeObject<Compra>(json_response);
                return compra;
            }
            return new Compra();
        }

        public async Task<bool> PostGenerarDetalleFactura(MandarDescripcion mandarDescr)
        {
            var content = new StringContent(JsonConvert.SerializeObject(mandarDescr), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/DetalleCarrito/GenerarDetalleCarrito", content);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();

                return true;
            }
            return false;
        }

        //por cliente
        public async Task<List<Compra>> GetListaComprasCli(int UsuarioIdUsuario)
        {
            var response = await _httpClient.GetAsync($"/api/Compra/PorCliente/{UsuarioIdUsuario}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Compra> descripciones = JsonConvert.DeserializeObject<List<Compra>>(json_response);
                return descripciones;
            }
            return new List<Compra>();

        }

        public async Task<float> GetPrecioTotalCompra(int CompraIdCompra)
        {
            var response = await _httpClient.GetAsync($"/api/Compra/TotalCompra/{CompraIdCompra}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                float total = JsonConvert.DeserializeObject<float>(json_response);
                return total;
            }
            return 0;

        }

        public async Task<float> GetPrecioTotalCarrito(int CarritoIdCarrito)
        {
            var response = await _httpClient.GetAsync($"/api/Carrito/TotalCarrito/{CarritoIdCarrito}");

            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                float total = JsonConvert.DeserializeObject<float>(json_response);
                return total;
            }
            return 0;

        }






    }



    }
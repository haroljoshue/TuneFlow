using Modelos.Tuneflow.Usuario.Administracion;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace API.Consumer
{
    public class Crud<T>
    {
        public static string EndPoint { get; set; }

        public static async Task<List<T>> GetAllAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(EndPoint);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<T> GetByIdAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{EndPoint}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<List<T>> GetNoAtendidasAsync()
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync("https://localhost:7158/AlertasNoAtendidas");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<List<T>> GetByAsync(string campo, int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync($"{EndPoint}/{campo}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<T>>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<T> CreateAsync(T item)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(
                    EndPoint,
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<T>(json);
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<bool> UpdateAsync(int id, T item)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PutAsync(
                    $"{EndPoint}/{id}",
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

        public static async Task<bool> DeleteAsync(int id)
        {
            using (var client = new HttpClient())
            {
                var response = await client.DeleteAsync($"{EndPoint}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

    }
}

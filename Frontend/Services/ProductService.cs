namespace Frontend.Services;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public List<string> Items { get; set; } = new();
}

public class CreateProduct
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Price { get; set; } = string.Empty;
    public string Items { get; set; } = string.Empty;
}

public class CreateProductDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public List<string> Items { get; set; } = new();
}

public class ProductService
{
    private readonly HttpClient _httpClient;

    public ProductService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ProductDto>> GetAllProductsAsync()
    {
        try
        {
            var products = await _httpClient.GetFromJsonAsync<List<ProductDto>>("api/product/all") ?? new();
            return products;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching products: {ex.Message}");
            return new();
        }
    }

    public async Task<ProductDto> GetProductByIdAsync(int id)
    {
        try
        {
            return await _httpClient.GetFromJsonAsync<ProductDto>($"api/product/{id}") ?? new();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching product: {ex.Message}");
            return new();
        }
    }

    public async Task<bool> CreateProductAsync(CreateProductDto product)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/product/create", product);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating product: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateProductAsync(CreateProductDto product, int productId)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync($"api/product/update?productId={productId}", product);
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating product: {ex.Message}");
            return false;
        }
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/product/delete?productId={productId}");
            return response.IsSuccessStatusCode;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting product: {ex.Message}");
            return false;
        }
    }
}

namespace Application.DTO.Items
{
    public class GetItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }
}

using System;

namespace ArandaCatalogs.Domain.ModelsDomain
{
    public class ProductModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }

        public byte[] Image { get; set; }
    }
}

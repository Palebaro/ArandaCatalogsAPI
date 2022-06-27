using System;

namespace ArandaCatalogs.Domain.ModelsDomain
{
    public class FilterProducts
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
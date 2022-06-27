using System;
using System.ComponentModel.DataAnnotations;

namespace ArandaCatalogs.Domain.ModelsDomain
{
    public class CategoryModel
    {
        public Guid Id { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }
    }
}

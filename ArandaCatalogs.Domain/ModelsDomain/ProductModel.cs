﻿using System;

namespace ArandaCatalogs.Domain.ModelsDomain
{
    public class ProductModel
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid Category_Id { get; set; }

        public byte[] Image { get; set; }
    }
}

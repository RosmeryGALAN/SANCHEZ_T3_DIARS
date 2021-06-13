﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T3_Rosmery.Models;

namespace T3_Rosmery.DB
{
    public class EjerciciosMap : IEntityTypeConfiguration<Ejercicios>
    {
        public void Configure(EntityTypeBuilder<Ejercicios> builder)
        {
            builder.ToTable("Ejercicios");
            builder.HasKey(o => o.Id);
        }
    }
}

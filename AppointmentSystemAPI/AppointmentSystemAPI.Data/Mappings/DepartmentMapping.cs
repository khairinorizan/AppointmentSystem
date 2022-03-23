using AppointmentSystemAPI.Data.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System;

namespace AppointmentSystemAPI.Data.Mappings
{
    public static class DepartmentMapping
    {
        public static void MapDepartment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepartmentID);
                
                entity
                    .Property(e => e.DepartmentID)
                    .HasColumnName("DepartmentID");

                entity
                    .Property(e => e.DepartmentName)
                    .HasColumnName("DepartmentName");

                entity
                    .Property(e => e.DepartmentFloor)
                    .HasColumnName("DepartmentFloor");

                entity.ToTable("Department", "dbo");
            });
        }
    }
}
using AutoMapper;
using Api.Logs;
using Api.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper.Profiler {
    public class OrganizationProfile : Profile {
        public OrganizationProfile() {
            CreateMap<Log, LogDto>();
            CreateMap<LogDto, Log>();
            CreateMap<Producto, ProductoDto>();
            CreateMap<ProductoDto, Producto>();
        }
    }
}

using AutoMapper;
using Api.Logs;
using Api.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.AutoMapper.Profiler;

namespace Application {
    public class MapperConfig {
        public static Mapper InitializeAutomapper() {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<OrganizationProfile>();
                cfg.AddProfile(new OrganizationProfile());
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }
            
    }
}

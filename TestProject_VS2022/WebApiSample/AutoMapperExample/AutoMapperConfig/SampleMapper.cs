using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace AutoMapperExample.AutoMapperConfig
{
    public class SampleMapper
    {
        private static SampleMapper instance = null;
        
        public static SampleMapper Instance
        {
            get
            {
                if (instance == null)
                {
                    string filepath = @"d:\SampleMapperTest.txt";
                    string filenote = $"Called it at {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff")}";

                    using (StreamWriter sw = new StreamWriter(filepath, true, Encoding.UTF8))
                    {
                        sw.WriteLine(filenote);
                    }

                    instance = new SampleMapper();
                }
                return instance;
            }
        }

        private SampleMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<SampleProfile>();
            });

            MyMapper = config.CreateMapper();
        }

        public IMapper MyMapper { get; set; }
    }
}
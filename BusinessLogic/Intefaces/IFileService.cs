﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Intefaces
{
    public interface IFileService
    {
        string SaveProductImage(IFormFile file);
        void DeleteProductImage(string path);
    }
}

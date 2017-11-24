using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using vega.Controllers.Resources;
using vega.Core;
using vega.Core.Models;

namespace vega.Controllers
{
    [Route("/api/vehicles/{vehicleId}/photos")]
    public class PhotosController : Controller
    {
        private readonly IHostingEnvironment host;
        private readonly IVehicleRepository repository;
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly PhotoSettings photoSettings;

        public PhotosController(IHostingEnvironment host, 
        IVehicleRepository repository, 
        IUnitOfWork uow, 
        IMapper mapper,
        IOptionsSnapshot<PhotoSettings> options)
        {
            this.photoSettings = options.Value;
            this.mapper = mapper;
            this.uow = uow;
            this.repository = repository;
            this.host = host;

        }

        [HttpPost]
        public async Task<IActionResult> Upload(int vehicleId, IFormFile file)
        {
            var vehicle = await repository.GetVehicle(vehicleId, incluedeRelated: false);

            if (vehicle == null)
                return NotFound();
            
            if(file == null) return BadRequest("File Not Found");
            if(file.Length == 0 ) return BadRequest("Empty File");
            if(file.Length > photoSettings.MaxBytes) return BadRequest("Maximum File Limit Execeeded");
            if(!photoSettings.IsSupported(file.FileName)) return BadRequest("Invalid file extension");


            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolderPath))
                Directory.CreateDirectory(uploadsFolderPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploadsFolderPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var photo = new Photo { FileName = fileName };
            vehicle.Photos.Add(photo);
            await uow.CompleteAsync();

            return Ok(mapper.Map<Photo,PhotoResource>(photo)); 
        }
    }
}
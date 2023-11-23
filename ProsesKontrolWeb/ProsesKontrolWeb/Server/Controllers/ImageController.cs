using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProsesKontrolWeb.Shared;
using ProsesKontrolWeb.Shared.Models;
using System.Net;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Jpeg;
using ProsesKontrolWeb.Server.Data;
using ProsesKontrolWeb.Client.Pages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.IO.Pipelines;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor.Diagrams;
using Syncfusion.Blazor.CircularGauge.Internal;
using Syncfusion.Blazor.PivotView;

namespace ProsesKontrolWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //private readonly IWebHostEnvironment _env;
        private readonly IHostEnvironment _env;
        private readonly ApplicationDbContext _context;
        //public List<ImageFile> imageFiles;
        //public List<string> imageNames;

        public ImageController(IHostEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        [HttpPost]
        public async Task Post([FromBody] ImageFile[] files)
        {
            foreach (var file in files)
            {
                ImageModel imageModel = new();
                string randomStringId = System.IO.Path.GetRandomFileName();
                string ext = System.IO.Path.GetExtension(file.fileName);
                string imageName = randomStringId + ext;
                string thumbnailName = randomStringId + "_thumbnail" + ext;
                string imagePath = System.IO.Path.Combine("images", imageName); // göstermelik yol
                string thumbnailPath = System.IO.Path.Combine("thumbnails", thumbnailName);

                imageModel.UniqueStrId = randomStringId;
                imageModel.FileExtension = ext;
                imageModel.ImageName = randomStringId + ext;
                imageModel.FileLocation = imagePath;
                imageModel.TableInsideId = file.tableInsideId;

                ////////
                var buf = Convert.FromBase64String(file.base64data);
                string absoluteImagePath = System.IO.Path.Combine(_env.ContentRootPath, imagePath); // Asıl yol (çekecekken kullanılıyor)
                string absoluteThumbnailPath = System.IO.Path.Combine(_env.ContentRootPath, thumbnailPath);

                await System.IO.File.WriteAllBytesAsync(absoluteImagePath, buf);
                CreateThumbnail(absoluteImagePath, absoluteThumbnailPath, 100, 100);
                _context.ImageModels.Add(imageModel);
                await _context.SaveChangesAsync();
            }
        }

        [HttpGet("{tableId}/{tableInsideId}")]
        public async Task<ActionResult<Dictionary<string, string>>> GetImageById(int tableId, int tableInsideId)
        {
            List<string> base64Datas = new List<string>();
            List<string> imageNames = new List<string>();

            List<ImageModel> selectedImageFiles = _context.ImageModels
            .Where(imageModel => imageModel.TableInsideId == tableInsideId && tableId == 1).ToList();
            foreach (var imageModels in _context.ImageModels.Where(i => i.TableInsideId == tableInsideId))
            {
                imageNames.Add(imageModels.ImageName);
            }
            foreach (var selectedImageFile in selectedImageFiles)
            {
                string imagePath = System.IO.Path.Combine(_env.ContentRootPath, "images", selectedImageFile.ImageName);
                var imageByte = System.IO.File.ReadAllBytes(imagePath);
                string base64Data = Convert.ToBase64String(imageByte);
                base64Datas.Add(base64Data);
                //return await base64Data;
            }

            Dictionary<string, string> imageModelDic = new();
            for (int i = 0; i < base64Datas.Count; i++)
            {
                imageModelDic[imageNames[i]] = base64Datas[i];
            }
            return imageModelDic;
        }
        [HttpGet("Model/{tableId}/{tableInsideId}")]
        public async Task<ActionResult<List<ImageModel>>> GetImageModel(int tableId, int tableInsideId)
        {
            List<string> imageUniqueStrIds = new List<string>();

            List<ImageModel> selectedImageFiles = _context.ImageModels
            .Where(imageModel => imageModel.TableInsideId == tableInsideId && tableId == 1).ToList();

            //iamgeModel dönmeyi denemek için yorum
            //foreach (var imageModels in _context.ImageModels.Where(i => i.TableInsideId == tableInsideId))
            //{
            //    imageUniqueStrIds.Add(imageModels.UniqueStrId);
            //}

            return selectedImageFiles;
        }

        [HttpGet("StrId/{tableId}/{tableInsideId}")]
        public async Task<ActionResult<List<string>>> GetThumbnailData(int tableId, int tableInsideId)
        {
            // List<string> base64Datas = new List<string>();

            List<ImageModel> selectedImageFiles = await _context.ImageModels
            .Where(imageModel => imageModel.TableInsideId == tableInsideId && tableId == 1).ToListAsync();
            if (selectedImageFiles.Count == 0)
            {
                List<string> tempThumbData = new List<string>();
                string tempPath = System.IO.Path.Combine(_env.ContentRootPath, "thumbnails", "temp.jpg");
                var tempImageByte = System.IO.File.ReadAllBytes(tempPath);
                var tempBase64Data = Convert.ToBase64String(tempImageByte);
                tempThumbData.Add(tempBase64Data);
                return tempThumbData;
            }
            var unique = selectedImageFiles[0].UniqueStrId;
            var thumbnailName = unique + "_thumbnail" + selectedImageFiles[0].FileExtension;
            string thumbnailPath = System.IO.Path.Combine(_env.ContentRootPath, "thumbnails", thumbnailName);
            var imageByte = System.IO.File.ReadAllBytes(thumbnailPath);
            var base64Data = Convert.ToBase64String(imageByte);
            //base64Datas.Add(base64Data);
            List<string> thumbData = new List<string>();

            //string newString = string.Format("data:{0};base64,{1}", selectedImageFiles[0].FileExtension, base64Data);
            thumbData.Add(base64Data);
            return thumbData;
            //List<string> thumbData = new();

            //thumbData.Add(base64Data);
        }
        /* Geri aç
        public async Task<ActionResult<List<string>>> GetImageById(int tableInsideId)
        {
            List<ImageModel> imageControls = new List<ImageModel>();
            List<string> base64Datas = new List<string>();

            //string imageLocation = " ";
            //FileStream stream = new FileStream(imageLocation, FileMode.Open, FileAccess.Read);

            ////// Resmi görüntüleme
            ////System.IO.Image image = Image.FromStream(stream);
            //System.IO.FileStream.Synchronized(stream);

            //var imageControl = await _context.ImageModels.Where(a => a.TableInsideId == tableInsideId).FirstOrDefaultAsync();
            List<ImageModel> selectedImageFiles = _context.ImageModels
            .Where(imageModel => imageModel.TableInsideId == tableInsideId).ToList();
            foreach (var selectedImageFile in selectedImageFiles)
            {
                string imagePath = Path.Combine(_env.ContentRootPath, "images", selectedImageFile.ImageName);
                var imageByte = System.IO.File.ReadAllBytes(imagePath);
                string base64Data = Convert.ToBase64String(imageByte);
                base64Datas.Add(base64Data);
                //return await base64Data;
            }
            return base64Datas;
        }
        */
        [HttpDelete("Delete/{tableId}/{tableInsideId}/{imageName}")]
        public async Task<ActionResult<List<ImageModel>>> DeleteImageByIdAndName(int tableId, int tableInsideId, string imageName)
        {
            var dbImages = await _context.ImageModels.Where(a => a.TableInsideId == tableInsideId && a.ImageName == imageName && tableId == 1).FirstOrDefaultAsync();
            if (dbImages == null)
            {
                return NotFound("Resim Yok");
            }
            _context.ImageModels.Remove(dbImages);
            await _context.SaveChangesAsync();

            //return Ok(await GetDbProses());
            return Ok();
        }
        [HttpDelete("Delete/{tableId}/{tableInsideId}")]
        public async Task<ActionResult<List<ImageModel>>> DeleteImagesById(int tableId, int tableInsideId) // proses silinince çalışacak yani ona ait bütün resimleri silecek.
        {
            List<ImageModel> dbImages = _context.ImageModels.Where(a => a.TableInsideId == tableInsideId && tableId == 1).ToList(); //await hata verdi sildim
            if (dbImages == null)
            {
                return NotFound("Resim Yok");
            }
            else
            {
                foreach (var dbImage in dbImages)
                {
                    _context.ImageModels.Remove(dbImage);
                    await _context.SaveChangesAsync();
                }
                //return Ok(await GetDbProses());
                return Ok();

            }
        }
        private async Task<List<ImageModel>> GetDbProses()
        {
            return await _context.ImageModels.ToListAsync();
        }
        public static void CreateThumbnail(string sourcePath, string outputPath, int width, int height)
        {
            try
            {
                using var image = Image.Load(sourcePath);

                image.Mutate(x => x.Resize(new ResizeOptions
                {
                    Size = new SixLabors.ImageSharp.Size(width, height),
                    Mode = ResizeMode.Max
                }));
                image.Save(outputPath, new JpegEncoder());
            }
            catch (Exception ex)
            {
                var a = ex.Message;
            }
        }
    }
}

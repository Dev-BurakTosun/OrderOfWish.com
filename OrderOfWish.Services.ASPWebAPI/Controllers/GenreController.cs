using Microsoft.AspNetCore.Mvc;
using OrderOfWish.BLL.Abstract;
using OrderOfWish.Model.Entities;
using OrderOfWish.Services.ASPWebAPI.Models;
using System;
using System.Collections.Generic;

namespace OrderOfWish.Services.ASPWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        IGenreBLL genreBLL;

        public GenreController(IGenreBLL bll)
        {
            genreBLL = bll;
        }

        List<GenreDTO> GenreDtoList(ICollection<Genre> listGenre)
        {
            List<GenreDTO> genres = new List<GenreDTO>();
            foreach (Genre item in listGenre)
            {
                genres.Add(new GenreDTO()
                {
                    GenreID = item.ID,
                    GenreName = item.GenreName,
                    Description = item.Description,
                    IsActive = item.IsActive,
                });
            }
            return genres;
        }

        public IActionResult GetGenre()
        {
            List<GenreDTO> genres = GenreDtoList(genreBLL.GetAll());
            return Ok(genres);
        }

        public IActionResult GetActiveGenre()
        {
            List<GenreDTO> genres = GenreDtoList(genreBLL.GetGenreAll());
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public IActionResult GetGenreByID(int id)
        {
            Genre genre = genreBLL.Get(id);
            GenreDTO genreDTO = new GenreDTO();
            genreDTO.GenreID = genre.ID;
            genreDTO.GenreName = genre.GenreName;
            genreDTO.Description = genre.Description;
            return Ok(genreDTO);
        }

        void ControlName(string GenreName)
        {
            ICollection<Genre> genres = genreBLL.GetAll();
            foreach (Genre item in genres)
            {
                if (item.GenreName == null)
                {
                    throw new Exception($"{GenreName} isimli bir tür mevcur değildir.");
                }
            }        
        }
        [HttpPost]
        public IActionResult UpdateGenre([FromBody] GenreDTO itemDto)
        {
            try
            {
                Genre genre = genreBLL.Get(itemDto.GenreID);
                genre.GenreName=itemDto.GenreName;
                genre.Description = itemDto.Description;
                genre.IsActive = true;
                genreBLL.Update(genre);
                return Ok(new { message = "Tür güncellendi.", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] GenreDTO genreDTO)
        {
            try
            {
                ControlName(genreDTO.GenreName);

                Genre genre = new Genre();
                genre.ID = genreDTO.GenreID;
                genre.GenreName = genreDTO.GenreName;
                genre.Description = genreDTO.Description;
                genreBLL.Insert(genre);
                return Ok(new { message = "Tür kaydedildi.", check = true });
            }
            catch (Exception ex)
            {

                return Ok(new { message = ex.Message, check = false });
            }
        }

        [HttpGet("{id}")]
        public IActionResult DeleteGenreByID(int id)
        {
            genreBLL.DeleteByID(id);
            return Ok(new { message = "Tür silindi.", check = true });
        }
    }
}

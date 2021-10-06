using OrderOfWish.BLL.Abstract;
using OrderOfWish.DAL.Abstract;
using OrderOfWish.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderOfWish.BLL.Concrete
{
    class GenreService : IGenreBLL
    {
        IGenreDAL genreDAL;

        public GenreService(IGenreDAL dal)
        {
            genreDAL = dal;
        }

        #region BaseMethod
        void CheckGenreName(Genre genre)
        {
            if (genre.GenreName.Length > 20)
            {
                throw new Exception("Tür adı 20 karakterden uzun olmamalıdır.");
            }

        }
        public void Insert(Genre entity)
        {
            CheckGenreName(entity);
            genreDAL.Add(entity);
        }

        public void Update(Genre entity)
        {
            CheckGenreName(entity);
            genreDAL.Update(entity);
        }
        public void Delete(Genre entity)
        {
            entity.IsActive = false;
            genreDAL.Update(entity);
        }

        public void DeleteByID(int entityID)
        {
            Genre genre = Get(entityID);
            genre.IsActive = false;
            genreDAL.Update(genre);
        }

        public Genre Get(int entityID)
        {
            return genreDAL.Get(a => a.ID == entityID);
        } 
        public ICollection<Genre> GetAll()
        {
            return genreDAL.GetAll();
        }
        #endregion

        //Satışta aktif olarak satılan tüm ürün (!Genre)türleri.
        public ICollection<Genre> GetGenreAll()
        {
            return genreDAL.GetAll(a => a.IsActive, a => a.GenreName);
        }

        
    }
}

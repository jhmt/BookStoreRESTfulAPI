using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.DataTransferObjects;
using TheBookStore.Models;

namespace TheBookStore
{
    public static class MapsConfig
    {
        private static MapperConfiguration _config;
        private static IMapper _mapper;

        public static void Register()
        {
            _config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDto>()
                   .ForMember(b => b.Authors, m => m.MapFrom(a => a.Authors));
                cfg.CreateMap<Author, BookAuthorsDto>()
                   .ForMember(b => b.FullName, m => m.MapFrom(a => a.Name + " " + a.Surname))
                   .ForSourceMember(b => b.Books, m => m.Ignore());
                cfg.CreateMap<Book, AuthorBooksDto>();
                cfg.CreateMap<Author, AuthorDto>()
                   .ForMember(b => b.FullName, m => m.MapFrom(a => a.Name + " " + a.Surname))
                   .ForMember(a => a.Books, m => m.MapFrom(b => b.Books))
                   .ForSourceMember(b => b.Books, m => m.Ignore());
                cfg.CreateMap<Review, ReviewDto>()
                    .ForMember(r => r.BookId, m => m.MapFrom(s => s.BookId));
            });
            _mapper = _config.CreateMapper();
        }

        public static T To<T>(this object source)
        {
            return _mapper.Map<T>(source);
        }

        public static IEnumerable<T> To<T>(this IEnumerable<object> source)
        {
            return _mapper.Map<IEnumerable<T>>(source);
        }
    }
}